using CashflowModelling.Domain.IRR.DTOs;
using FluentNHibernate.Conventions;
using CashflowModelling.Application.IRR.Interface;
using CashflowModelling.Application.IRR.Payload;
using CashflowModelling.Domain.IRR.Model;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using LanguageExt;
using Microsoft.Spark.Sql.Expressions;
using Microsoft.Spark;






namespace CashflowModelling.Application.IRR.Service
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
        /// Compute IRR based on specified start and end dates, retroporgram ids and retroprofile ids
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 


        public async Task<IEnumerable<Decimal>> IRRComputation(IRRInputs input)
        {
            var StartDate = input.QuarterStartDate;
            var EndDate = input.QuarterEndDate;
            var CommutationDate = input.CommutationDate;
            var RetroProgramIds = input.RetroProgramIds;
            var RetroProfileIds = input.RetroProfileIds;
            var AcquisitonExpenseRate = input.AcquisitionExpense;
            var CommissionRate = 1;
            var IncomeAccumuationRate = (float) Math.Pow(1.05, 1 / 360);



             var StartDateRange = Enumerable.Range(0, EndDate.Subtract(StartDate).Days + 1).
                                   Select(days => StartDate.AddDays(days));

            var EndDateRange = StartDateRange.Select(date => date.AddDays(1));

            //var IsCommutable = StartDateRange.AsParallel().Select(s => s > CommutationDate ? 0 : 1);


            IEnumerable<DateTuple> DateRange =
                (IEnumerable<DateTuple>)ListsToTuple<DateTime, DateTime>(StartDateRange,
                EndDateRange);

            //Read all the tables as IRR Inputs

            Task<IEnumerable<PremiumSchedule>> PremiumTable =
                this.GetPremiumSchedule(RetroProgramIds, RetroProfileIds);


            Task<IEnumerable<PaidSchedule>> PaidLossTable = this.GetPaidLossSchedule(RetroProfileIds,
                                                                                RetroProgramIds);

            Task<IEnumerable<IRRLossSchedule>> IncurredLossTable = this.GetIRRLossSchedule();


            await Task.WhenAll(PremiumTable, PaidLossTable, IncurredLossTable);




            // Get the all the required data forms for IRR calculation
            var GrossEarnedPremiums = this.GrossEarnedPremiumTable(DateRange,
                                                        PremiumTable.Result, CommutationDate);

            var IncurredLosses = this.IncurredLossTable(DateRange,
                                    IncurredLossTable.Result, CommutationDate);

            var PaidLosses = this.PaidLossTable(DateRange, PaidLossTable.Result, CommutationDate);


            await Task.WhenAll(GrossEarnedPremiums, IncurredLosses, PaidLosses);


            var GenericRows = DateRange
                                     .Zip(GrossEarnedPremiums.Result, (x, y) => (x.StartDate, x.EndDate, y))
                                     .Zip(IncurredLosses.Result, (x, y) => (x.StartDate, x.EndDate, x.y, y))
                                     .Zip(PaidLosses.Result, (x, y) => (x.StartDate, x.EndDate, x.Item3, x.Item4, y));

           



            //Calculation 

            var IRRTable = GetDataFrame(DataFrameTableNames, GetTupleToGenericRow(GenericRows));

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


            IRRTable.CreateOrReplaceTempView("IRRTable");


            IRRTable = RecursiveCTE(IRRTable, IncomeAccumuationRate);


            IRRTable.WithColumn("Cumulative Investment Income",

                Functions.Sum(IRRTable.Col("Investment Income on Float").Over(
                    Window.OrderBy(IRRTable.Col("Period Start Date"))
                           .RowsBetween(Window.UnboundedPreceding, Window.CurrentRow))

                ));


            IRRTable.WithColumn("Subject To Profit Commission",

                Functions.Greatest(IRRTable.Col("Net Ceded Premium") - IRRTable.Col("Incurred Losses")
                + IRRTable.Col("Cumulative Investment Income"), Functions.Lit(Functions.Max(IRRTable.Col("Net Ceded Premium"))
                - Functions.Max(IRRTable.Col("Incurred Losses")) + IRRTable.Col("Cumulative Investment Income"))

                ));





            throw new NotImplementedException();
        }



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


        private static DataFrame RecursiveCTE(DataFrame IrrTable, float AccumulationFactor)
        {

            var IRRTable = IrrTable.WithColumn("Row Number", Functions.RowNumber().Over(Window.OrderBy(IrrTable.Col("Period Start Date"))));

            var sparksesssion = SparkSession.Builder().GetOrCreate();

            var query = $@"


              with recursive_cte as (
                 
                select top 1 * 
                    
                    cast(0 as float) As [Starting Float],

                    cast(Case when [Float Change]*0.5 > 0 
                            then [Float Change]*0.5 else 0 end as float) As [Average Investment Float],

                    cast(Case when [Float Change]*0.5*{AccumulationFactor} > 0 
                            then [Float Change]*0.5*{AccumulationFactor} else 0 end as float) As [Investment Income on Float],

                    cast([Float Change] + Case when [Float Change]*0.5*{AccumulationFactor} > 0 
                            then [Float Change]*0.5*{AccumulationFactor} else 0 end as float) As [Ending Float],
                
                from IRRTable 

                union all

                select 
                    
                    irrtable.*, 

                    recurs.[Ending Float] As [Starting Float]

                    cast(Case when recurs.[Ending Float] + 0.5*irrtable.[Float Change] > 0 
		
			                then recurs.[Ending Float] + 0.5*irrtable.[Float Change]
			    
			                else 0 
			
		                    end as float) As [Average Investment Float],

                    cast(Case when recurs.[Ending Float] + 0.5*irrtable.[Float Change] > 0 
		
			                then recurs.[Ending Float] + 0.5*irrtable.[Float Change]
			    
			                else 0 
			
		                    end * {AccumulationFactor} as float) As [Average Investment Float],


                    irrtable.[Float Change] + recurs.[Ending Float] + 
                    
                    cast(Case when recurs.[Ending Float] + 0.5*irrtable.[Float Change] > 0 
		
			                then recurs.[Ending Float] + 0.5*irrtable.[Float Change]
			    
			                else 0 
			
		                    end * {AccumulationFactor} as float) As [Investment Income on Float]


                from IRRtable irrtable 
                
                inner join recursive_cte recurs

                on  irrtable.[Row Number] = recursive_cte.[Row Number] + 1

             )
             select * from recursive_cte

               ";


            IRRTable.CreateOrReplaceTempView("IRRTable");

            IRRTable = sparksesssion.Sql(query.ToString());

            IRRTable.Drop("Row Number");


            return IRRTable;

        }




 
        public async Task<IEnumerable<IRRPremiumInputDTO>> ComputeIRR(IRRInputs input)
        {

            var StartDate = input.QuarterStartDate;
            var EndDate = input.QuarterEndDate;
            var CommutationDate = input.CommutationDate;
            var RetroProgramIds = input.RetroProgramIds;
            var RetroProfileIds = input.RetroProfileIds;
            var AcquisitonExpenseRate = input.AcquisitionExpense;
            var ProfitHurdle = 0;


            var NetCededPremium = new List<decimal>();
            var StartingFloat = new List<decimal>();
            var FloatChange = new List<decimal>();
            var EndingFloat = new List<decimal>();
            var AverageInvestmentFloat = new List<decimal>();
            var InvestmentFloat = new List<decimal>();
            var SubjectToProfitCommission = new List<decimal>();
            var CumulativeCasflow = new List<decimal>();
            var TotalEarnedProfit = new List<decimal>();


            //Get all the date ranges 
            var StartDateRange = Enumerable.Range(0, EndDate.Subtract(StartDate).Days+1).
                                      AsParallel().Select(days => StartDate.AddDays(days));

            var EndDateRange = StartDateRange.AsParallel().Select(date  => date.AddDays(1));


            IEnumerable<DateTuple> DateRange =
                (IEnumerable<DateTuple>) ListsToTuple<DateTime, DateTime>(StartDateRange, 
                EndDateRange);


            var IsCommutable = StartDateRange.AsParallel().Select(s => s > CommutationDate ? 0 : 1);

            //Read all the tables as IRR Inputs

            Task<IEnumerable<PremiumSchedule>> PremiumTable =
                this.GetPremiumSchedule(RetroProgramIds, RetroProfileIds);

            
            Task<IEnumerable<PaidSchedule>> PaidLossTable = this.GetPaidLossSchedule(RetroProfileIds,
                                                                                RetroProgramIds);

            Task<IEnumerable<IRRLossSchedule>> IncurredLossTable = this.GetIRRLossSchedule();


            await Task.WhenAll(PremiumTable, PaidLossTable, IncurredLossTable);




            // Get the all the required data forms for IRR calculation
            var GrossEarnedPremiums = this.GrossEarnedPremiumTable(DateRange,
                                                        PremiumTable.Result, CommutationDate);

            var IncurredLosses = this.IncurredLossTable(DateRange,
                                    IncurredLossTable.Result, CommutationDate);

            var PaidLosses = this.PaidLossTable(DateRange, PaidLossTable.Result, CommutationDate);


            await Task.WhenAll(GrossEarnedPremiums, IncurredLosses, PaidLosses);


            //Calculation
            var AcquisitionExpenseRate = GrossEarnedPremiums.Result.AsParallel()
                                        .Select(g => g * (decimal) AcquisitonExpenseRate);


            var CommissionExpense = SubtractListItems<decimal>(GrossEarnedPremiums.Result,
                                                        AcquisitionExpenseRate).Select(s => s * (decimal) 1.5);

            
           

            for(int iterator =0; iterator< (int) GrossEarnedPremiums.Result.Count(); iterator++)
            {

                

                NetCededPremium.Add(GrossEarnedPremiums.Result.ElementAt(iterator) 
                    - (AcquisitionExpenseRate.ElementAt(iterator) + CommissionExpense.ElementAt(iterator)));

                if (iterator == 0)
                {
                    StartingFloat.Add(0);

                    FloatChange.Add(NetCededPremium.ElementAt(iterator) - PaidLosses.Result.ElementAt(iterator));

                    AverageInvestmentFloat.Add(Math.Max(StartingFloat.ElementAt(iterator) 
                        + (decimal) 0.5*FloatChange.ElementAt(iterator), 0));

                    InvestmentFloat.Add((decimal)Math.Pow(1, 1/365)*AverageInvestmentFloat.ElementAt(iterator));


                    EndingFloat.Add(StartingFloat.ElementAt(iterator) 
                        + FloatChange.ElementAt(iterator) + InvestmentFloat.ElementAt(iterator));

                    continue;
                }

                StartingFloat.Add(EndingFloat.ElementAt(iterator-1));

                FloatChange.Add((NetCededPremium.ElementAt(iterator) - NetCededPremium.ElementAt(iterator - 1)) -
                                (PaidLosses.Result.ElementAt(iterator) - PaidLosses.Result.ElementAt(iterator)));

                AverageInvestmentFloat.Add(Math.Max(StartingFloat.ElementAt(iterator)
                        + (decimal)0.5 * FloatChange.ElementAt(iterator), 0));

                InvestmentFloat.Add((decimal)Math.Pow(1, 1 / 365) * AverageInvestmentFloat.ElementAt(iterator));

                EndingFloat.Add(StartingFloat.ElementAt(iterator)
                    + FloatChange.ElementAt(iterator) + InvestmentFloat.ElementAt(iterator));

            }


            var CumulativeInvestmentIncome = CumulativeSum<decimal>(InvestmentFloat);

            var MaxIncurrredLosses = IncurredLosses.Result.Max();
            var MaxNetCededPremium = NetCededPremium.Max();


            Parallel.For(0, (int)CumulativeInvestmentIncome.Count(), iterator =>
            {



                SubjectToProfitCommission.Add(

                    Math.Min(NetCededPremium.ElementAt(iterator)
                   - IncurredLosses.Result.ElementAt(iterator)
                   + CumulativeInvestmentIncome.ElementAt(iterator),

                    MaxIncurrredLosses - MaxNetCededPremium
                    + CumulativeInvestmentIncome.ElementAt(iterator)
                    ));

                CumulativeCasflow.Add(

                    NetCededPremium.ElementAt(iterator)
                   - PaidLosses.Result.ElementAt(iterator)
                   + CumulativeInvestmentIncome.ElementAt(iterator)

                    );             

            });
          

           

            switch (input.ViewType)
            {
                case (int)ViewType.ArchView:
                    break;
                case (int)ViewType.SensitivityView:
                    break;

            }
            throw new NotImplementedException();
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

        //Returns the cumulative incurred loss for all given date ranges
        public async Task<IEnumerable<decimal>> IncurredLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<IRRLossSchedule> IRRLossTable, DateTime CommutationDate)
        {
            var CurrentIncurredLoss = DateRange.AsParallel()
                            .Select(datetuple => this.CurrentIncurredLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, IRRLossTable));

            return await CumulativeTable(DateRange, CurrentIncurredLoss, CommutationDate);
        }


        //Returns the cumulative Paid Loss table
        public async Task<IEnumerable<decimal>> PaidLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<PaidSchedule> PaidLosses, DateTime CommutationDate)
        {
            var CurrentPaidLoss = DateRange.AsParallel()
                            .Select(datetuple => this.CurrentPaidLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, PaidLosses));

            return await CumulativeTable(DateRange, CurrentPaidLoss, CommutationDate);
        }



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

        //Get Paid Loss Schedule
        public async Task<IEnumerable<PaidSchedule>> GetPaidLossSchedule(IEnumerable<int>? RetroProfileIds,
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
            FormattableString _queryString = ids.IsEmpty()
                ? $@"{_queryService.GetIRRPremiumString()} 
                     order by RetroProfileId, SPInvestor, 
                     RetroProgramId, LayerInception;"

                : (FormattableString)$@"{_queryService.GetIRRPremiumString()}
                               where RetroProfileId in ({string.Join(",", ids!)})
                               order by RetroProfileId, SPInvestor, 
                               RetroProgramId, LayerInception;";

            return await _queryService.QuerySet<IRRPremiumInputDTO>(_queryString);

        }


        //Get Premium Schedule
        public async Task<IEnumerable<PremiumSchedule>> GetPremiumSchedule(IEnumerable<int>? RetroProfileIds,
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<PremiumSchedule>(_queryService.GetPremiumScheduleQuery());
        }

        public async Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(
                                                                    IEnumerable<int>? RetroProfileIds, 
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            FormattableString RetroProfileIdString =
               RetroProgramIds.IsNullOrEmpty() ? $@"" :
                (FormattableString)$@"where RetroProfileId in 
                                        ({string.Join(",", RetroProfileIds!)})";

            FormattableString RetroProgramIdString =
                RetroProgramIds.IsNullOrEmpty() ? $@"" :
                (FormattableString)$@"and RetroProgramId 
                                    in ({string.Join(",", RetroProgramIds!)})";


            FormattableString _queryString = $@"{_queryService.GetIRRPremiumString()} 
                                  {RetroProfileIdString} {RetroProgramIdString}
                                  order by RetroProfileId, SPInvestor, 
                                  RetroProgramId, LayerInception;";

            return await _queryService.QuerySet<IRRPremiumInputDTO>(_queryString);
        }



        private static async Task<IEnumerable<Decimal>> CumulativeTable(IEnumerable<DateTuple> timeTuple, 
            IEnumerable<decimal> values, DateTime CommutationDate)
        { 
            var IncurDateTuple = timeTuple.Zip(values,
                (first, second) => new LossPremTuple(first.StartDate, second));

            return await Task.FromResult<IEnumerable<decimal>>(
                                    CumulativeSum(IncurDateTuple, CommutationDate));

        }


        private static IEnumerable<Tuple<T, P>> ListsToTuple<T, P>(IEnumerable<T> list1, 
            IEnumerable<P> list2)
        {
            return (IEnumerable<Tuple<T, P>>) list1.AsParallel().Zip(list2);
        }


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


        private static IEnumerable<GenericRow> GetTupleToGenericRow(IEnumerable<DataFrameRow> list)
        {
            foreach (var Item in list) { 
            
                yield return new GenericRow([ Item.StartDate, Item.EndDate, 
                                        Item.GrossEarnedPremium, Item.IncurredLoss, Item.PaidLoss ]);
            
            }



        }


        public static IEnumerable<T> AddListItems<T>(IEnumerable<T> list1, IEnumerable<T> list2)
            where T : INumber<T> 
        {
            foreach(var (number1, number2) in ListsToTuple<T, T>(list1, list2)) { 
                yield return number1 + number2;
            }
        }

        
        ///<summary>
        /// This is to calculate the difference in times for two lists
        ///<summary/>
    

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
