using IRR.Domain.DTOs;
using IRR.Application.Interface;
using Microsoft.IdentityModel.Tokens;
using LanguageExt;
using Microsoft.Extensions.Caching.Memory;
using IRR.Application.Payload.Request;
using IRR.Application.Payload.Response;



namespace IRR.Application.Service
{

    public sealed class ArchViewIRRService: IRRCalculation, IIRR
    {

        private readonly IQuery _queryService;
        

        public ArchViewIRRService(IQuery queryService, IDataTest testData, IConfiguration configuration,
            IMemoryCache memoryCache)
            : base(queryService, memoryCache, testData, configuration)
        {
           
           _queryService = queryService;

        }


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

            Task<IEnumerable<LossSchedule>> IncurredLossTable = this.GetIRRLossSchedule();

            Task<IEnumerable<CapitalSchedule>> CapitalTable = this.GetCapitalSchedule();


            await Task.WhenAll(PremiumTable, PaidLossTable, IncurredLossTable, CapitalTable);


            var BufferDate = bufferSchedules.OrderBy(p => p.BufferDate).First().BufferDate;



            var dataframeIRRResponse = await IRRCompute(PremiumTable.Result, PaidLossTable.Result,
                                        IncurredLossTable.Result, CapitalTable.Result,bufferSchedules,
                                        CommutationDate,  (double) AcquisitionExpenseRate, DateRange);

            responseDictionary.Add(SPInvestorId, dataframeIRRResponse.irr);



            return responseDictionary;
        }


        //Just is just dummy and may not be used.
        public Task<IRRResponse> TestIRR()
        {

            Type[] premiumTypes = [typeof(DateTime),
                typeof(double), typeof(double), typeof(int)];

            Type[] paidLossTypes = [ typeof(int), typeof(DateTime),
                typeof(double), typeof(double)];

            Type[] incurredLossTypes = [ typeof(int), typeof(DateTime),
                typeof(double), typeof(double)];

            Type[] capitalTypes = [typeof(int), typeof(double), typeof(DateTime)];

            Type[] bufferTypes = [typeof(int), typeof(float), typeof(DateTime)];


            var PremiumTable = GetCachedObject<IEnumerable<PremiumSchedule>>("PremiumTable", "C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/PremiumScheduleTest.csv", premiumTypes);

            var IncurredLossTable = GetCachedObject<IEnumerable<LossSchedule>>("IncurredLossTable","C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/LossScheduleTest.csv", incurredLossTypes);

            var PaidLossTable = GetCachedObject<IEnumerable<PaidSchedule>>("PaidLossTable", "C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/PaidLossTest.csv", paidLossTypes);

            var CapitalTable = GetCachedObject<IEnumerable<CapitalSchedule>>("CapitalTable","C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/CapitalScheduleTest.csv", capitalTypes);


            var BufferTable = GetCachedObject<IEnumerable<BufferSchedule>>("BufferTable","C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/BufferScheduleTest.csv", bufferTypes);


            Task.WhenAll(PremiumTable, PaidLossTable, CapitalTable, BufferTable);



            DateTime startDate = new (2024, 1, 1);

            DateTime endDate = new(2027, 3, 31);

            DateTime commutationDate = new(2027, 1, 2);


            var StartDateRange = Enumerable.Range(0, endDate.Subtract(startDate).Days).
                                   Select(days => days == 0 ? startDate.AddDays(0)
                                   : startDate.AddDays(2 * days)).ToList();


            var EndDateRange = StartDateRange.Select(date => date.AddDays(1)).ToList();


            var NDate = Enumerable.Range(0, ((int)Math.Ceiling((decimal)endDate.Subtract(startDate).Days / 365)*12)).AsParallel()
                                  .Select(day => startDate.AddMonths(day * 3)).ToList();

            var NEnd = NDate.Select(date => date.AddMonths(3).AddDays(-1)).ToList(); 

            var rangedate = ListsToTuple<DateTime, DateTime>(NDate, NEnd);


            IEnumerable<DateTuple> DateRange = rangedate.Select(p => new DateTuple(p.Item1, p.Item2));


            var NewDateRange = DateRange.Where(predicate => predicate.StartDate.Subtract(commutationDate).Days < 0).ToList();


            return IRRCompute(PremiumTable.Result, PaidLossTable.Result, IncurredLossTable.Result, CapitalTable.Result, 
                BufferTable.Result, commutationDate, 9.01930993488021/100, NewDateRange);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
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




        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public async Task<IEnumerable<LossInput>> GetLossInput(int SPInvestor, List<int>? RetroProgramIds)
        {
            return await _queryService.ApiResponseSet<List<int>, IEnumerable<LossInput>>("", RetroProgramIds!);
        }

        public async Task<PremiumServiceResponse> TestGetDepositPremiums()
        {

            var premiumrequest = new PremiumServiceRequest(89695, 4500, 0, 0);
            return await GetDepositPremium(premiumrequest);
        }
    }
}
