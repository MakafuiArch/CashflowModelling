using IRR.Domain.DTOs;
using IRR.Application.Interface;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Microsoft.Spark.Sql.Expressions;
using Excel.FinancialFunctions;
using FluentValidation;
using IRR.Application.Payload;
using Microsoft.Data.Analysis;



namespace IRR.Application.Service
{
    using DataFrame = Microsoft.Spark.Sql.DataFrame;
    using DataFrameRow = (DateTime StartDate, DateTime EndDate,
        double GrossEarnedPremium, double IncurredLoss, double PaidLoss);

    public partial class ArchViewIRRService(IQuery queryService, IDataTest _testData) : IIRR
    {

        private readonly IQuery _queryService = queryService;
        private readonly IDataTest _testData = _testData;

        private static readonly Dictionary<string, StructField> DataFrameTableNames = new()
        {
            { "Period Start Date", new StructField("Period Start Date", new DoubleType())},
            { "Period End Date", new StructField("Period End Date", new DoubleType()) },
            { "Gross Earned Premium", new StructField("Gross Earned Premium", new DoubleType()) },
            { "Incurred Losses",new StructField("Incurred Losses", new DoubleType()) },
            { "Paid Losses", new StructField("Paid Losses", new DoubleType()) }
        };



        public async Task<Dictionary<int, Tuple<DataFrame, double>>> GetIRRForSPInvestor(IRRInputs input)
        {

            var StartDate = (DateTime) input.QuarterStartDate!;
            var EndDate = (DateTime) input.QuarterEndDate!;
            var CommutationDate = input.CommutationDate;
            var RetroProgramIds = input.RetroProgramIds;
            var SPInvestorId = input.SPInvestorId;
            var Capital = input.Capital;
            var AcquisitionExpenseRate = input.AcquisitionExpense;


            return await IRRCashFlow(StartDate, EndDate, CommutationDate, RetroProgramIds!, 
                SPInvestorId, Capital, AcquisitionExpenseRate);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="CommutationDate"></param>
        /// <param name="RetroProgramIds"></param>
        /// <param name="SPInvestorId"></param>
        /// <param name="Capital"></param>
        /// <param name="AcquisitionExpenseRate"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, Tuple<DataFrame, double>>> IRRCashFlow(DateTime StartDate, 
            DateTime EndDate, 
            DateTime CommutationDate, 
            IEnumerable<int> RetroProgramIds, 
            int SPInvestorId, 
            double Capital, 
            double AcquisitionExpenseRate
            
            )
        {

            var responseDictionary = new Dictionary<int, Tuple<DataFrame, double>>();



            var StartDateRange = Enumerable.Range(0,  EndDate.Subtract(EndDate).Days + 2).
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



                var dataframeIRRResponse = await ComputeIRR(PremiumTable.Result, PaidLossTable.Result,
                                        IncurredLossTable.Result, CapitalTable.Result, (double) Capital,
                                        CommutationDate, (double) AcquisitionExpenseRate, DateRange);

                responseDictionary.Add(SPInvestorId, dataframeIRRResponse);



                return responseDictionary;
        }


