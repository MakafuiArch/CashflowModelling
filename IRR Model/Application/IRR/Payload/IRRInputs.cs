using CashflowModelling.Domain.IRR.Model;
using IRR_Model.Domain.IRR.DTOs;
using LanguageExt;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CashflowModelling.Application.IRR.Payload
{
    public record IRRInputs(
        int Duration,
        DateTime CommutationDate,
        DateTime QuarterStartDate,
        DateTime QuarterEndDate,
        double Capital,
        IEnumerable<int>? RetroProgramIds,
        IEnumerable<int>? SPInvestorIds,
        IEnumerable<double>? IncrementalCapitalAdded,
        IEnumerable<CapitalSchedule>? CapitalSchedules,
        int ViewType,
        double AcquisitionExpense
        )
    {

        private IEnumerable<CapitalSchedule> GetCapitalSchedule() => CapitalSchedules.IsNull() ? new List<CapitalSchedule>([new
                CapitalSchedule(1, (decimal)Capital, QuarterStartDate)]) : CapitalSchedules!;
    }
}
