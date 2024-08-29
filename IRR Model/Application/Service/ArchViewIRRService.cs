using IRR.Domain.DTOs;
using IRR.Application.Interface;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using FluentValidation;
using IRR.Application.Payload;
using Microsoft.Data.Analysis;
using LanguageExt;
using LanguageExt.ClassInstances;
using Excel.FinancialFunctions;




namespace IRR.Application.Service
{
   
    using DataFrameRow = (DateTime StartDate, DateTime EndDate,
        double GrossEarnedPremium, double IncurredLoss, double PaidLoss);

    public partial class ArchViewIRRService(IQuery queryService, IDataTest _testData) : IIRR
    {

        private readonly IQuery _queryService = queryService;
        private readonly IDataTest _testData = _testData;

 

        public async Task<Dictionary<int, double>> GetIRRForSPInvestor(IRRInputs input)
        {

            var StartDate = (DateTime) input.QuarterStartDate!;
            var EndDate = (DateTime) input.QuarterEndDate!;
            var CommutationDate = input.CommutationDate;
            var RetroProgramIds = input.RetroProgramIds;
            var SPInvestorId = input.SPInvestorId;
            var Capital = input.Capital;
            var AcquisitionExpenseRate = input.AcquisitionExpense;

            var bufferSchedule = new List<BufferSchedule>();


            return await IRRCashFlow(StartDate, EndDate, CommutationDate, RetroProgramIds!, 
                SPInvestorId, Capital, bufferSchedule, AcquisitionExpenseRate);

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
        public async Task<Dictionary<int,double>> IRRCashFlow(DateTime StartDate, 
            DateTime EndDate, 
            DateTime CommutationDate, 
            IEnumerable<int> RetroProgramIds, 
            int SPInvestorId, 
            double Capital, 
            IEnumerable<BufferSchedule> bufferSchedules,
            double AcquisitionExpenseRate
            
            )
        {

            var responseDictionary = new Dictionary<int, double>();



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



                var dataframeIRRResponse = await IRRCompute(PremiumTable.Result, PaidLossTable.Result,
                                        IncurredLossTable.Result, CapitalTable.Result,bufferSchedules,
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


            var NDate = Enumerable.Range(0, ((int)Math.Ceiling((decimal)endDate.Subtract(startDate).Days / 365)*12))
                                  .Select(day => startDate.AddMonths(day * 3)).ToList();

            var NEnd = NDate.Select(date => date.AddMonths(3).AddDays(-1)).ToList();

            var StartDateRange = Enumerable.Range(0, endDate.Subtract(startDate).Days).
                                   Select(days => days ==0 ? startDate.AddDays(0) 
                                   : startDate.AddDays(2*days)).ToList();


            var EndDateRange = StartDateRange.Select(date => date.AddDays(1)).ToList();

            var rangedate = ListsToTuple<DateTime, DateTime>(NDate, NEnd);


            IEnumerable<DateTuple> DateRange = rangedate.Select(p => new DateTuple(p.Item1, p.Item2));


            var NewDateRange = DateRange.Where(predicate => predicate.StartDate.Subtract(commutationDate).Days < 0).ToList();


            return IRRCompute(PremiumTable, PaidLossTable, IncurredLossTable, CapitalTable, 
                BufferTable, commutationDate, 9.01930993488021/100, NewDateRange);


        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="PremiumTable"></param>
        /// <param name="PaidLossTable"></param>
        /// <param name="IncurredLossTable"></param>
        /// <param name="CapitalTable"></param>
        /// <param name="BufferTab"></param>
        /// <param name="CommutationDate"></param>
        /// <param name="AcquisitonExpenseRate"></param>
        /// <param name="DateRange"></param>
        /// <returns></returns>
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
            var IncomeAccumuationRate = Math.Pow((1+0.05/4), (double) 1/ (double) 360);

            var ProfitCommission = 0.35;

            var CashFlowRange = DateRange.Select(p => p.StartDate).ToList();


            var CashFlowEndRange = DateRange.Select(p => p.EndDate).ToList();



            // Get the all the f data forms for IRR calculation
            var GrossEarnedPremiums = this.GrossEarnedPremiumTable(DateRange,
                                                        PremiumTable, CommutationDate);

            var IncurredLosses = this.IncurredLossTable(DateRange,
                                    IncurredLossTable, CommutationDate);

            var PaidLosses = this.PaidLossTable(DateRange, PaidLossTable, CommutationDate);


            var CapitalContribution = Contributions(CapitalTable, 
                        DateRange.Select(d => new Tuple<DateTime, DateTime>(d.StartDate, d.EndDate)).ToList());

            var TotalCapital = CapitalTable.Sum(p => p.IncrementalCapitalAdded);

            var Buffers = BuffersTab(BufferTab, DateRange);


            var minBuf = BufferTab.Min(b => b.BufferDate);


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


            CashFlowDataFrame["Original Acquisition Expenses"] = CashFlowDataFrame["Gross Earned Premium"].Multiply(
                                                                    AcquisitonExpenseRate);

            CashFlowDataFrame["Commission and Tail Fee"] = CashFlowDataFrame["Gross Earned Premium"].Subtract(
                CashFlowDataFrame["Original Acquisition Expenses"]).Multiply(CommissionRate);

            CashFlowDataFrame["Net Ceded Premium"] = CashFlowDataFrame["Gross Earned Premium"].Subtract(
                CashFlowDataFrame["Original Acquisition Expenses"]).Subtract(CashFlowDataFrame["Commission and Tail Fee"]);


            CashFlowDataFrame.Columns.Add(DataFrameLag("Float Change", CashFlowDataFrame["Net Ceded Premium"], (double) CashFlowDataFrame["Net Ceded Premium"][0]));


            CashFlowDataFrame.Columns.Add(DataFrameLag("Paid Loss Lag", CashFlowDataFrame["Paid Losses"], (double)CashFlowDataFrame["Paid Losses"][0]));


            CashFlowDataFrame["Float Change"] = CashFlowDataFrame["Float Change"].Subtract(CashFlowDataFrame["Paid Loss Lag"]);

            //<---------------------Calculating Float------------------------------->

            var StartingFloat = new PrimitiveDataFrameColumn<double>("Starting Float", CashFlowDataFrame.Rows.Count);

            var AverageInvestmentFloat = new PrimitiveDataFrameColumn<double>("Average Investment Float",
                CashFlowDataFrame.Rows.Count);

            var InvestmentIncome = new PrimitiveDataFrameColumn<double>("Investment Income on Float",
                CashFlowDataFrame.Rows.Count);

            var EndingFloat = new PrimitiveDataFrameColumn<double>("Ending Float",
                CashFlowDataFrame.Rows.Count);

            var PeriodDays= new List<int>();

            var YearDays = new List<int>();

            for (int i = 0; i < CashFlowDataFrame.Rows.Count; i++)
            {

                int DaysInPeriod = ((DateTime)CashFlowDataFrame["Period End Date"][i]).Subtract(((DateTime)CashFlowDataFrame["Period Start Date"][i])).Days + 1;

                DateTime startYear = new(((DateTime)CashFlowDataFrame["Period Start Date"][i]).Year, 1, 1);

                DateTime endYear = new(((DateTime)CashFlowDataFrame["Period End Date"][i]).Year, 12, 31);

                int DaysOfYear = Math.Abs(endYear.Subtract(startYear).Days) + 1;


                PeriodDays.Add(DaysInPeriod);
                YearDays.Add(DaysOfYear);

                StartingFloat[i] = i == 0 ? (double?)0 : EndingFloat[i - 1];

                AverageInvestmentFloat[i] = (double)Math.Max((double) StartingFloat[i]! + 
                                    (double) CashFlowDataFrame["Float Change"][i]*0.5 , 0);

                InvestmentIncome[i] =  AverageInvestmentFloat[i] * ((double)Math.Pow((float) 1.05, (float) DaysInPeriod / (float) DaysOfYear) - 1);

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

                                            ).Select(p => p!.Value == true ? (double) 1 : (double) 0);


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("SubjectBool", SubjectProfitBoolResult));


            CashFlowDataFrame["Subject To Profit Commission"] = CashFlowDataFrame["Subject To Profit Commission"]
                                                            .Multiply(CashFlowDataFrame["SubjectBool"])
                                                            .Add(CashFlowDataFrame["Cumulative Investment Income"]) +
                                                            ((double)CashFlowDataFrame["Net Ceded Premium"].Max()
                                            - (double)CashFlowDataFrame["Incurred Losses"].Max());


            CashFlowDataFrame["Total Earned Profits"] = CashFlowDataFrame["Subject To Profit Commission"] - HurdleAmount;


            //var LagCashFlow = CashFlowDataFrame["Capital Contribution"].RightShift(1, false);


            var EarnedProfitsBoolResult = CashFlowDataFrame["Total Earned Profits"]
                                                .ElementwiseGreaterThan(0)
                                                .Select(p => p!.Value == true ? (double) 1 : (double) 0).ToList();


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("EarnedBool", EarnedProfitsBoolResult));


            CashFlowDataFrame["Total Earned Profits"] = CashFlowDataFrame["Subject To Profit Commission"]

                                    .Subtract(

                                       CashFlowDataFrame["Total Earned Profits"]
                                        .Multiply(CashFlowDataFrame["EarnedBool"])*ProfitCommission
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
                    StartingCapital[i] = (double)CashFlowDataFrame["Capital Contribution"][i] +
                                        Math.Min((double)CashFlowDataFrame["Incremental Cashflow"][i], 0) + EndingCapital[i-1];
                }


                InvestmentIncomeOnCapital[i] = StartingCapital[i] * (Math.Pow((float) 1.05, (float)PeriodDays[i] / (float)YearDays[i]) -1);

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
                
                                       .ElementwiseLessThan(0).Select(p => p!.Value == true ? (double)1 : (double)0).ToList();


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("RequiredCapitalBool", requiredCapitalBoolResult));



