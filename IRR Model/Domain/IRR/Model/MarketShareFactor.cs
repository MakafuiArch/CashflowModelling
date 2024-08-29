using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class MarketShareFactor
{
    public int MarketShareFactorId { get; set; }

    public int LossEstScenarioId { get; set; }

    public int IndustryLossSubRegionId { get; set; }

    public string? Peril { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual IndustryLossSubRegion IndustryLossSubRegion { get; set; } = null!;

    public virtual ICollection<LayerMarketShareFactor> LayerMarketShareFactors { get; set; } = new List<LayerMarketShareFactor>();

    public virtual LossEstScenario LossEstScenario { get; set; } = null!;

    public virtual ICollection<MarketShareLoss> MarketShareLosses { get; set; } = new List<MarketShareLoss>();
}