        //Just is just dummy and may not be used.
        public Task<double> TestIRR()
        {

            Type[] premiumTypes = [typeof(int), typeof(int), typeof(int), typeof(DateTime),
                typeof(double), typeof(double), typeof(int)];

            Type[] paidLossTypes = [typeof(int), typeof(int), typeof(int), typeof(int), typeof(DateTime),
                typeof(double), typeof(double)];

            Type[] incurredLossTypes = [typeof(int), typeof(int), typeof(int), typeof(int), typeof(DateTime),
                typeof(double), typeof(double)];

            Type[] capitalTypes = [typeof(int), typeof(double), typeof(DateTime)];

            Type[] bufferTypes = [typeof(int), typeof(float), typeof(DateTime)];


            var PremiumTable = _testData.ReadFileToObject<PremiumSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/PremiumScheduleTest.csv", premiumTypes);

            var IncurredLossTable = _testData.ReadFileToObject<IRRLossSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/LossScheduleTest.csv", incurredLossTypes);

            var PaidLossTable = _testData.ReadFileToObject<PaidSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/PaidLossTest.csv", paidLossTypes);

            var CapitalTable = _testData.ReadFileToObject<CapitalSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/CapitalScheduleTest.csv", capitalTypes);


            var BufferTable = _testData.ReadFileToObject<BufferSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/BufferScheduleTest.csv", bufferTypes);



            DateTime startDate = new (2024, 1, 1);

            DateTime endDate = new(2027, 3, 31);

            DateTime commutationDate = new(2027, 1, 2);

            var StartDateRange = Enumerable.Range(0, endDate.Subtract(startDate).Days).
                                   Select(days => days ==0 ? startDate.AddDays(0) 
                                   : startDate.AddDays(2*days)).ToList();


            var EndDateRange = StartDateRange.Select(date => date.AddDays(1)).ToList();

            var rangedate = ListsToTuple<DateTime, DateTime>(StartDateRange, EndDateRange);


            IEnumerable<DateTuple> DateRange = rangedate.Select(p => new DateTuple(p.Item1, p.Item2));


            var NewDateRange = DateRange.Where(predicate => predicate.StartDate.Subtract(commutationDate).Days < 0).ToList();


            return IRRCompute(PremiumTable, PaidLossTable, IncurredLossTable, CapitalTable, BufferTable, commutationDate, 0.35, NewDateRange);


        }





