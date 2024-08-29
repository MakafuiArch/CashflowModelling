using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class MarketShareLoss
{
    public int MarketShareLossId { get; set; }

    public int LossEstScenarioId { get; set; }

    public int IndustryLossId { get; set; }

    public double IndustryOnLevelLoss { get; set; }

    public DateTime IndustryOnLevelDate { get; set; }

    public int? MarketShareFactorId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual IndustryLoss IndustryLoss { get; set; } = null!;

    public virtual ICollection<LayerMarketShareLoss> LayerMarketShareLosses { get; set; } = new List<LayerMarketShareLoss>();

    public virtual LossEstScenario LossEstScenario { get; set; } = null!;

    public virtual MarketShareFactor? MarketShareFactor { get; set; }
}
