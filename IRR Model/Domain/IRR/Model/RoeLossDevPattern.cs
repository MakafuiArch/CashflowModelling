using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class RoeLossDevPattern
{
    public int RoeLossDevPatternId { get; set; }

    public int RoeAssumptionId { get; set; }

    public int AsOfMonth { get; set; }

    public decimal PaidLoss { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RoeAssumption RoeAssumption { get; set; } = null!;
}
