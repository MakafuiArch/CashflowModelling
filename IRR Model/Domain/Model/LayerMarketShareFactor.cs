using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class LayerMarketShareFactor
{
    public int LayerMarketShareFactorId { get; set; }

    public int MarketShareFactorId { get; set; }

    public int LayerLossEstScenarioId { get; set; }

    public double MarketShare { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual LayerLossEstScenario LayerLossEstScenario { get; set; } = null!;

    public virtual MarketShareFactor MarketShareFactor { get; set; } = null!;
}
