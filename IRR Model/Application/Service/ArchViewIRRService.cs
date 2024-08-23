using IRR.Domain.DTOs;
using IRR.Application.Interface;
using IRR.Application.Payload;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Microsoft.Spark.Sql.Expressions;
using Excel.FinancialFunctions;


namespace IRR.Application.Service
{

    using DataFrameRow = (DateTime StartDate, DateTime EndDate,
        Decimal GrossEarnedPremium, Decimal IncurredLoss, Decimal PaidLoss);

    public partial class ArchViewIRRService(IQuery queryService) : IIRR
    {

        private readonly IQuery _queryService = queryService;

        private static readonly Dictionary<string, StructField> DataFrameTableNames = new()
        {
            { "Period Start Date", new StructField("Period Start Date", new DecimalType())},
            { "Period End Date", new StructField("Period End Date", new DecimalType()) },
            { "Gross Earned Premium", new StructField("Gross Earned Premium", new DecimalType()) },
            { "Incurred Losses",new StructField("Incurred Losses", new DecimalType()) },
            { "Paid Losses", new StructField("Paid Losses", new DecimalType()) }
        };

     

        /// <summary>
        /// This calculates the IRR over various retroprogrammes over multiple years
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Dictionary<int, Tuple<DataFrame, double>>> GetIRRForSPInvestor(IRRInputs input)
        {
            var StartDate = (DateTime)input.QuarterStartDate!;
            var EndDate = (DateTime) input.QuarterEndDate!;
            var CommutationDate = input.CommutationDate;
            var RetroProgramIds = input.RetroProgramIds;
            var SPInvestorId = input.SPInvestorId;
            var Capital = input.Capital;
            var AcquisitionExpenseRate = input.AcquisitionExpense;

            var responseDictionary = new Dictionary<int, Tuple<DataFrame, double>>();



            var StartDateRange = Enumerable.Range(0,  EndDate.Subtract(StartDate).Days + 1).
                                   Select(days => StartDate.AddDays(days));

            var EndDateRange = StartDateRange.Select(date => date.AddDays(1));


            IEnumerable<DateTuple> DateRange =
                (IEnumerable<DateTuple>)ListsToTuple<DateTime, DateTime>(StartDateRange,
                EndDateRange);

            //Read all the tables as IRR Inputs

            Task<IEnumerable<PremiumSchedule>> PremiumTable =
                GetPremiumSchedule(SPInvestorId, RetroProgramIds);


            Task<IEnumerable<PaidSchedule>> PaidLossTable = this.GetPaidLossSchedule(SPInvestorId,
                                                                                RetroProgramIds);

            Task<IEnumerable<IRRLossSchedule>> IncurredLossTable = this.GetIRRLossSchedule();

            Task<IEnumerable<CapitalSchedule>> CapitalTable = this.GetCapitalSchedule();


            await Task.WhenAll(PremiumTable, PaidLossTable, IncurredLossTable, CapitalTable);


            /* 
            
                You will need to consider pushing the part below into another function. This is because currently
                This runs for all retroprofile ids together which shouldn't be the case. We have to the IRR computation
                run for each profile id accross any given profile
              
             */


                var dataframeIRRResponse = await ComputeIRR(PremiumTable.Result, PaidLossTable.Result,
                                        IncurredLossTable.Result, CapitalTable.Result, (decimal) Capital,
                                        CommutationDate, (decimal) AcquisitionExpenseRate, DateRange);

                responseDictionary.Add(SPInvestorId, dataframeIRRResponse);



                return responseDictionary;
        }







