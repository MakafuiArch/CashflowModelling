using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class LossEstScenario
{
    public int LossEstScenarioId { get; set; }

    public int? SubmissionId { get; set; }

    public int LossAdjustmentIndex { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime Fxdate { get; set; }

    public decimal IndLossFxRateUsd { get; set; }

    public int? IndustryLossFilterId { get; set; }

    public int LossFreqMaxYear { get; set; }

    public virtual ICollection<ExperienceLoss> ExperienceLosses { get; set; } = new List<ExperienceLoss>();

    public virtual IndustryLossFilter? IndustryLossFilter { get; set; }

    public virtual ICollection<LayerLossEstScenario> LayerLossEstScenarios { get; set; } = new List<LayerLossEstScenario>();

    public virtual ICollection<LossTrendFactor> LossTrendFactors { get; set; } = new List<LossTrendFactor>();

    public virtual ICollection<MarketShareFactor> MarketShareFactors { get; set; } = new List<MarketShareFactor>();

    public virtual ICollection<MarketShareLoss> MarketShareLosses { get; set; } = new List<MarketShareLoss>();

    public virtual Submission? Submission { get; set; }
}
