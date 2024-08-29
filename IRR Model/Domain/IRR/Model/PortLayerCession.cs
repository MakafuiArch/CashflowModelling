using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PortLayerCession
{
    public int PortLayerCessionId { get; set; }

    public int PortLayerId { get; set; }

    public int RetroProgramId { get; set; }

    public bool ShouldCessionApply { get; set; }

    public decimal CessionGross { get; set; }

    public decimal CessionNet { get; set; }

    public decimal CessionNetAdjusted { get; set; }

    public decimal CessionFeesRaw { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsSelected { get; set; }

    public string? CalculationMessage { get; set; }

    public virtual PortLayer PortLayer { get; set; } = null!;

    public virtual RetroProgram RetroProgram { get; set; } = null!;
}
