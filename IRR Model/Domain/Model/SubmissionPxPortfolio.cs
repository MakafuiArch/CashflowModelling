using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class SubmissionPxPortfolio
{
    public int SubmissionPxPortfolioId { get; set; }

    public int SubmissionId { get; set; }

    public int PortfolioId { get; set; }

    public DateTime? RunDate { get; set; }

    public string? JobId { get; set; }

    public int JobStatus { get; set; }

    public string? JobMessage { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<DeltaPxResult> DeltaPxResults { get; set; } = new List<DeltaPxResult>();

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual ICollection<SubDeltaPxResult> SubDeltaPxResults { get; set; } = new List<SubDeltaPxResult>();

    public virtual Submission Submission { get; set; } = null!;
}
