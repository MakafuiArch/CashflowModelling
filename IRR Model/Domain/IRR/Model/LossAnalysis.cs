using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class LossAnalysis
{
    public int LossAnalysisId { get; set; }

    public string? Name { get; set; }

    public string? Notes { get; set; }

    public int SubmissionId { get; set; }

    public string? Model { get; set; }

    public string? Version { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int SimYears { get; set; }

    public int JobStatus { get; set; }

    public string? JobId { get; set; }

    public string? JobMessage { get; set; }

    public DateTime? RunDate { get; set; }

    public string? ReasonStale { get; set; }

    public int EngineType { get; set; }

    public DateTime? RunStartDate { get; set; }

    public int? GuAnalysisId { get; set; }

    public int LossView { get; set; }

    public decimal PerilEq { get; set; }

    public decimal PerilWs { get; set; }

    public decimal PerilCs { get; set; }

    public decimal PerilWt { get; set; }

    public decimal PerilFl { get; set; }

    public decimal PerilWf { get; set; }

    public decimal GrowthEq { get; set; }

    public decimal GrowthWs { get; set; }

    public decimal GrowthCs { get; set; }

    public decimal GrowthWt { get; set; }

    public decimal GrowthFl { get; set; }

    public decimal GrowthWf { get; set; }

    public decimal LaeEq { get; set; }

    public decimal LaeWs { get; set; }

    public decimal LaeCs { get; set; }

    public decimal LaeWt { get; set; }

    public decimal LaeFl { get; set; }

    public decimal LaeWf { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool IsCalcIndustryMetrics { get; set; }

    public decimal Inflation { get; set; }

    public decimal SocialEq { get; set; }

    public decimal SocialWs { get; set; }

    public decimal SocialCs { get; set; }

    public decimal SocialWt { get; set; }

    public decimal SocialFl { get; set; }

    public decimal SocialWf { get; set; }

    public decimal CedentEq { get; set; }

    public decimal CedentWs { get; set; }

    public decimal CedentCs { get; set; }

    public decimal CedentWt { get; set; }

    public decimal CedentFl { get; set; }

    public decimal CedentWf { get; set; }

    public bool SkipAggFeatures { get; set; }

    public Guid? LossAnalysisGuid { get; set; }

    public virtual GuAnalysis? GuAnalysis { get; set; }

    public virtual ICollection<LayerLossAnalysis> LayerLossAnalyses { get; set; } = new List<LayerLossAnalysis>();

    public virtual Submission Submission { get; set; } = null!;
}
