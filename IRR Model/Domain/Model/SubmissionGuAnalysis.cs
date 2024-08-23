using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class SubmissionGuAnalysis
{
    public int SubmissionGuAnalysisId { get; set; }

    public int GuAnalysisId { get; set; }

    public int SubmissionId { get; set; }

    public decimal Fxrate { get; set; }

    public DateTime Fxdate { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual GuAnalysis GuAnalysis { get; set; } = null!;

    public virtual Submission Submission { get; set; } = null!;
}
