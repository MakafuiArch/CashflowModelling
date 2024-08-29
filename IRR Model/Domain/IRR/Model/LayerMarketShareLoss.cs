using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class LayerMarketShareLoss
{
    public int LayerMarketShareLossId { get; set; }

    public int MarketShareLossId { get; set; }

    public int LayerLossEstScenarioId { get; set; }

    public double LayerLoss { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual LayerLossEstScenario LayerLossEstScenario { get; set; } = null!;

    public virtual MarketShareLoss MarketShareLoss { get; set; } = null!;
}
