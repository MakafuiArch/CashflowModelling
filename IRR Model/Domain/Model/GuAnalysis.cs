using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class GuAnalysis
{
    public int GuAnalysisId { get; set; }

    public int? SubmissionId { get; set; }

    public string? Platform { get; set; }

    public string? Version { get; set; }

    public string? Database { get; set; }

    public string? Name { get; set; }

    public string? Perils { get; set; }

    public string? Currency { get; set; }

    public DateTime? RunDate { get; set; }

    public int JobStatus { get; set; }

    public string? JobId { get; set; }

    public string? ExtJobId { get; set; }

    public string? ExtJobStatus { get; set; }

    public string? JobMessage { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? Server { get; set; }

    public int SimYears { get; set; }

    public int LossDetailType { get; set; }

    public int? ZoneDefinitionId { get; set; }

    public DateTime? RunStartDate { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool UseSwift { get; set; }

    public string? CompatibleVersions { get; set; }

    public int AdjustmentType { get; set; }

    public int YeltRowCount { get; set; }

    public int YeltGeoRowCount { get; set; }

    public Guid? GuAnalysisGuid { get; set; }

    public virtual ICollection<GuCurveAdjDef> GuCurveAdjDefSourceGuAnalyses { get; set; } = new List<GuCurveAdjDef>();

    public virtual ICollection<GuCurveAdjDef> GuCurveAdjDefTargetGuAnalyses { get; set; } = new List<GuCurveAdjDef>();

    public virtual ICollection<IndustryCalibrationDef> IndustryCalibrationDefSourceGuAnalyses { get; set; } = new List<IndustryCalibrationDef>();

    public virtual ICollection<IndustryCalibrationDef> IndustryCalibrationDefTargetGuAnalyses { get; set; } = new List<IndustryCalibrationDef>();

    public virtual ICollection<LayerLossAnalysis> LayerLossAnalyses { get; set; } = new List<LayerLossAnalysis>();

    public virtual ICollection<LossAnalysis> LossAnalyses { get; set; } = new List<LossAnalysis>();

    public virtual ICollection<ModelAnalysis> ModelAnalyses { get; set; } = new List<ModelAnalysis>();

    public virtual ICollection<PmlMatchingDef> PmlMatchingDefSourceGuAnalyses { get; set; } = new List<PmlMatchingDef>();

    public virtual ICollection<PmlMatchingDef> PmlMatchingDefTargetGuAnalyses { get; set; } = new List<PmlMatchingDef>();

    public virtual Submission? Submission { get; set; }

    public virtual ICollection<SubmissionGuAnalysis> SubmissionGuAnalyses { get; set; } = new List<SubmissionGuAnalysis>();

    public virtual ZoneDefinition? ZoneDefinition { get; set; }
}