        /// <summary>
        /// 
        /// </summary>
        /// <param name="PremiumTable"></param>
        /// <param name="PaidLossTable"></param>
        /// <param name="IncurredLossTable"></param>
        /// <param name="CapitalTable"></param>
        /// <param name="Capital"></param>
        /// <param name="CommutationDate"></param>
        /// <param name="AcquisitonExpenseRate"></param>
        /// <param name="DateRange"></param>
        /// <returns></returns>
        private async Task<Tuple<DataFrame, double>> ComputeIRR(IEnumerable<PremiumSchedule> PremiumTable, 
                                            IEnumerable<PaidSchedule> PaidLossTable, 
                                            IEnumerable<IRRLossSchedule> IncurredLossTable, 
                                            IEnumerable<CapitalSchedule> CapitalTable,
                                            Decimal Capital,
                                            DateTime CommutationDate, 
                                            Decimal AcquisitonExpenseRate,
                                            IEnumerable<DateTuple> DateRange)
        {
            var CommissionRate = 1;
            var ProfitCommission = 0.35;
            var HurdleAmount = 0;
            var IncomeAccumuationRate = (float)Math.Pow(1.05, 1 / 360);

            var CashFlowRange = DateRange.Select(p => p.StartDate).ToList();


            // Get the all the required data forms for IRR calculation
            var GrossEarnedPremiums = this.GrossEarnedPremiumTable(DateRange,
                                                        PremiumTable, CommutationDate);

            var IncurredLosses = this.IncurredLossTable(DateRange,
                                    IncurredLossTable, CommutationDate);

            var PaidLosses = this.PaidLossTable(DateRange, PaidLossTable, CommutationDate);


            var CapitalContribution = this.Contributions(CapitalTable, CashFlowRange);


            var TotalCapital = CapitalTable.Sum(p => p.IncrementalCapitalAdded);
            

            await Task.WhenAll(GrossEarnedPremiums, IncurredLosses, PaidLosses, CapitalContribution);


            var GenericRows = DateRange
                                     .Zip(GrossEarnedPremiums.Result, (x, y) => (x.StartDate, x.EndDate, y))
                                     .Zip(IncurredLosses.Result, (x, y) => (x.StartDate, x.EndDate, x.y, y))
                                     .Zip(PaidLosses.Result, (x, y) => (x.StartDate, x.EndDate, x.Item3, x.Item4, y));

            //Calculation 

            var IRRTable = GetDataFrame(DataFrameTableNames, GetTupleToGenericRow(GenericRows));

            IRRTable.WithColumn("Row Number",
                Functions.RowNumber().Over(Window.OrderBy(IRRTable.Col("Period Start Date"))));

            IRRTable.WithColumn("IsCommutable", IRRTable.Col("Period Start Date") > Functions.Lit(CommutationDate));

            IRRTable.WithColumn("AcquisitionExpense", IRRTable.Col("Gross Earned Premium").Multiply(AcquisitonExpenseRate));

            IRRTable.WithColumn("Commission and Tail Fee", (IRRTable.Col("Gross Earned Premium")
                                    - IRRTable.Col("AcquisitionExpense")) * Functions.Lit(CommissionRate));

            IRRTable.WithColumn("Net Ceded Premium", IRRTable.Col("Gross Earned Premium")
                                    - IRRTable.Col("AcquisitionExpense") - IRRTable.Col("Commision and Tail Fee"));


            IRRTable.WithColumn("Float Change", (IRRTable.Col("Net Ceded Premium")
                                - Functions.Lag(IRRTable.Col("Net Ceded Premium"), 1, 0)) -
                                (IRRTable.Col("Paid Losses")
                                - Functions.Lag(IRRTable.Col("Paid Losses"), 1, 0)));


             var NewTable = GetFloatRecursion((int) IRRTable.Count(), IncomeAccumuationRate);

            IRRTable.Join(NewTable, "Row Number");


            IRRTable.WithColumn("Cumulative Investment Income",

                Functions.Sum(IRRTable.Col("Investment Income on Float").Over(
                    Window.OrderBy(IRRTable.Col("Period Start Date"))
                           .RowsBetween(Window.UnboundedPreceding, Window.CurrentRow))

                ));


            IRRTable.WithColumn("Subject To Profit Commission",

                Functions.Greatest(IRRTable.Col("Net Ceded Premium") - IRRTable.Col("Incurred Losses")
                + IRRTable.Col("Cumulative Investment Income"), (Functions.Max(IRRTable.Col("Net Ceded Premium"))
                - Functions.Max(IRRTable.Col("Incurred Losses")) + IRRTable.Col("Cumulative Investment Income"))

                ));


            IRRTable.WithColumn("Total Earned Profits",

                IRRTable.Col("Subject To Profit Commission") -

                Functions.Greatest(IRRTable.Col("Subject To Profit Commission") - Functions.Lit(HurdleAmount), Functions.Lit(0))
                         .Multiply(ProfitCommission)

                );


            IRRTable.WithColumn("Profit Commission", IRRTable.Col("Subject To Profit Commission") 
                - IRRTable.Col("Total Earned Profits"));

            IRRTable.WithColumn("Cumulative Cashflow", IRRTable.Col("Net Ceded Premium")
                - IRRTable.Col("Paid Losses") + IRRTable.Col("Cumulative Investment Income"));

            IRRTable.WithColumn("Incremental Cashflow", IRRTable.Col("Total Earned Profits")
                                - Functions.Lag(IRRTable.Col("Total Earned Profits"), 1, 0));


            IRRTable = AddNewColumnToDataFrame(IRRTable, CapitalContribution.Result, "Capital Contribution");



            IRRTable = RecursiveCTE(IRRTable, _queryService.CapitalRecursionQuery(IncomeAccumuationRate).ToString());


            IRRTable.WithColumn("Cumulative Investment Income On Capital",

            Functions.Sum(IRRTable.Col("Investment Income On Capital").Over(
                Window.OrderBy(IRRTable.Col("Period Start Date"))
                       .RowsBetween(Window.UnboundedPreceding, Window.CurrentRow))

            ));


            IRRTable.WithColumn("Investors Funds",
            
                IRRTable.Col("Total Earned Profits") +

                IRRTable.Col("Cumulative Investment Income On Capital") +

                Functions.Sum(IRRTable.Col("Investment Income on Float").Over(
                    Window.OrderBy(IRRTable.Col("Period Start Date"))
                        .RowsBetween(Window.UnboundedPreceding, Window.CurrentRow))

            ));

            IRRTable.WithColumn("Unpaid Losses",
                                    Functions.Max(IRRTable.Col("Paid Losses")) - IRRTable.Col("Paid Losses"));



            IRRTable.WithColumn("Buffer Factor", Functions.Lit(1.25));


            IRRTable.WithColumn("Buffer Reserves", IRRTable.Col("Upaid Losses") * IRRTable.Col("Buffer Factor"));


            IRRTable.WithColumn("Required Capital", Functions.Greatest(IRRTable.Col("Buffer Reserves"), Functions.Lit(Capital)));


            IRRTable.WithColumn("Capital Released", Functions.Greatest(IRRTable.Col("Investors Funds") - IRRTable.Col("Required Capital"),
                                 Functions.Lit(0)));

            //This is dummy. Please change later

            IRRTable.WithColumn("Investor Cashflow", (IRRTable.Col("Capital Released")
                               - IRRTable.Col("Capital Contribution") - Functions.Lag(IRRTable.Col("Capital Released"),
                               1, Functions.Lit(0))).Multiply(IRRTable.Col("IsCommutable")));

            var Cashflow = IRRTable.Select("Investor Cashflow").Collect().Select(row => (double) Convert.ToDecimal(row.Get(0)));

            var CashflowDate = IRRTable.Select("Period Start Date").Collect().Select(row => Convert.ToDateTime(row.Get(0)));

            
            return new Tuple<DataFrame, double>( IRRTable, Financial.XIrr(Cashflow, CashflowDate) ) ;

        }



