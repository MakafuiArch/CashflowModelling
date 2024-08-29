using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class IndustryGuAnalysis
{
    public int IndustryGuAnalysisId { get; set; }

    public string? Platform { get; set; }

    public string? Version { get; set; }

    public string? Name { get; set; }

    public string? Currency { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? Peril { get; set; }

    public int Year { get; set; }

    public bool IsDefault { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<PmlMatchingDef> PmlMatchingDefs { get; set; } = new List<PmlMatchingDef>();
}