        private async Task<double> IRRCompute(IEnumerable<PremiumSchedule> PremiumTable,
                                            IEnumerable<PaidSchedule> PaidLossTable,
                                            IEnumerable<IRRLossSchedule> IncurredLossTable,
                                            IEnumerable<CapitalSchedule> CapitalTable,
                                            IEnumerable<BufferSchedule> BufferTab,
                                            DateTime CommutationDate,
                                            double AcquisitonExpenseRate,
                                            IEnumerable<DateTuple> DateRange)
        {

            var CommissionRate = 0;
            var HurdleAmount = 0;
            var IncomeAccumuationRate = Math.Pow(1.05, (double) 1/ (double) 360);

            var ProfitCommission = 0.35;

            var CashFlowRange = DateRange.Select(p => p.StartDate).ToList();


            var CashFlowEndRange = DateRange.Select(p => p.EndDate).ToList();



            // Get the all the f data forms for IRR calculation
            var GrossEarnedPremiums = this.GrossEarnedPremiumTable(DateRange,
                                                        PremiumTable, CommutationDate);

            var IncurredLosses = this.IncurredLossTable(DateRange,
                                    IncurredLossTable, CommutationDate);

            var PaidLosses = this.PaidLossTable(DateRange, PaidLossTable, CommutationDate);


            var CapitalContribution = Contributions(CapitalTable, CashFlowRange);


            var TotalCapital = CapitalTable.Sum(p => p.IncrementalCapitalAdded);

            var Buffers = BuffersTab(BufferTab, DateRange);


            await Task.WhenAll(GrossEarnedPremiums, IncurredLosses, PaidLosses, CapitalContribution, Buffers);



            var GrossEarnedPremium = new DoubleDataFrameColumn("Gross Earned Premium",  GrossEarnedPremiums.Result);
            var IncurLosses = new DoubleDataFrameColumn("Incurred Losses", IncurredLosses.Result);
            var PaidLoss = new DoubleDataFrameColumn("Paid Losses", PaidLosses.Result);
            var CapitalTab = new DoubleDataFrameColumn("Capital Contribution",  CapitalContribution.Result);
            var Buffer = new SingleDataFrameColumn("Buffer Factor", Buffers.Result);
            var CashFlowStart = new DateTimeDataFrameColumn("Period Start Date", CashFlowRange);
            var CashFlowEnd = new DateTimeDataFrameColumn("Period End Date", CashFlowEndRange);

            var CashFlowDataFrame = new Microsoft.Data.Analysis.DataFrame(CashFlowStart, CashFlowEnd, 
                GrossEarnedPremium, IncurLosses, PaidLoss, CapitalTab, Buffer);



            Microsoft.Data.Analysis.DataFrame.SaveCsv(CashFlowDataFrame, "C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/InitialData.csv");


            CashFlowDataFrame["Original Acquisition Expenses"] = CashFlowDataFrame["Gross Earned Premium"].Multiply(
                                                                    AcquisitonExpenseRate);

            CashFlowDataFrame["Commission and Tail Fee"] = CashFlowDataFrame["Gross Earned Premium"].Subtract(
                CashFlowDataFrame["Original Acquisition Expenses"]).Multiply(CommissionRate);

            CashFlowDataFrame["Net Ceded Premium"] = CashFlowDataFrame["Gross Earned Premium"].Subtract(
                CashFlowDataFrame["Original Acquisition Expenses"]).Subtract(CashFlowDataFrame["Commission and Tail Fee"]);


            CashFlowDataFrame.Columns.Add(DataFrameLag("Float Change", CashFlowDataFrame["Net Ceded Premium"], (double) CashFlowDataFrame["Net Ceded Premium"][0]));


            CashFlowDataFrame.Columns.Add(DataFrameLag("Paid Loss Lag", CashFlowDataFrame["Paid Losses"], (double)CashFlowDataFrame["Paid Losses"][0]));


            CashFlowDataFrame["Float Change"] = CashFlowDataFrame["Float Change"].Subtract(CashFlowDataFrame["Paid Loss Lag"]);

            //<--------------- Calculating Float------------------->

            var StartingFloat = new PrimitiveDataFrameColumn<double>("Starting Float", CashFlowDataFrame.Rows.Count);

            var AverageInvestmentFloat = new PrimitiveDataFrameColumn<double>("Average Investment Float",
                CashFlowDataFrame.Rows.Count);

            var InvestmentIncome = new PrimitiveDataFrameColumn<double>("Investment Income on Float",
                CashFlowDataFrame.Rows.Count);

            var EndingFloat = new PrimitiveDataFrameColumn<double>("Ending Float",
                CashFlowDataFrame.Rows.Count);

            for (int i = 0; i < CashFlowDataFrame.Rows.Count; i++)
            {

                if (i == 0)
                {
                    StartingFloat[i] = 0;

                }
                else
                {
                    StartingFloat[i] = EndingFloat[i - 1];
                }

                AverageInvestmentFloat[i] = (double)Math.Max((double) StartingFloat[i]! + 
                                    (double) CashFlowDataFrame["Float Change"][i]*0.5/360, 0);

                InvestmentIncome[i] =  AverageInvestmentFloat[i] * (double) IncomeAccumuationRate;

                EndingFloat[i] = StartingFloat[i] + (double) CashFlowDataFrame["Float Change"][i] + InvestmentIncome[i];

            }


            CashFlowDataFrame.Columns.Add(StartingFloat);
            CashFlowDataFrame.Columns.Add(AverageInvestmentFloat);
            CashFlowDataFrame.Columns.Add(InvestmentIncome);
            CashFlowDataFrame.Columns.Add(EndingFloat);


            //<------------------End Float Calculation ----------------------------->

            CashFlowDataFrame["Cumulative Investment Income"] = CashFlowDataFrame["Investment Income on Float"].CumulativeSum();

            CashFlowDataFrame["Subject To Profit Commission"] = (CashFlowDataFrame["Net Ceded Premium"]
                                             .Subtract(CashFlowDataFrame["Incurred Losses"])
                                         
                                              -
                                             
                                            ((double)CashFlowDataFrame["Net Ceded Premium"].Max()
                                            - (double)CashFlowDataFrame["Incurred Losses"].Max()));


            var SubjectProfitBoolResult = CashFlowDataFrame["Subject To Profit Commission"]
                                        .ElementwiseLessThan(

                                           0

                                            ).Select(p => p.Value == true ? (double) 1 : (double) 0);


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("SubjectBool", SubjectProfitBoolResult));


