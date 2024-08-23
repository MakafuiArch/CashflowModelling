using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class ExperienceLoss
{
    public int ExperienceLossId { get; set; }

    public int LossEstScenarioId { get; set; }

    public int GeographyId { get; set; }

    public int? LossEventId { get; set; }

    public string? EventUniqueId { get; set; }

    public int DataSource { get; set; }

    public DateTime ValuationDate { get; set; }

    public DateTime? EventStartDate { get; set; }

    public int EventYear { get; set; }

    public string? EventName { get; set; }

    public string? IndustryEventCode { get; set; }

    public string? ReportedPeril { get; set; }

    public string? Peril { get; set; }

    public string? CountryCode { get; set; }

    public string? AreaCode { get; set; }

    public string? SubareaCode { get; set; }

    public string? Division { get; set; }

    public string? LineOfBusiness { get; set; }

    public string? Currency { get; set; }

    public int? ClaimsCount { get; set; }

    public bool? IsOpen { get; set; }

    public double ExposureAdjustment { get; set; }

    public double IncurredLdfs { get; set; }

    public double SeverityTrend { get; set; }

    public double TotalExposureAdjustedLoss { get; set; }

    public double? ActualPaidLoss { get; set; }

    public double ActualIncurredLoss { get; set; }

    public double? AsIfIncurredLoss { get; set; }

    public int TrendedLossSelector { get; set; }

    public double TrendedLoss { get; set; }

    public double? MarketShare { get; set; }

    public string? SelectedLayers { get; set; }

    public string? Notes { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? PcscatNum { get; set; }

    public string? EventCode { get; set; }

    public double ExposureFactor { get; set; }

    public virtual Geography Geography { get; set; } = null!;

    public virtual ICollection<LayerExperienceLoss> LayerExperienceLosses { get; set; } = new List<LayerExperienceLoss>();

    public virtual LossEstScenario LossEstScenario { get; set; } = null!;

    public virtual LossEvent? LossEvent { get; set; }
}
