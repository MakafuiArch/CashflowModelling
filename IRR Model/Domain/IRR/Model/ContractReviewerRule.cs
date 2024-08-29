using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class ContractReviewerRule
{
    public int ContractReviewerRuleId { get; set; }

    public int ReviewerId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ContractReviewerCriterion> ContractReviewerCriteria { get; set; } = new List<ContractReviewerCriterion>();

    public virtual User Reviewer { get; set; } = null!;
}
