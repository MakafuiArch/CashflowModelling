using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class GuCurveAdjDef
{
    public int GuCurveAdjDefId { get; set; }

    public int SourceGuAnalysisId { get; set; }

    public int TargetGuAnalysisId { get; set; }

    public string? PmlType { get; set; }

    public string? FileName { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<GuCurveAdjPmlSrc> GuCurveAdjPmlSrcs { get; set; } = new List<GuCurveAdjPmlSrc>();

    public virtual GuAnalysis SourceGuAnalysis { get; set; } = null!;

    public virtual GuAnalysis TargetGuAnalysis { get; set; } = null!;
}
