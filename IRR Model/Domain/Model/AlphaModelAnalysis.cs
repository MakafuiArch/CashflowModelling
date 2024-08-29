using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class AlphaModelAnalysis
{
    public int AlphaModelAnalysisId { get; set; }

    public int AlphaGuAnalysisId { get; set; }

    public string? Peril { get; set; }

    public int DistributionType { get; set; }

    public decimal TargetLr { get; set; }

    public decimal Cv { get; set; }

    public decimal TargetEl { get; set; }

    public decimal Alpha { get; set; }

    public int RandomSeed { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public decimal DistributionLimit { get; set; }

    public decimal AttachmentPoint { get; set; }

    public virtual AlphaGuAnalysis AlphaGuAnalysis { get; set; } = null!;
}
