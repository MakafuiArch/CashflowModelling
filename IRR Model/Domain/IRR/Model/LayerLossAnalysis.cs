using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class LayerLossAnalysis
{
    public int LayerLossAnalysisId { get; set; }

    public int LayerId { get; set; }

    public int LossAnalysisId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public double Rp { get; set; }

    public double? StandaloneRoe { get; set; }

    public double El { get; set; }

    public double? StdvAdj { get; set; }

    public int? GuAnalysisId { get; set; }

    public decimal Cr { get; set; }

    public decimal Er { get; set; }

    public decimal Lr { get; set; }

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

    public decimal EllargeLoss { get; set; }

    public decimal Elmodeled { get; set; }

    public decimal ElnonModeled { get; set; }

    public decimal Elattritional { get; set; }

    public double Rb { get; set; }

    public double TotalExp { get; set; }

    public double CatPml { get; set; }

    public double? StandaloneCapital { get; set; }

    public double? StandaloneRoequote { get; set; }

    public double CatPmlQuote { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? ReasonStale { get; set; }

    public int? AlphaGuAnalysisId { get; set; }

    public bool IncludeAttritional { get; set; }

    public bool IncludeLargeLoss { get; set; }

    public bool IncludeNonModel { get; set; }

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

    public bool IncludeModeled { get; set; }

    public virtual AlphaGuAnalysis? AlphaGuAnalysis { get; set; }

    public virtual GuAnalysis? GuAnalysis { get; set; }

    public virtual Layer Layer { get; set; } = null!;

    public virtual LossAnalysis LossAnalysis { get; set; } = null!;
}
