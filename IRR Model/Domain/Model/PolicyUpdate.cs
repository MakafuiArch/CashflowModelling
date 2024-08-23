using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class PolicyUpdate
{
    public int PolicyUpdateId { get; set; }

    public int PolicyTrackerId { get; set; }

    public int LayerId { get; set; }

    public int SubmissionId { get; set; }

    public string? Comments { get; set; }

    public int Status { get; set; }

    public string? ChangeUser { get; set; }

    public DateTime ChangeDate { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Layer Layer { get; set; } = null!;

    public virtual PolicyTracker PolicyTracker { get; set; } = null!;

    public virtual ICollection<PolicyUpdateDetail> PolicyUpdateDetails { get; set; } = new List<PolicyUpdateDetail>();

    public virtual Submission Submission { get; set; } = null!;
}
