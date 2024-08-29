using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class VwContractReviewerPending
{
    public string ReviewerFirstName { get; set; } = null!;

    public string ReviewerLastName { get; set; } = null!;

    public string ContractBinderStatus { get; set; } = null!;

    public int ContractBinderId { get; set; }

    public string? SubmissionName { get; set; }

    public DateTime InceptionDefault { get; set; }

    public string? UnderwriterName { get; set; }

    public int UwyearDefault { get; set; }
}
