using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class IndustryCalibrationDef
{
    public int IndustryCalibrationDefId { get; set; }

    public int SourceGuAnalysisId { get; set; }

    public int SourceIndustryCalibrationAnalysisId { get; set; }

    public int TargetGuAnalysisId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual GuAnalysis SourceGuAnalysis { get; set; } = null!;

    public virtual IndustryCalibrationAnalysis SourceIndustryCalibrationAnalysis { get; set; } = null!;

    public virtual GuAnalysis TargetGuAnalysis { get; set; } = null!;
}
