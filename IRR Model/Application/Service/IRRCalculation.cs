using IRR.Application.Payload;
using IRR.Domain.DTOs;
using Microsoft.Data.Analysis;
using System.Numerics;
using Excel.FinancialFunctions;
using Microsoft.Extensions.Caching.Memory;
using IRR.Application.Interface;


namespace IRR.Application.Service
{
    public abstract class IRRCalculation(IMemoryCache memoryCache, IDataTest testData)
    {

        private readonly IMemoryCache _memoryCache =memoryCache;
        private readonly IDataTest _testData=testData;

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
        public async Task<IRRResponse> IRRCompute(IEnumerable<PremiumSchedule> PremiumTable,
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



            var GrossEarnedPremium = new DoubleDataFrameColumn("Gross Earned Premium", GrossEarnedPremiums.Result);
            var IncurLosses = new DoubleDataFrameColumn("Incurred Losses", IncurredLosses.Result);
            var PaidLoss = new DoubleDataFrameColumn("Paid Losses", PaidLosses.Result);
            var CapitalTab = new DoubleDataFrameColumn("Capital Contribution", CapitalContribution.Result);
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


            CashFlowDataFrame.Columns.Add(DataFrameLag("Float Change", CashFlowDataFrame["Net Ceded Premium"], (double)CashFlowDataFrame["Net Ceded Premium"][0]));


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

            var PeriodDays = new List<int>();

            var YearDays = new List<int>();

            for (int i = 0; i < CashFlowDataFrame.Rows.Count; i++)
            {

                int DaysInPeriod = ((DateTime)CashFlowDataFrame["Period End Date"][i])
                                    .Subtract(((DateTime)CashFlowDataFrame["Period Start Date"][i])).Days + 1;

                DateTime startYear = new(((DateTime)CashFlowDataFrame["Period Start Date"][i]).Year, 1, 1);

                DateTime endYear = new(((DateTime)CashFlowDataFrame["Period End Date"][i]).Year, 12, 31);

                int DaysOfYear = Math.Abs(endYear.Subtract(startYear).Days) + 1;


                PeriodDays.Add(DaysInPeriod);
                YearDays.Add(DaysOfYear);

                StartingFloat[i] = i == 0 ? (double?)0 : EndingFloat[i - 1];

                AverageInvestmentFloat[i] = (double)Math.Max((double)StartingFloat[i]! +
                                    (double)CashFlowDataFrame["Float Change"][i] * 0.5, 0);

                InvestmentIncome[i] = AverageInvestmentFloat[i] * ((double)Math.Pow((float)(1 +
                    0.2 * (float)DaysInPeriod / (float)DaysOfYear), (float)DaysInPeriod / (float)DaysOfYear) - 1);

                EndingFloat[i] = StartingFloat[i] + (double)CashFlowDataFrame["Float Change"][i] + InvestmentIncome[i];

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

                                            ).Select(p => p!.Value == true ? (double)1 : (double)0);


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
                                                .Select(p => p!.Value == true ? (double)1 : (double)0).ToList();


            CashFlowDataFrame.Columns.Add(new DoubleDataFrameColumn("EarnedBool", EarnedProfitsBoolResult));


            CashFlowDataFrame["Total Earned Profits"] = CashFlowDataFrame["Subject To Profit Commission"]

                                    .Subtract(

                                       CashFlowDataFrame["Total Earned Profits"]
                                        .Multiply(CashFlowDataFrame["EarnedBool"]) * ProfitCommission
                                    );


            CashFlowDataFrame["Profit Commission"] = CashFlowDataFrame["Subject To Profit Commission"]
                                                .Subtract(CashFlowDataFrame["Total Earned Profits"]);


            CashFlowDataFrame["Cumulative Cashflow"] = CashFlowDataFrame["Net Ceded Premium"]
                                                .Subtract(CashFlowDataFrame["Paid Losses"]).Add(CashFlowDataFrame["Cumulative Investment Income"]);

            CashFlowDataFrame.Columns.Add(DataFrameLag("Incremental Cashflow", CashFlowDataFrame["Total Earned Profits"],

                                    (double)CashFlowDataFrame["Total Earned Profits"][0]));

            //<-----------------------Capital Calculation----------------------------------->

            var StartingCapital = new PrimitiveDataFrameColumn<double>("Starting Capital", CashFlowDataFrame.Rows.Count);

            var InvestmentIncomeOnCapital = new PrimitiveDataFrameColumn<double>("Investment Income On Capital",
                CashFlowDataFrame.Rows.Count);

            var EndingCapital = new PrimitiveDataFrameColumn<double>("Ending Capital",
                CashFlowDataFrame.Rows.Count);

            for (int i = 0; i < CashFlowDataFrame.Rows.Count; i++)
            {

                if (i == 0)
                {

                    StartingCapital[i] = (double)CashFlowDataFrame["Capital Contribution"][0] +
                                        Math.Min((double)CashFlowDataFrame["Incremental Cashflow"][0], 0);
                }
                else
                {
                    StartingCapital[i] = (double)CashFlowDataFrame["Capital Contribution"][i] +
                                        Math.Min((double)CashFlowDataFrame["Incremental Cashflow"][i], 0) + EndingCapital[i - 1];
                }


                InvestmentIncomeOnCapital[i] = StartingCapital[i] * (Math.Pow((float)1 +
                    0.2 * (float)PeriodDays[i] / (float)YearDays[i], (float)PeriodDays[i] / (float)YearDays[i]) - 1);

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


            CashFlowDataFrame["Unpaid Losses"] = (double)CashFlowDataFrame["Paid Losses"].Max() - CashFlowDataFrame["Paid Losses"];


            CashFlowDataFrame["Buffered Reserves"] = CashFlowDataFrame["Buffer Factor"].Multiply(CashFlowDataFrame["Unpaid Losses"]);


            CashFlowDataFrame["Required Capital"] = (CashFlowDataFrame["Buffered Reserves"] - TotalCapital);


            var requiredCapitalBoolResult = CashFlowDataFrame["Required Capital"]

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


            for (int i = 0; i < CashFlowDataFrame.Rows.Count; i++)
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


            List<CashFlow> cashflows = [];

            var investorCashflow = GetColumnData<double>(CashFlowDataFrame["Investor Cashflow"]);

            var cashflowDates = GetColumnData<DateTime>(CashFlowDataFrame["Period Start Date"]);

            for (int iterator = 0; iterator < CashFlowDataFrame.Rows.Count; iterator++)
            {
                cashflows.Add(new CashFlow(cashflowDates.ElementAt(iterator), investorCashflow.ElementAt(iterator)));
            }


            var response = new IRRResponse(Financial.XIrr(investorCashflow, cashflowDates), cashflows);


            return response;



        }



        public virtual void RollForward(IEnumerable<DateTime> rollFowardDates)
        {



        }




        public virtual IEnumerable<T> GetColumnData<T>(DataFrameColumn dataFrameColumn)
        {
            for (int i = 0; i < dataFrameColumn.Length; i++)
            {

                yield return (T)dataFrameColumn[i];

            }


        }



        public virtual DataFrameColumn DataFrameLag(string ColumnName, DataFrameColumn dataframeColumn, double DefaultFirst = 0)
        {
            var lagList = new PrimitiveDataFrameColumn<double>(ColumnName, dataframeColumn.Length);

            for (int index = 0; index < dataframeColumn.Length; index++)
            {

                if (index == 0)
                {


                    lagList[index] = DefaultFirst;
                    continue;

                }


                lagList[index] = (double)dataframeColumn[index] - (double)dataframeColumn[index - 1];
            }

            return lagList;

        }


        public virtual async Task<IEnumerable<double>> GrossEarnedPremiumTable(
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
        public virtual async Task<IEnumerable<double>> IncurredLossTable(IEnumerable<DateTuple> DateRange,
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
        public virtual async Task<IEnumerable<double>> PaidLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<PaidSchedule> PaidLosses, DateTime CommutationDate)
        {
            var CurrentPaidLoss = DateRange.AsParallel().Select(datetuple => this.CurrentPaidLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, PaidLosses)).ToList();

            return await CumulativeTable(DateRange, CurrentPaidLoss, CommutationDate);
        }


        public virtual async Task<IEnumerable<double>> Contributions(IEnumerable<CapitalSchedule> CapitalSchedule,
            IEnumerable<Tuple<DateTime, DateTime>> CashflowRange)
        {


            var CumSum = CashflowRange.AsParallel().Select(
                cashflowdate => GetContribution(cashflowdate, CapitalSchedule)).ToList();

            var newCumList = new List<double>() { 0 };

            newCumList.AddRange(CumSum.GetRange(0, CumSum.Count - 1));

            var diffCumList = SubtractListItems(CumSum, newCumList);

            return await Task.FromResult<IEnumerable<double>>(diffCumList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BufferSchedule"></param>
        /// <param name="DateRange"></param>
        /// <returns></returns>
        public virtual async Task<List<float>> BuffersTab(IEnumerable<BufferSchedule> BufferSchedule,
            IEnumerable<DateTuple> DateRange)
        {

            List<float> BuffersTab = [];

            foreach (DateTuple dataTuple in DateRange)
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
                        (b.BufferDate.Month + 3 > dataTuple.StartDate.Month) && (b.BufferDate.Month <= dataTuple.StartDate.Month))
                        .Select(m => m.BufferFactor).FirstOrDefault());
                }


            }

