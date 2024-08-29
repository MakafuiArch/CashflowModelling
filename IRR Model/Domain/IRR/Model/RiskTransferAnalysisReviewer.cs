using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RiskTransferAnalysisReviewer
{
    public int RiskTransferAnalysisReviewerId { get; set; }

    public int RiskTransferAnalysisId { get; set; }

    public int UserId { get; set; }

    public int Status { get; set; }

    public string? Comments { get; set; }

    public DateTime? ReviewDate { get; set; }

    public int ReviewerType { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RiskTransferAnalysis RiskTransferAnalysis { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
