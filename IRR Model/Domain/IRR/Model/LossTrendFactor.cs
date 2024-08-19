using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class LossTrendFactor
{
    public int LossTrendFactorId { get; set; }

    public int LossEstScenarioId { get; set; }

    public int ExposureYear { get; set; }

    public decimal HistoricalPremium { get; set; }

    public double DevelopFactor { get; set; }

    public decimal ExposureTrend { get; set; }

    public double ExposureFactor { get; set; }

    public decimal RateChange { get; set; }

    public double RateLevel { get; set; }

    public double RateIndex { get; set; }

    public double OnLevelPremium { get; set; }

    public double PremiumIndex { get; set; }

    public decimal IncurredLdfs { get; set; }

    public decimal SeverityTrend { get; set; }

    public double SeverityFactor { get; set; }

    public decimal HistPremXol { get; set; }

    public decimal HistPremProportional { get; set; }

    public decimal HistPremFacultative { get; set; }

    public decimal HistPremTotal { get; set; }

    public decimal HistTivXol { get; set; }

    public decimal HistTivProportional { get; set; }

    public decimal HistTivFacultative { get; set; }

    public decimal HistTivTotal { get; set; }

    public double HistTivIndex { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public double BaselineForPremiumIndex { get; set; }

    public double FinalTrendFactor { get; set; }

    public virtual LossEstScenario LossEstScenario { get; set; } = null!;
}