        /// <summary>
        /// Create A New DataFrame having a given name list and row data
        /// </summary>
        /// <param name="NameList"></param>
        /// <param name="DataLists"></param>
        /// <returns> Returns a DataFrame</returns>
        private static DataFrame GetDataFrame(Dictionary<string, StructField> NameList, 
                                            IEnumerable<GenericRow> DataLists)
        {

            var dataspark = SparkSession.Builder().GetOrCreate();

            List<StructField> structFieldList = [];

            foreach(string key in NameList.Keys)
            {
                structFieldList.Add(NameList[key]);
            }

            return  dataspark.CreateDataFrame(

                        new List<GenericRow> (DataLists),

                        new StructType(structFieldList)
                ).Checkpoint().Cache();

           
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IrrTable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private static DataFrame RecursiveCTE(DataFrame IrrTable, string query)
        {

            var sparksesssion = SparkSession.Builder().GetOrCreate();

            IrrTable.CreateOrReplaceTempView("IRRTable");

            IrrTable = sparksesssion.Sql(query);

            IrrTable.Drop("Row Number");


            return IrrTable;

        }


        private static DataFrame GetFloatRecursion(int row_count, float AccumulationFactor)
        {

            var spark = SparkSession.Builder().GetOrCreate();

            var FirstRow = spark.Sql("Select top 1 [Row Number], " +
                "[Float Change] From IRRTable Order by [Row Number]").Collect().ElementAt(0);

            double StartingFloat = 0;

            double FloatChange = FirstRow.GetAs<double>("[Float Change]");


            double AverageInvestmentFloat = Math.Max(FloatChange* 0.5, 0);

            double InvestmentIncomeOnFloat = AverageInvestmentFloat * AccumulationFactor;

            double EndingFloat = StartingFloat + FloatChange + InvestmentIncomeOnFloat;


            List<GenericRow> results =
            [
                new GenericRow([1, FloatChange, StartingFloat, AverageInvestmentFloat, InvestmentIncomeOnFloat, EndingFloat])
            ];

            int rowNumber = 2;

            while (rowNumber <= row_count) {



                var CurrentRow = spark.Sql($"Select [Row Number], [Float Change] " +
                    $"From IRRTable Where RowNumber = {rowNumber}").Collect().ElementAt(0);


                FloatChange = CurrentRow.GetAs<double>("Float Change");

                StartingFloat = EndingFloat;

                AverageInvestmentFloat = Math.Max(StartingFloat + FloatChange* 0.5, 0);

                InvestmentIncomeOnFloat = AverageInvestmentFloat * AccumulationFactor;

                EndingFloat = StartingFloat + FloatChange + InvestmentIncomeOnFloat;


                results.Add(new GenericRow([rowNumber, FloatChange, StartingFloat, AverageInvestmentFloat, 
                                    InvestmentIncomeOnFloat, EndingFloat]));

                rowNumber++;            
            
            }


            var resultSchema = new StructType(
            [
                new StructField("Row Number", new IntegerType()),
                new StructField("Float Change", new DoubleType()),
                new StructField("Starting Float", new DoubleType()),
                new StructField("Average Investment Float", new DoubleType()),
                new StructField("Investment Income On Float", new DoubleType()),
                new StructField("Ending Float", new DoubleType())
            ]);

            return spark.CreateDataFrame(results, resultSchema);

        }


        private static DataFrame AddNewColumnToDataFrame(DataFrame Table, IEnumerable<decimal> items, string ColumnName)
        {


            var sparksession = SparkSession.Builder().GetOrCreate();


            DataFrame newColumnDf = sparksession.CreateDataFrame((IEnumerable<int>)items.Select((value, index) => 
                                                        new{ Index = index, Value = value })).ToDF(ColumnName);


            return Table.WithColumn(ColumnName, newColumnDf.Col(ColumnName));

        }







        //Returns the Gross Earned Premium over a given date range
        public async Task<IEnumerable<decimal>> GrossEarnedPremiumTable(
            IEnumerable<DateTuple> DateRange, 
            IEnumerable<PremiumSchedule> IRRPremiumTable, DateTime CommutationDate)
        {
            var GrossEarnedPremium = DateRange.AsParallel()
                            .Select(datetuple => this.GrossEarnedPremium(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, IRRPremiumTable));

            return await CumulativeTable(DateRange, GrossEarnedPremium, CommutationDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DateRange"></param>
        /// <param name="IRRLossTable"></param>
        /// <param name="CommutationDate"></param>
        /// <returns></returns>
        //Returns the cumulative incurred loss for all given date ranges
        public async Task<IEnumerable<decimal>> IncurredLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<IRRLossSchedule> IRRLossTable, DateTime CommutationDate)
        {
            var CurrentIncurredLoss = DateRange.AsParallel()
                            .Select(datetuple => this.CurrentIncurredLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, IRRLossTable));

            return await CumulativeTable(DateRange, CurrentIncurredLoss, CommutationDate);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="DateRange"></param>
        /// <param name="PaidLosses"></param>
        /// <param name="CommutationDate"></param>
        /// <returns></returns>
        //Returns the cumulative Paid Loss table
        public async Task<IEnumerable<decimal>> PaidLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<PaidSchedule> PaidLosses, DateTime CommutationDate)
        {
            var CurrentPaidLoss = DateRange.AsParallel()
                            .Select(datetuple => this.CurrentPaidLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, PaidLosses));

            return await CumulativeTable(DateRange, CurrentPaidLoss, CommutationDate);
        }


