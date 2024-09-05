using IRR.Domain.DTOs;
using Microsoft.Data.Analysis;
using System.Numerics;
using Excel.FinancialFunctions;
using Microsoft.Extensions.Caching.Memory;
using IRR.Application.Interface;
using IRR.Application.Exceptions;
using IRR.Application.Payload.Response;
using LanguageExt;
using Joker.Extensions;
using IRR.Application.Payload.Request;


namespace IRR.Application.Service
{
    public abstract class IRRCalculation(IQuery queryService, IMemoryCache memoryCache, 
        IDataTest testData, IConfiguration configuration)
    {

        private readonly IMemoryCache _memoryCache =memoryCache;
        private readonly IDataTest _testData=testData;
        private readonly IQuery _queryService= queryService;
        private readonly IConfiguration _configuration=configuration;



        protected IEnumerable<PremiumSchedule> GetPremiumSchedule(IEnumerable<LossInput> LossInputs,
            IEnumerable<PremiumInput> PremiumInputs,
            int PremiumView=0, int PremiumFrequency = 0)
        {

            List<PremiumServiceResponse> premiumServiceResponses = [];
            List<PremiumSchedule> premiumSchedules = [];

            var OccurrenceYear = LossInputs.Map(loss => loss.LayerInception.Year).OrderBy(y => y).ToList();

            var UniqueLayerIds = LossInputs.AsParallel().Select(p => (p.LayerId, PremiumInputs.AsParallel().Find(r =>
                                (r.LayerInception == p.LayerInception) & (r.LayerId == p.LayerId))
                                .First().TotalSubjectPremium)).Distinct();

            UniqueLayerIds.AsParallel().ForEach(async p =>
            {

                var premiumrequest = new PremiumServiceRequest(p.LayerId, p.TotalSubjectPremium, PremiumView, PremiumFrequency);

                var premiumresponse = await GetDepositPremium(premiumrequest);

                lock (premiumServiceResponses)
                {

                    premiumServiceResponses.Add(premiumresponse);

                }

            });

            LossInputs.AsParallel().ForEach((loss) => {

                var UnadjustedPremium = loss.ReinstPremium + (double) premiumServiceResponses.AsParallel().Map(p =>
                                            p.PremiumValues.AsParallel().Find(k => (k.LayerId == loss.LayerId) 
                                            & (k.Date == loss.OccurrenceDay)).Select(k => k.Value)).FirstOrDefault();


                var premiumschedule = new PremiumSchedule
                {
                    Year = OccurrenceYear.IndexOf(loss.LayerInception.Year) + 1,
                    LayerId = loss.LayerId,
                    UnadjustedPremium = UnadjustedPremium,
                    EarnedDay = loss.OccurrenceDay
                };

                premiumSchedules.Add(premiumschedule);
            
            });



            return premiumSchedules;

        }
        



        protected async Task<PremiumServiceResponse> GetDepositPremium(PremiumServiceRequest request)
        {
            return await _queryService.ApiResponseSet<PremiumServiceRequest, 
                PremiumServiceResponse>(_configuration.GetValue<string>("ConnectionString:PremiumService")!, request);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="SPInvestorId"></param>
        /// <param name="RetroProgramIds"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<PaidSchedule>> GetPaidLossSchedule(int SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<PaidSchedule>(_queryService.GetPaidLossQuery());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClimateLoading"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<IRRLossSchedule>> GetIRRLossSchedule(double ClimateLoading = 1)
        {

            return await _queryService.QuerySet<IRRLossSchedule>(
                _queryService.GetIRRLossScheduleQuery(ClimateLoading));

        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SPInvestorId"></param>
        /// <param name="RetroProgramIds"></param>
        /// <returns></returns>
        //Get Premium Schedule
        protected async Task<IEnumerable<PremiumSchedule>> GetPremiumSchedule(int SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds)
        {
            return await _queryService.QuerySet<PremiumSchedule>(_queryService.GetPremiumScheduleQuery());
        }

        protected async Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(
                                                                    int SPInvestor,
                                                                    IEnumerable<int>? RetroProgramIds)
        {

            return await _queryService.QuerySet<IRRPremiumInputDTO>(_queryService.GetIRRPremiumString());
        }



        protected  async Task<IEnumerable<CapitalSchedule>> GetCapitalSchedule()
        {
            //var capitalschedule = _queryService.ApiResponseSet<CapitalSchedule>()

            return await _queryService.QuerySet<CapitalSchedule>(_queryService.GetCapitalScheduleQuery());

        }


        protected async Task<IEnumerable<BufferSchedule>> GetBufferSchedule()
        {
            return await _queryService.QuerySet<BufferSchedule>(_queryService.GetBufferQuery());

        }


        protected async Task<IRRResponse> IRRCompute(IEnumerable<PremiumSchedule> PremiumTable,
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

            var BufferStartDate = BufferTab.OrderBy(p => p.BufferDate).First().BufferDate;



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



            var CashFlowDates = new DateTimeDataFrameColumn("CashFlow Dates", CashFlowDataFrame.Rows.Count);


            for (int i = 0; i < CashFlowDataFrame.Rows.Count; i++)
            {
                if ((DateTime)CashFlowDataFrame["Period End Date"][i] < BufferStartDate)
                {
                    CashFlowDates[i] = (DateTime)CashFlowDataFrame["Period Start Date"][i];
                }
                else
                {
                    CashFlowDates[i] = (DateTime)CashFlowDataFrame["Period End Date"][i];
                }
            }

            CashFlowDataFrame.Columns.Add(CashFlowDates);


            CashFlowDataFrame["CashFlow Dates"][1] = new DateTime(2024, 6, 1);

            var BasePath = "C:/Users/maheto/OneDrive - Arch Capital Group/Desktop/Work Files/Cashflow Modelling/";

            var filePath = BasePath + "TestData.csv";

            var newFilePath = filePath;

            int counter = 1;


            while (File.Exists(newFilePath))
            {

                newFilePath = BasePath + Path.GetFileNameWithoutExtension(filePath) + $"({counter})".ToString() + 
                    Path.GetExtension(filePath);

                counter++;

            }

 
            Microsoft.Data.Analysis.DataFrame.SaveCsv(CashFlowDataFrame, newFilePath);

            List<CashFlow> cashflows = [];

            var investorCashflow = GetColumnData<double>(CashFlowDataFrame["Investor Cashflow"]).ToList();

            var cashflowDates = GetColumnData<DateTime>(CashFlowDataFrame["CashFlow Dates"]).ToList();

            

            for (int iterator = 0; iterator < CashFlowDataFrame.Rows.Count; iterator++)
            {
                cashflows.Add(new CashFlow(cashflowDates.ElementAt(iterator), investorCashflow.ElementAt(iterator)));
            }


            var response = new IRRResponse(Financial.XIrr(investorCashflow, cashflowDates),
               (double) CashFlowDataFrame["Investment Income on Float"].Sum(),
               (double) CashFlowDataFrame["Investment Income On Capital"].Sum(),
                cashflows);


            return response;



        }



        protected virtual IEnumerable<double> RollForward( IEnumerable<RollForwardInput> RollForwardInputs, 
             IEnumerable<PremiumSchedule> PremiumTable, 
             IEnumerable<IRRLossSchedule> IncurredLossTable,  IEnumerable<PaidSchedule>PaidLossTable,
            double TotalCapital,
            double InvestmentIncomeOnFloat,
            double CommissionRatio, 
            double AcquisitionExpenseRate, 
            double BufferFactor
            )
        {


            

            List<double> CumulativeExpectedEarnedProfits = [];

            double CumSum = 0;

            Parallel.ForEach(RollForwardInputs, async (rollforwardInput) =>
            {
                Task<double> EarnedPremium = Task.Run(()=>PremiumTable.AsParallel()
                                    .Where(c => c.EarnedDay <= rollforwardInput.RollForwardDate).Sum(c => c.UnadjustedPremium));

                Task<double> IncurredLosses = Task.Run(() => IncurredLossTable.AsParallel()
                                     .Where(i => i.LossOccurenceDay <= rollforwardInput.RollForwardDate).Sum(i => i.UnadjustedIncurredLoss));

                Task<double> PaidLosses = Task.Run(() => PaidLossTable.AsParallel()
                                            .Where(i => i.LossPaymentDate <= rollforwardInput.RollForwardDate).Sum(i =>i.UnadjustedPaid));


                await Task.WhenAll(EarnedPremium, IncurredLosses, PaidLosses);


                var AcquisitionCost = AcquisitionExpenseRate * EarnedPremium.Result;

                var CommissionCost = (EarnedPremium.Result - AcquisitionExpenseRate) * CommissionRatio;


                var ExpectedProfitCommission = Math.Max(EarnedPremium.Result - AcquisitionCost
                                                - CommissionCost - IncurredLosses.Result + InvestmentIncomeOnFloat, 0);


                var ExpectedEarned = EarnedPremium.Result - AcquisitionCost - CommissionCost + InvestmentIncomeOnFloat
                                    - ExpectedProfitCommission - IncurredLosses.Result - PaidLosses.Result - 
                                    (IncurredLosses.Result - PaidLosses.Result)*BufferFactor; 


                lock(CumulativeExpectedEarnedProfits) 
                {
                    CumSum += ExpectedEarned;
                    CumulativeExpectedEarnedProfits.Add(ExpectedEarned/CumSum);
                }
                

            });

           
            Parallel.For(1, CumulativeExpectedEarnedProfits.Count, async (iterator) =>
            {

                var RollForward = RollForwardInputs.ElementAt(iterator).ApplyRollForward ? CumulativeExpectedEarnedProfits[iterator - 1] : 1;

                Task EarnedPremTable = Task.Run(() => PremiumTable.AsParallel().ForEach(p =>
                {
                    if (p.Year - 1 != iterator)
                    {
                        return;
                    }
                    p.EarnedPremium = p.UnadjustedPremium * RollForward;
                }));

                Task IncurredTable = Task.Run(() => IncurredLossTable.AsParallel().ForEach(i =>
                {
                    if (i.Year - 1 != iterator)
                    {
                        return;
                    }
                    i.IncurredLoss = i.UnadjustedIncurredLoss * RollForward;
                }));

                await Task.WhenAll(IncurredTable, EarnedPremTable);

            });


            PremiumTable.AsParallel().ForEach(p =>
            {
                if (p.EarnedPremium == 0)
                {
                    p.EarnedPremium = p.UnadjustedPremium;
                }
            });

            IncurredLossTable.ForEach(i => { 
            
                if(i.IncurredLoss == 0)
                {
                    i.IncurredLoss = i.UnadjustedIncurredLoss;
                }
                
            });

            return CumulativeExpectedEarnedProfits;

        }



        protected virtual IEnumerable<T> GetColumnData<T>(DataFrameColumn column)
        {
            

            for (int i = 0; i < column.Length; i++)
            {

                yield return (T)column[i];

            }

        }



        protected virtual DataFrameColumn DataFrameLag(string ColumnName, DataFrameColumn dataframeColumn, double DefaultFirst = 0)
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


        protected virtual async Task<IEnumerable<double>> GrossEarnedPremiumTable(
            IEnumerable<DateTuple> DateRange,
            IEnumerable<PremiumSchedule> IRRPremiumTable, DateTime CommutationDate)
        {
            var GrossEarnedPremium = DateRange.AsParallel().Select(datetuple => this.GrossEarnedPremium(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, IRRPremiumTable)).ToList();

            return await CumulativeTable(DateRange, GrossEarnedPremium, CommutationDate);
        }

      
        protected virtual async Task<IEnumerable<double>> IncurredLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<IRRLossSchedule> IRRLossTable, DateTime CommutationDate)
        {
            var CurrentIncurredLoss = DateRange.AsParallel().Select(datetuple => this.CurrentIncurredLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, IRRLossTable)).ToList();

            return await CumulativeTable(DateRange, CurrentIncurredLoss, CommutationDate);
        }



        protected virtual async Task<IEnumerable<double>> PaidLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<PaidSchedule> PaidLosses, DateTime CommutationDate)
        {
            var CurrentPaidLoss = DateRange.AsParallel().Select(datetuple => this.CurrentPaidLoss(datetuple.StartDate,
                            datetuple.EndDate, CommutationDate, PaidLosses)).ToList();

            return await CumulativeTable(DateRange, CurrentPaidLoss, CommutationDate);
        }


