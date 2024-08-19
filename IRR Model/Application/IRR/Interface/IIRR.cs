global using DateTuple = (System.DateTime StartDate, System.DateTime EndDate);
global using LossPremTuple = (System.DateTime StartDate, decimal LossPremValue);

using CashflowModelling.Domain.IRR.DTOs;
using CashflowModelling.Application.IRR.Payload;



namespace CashflowModelling.Application.IRR.Interface
{
    

    public interface IIRR
    {
        Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(IEnumerable<int>? ids);
        Task<IEnumerable<IRRPremiumInputDTO>> ComputeIRR(IRRInputs iRRInputs);
        Task<IEnumerable<PremiumSchedule>> GetPremiumSchedule(IEnumerable<int>? RetroProfileIds,
                                                                    IEnumerable<int>? RetroProgramIds);
        Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(
                                                                    IEnumerable<int>? RetroProfileIds,
                                                                    IEnumerable<int>? RetroProgramIds);
        Task<IEnumerable<PaidSchedule>> GetPaidLossSchedule(IEnumerable<int>? RetroProfileIds,
                                                                    IEnumerable<int>? RetroProgramIds);
        Task<IEnumerable<IRRLossSchedule>> GetIRRLossSchedule(double ClimateLoading);
        Decimal GrossEarnedPremium(DateTime StartDate, 
            DateTime EndDate, DateTime CommutationDate, IEnumerable<PremiumSchedule> IRRPremiumTable);

        Decimal CurrentIncurredLoss(DateTime StartDate,
            DateTime EndDate, DateTime CommutationDate, IEnumerable<IRRLossSchedule> IRRLossSchedules);

        Task<IEnumerable<Decimal>> GrossEarnedPremiumTable(
            IEnumerable<DateTuple> DateRange,
            IEnumerable<PremiumSchedule> IRRPremiumTable, DateTime CommutationDate);

        Task<IEnumerable<Decimal>> IncurredLossTable(IEnumerable<DateTuple> DateRange,
            IEnumerable<IRRLossSchedule> IRRLossTable, DateTime CommutationDate);

    }
}
