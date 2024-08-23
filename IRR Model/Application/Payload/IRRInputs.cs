using IRR.Domain.IRR.DTOs;
using LanguageExt;


namespace IRR.Application.IRR.Payload
{
    public record IRRInputs(
        int Duration,
        DateTime CommutationDate,
        DateTime? QuarterStartDate,
        DateTime? QuarterEndDate,
        double Capital,
        IEnumerable<int>? RetroProgramIds,
        int SPInvestorId,
        IEnumerable<double>? IncrementalCapitalAdded,
        IEnumerable<CapitalSchedule>? CapitalSchedules,
        int ViewType,
        double AcquisitionExpense
        )
    {

        private IEnumerable<CapitalSchedule> GetCapitalSchedule() => CapitalSchedules.IsNull() ? new List<CapitalSchedule>([new
                CapitalSchedule(1, (decimal)Capital, (DateTime) QuarterStartDate!)]) : CapitalSchedules!;
    }
}
