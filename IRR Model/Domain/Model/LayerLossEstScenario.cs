using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class LayerLossEstScenario
{
    public int LayerLossEstScenarioId { get; set; }

    public int LossEstScenarioId { get; set; }

    public int? LayerId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Layer? Layer { get; set; }

    public virtual ICollection<LayerExperienceLoss> LayerExperienceLosses { get; set; } = new List<LayerExperienceLoss>();

    public virtual ICollection<LayerMarketShareFactor> LayerMarketShareFactors { get; set; } = new List<LayerMarketShareFactor>();

    public virtual ICollection<LayerMarketShareLoss> LayerMarketShareLosses { get; set; } = new List<LayerMarketShareLoss>();

    public virtual LossEstScenario LossEstScenario { get; set; } = null!;
}
