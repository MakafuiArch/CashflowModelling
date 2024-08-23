using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PolicyTracker
{
    public int PolicyTrackerId { get; set; }

    public string? RegisMkey { get; set; }

    public string? RegisContractId { get; set; }

    public int LayerId { get; set; }

    public string? RegisNbr { get; set; }

    public string? RegisPgmNbr { get; set; }

    public string? Comments { get; set; }

    public DateTime RowEffectiveDate { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Layer Layer { get; set; } = null!;

    public virtual ICollection<PolicyTrackerDetail> PolicyTrackerDetails { get; set; } = new List<PolicyTrackerDetail>();

    public virtual ICollection<PolicyUpdate> PolicyUpdates { get; set; } = new List<PolicyUpdate>();
}
