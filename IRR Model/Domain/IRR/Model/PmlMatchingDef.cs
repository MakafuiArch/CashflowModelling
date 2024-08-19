using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PmlMatchingDef
{
    public int PmlMatchingDefId { get; set; }

    public int MatchingType { get; set; }

    public int SourceType { get; set; }

    public int? SourceGuAnalysisId { get; set; }

    public int? SourceIndustryAnalysisId { get; set; }

    public int TargetGuAnalysisId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual GuAnalysis? SourceGuAnalysis { get; set; }

    public virtual IndustryGuAnalysis? SourceIndustryAnalysis { get; set; }

    public virtual GuAnalysis TargetGuAnalysis { get; set; } = null!;

    public virtual ICollection<TargetPmldef> TargetPmldefs { get; set; } = new List<TargetPmldef>();
}
