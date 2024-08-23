using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class RoeLeverageFactor
{
    public int RoeLeverageFactorId { get; set; }

    public int RoeAssumptionId { get; set; }

    public int ClassOfBusinessId { get; set; }

    public decimal Weight { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RoeAssumption RoeAssumption { get; set; } = null!;
}