        public Task<IEnumerable<decimal>> Contributions(IEnumerable<CapitalSchedule> CapitalSchedule, 
            IEnumerable<DateTime> CashflowRange)
        {
            return Task.FromResult<IEnumerable<decimal>>(CashflowRange.AsParallel().Select(
                cashflowdate => GetContribution(cashflowdate, CapitalSchedule)));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="CommutationDate"></param>
        /// <param name="IRRPremiumTable"></param>
        /// <returns></returns>
        //Calculate Gross Earned premium over all entries for the premium schedule
        public Decimal GrossEarnedPremium(DateTime StartDate, 
            DateTime EndDate, 
            DateTime CommutationDate, IEnumerable<PremiumSchedule> IRRPremiumTable)
        {
            if (StartDate > CommutationDate)
            {
                return 0;
            }
            else if (StartDate <= CommutationDate &&
                    StartDate.AddMonths(3).AddDays(-1) >= CommutationDate)
            {

                return IRRPremiumTable.Sum(p => p.EarnedPremium);

            }

            return IRRPremiumTable.AsParallel().Where(p =>
               (p.EarnedDay >= StartDate)
               && (p.EarnedDay <= EndDate)).Sum(p => p.EarnedPremium);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="CommutationDate"></param>
        /// <param name="IRRLossSchedules"></param>
        /// <returns></returns>
        public decimal CurrentIncurredLoss(DateTime StartDate, DateTime EndDate, 
            DateTime CommutationDate, IEnumerable<IRRLossSchedule> IRRLossSchedules)
        {

            if (StartDate > CommutationDate)
            {
                return 0;
            }
            else if (StartDate <= CommutationDate &&
                    StartDate.AddMonths(3).AddDays(-1) >= CommutationDate)
            {

                return IRRLossSchedules.Sum(p => p.IncurredLoss);

            }
           

            return IRRLossSchedules.AsParallel().Where(p =>
                (p.LossOccurenceDay >= StartDate)
                && (p.LossOccurenceDay <= EndDate)).Sum(p => p.IncurredLoss);


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"> </param>
        /// <param name="EndDate"></param>
        /// <param name="CommutationDate"></param>
        /// <param name="PaidLossSchedules"></param>
        /// <returns></returns>
        //Calculate PaidLoss without accumulation
        public decimal CurrentPaidLoss(DateTime StartDate, DateTime EndDate,
            DateTime CommutationDate, IEnumerable<PaidSchedule> PaidLossSchedules)
        {

            if (StartDate > CommutationDate)
            {
                return 0;
            }
            else if (StartDate <= CommutationDate &&
                    StartDate.AddMonths(3).AddDays(-1) >= CommutationDate)
            {

                return PaidLossSchedules.Sum(p => p.PaidLoss);

            }
           

            return PaidLossSchedules.AsParallel().Where(p =>
                               (p.LossPaymentDate >= StartDate) &&
                               p.LossPaymentDate <= EndDate).Sum(p => p.PaidLoss);

            

        }


        public decimal GetContribution(DateTime StartDate, IEnumerable<CapitalSchedule> CapitalSchedule)
        {
            return CapitalSchedule.AsParallel().Where(c => c.Date == StartDate).Sum(c => c.IncrementalCapitalAdded);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="SPInvestorId"></param>
        /// <param name="RetroProgramIds"></param>
        /// <returns></returns>
        //Get Paid Loss Schedule
        public async Task<IEnumerable<PaidSchedule>> GetPaidLossSchedule(int  SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<PaidSchedule>(_queryService.GetPaidLossQuery());
        }


        //Get all response from the loss table
        public async Task<IEnumerable<IRRLossSchedule>> GetIRRLossSchedule(double ClimateLoading = 1)
        {

            return await _queryService.QuerySet<IRRLossSchedule>(
                _queryService.GetIRRLossScheduleQuery(ClimateLoading));

        }

        //Get Premium Table Inputs
        public async Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(IEnumerable<int>? ids)
        {
            FormattableString _queryString = ids.IsNullOrEmpty()
                ? $@"{_queryService.GetIRRPremiumString()} 
                     order by SPInvestor, RetroProfileId, 
                     RetroProgramId, LayerInception;"

                : (FormattableString)$@"{_queryService.GetIRRPremiumString()}
                               where SPInvestor in ({string.Join(",", ids!)})
                               order by SPInvestor, RetroProfileId, 
                               RetroProgramId, LayerInception;";

            return await _queryService.QuerySet<IRRPremiumInputDTO>(_queryString);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="SPInvestorId"></param>
        /// <param name="RetroProgramIds"></param>
        /// <returns></returns>
        //Get Premium Schedule
        public async Task<IEnumerable<PremiumSchedule>> GetPremiumSchedule(int SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<PremiumSchedule>(_queryService.GetPremiumScheduleQuery());
        }

        public async Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(
                                                                    int SPInvestor, 
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<IRRPremiumInputDTO>(_queryService.GetIRRPremiumString());
        }



        public async Task<IEnumerable<CapitalSchedule>> GetCapitalSchedule()
        {

            return await _queryService.QuerySet<CapitalSchedule>(_queryService.GetCapitalScheduleQuery());
            
        }


        public async Task<IEnumerable<BufferSchedule>> GetBufferSchedule()
        {
            return await _queryService.QuerySet<BufferSchedule>(_queryService.GetBufferQuery());

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeTuple"></param>
        /// <param name="values"></param>
        /// <param name="CommutationDate"></param>
        /// <returns></returns>
        private static async Task<IEnumerable<Decimal>> CumulativeTable(IEnumerable<DateTuple> timeTuple, 
            IEnumerable<decimal> values, DateTime CommutationDate)
        { 
            var IncurDateTuple = timeTuple.Zip(values,
                (first, second) => new LossPremTuple(first.StartDate, second));

            return await Task.FromResult<IEnumerable<decimal>>(
                                    CumulativeSum(IncurDateTuple, CommutationDate));

        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        private static IEnumerable<Tuple<T, P>> ListsToTuple<T, P>(IEnumerable<T> list1, 
            IEnumerable<P> list2)
        {
            return (IEnumerable<Tuple<T, P>>) list1.AsParallel().Zip(list2);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numbers"></param>
        /// <returns></returns>
        //Compute the cumulative sum of a numeric list
        private static IEnumerable<T> CumulativeSum<T>(IEnumerable<T> numbers) where T : INumber<T>
        {
            T sum = T.Zero;

            foreach (var number in numbers)
            {
                sum += number;
                yield return sum;
            }
           
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="CommutationDate"></param>
        /// <returns></returns>
        private static IEnumerable<decimal> CumulativeSum(IEnumerable<LossPremTuple> numbers, 
            DateTime CommutationDate) 
        {
            decimal sum = 0;

            foreach (var (StartDate, LossPremValue) in numbers)
            {
                if(StartDate.AddMonths(3).AddDays(-1) >= CommutationDate)
                {
                    yield return LossPremValue;
                }

                sum += LossPremValue;
                yield return sum;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static IEnumerable<GenericRow> GetTupleToGenericRow(IEnumerable<DataFrameRow> list)
        {
            foreach (var Item in list) { 
            
                yield return new GenericRow([ Item.StartDate, Item.EndDate, 
                                        Item.GrossEarnedPremium, Item.IncurredLoss, Item.PaidLoss ]);
            
            }



        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static IEnumerable<T> AddListItems<T>(IEnumerable<T> list1, IEnumerable<T> list2)
            where T : INumber<T> 
        {
            foreach(var (number1, number2) in ListsToTuple<T, T>(list1, list2)) { 
                yield return number1 + number2;
            }
        }

        
       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="list1"></param>
       /// <param name="list2"></param>
       /// <param name="reverse"></param>
       /// <returns></returns>
        public static IEnumerable<T> SubtractListItems<T>(IEnumerable<T> list1, 
            IEnumerable<T> list2, bool reverse=false)
            where T : INumber<T>
        {
            foreach (var (number1, number2) in ListsToTuple<T, T>(list1, list2))
            {
                yield return !reverse ? number1 - number2 : number2 - number1;
            }
        }




    }
}
