global using DateTuple = (System.DateTime StartDate, System.DateTime EndDate);
global using LossPremTuple = (System.DateTime StartDate, decimal LossPremValue);
using IRR.Application.Payload;
using IRR.Domain.DTOs;
using Microsoft.Spark.Sql;


namespace IRR.Application.Interface
{
    
    
    public interface IIRR
    {
        Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(IEnumerable<int>? ids);
        Task<IEnumerable<PremiumSchedule>> GetPremiumSchedule(int SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds);
        Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(
                                                                    int SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds);
        Task<IEnumerable<PaidSchedule>> GetPaidLossSchedule(int SPInvestorId,
                                                                    IEnumerable<int>? RetroProgramIds);
        Task<IEnumerable<IRRLossSchedule>> GetIRRLossSchedule(double ClimateLoading);

        Task<IEnumerable<CapitalSchedule>> GetCapitalSchedule();

        Decimal GrossEarnedPremium(DateTime StartDate, 
            DateTime EndDate, DateTime CommutationDate, IEnumerable<PremiumSchedule> IRRPremiumTable);

        Task<Dictionary<int, Tuple<DataFrame, double>>> IRRCashFlow(DateTime StartDate,
            DateTime EndDate,
            DateTime CommutationDate,
            IEnumerable<int> RetroProgramIds,
            int SPInvestorId,
            double Capital,
            double AcquisitionExpenseRate

            );

        Decimal CurrentIncurredLoss(DateTime StartDate,
            DateTime EndDate, DateTime CommutationDate, IEnumerable<IRRLossSchedule> IRRLossSchedules);

        Task<IEnumerable<Decimal>> GrossEarnedPremiumTable(
            IEnumerable<DateTuple> DateRange,
            IEnumerable<PremiumSchedule> IRRPremiumTable, DateTime CommutationDate);

        Task<IEnumerable<Decimal>> IncurredLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<IRRLossSchedule> IRRLossTable, DateTime CommutationDate);
        Task<Dictionary<int, Tuple<DataFrame, double>>> GetIRRForSPInvestor(IRRInputs input);
    }
}
