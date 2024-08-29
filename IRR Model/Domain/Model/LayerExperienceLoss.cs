using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class LayerExperienceLoss
{
    public int LayerExperienceLossId { get; set; }

    public int ExperienceLossId { get; set; }

    public int LayerLossEstScenarioId { get; set; }

    public double LayerLoss { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ExperienceLoss ExperienceLoss { get; set; } = null!;

    public virtual LayerLossEstScenario LayerLossEstScenario { get; set; } = null!;
}