            CashFlowDataFrame["Subject To Profit Commission"] = CashFlowDataFrame["Subject To Profit Commission"]
                                                            .Multiply(CashFlowDataFrame["SubjectBool"])
                                                            .Add(CashFlowDataFrame["Cumulative Investment Income"]) +
                                                            ((double)CashFlowDataFrame["Net Ceded Premium"].Max()
                                            + (double)CashFlowDataFrame["Incurred Losses"].Max());


            CashFlowDataFrame["Total Earned Profits"] = CashFlowDataFrame["Subject To Profit Commission"] - HurdleAmount;


            var EarnedProfitsBoolResult = (CashFlowDataFrame["Total Earned Profits"] - HurdleAmount)
                                                .ElementwiseGreaterThan(0).Select(p => p.Value == true ? (double) 1 : (double) 0).ToList();


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("EarnedBool", EarnedProfitsBoolResult));


            CashFlowDataFrame["Total Earned Profits"] = CashFlowDataFrame["Subject To Profit Commission"]

                                    .Subtract(

                                        (CashFlowDataFrame["Total Earned Profits"] - HurdleAmount)
                                        .Multiply(CashFlowDataFrame["SubjectBool"])*ProfitCommission
                                    );


            CashFlowDataFrame["Profit Commission"] = CashFlowDataFrame["Subject To Profit Commission"]
                                                .Subtract(CashFlowDataFrame["Total Earned Profits"]);


            CashFlowDataFrame["Cumulative Cashflow"] = CashFlowDataFrame["Net Ceded Premium"]
                                                .Subtract(CashFlowDataFrame["Paid Losses"]).Add(CashFlowDataFrame["Cumulative Investment Income"]);

            CashFlowDataFrame.Columns.Add(DataFrameLag("Incremental Cashflow", CashFlowDataFrame["Total Earned Profits"],

                                    (double) CashFlowDataFrame["Total Earned Profits"][0] ));



            //<-----------------------Capital Calculation----------------------------------->

            var StartingCapital = new PrimitiveDataFrameColumn<double>("Starting Capital", CashFlowDataFrame.Rows.Count);

            var InvestmentIncomeOnCapital = new PrimitiveDataFrameColumn<double>("Investment Income On Capital",
                CashFlowDataFrame.Rows.Count);

            var EndingCapital = new PrimitiveDataFrameColumn<double>("Ending Capital",
                CashFlowDataFrame.Rows.Count);

            for (int i = 0; i < CashFlowDataFrame.Rows.Count; i++)
            {

                if(i == 0)
                {
                    StartingCapital[i] = (double) CashFlowDataFrame["Capital Contribution"][0] + 
                                        Math.Min((double) CashFlowDataFrame["Incremental Cashflow"][0], 0);
                }
                else
                {
                    StartingCapital[i] = (double)CashFlowDataFrame["Capital Contribution"][0] +
                                        Math.Min((double)CashFlowDataFrame["Incremental Cashflow"][0], 0) + EndingCapital[i-1];
                }


                InvestmentIncomeOnCapital[i] = StartingCapital[i] * IncomeAccumuationRate;

                EndingCapital[i] = InvestmentIncomeOnCapital[i] + StartingCapital[i];


            }

            CashFlowDataFrame.Columns.Add(StartingCapital);
            CashFlowDataFrame.Columns.Add(InvestmentIncomeOnCapital);
            CashFlowDataFrame.Columns.Add(EndingCapital);


            CashFlowDataFrame["Cumulative Investment Income On Capital"] = CashFlowDataFrame["Investment Income On Capital"]
                                                                                .CumulativeSum();


            CashFlowDataFrame["Investors Funds"] = CashFlowDataFrame["Total Earned Profits"]
                                                   .Add(CashFlowDataFrame["Capital Contribution"].CumulativeSum())
                                                   .Add(CashFlowDataFrame["Cumulative Investment Income On Capital"]);


