using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class TargetPmldef
{
    public int TargetPmldefId { get; set; }

    public int PmlmatchingDefId { get; set; }

    public int? LossZoneId { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? Peril { get; set; }

    public int Rp { get; set; }

    public double LossAmt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual LossZone? LossZone { get; set; }

    public virtual PmlMatchingDef PmlmatchingDef { get; set; } = null!;
}
