using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RiskTransferAnalysis
{
    public int RiskTransferAnalysisId { get; set; }

    public int SubmissionId { get; set; }

    public string? Layers { get; set; }

    public string? TreatyNbr { get; set; }

    public int Uwyear { get; set; }

    public bool IsSlidingScale { get; set; }

    public bool IsProfitComm { get; set; }

    public bool IsLossCorridor { get; set; }

    public bool IsAggLimitLess { get; set; }

    public bool IsExperienceAccount { get; set; }

    public bool IsFundsHeld { get; set; }

    public bool IsRated { get; set; }

    public bool IsRetroactiveContract { get; set; }

    public bool IsDerivativeAccounting { get; set; }

    public bool IsOptionsContract { get; set; }

    public bool IsFundBalance { get; set; }

    public bool IsPaymentTiming { get; set; }

    public bool HasSideAgreements { get; set; }

    public bool IsOthers { get; set; }

    public string? OtherDesc { get; set; }

    public bool IsCatException { get; set; }

    public decimal? LossProbability { get; set; }

    public decimal? LossPercentage { get; set; }

    public bool RiskTransferDiscussion { get; set; }

    public string? Comments { get; set; }

    public int Status { get; set; }

    public string? RiskTransferAnalysisNotes { get; set; }

    public string? CancelReason { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsNoClaimBonus { get; set; }

    public bool IsMaintenanceFees { get; set; }

    public virtual ICollection<RiskTransferAnalysisReviewer> RiskTransferAnalysisReviewers { get; set; } = new List<RiskTransferAnalysisReviewer>();

    public virtual Submission Submission { get; set; } = null!;
}
