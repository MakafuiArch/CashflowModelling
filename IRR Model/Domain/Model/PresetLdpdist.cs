using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class PresetLdpdist
{
    public int PresetLdpdistId { get; set; }

    public int PresetLdpid { get; set; }

    public int Month { get; set; }

    public decimal PaidLossPct { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PresetLdp PresetLdp { get; set; } = null!;
}
