using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class RetroZone
{
    public int RetroZoneId { get; set; }

    public int RetroProgramId { get; set; }

    public string? Name { get; set; }

    public decimal EllowerBound { get; set; }

    public decimal ElupperBound { get; set; }

    public decimal RollowerBound { get; set; }

    public decimal RolupperBound { get; set; }

    public decimal Cession { get; set; }

    public double CessionCap { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public double CessionCapAdjusted { get; set; }

    public int TopUpZoneId { get; set; }

    public DateTime StartDate { get; set; }

    public virtual RetroProgram RetroProgram { get; set; } = null!;

    public virtual ICollection<RetroZoneOverride> RetroZoneOverrides { get; set; } = new List<RetroZoneOverride>();
}