        protected virtual async Task<IEnumerable<double>> Contributions(IEnumerable<CapitalSchedule> CapitalSchedule,
            IEnumerable<Tuple<DateTime, DateTime>> CashflowRange)
        {


            var CumSum = CashflowRange.AsParallel().Select(
                cashflowdate => GetContribution(cashflowdate, CapitalSchedule)).ToList();

            var newCumList = new List<double>() { 0 };

            newCumList.AddRange(CumSum.GetRange(0, CumSum.Count - 1));

            var diffCumList = SubtractListItems(CumSum, newCumList);

            return await Task.FromResult<IEnumerable<double>>(diffCumList);
        }

      

        protected virtual async Task<List<float>> BuffersTab(IEnumerable<BufferSchedule> BufferSchedule,
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


     
        protected virtual double GrossEarnedPremium(DateTime StartDate,
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



        protected virtual double CurrentIncurredLoss(DateTime StartDate, DateTime EndDate,
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



        protected virtual double CurrentPaidLoss(DateTime StartDate, DateTime EndDate,
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


        protected virtual double GetContribution(Tuple<DateTime, DateTime> DateRange, IEnumerable<CapitalSchedule> CapitalSchedule)
        {
            var yearcapital = CapitalSchedule.AsParallel()
                .Where(c => c.Date >= DateRange.Item1 && c.Date < DateRange.Item2).ToList();

            var oldcaprital = CapitalSchedule.AsParallel().Where(c => c.Date < DateRange.Item1).ToList();


            return yearcapital.Union(oldcaprital).Sum(c => c.IncrementalCapitalAdded);

        }

        
        protected virtual async Task<IEnumerable<double>> CumulativeTable(IEnumerable<DateTuple> timeTuple,
            IEnumerable<double> values, DateTime CommutationDate)
        {
            var IncurDateTuple = timeTuple.Zip(values).Select(value => new LossPremTuple(value.Item1.StartDate, value.Item2)).ToList();

            return await Task.FromResult<IEnumerable<double>>(
                                    CumulativeSum(IncurDateTuple, CommutationDate));

        }




      

        protected virtual List<Tuple<T, P>> ListsToTuple<T, P>(IEnumerable<T> list1,
            IEnumerable<P> list2)
        {

            List<Tuple<T, P>> data = [];

            foreach ((T start, P end) in list1.AsParallel().Zip(list2))
            {
                data.Add(Tuple.Create(start, end));
            }

            return data;
        }



        protected virtual IEnumerable<T> CumulativeSum<T>(IEnumerable<T> numbers) where T : INumber<T>
        {
            T sum = T.Zero;

            foreach (var number in numbers)
            {
                sum += number;
                yield return sum;
            }

        }




        protected virtual List<double> CumulativeSum(IEnumerable<LossPremTuple> numbers,
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



        protected virtual IEnumerable<T> AddListItems<T>(IEnumerable<T> list1, IEnumerable<T> list2)
            where T : INumber<T>
        {

            if(list1.Count() != list2.Count())
            {
                throw new LengthEqualityException("Ensure lengths of lists are equal");
            }

            foreach (var (number1, number2) in ListsToTuple<T, T>(list1, list2))
            {
                yield return number1 + number2;
            }
        }


        protected virtual IEnumerable<T> SubtractListItems<T>(IEnumerable<T> list1,
            IEnumerable<T> list2, bool reverse = false)
            where T : INumber<T>
        {
            foreach (var (number1, number2) in ListsToTuple<T, T>(list1, list2))
            {
                yield return !reverse ? number1 - number2 : number2 - number1;
            }
        }





        protected Task<TResult> GetCachedObject<TResult>(string cacheKey, 
            string filePath, Type[] types)
        {
#pragma warning disable CS8600 
            if (!_memoryCache.TryGetValue(cacheKey, value: out TResult result))
            {
                 result = (TResult) _testData.ReadFileToObject<TResult>(filePath, types) ;

                _memoryCache.Set(cacheKey, result, TimeSpan.FromMinutes(10)) ;
            }
#pragma warning restore CS8600 

            return Task.FromResult(result!);
        }

    }
}
