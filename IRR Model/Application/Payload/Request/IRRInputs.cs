using IRR.Domain.DTOs;
using LanguageExt;


namespace IRR.Application.Payload.Request
{
    public record IRRInputs(
        int Duration,
        DateTime CommutationDate,
        DateTime? QuarterStartDate,
        DateTime? QuarterEndDate,
        int RetroProgramId,
        int SPInvestorId,
        IEnumerable<CapitalSchedule>? CapitalSchedules,
        IEnumerable<BufferSchedule>? BufferSchedules,
        IEnumerable<RollForwardInput>? RollForwardInputs,
        int ViewType,
        double InvestmentIncomeOnFloat,
        double CommissionRatio,
        double AcquisitionExpense, 
        double AssumedBufferFactor
        )
    {

        //private IEnumerable<CapitalSchedule> GetCapitalSchedule() => CapitalSchedules.IsNull() ? new List<CapitalSchedule>([new
        //        CapitalSchedule(1, Capital, (DateTime) QuarterStartDate!)]) : CapitalSchedules!;
    }
}