            CashFlowDataFrame["Required Capital"] = (CashFlowDataFrame["Required Capital"])
                                                    .Multiply(CashFlowDataFrame["RequiredCapitalBool"]) + TotalCapital;


            CashFlowDataFrame["Capital Released"] = CashFlowDataFrame["Investors Funds"]
                            .Subtract(CashFlowDataFrame["Required Capital"]);


            var CapitalBoolResult = CashFlowDataFrame["Capital Released"]

                                       .ElementwiseGreaterThan(0).Select(p => p!.Value == true ? (double)1 : (double)0).ToList();


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("CapitalBool", CapitalBoolResult));



            //<--------------------- Calculating IRR ----------------------------------------------->

            var CapitalReleasedBool = new List<double>();


            for (int i =0; i < CashFlowDataFrame.Rows.Count; i++)
            {

                CapitalReleasedBool.Add((DateTime)CashFlowDataFrame["Period End Date"][i] > minBuf ? 1 : 0);

            }



            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("CapitalReleasedBool", CapitalReleasedBool));


            CashFlowDataFrame["Capital Released"] = CashFlowDataFrame["Capital Released"].Multiply(

                CashFlowDataFrame["CapitalBool"]).Multiply(CashFlowDataFrame["CapitalReleasedBool"]);


            CashFlowDataFrame.Columns.Add(DataFrameLag("Investor Cashflow", 
                CashFlowDataFrame["Capital Released"]).Subtract(CashFlowDataFrame["Capital Contribution"]));


           


            Microsoft.Data.Analysis.DataFrame.SaveCsv(CashFlowDataFrame, "C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/TestData.csv");


            return Financial.XIrr(GetColumnData<double>(CashFlowDataFrame["Investor Cashflow"]),
                GetColumnData<DateTime>(CashFlowDataFrame["Period Start Date"])); 
                
                
               
        }



        private static IEnumerable<T> GetColumnData<T>(DataFrameColumn dataFrameColumn)
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
            IEnumerable<Tuple<DateTime, DateTime>> CashflowRange)
        {


            var CumSum = CashflowRange.AsParallel().Select(
                cashflowdate => GetContribution(cashflowdate, CapitalSchedule)).ToList();

            var newCumList = new List<double>() {0};

            newCumList.AddRange(CumSum.GetRange(0, CumSum.Count-1));

            var diffCumList = SubtractListItems(CumSum, newCumList);

            return Task.FromResult<IEnumerable<double>>(diffCumList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BufferSchedule"></param>
        /// <param name="DateRange"></param>
        /// <returns></returns>
        private static Task<List<float>> BuffersTab(IEnumerable<BufferSchedule> BufferSchedule, 
            IEnumerable<DateTuple> DateRange)
        {

            List<float> BuffersTab = [];
            
            foreach(DateTuple dataTuple in DateRange)
            {

                var minDate = BufferSchedule.Select(m => m.BufferDate).Min(date => date);

                if (dataTuple.EndDate <= minDate)
                {
                    BuffersTab.Add(BufferSchedule.Select(m => m.BufferFactor).Max(buffer => buffer));
                }
                else
                {
                    BuffersTab.Add(BufferSchedule
                        .Where(b => (b.BufferDate.Year == dataTuple.StartDate.Year) && 
                        (b.BufferDate.Month + 3  > dataTuple.StartDate.Month) && (b.BufferDate.Month <= dataTuple.StartDate.Month))
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


        private static double GetContribution(Tuple<DateTime, DateTime>  DateRange, IEnumerable<CapitalSchedule> CapitalSchedule)
        {
            var yearcapital = CapitalSchedule.AsParallel()
                .Where(c => c.Date >= DateRange.Item1 && c.Date < DateRange.Item2).ToList();

            var oldcaprital = CapitalSchedule.AsParallel().Where(c => c.Date < DateRange.Item1).ToList();


            return yearcapital.Union(oldcaprital).Sum(c => c.IncrementalCapitalAdded);
              
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
        private static List<Tuple<T, P>> ListsToTuple<T, P>(IEnumerable<T> list1, 
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
        private static List<double> CumulativeSum(IEnumerable<LossPremTuple> numbers, 
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
