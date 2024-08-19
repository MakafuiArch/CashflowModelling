using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class ModelAnalysis
{
    public int ModelAnalysisId { get; set; }

    public string? Platform { get; set; }

    public string? Version { get; set; }

    public string? Database { get; set; }

    public int AnalysisId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Perspective { get; set; }

    public string? Peril { get; set; }

    public string? Zones { get; set; }

    public string? Currency { get; set; }

    public decimal Fxrate { get; set; }

    public DateTime Fxdate { get; set; }

    public DateTime? RunDate { get; set; }

    public int RollUp { get; set; }

    public int GuAnalysisId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? ExcludedPerils { get; set; }

    public string? ExcludedGeographies { get; set; }

    public int TreatyId { get; set; }

    public string? Server { get; set; }

    public string? ExcludedLobs { get; set; }

    public byte LossType { get; set; }

    public int? GeographyId { get; set; }

    public string? FileName { get; set; }

    public decimal CedentShare { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int CurveType { get; set; }

    public int YeltRowCount { get; set; }

    public int YeltGeoRowCount { get; set; }

    public virtual GuAnalysis GuAnalysis { get; set; } = null!;
}
