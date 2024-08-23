using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class AlphaGuAnalysis
{
    public int AlphaGuAnalysisId { get; set; }

    public int SimYears { get; set; }

    public string? Platform { get; set; }

    public string? Name { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AlphaModelAnalysis> AlphaModelAnalyses { get; set; } = new List<AlphaModelAnalysis>();

    public virtual ICollection<LayerLossAnalysis> LayerLossAnalyses { get; set; } = new List<LayerLossAnalysis>();
}