            return await Task.FromResult(BuffersTab);

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
        public virtual double GrossEarnedPremium(DateTime StartDate,
            DateTime EndDate,
            DateTime CommutationDate, IEnumerable<PremiumSchedule> IRRPremiumTable)
        {
            if (StartDate.Subtract(CommutationDate).Days > 0)
            {
                return 0;
            }
            else if (StartDate.Subtract(CommutationDate).Days <= 0 &&
                    StartDate.AddMonths(3).AddDays(-1).Subtract(CommutationDate).Days >= 0)
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
        public virtual double CurrentIncurredLoss(DateTime StartDate, DateTime EndDate,
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
        public virtual double CurrentPaidLoss(DateTime StartDate, DateTime EndDate,
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


        public virtual double GetContribution(Tuple<DateTime, DateTime> DateRange, IEnumerable<CapitalSchedule> CapitalSchedule)
        {
            var yearcapital = CapitalSchedule.AsParallel()
                .Where(c => c.Date >= DateRange.Item1 && c.Date < DateRange.Item2).ToList();

            var oldcaprital = CapitalSchedule.AsParallel().Where(c => c.Date < DateRange.Item1).ToList();


            return yearcapital.Union(oldcaprital).Sum(c => c.IncrementalCapitalAdded);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeTuple"></param>
        /// <param name="values"></param>
        /// <param name="CommutationDate"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<double>> CumulativeTable(IEnumerable<DateTuple> timeTuple,
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
        public virtual List<Tuple<T, P>> ListsToTuple<T, P>(IEnumerable<T> list1,
            IEnumerable<P> list2)
        {

            List<Tuple<T, P>> data = [];

            foreach ((T start, P end) in list1.AsParallel().Zip(list2))
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
        public virtual IEnumerable<T> CumulativeSum<T>(IEnumerable<T> numbers) where T : INumber<T>
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
        public virtual List<double> CumulativeSum(IEnumerable<LossPremTuple> numbers,
            DateTime CommutationDate)
        {
            double sum = 0;

            List<double> cumsum = [];

            foreach (var (StartDate, LossPremValue) in numbers)
            {
                if (StartDate.AddMonths(3).AddDays(-1).Subtract(CommutationDate).Days >= 0)
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
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> AddListItems<T>(IEnumerable<T> list1, IEnumerable<T> list2)
            where T : INumber<T>
        {
            foreach (var (number1, number2) in ListsToTuple<T, T>(list1, list2))
            {
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
        public virtual IEnumerable<T> SubtractListItems<T>(IEnumerable<T> list1,
            IEnumerable<T> list2, bool reverse = false)
            where T : INumber<T>
        {
            foreach (var (number1, number2) in ListsToTuple<T, T>(list1, list2))
            {
                yield return !reverse ? number1 - number2 : number2 - number1;
            }
        }





        public Task<TResult> GetCachedObject<TResult>(string cacheKey, 
            string filePath, Type[] types)
        {
            if (!_memoryCache.TryGetValue(cacheKey, value: out TResult result))
            {
                 result = (TResult) _testData.ReadFileToObject<TResult>(filePath, types) ;

                _memoryCache.Set(cacheKey, result, TimeSpan.FromMinutes(10)) ;
            }

            return Task.FromResult(result!);
        }

    }
}