            CashFlowDataFrame["Unpaid Losses"] = (double) CashFlowDataFrame["Paid Losses"].Max() - CashFlowDataFrame["Paid Losses"];


            CashFlowDataFrame["Buffered Reserves"] = CashFlowDataFrame["Buffer Factor"].Multiply(CashFlowDataFrame["Unpaid Losses"]);


            CashFlowDataFrame["Required Capital"] = (CashFlowDataFrame["Buffered Reserves"] - TotalCapital);


            var requiredCapitalBoolResult= CashFlowDataFrame["Required Capital"]
                
                                       .ElementwiseLessThan(0).Select(p => p.Value == true ? (double)1 : (double)0).ToList();


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("RequiredCapitalBool", requiredCapitalBoolResult));



            CashFlowDataFrame["Required Capital"] = (CashFlowDataFrame["Required Capital"] - (double) TotalCapital).Multiply(CashFlowDataFrame["RequiredCapitalBool"]) + TotalCapital;


            CashFlowDataFrame["Capital Released"] = CashFlowDataFrame["Investors Funds"].Subtract(CashFlowDataFrame["Required Capital"]);


            var CapitalBoolResult = CashFlowDataFrame["Capital Released"]

                                       .ElementwiseLessThan(0).Select(p => p.Value == true ? (double)1 : (double)0).ToList();


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("CapitalBool", CapitalBoolResult));



            CashFlowDataFrame["Capital Released"] = CashFlowDataFrame["Capital Released"].Multiply(

                CashFlowDataFrame["CapitalBool"]);


            CashFlowDataFrame.Columns.Add(DataFrameLag("Investor Cashflow", 
                CashFlowDataFrame["Capital Released"]).Subtract(CashFlowDataFrame["Capital Contribution"]));


            //PrimitiveDataFrameColumn<bool> boolFilter = CashFlowDataFrame["Period End Date"]


            Microsoft.Data.Analysis.DataFrame.SaveCsv(CashFlowDataFrame, "C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/TestData.csv");


            return 0;
                
                
                //Financial.XIrr(GetColumnData<double> (CashFlowDataFrame["Investor Cashflow"]),
                //GetColumnData<DateTime>(CashFlowDataFrame["Period Start Date"]));

        }



        private IEnumerable<T> GetColumnData<T>(DataFrameColumn dataFrameColumn)
        {
            for(int i = 0; i < dataFrameColumn.Length; i++)
            {

                yield return (T) dataFrameColumn[i];

            }


        }



        private DataFrameColumn DataFrameLag(string ColumnName, DataFrameColumn dataframeColumn, double DefaultFirst = 0)
        {
            var lagList = new PrimitiveDataFrameColumn<double>(ColumnName, dataframeColumn.Length) ;

            for(int index=0; index < dataframeColumn.Length; index++)
            {

                if (index == 0)
                {

                   
                   lagList[index] = DefaultFirst;
                   continue;

                }


                lagList[index] = (double) dataframeColumn[index] - (double) dataframeColumn[index-1];
            }

            return lagList;

        }





        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
        private async Task<Tuple<Microsoft.Spark.Sql.DataFrame, double>> ComputeIRR(IEnumerable<PremiumSchedule> PremiumTable, 
                                            IEnumerable<PaidSchedule> PaidLossTable, 
                                            IEnumerable<IRRLossSchedule> IncurredLossTable, 
                                            IEnumerable<CapitalSchedule> CapitalTable,
                                            double Capital,
                                            DateTime CommutationDate, 
                                            double AcquisitonExpenseRate,
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

            var Cashflow = IRRTable.Select("Investor Cashflow").Collect().Select(row => (double) Convert.ToDouble(row.Get(0)));

            var CashflowDate = IRRTable.Select("Period Start Date").Collect().Select(row => Convert.ToDateTime(row.Get(0)));


            
            return new Tuple<Microsoft.Spark.Sql.DataFrame, double>( IRRTable.ToJSON(), Financial.XIrr(Cashflow, CashflowDate) ) ;

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


        private static DataFrame AddNewColumnToDataFrame(DataFrame Table, IEnumerable<double> items, string ColumnName)
        {


            var sparksession = SparkSession.Builder().GetOrCreate();


            DataFrame newColumnDf = sparksession.CreateDataFrame((IEnumerable<int>)items.Select((value, index) => 
                                                        new{ Index = index, Value = value })).ToDF(ColumnName);


            return Table.WithColumn(ColumnName, newColumnDf.Col(ColumnName));

        }







        //Returns the Gross Earned Premium over a given date range
        private async Task<IEnumerable<double>> GrossEarnedPremiumTable(
            IEnumerable<DateTuple> DateRange, 
            IEnumerable<PremiumSchedule> IRRPremiumTable, DateTime CommutationDate)
        {
            var GrossEarnedPremium = DateRange.AsParallel().Select(datetuple => this.GrossEarnedPremium(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, IRRPremiumTable)).ToList();

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
        private async Task<IEnumerable<double>> IncurredLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<IRRLossSchedule> IRRLossTable, DateTime CommutationDate)
        {
            var CurrentIncurredLoss = DateRange.AsParallel().Select(datetuple => this.CurrentIncurredLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, IRRLossTable)).ToList();

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
        private async Task<IEnumerable<double>> PaidLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<PaidSchedule> PaidLosses, DateTime CommutationDate)
        {
            var CurrentPaidLoss = DateRange.AsParallel().Select(datetuple => this.CurrentPaidLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, PaidLosses)).ToList();

            return await CumulativeTable(DateRange, CurrentPaidLoss, CommutationDate);
        }


        private Task<IEnumerable<double>> Contributions(IEnumerable<CapitalSchedule> CapitalSchedule, 
            IEnumerable<DateTime> CashflowRange)
        {
            return Task.FromResult<IEnumerable<double>>(CashflowRange.AsParallel().Select(
                cashflowdate => GetContribution(cashflowdate, CapitalSchedule)).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BufferSchedule"></param>
        /// <param name="DateRange"></param>
        /// <returns></returns>
        private Task<List<float>> BuffersTab(IEnumerable<BufferSchedule> BufferSchedule, 
            IEnumerable<DateTuple> DateRange)
        {

            List<float> BuffersTab = [];
            
            foreach(DateTuple dataTuple in DateRange)
            {

                if(dataTuple.EndDate.Subtract(BufferSchedule.Select(m => m.BufferDate).Max()).Days <= 0)
                {
                    BuffersTab.Add(BufferSchedule.Select(m => m.BufferFactor).Max());
                }
                else
                {
                    BuffersTab.Add(BufferSchedule
                        .Where(b => b.BufferDate.Equals(dataTuple.StartDate))
                        .Select(m => m.BufferFactor).FirstOrDefault());
                }


            }

            return Task.FromResult(BuffersTab);
            
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
        private double GrossEarnedPremium(DateTime StartDate, 
            DateTime EndDate, 
            DateTime CommutationDate, IEnumerable<PremiumSchedule> IRRPremiumTable)
        {
            if (StartDate.Subtract(CommutationDate).Days > 0)
            {
                return 0;
            }
            else if (StartDate.Subtract(CommutationDate).Days <= 0 &&
                    StartDate.AddMonths(3).AddDays(-1).Subtract(CommutationDate).Days >=0)
            {

                return IRRPremiumTable.Sum(p => p.EarnedPremium);

            }

            return IRRPremiumTable.AsParallel().Where(p =>
               (p.EarnedDay.Subtract(StartDate).Days >= 0)
               && (p.EarnedDay.Subtract(EndDate).Days <= 0)).Sum(p => p.EarnedPremium);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="CommutationDate"></param>
        /// <param name="IRRLossSchedules"></param>
        /// <returns></returns>
        private double CurrentIncurredLoss(DateTime StartDate, DateTime EndDate, 
            DateTime CommutationDate, IEnumerable<IRRLossSchedule> IRRLossSchedules)
        {

            if (StartDate.Subtract(CommutationDate).Days > 0)
            {
                return 0;
            }
            else if (StartDate.Subtract(CommutationDate).Days <= 0 &&
                    StartDate.AddMonths(3).AddDays(-1).Subtract(CommutationDate).Days >= 0)
            {

                return IRRLossSchedules.Sum(p => p.IncurredLoss);

            }
           

            return IRRLossSchedules.AsParallel().Where(p =>
                (p.LossOccurenceDay.Subtract(StartDate).Days >= 0)
                && (p.LossOccurenceDay.Subtract(EndDate).Days <= 0)).Sum(p => p.IncurredLoss);


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
        private double CurrentPaidLoss(DateTime StartDate, DateTime EndDate,
            DateTime CommutationDate, IEnumerable<PaidSchedule> PaidLossSchedules)
        {

            if (StartDate.Subtract(CommutationDate).Days > 0)
            {
                return 0;
            }
            else if (StartDate.Subtract(CommutationDate).Days <= 0 &&
                    StartDate.AddMonths(3).AddDays(-1).Subtract(CommutationDate).Days >= 0)
            {

                return PaidLossSchedules.Sum(p => p.PaidLoss);

            }
           

            return PaidLossSchedules.AsParallel().Where(p =>
                               (p.LossPaymentDate.Subtract(StartDate).Days >= 0) &&
                               p.LossPaymentDate.Subtract(EndDate).Days <= 0).Sum(p => p.PaidLoss);

            

        }


        private double GetContribution(DateTime StartDate, IEnumerable<CapitalSchedule> CapitalSchedule)
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
        private async Task<IEnumerable<PaidSchedule>> GetPaidLossSchedule(int  SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<PaidSchedule>(_queryService.GetPaidLossQuery());
        }


        //Get all response from the loss table
        private async Task<IEnumerable<IRRLossSchedule>> GetIRRLossSchedule(double ClimateLoading = 1)
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
        private async Task<IEnumerable<PremiumSchedule>> GetPremiumSchedule(int SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<PremiumSchedule>(_queryService.GetPremiumScheduleQuery());
        }

        private async Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(
                                                                    int SPInvestor, 
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<IRRPremiumInputDTO>(_queryService.GetIRRPremiumString());
        }



        private async Task<IEnumerable<CapitalSchedule>> GetCapitalSchedule()
        {

            return await _queryService.QuerySet<CapitalSchedule>(_queryService.GetCapitalScheduleQuery());
            
        }


        private async Task<IEnumerable<BufferSchedule>> GetBufferSchedule()
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
        private static async Task<IEnumerable<double>> CumulativeTable(IEnumerable<DateTuple> timeTuple, 
            IEnumerable<double> values, DateTime CommutationDate)
        { 
            var IncurDateTuple = timeTuple.Zip(values).Select(value => new LossPremTuple(value.Item1.StartDate, value.Item2)).ToList();

            return await Task.FromResult<IEnumerable<double>>(
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

            List<Tuple<T, P>> data = [];

            foreach((T start, P end) in list1.AsParallel().Zip(list2))
            {
              data.Add(Tuple.Create(start, end));
            }

            return data;
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
        private static IEnumerable<double> CumulativeSum(IEnumerable<LossPremTuple> numbers, 
            DateTime CommutationDate) 
        {
            double sum = 0;

            List<double> cumsum = [];

            foreach (var (StartDate, LossPremValue) in numbers)
            {
                if(StartDate.AddMonths(3).AddDays(-1).Subtract(CommutationDate).Days >= 0)
                {
                    cumsum.Add(LossPremValue);

                    continue;
                }

                sum += LossPremValue;
                cumsum.Add(sum);
            }
            return cumsum;
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
