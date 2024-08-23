using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class RoeAssumption
{
    public int RoeAssumptionId { get; set; }

    public int LayerId { get; set; }

    public int RiskCarrier { get; set; }

    public double CatastrophePremium { get; set; }

    public double PremiumDuration { get; set; }

    public int LossTiming { get; set; }

    public double ProportionalWeight { get; set; }

    public double CatastropheLossRatio { get; set; }

    public double CatastropheOccurrenceLimit { get; set; }

    public int? PresetLdpid { get; set; }

    public string? AgencyCode { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Layer Layer { get; set; } = null!;

    public virtual PresetLdp? PresetLdp { get; set; }

    public virtual ICollection<RoeLeverageFactor> RoeLeverageFactors { get; set; } = new List<RoeLeverageFactor>();

    public virtual ICollection<RoeLossDevPattern> RoeLossDevPatterns { get; set; } = new List<RoeLossDevPattern>();
}
