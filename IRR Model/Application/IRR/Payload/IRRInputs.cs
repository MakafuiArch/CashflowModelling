using CashflowModelling.Domain.IRR.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CashflowModelling.Application.IRR.Payload
{
    public record IRRInputs(
        [Required]
        int Duration, 
        DateTime CommutationDate,
        DateTime QuarterStartDate,
        DateTime QuarterEndDate,
        IEnumerable<int>? RetroProgramIds,
        IEnumerable<int>? RetroProfileIds,
        IEnumerable<int>? CapitalScheduleDates,
        [Required]
        int ViewType, 
        double AcquisitionExpense
        )
    {

      

    }
}
