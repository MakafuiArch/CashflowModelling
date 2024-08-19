using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class ContractReviewerCriterion
{
    public int ContractReviewerCriteriaId { get; set; }

    public int ContractReviewerRuleId { get; set; }

    public int FilterCriteriaPropertyType { get; set; }

    public string? FilterCriteriaValue { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? OperationType { get; set; }

    public virtual ContractReviewerRule ContractReviewerRule { get; set; } = null!;
}
