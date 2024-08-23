using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class RetroInvestor
{
    public int RetroInvestorId { get; set; }

    public int SpinsurerId { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public decimal TargetCollateral { get; set; }

    public decimal NotionalCollateral { get; set; }

    public decimal InvestmentEstimated { get; set; }

    public decimal InvestmentAuth { get; set; }

    public decimal InvestmentSigned { get; set; }

    public decimal InvestmentEstimatedAmt { get; set; }

    public decimal InvestmentAuthAmt { get; set; }

    public decimal InvestmentSignedAmt { get; set; }

    public string? ExcludedFacilities { get; set; }

    public string? ExcludedLayerSubNos { get; set; }

    public string? ExcludedDomiciles { get; set; }

    public bool IsFundsWithheld { get; set; }

    public int RetroCommissionId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? RuleDefs { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? ExcludedLayerIds { get; set; }

    public decimal TargetPremium { get; set; }

    public decimal Override { get; set; }

    public decimal ManagementFee { get; set; }

    public decimal ProfitComm { get; set; }

    public decimal PerformanceFee { get; set; }

    public decimal Rhoe { get; set; }

    public decimal HurdleRate { get; set; }

    public bool IsPortIn { get; set; }

    public bool IsPortOut { get; set; }

    public int RetroBufferType { get; set; }

    public decimal CessionCapBufferPct { get; set; }

    public string? RetroValuesToBuffer { get; set; }

    public virtual ICollection<RetroAllocation> RetroAllocations { get; set; } = new List<RetroAllocation>();

    public virtual ICollection<RetroBufferByEvent> RetroBufferByEvents { get; set; } = new List<RetroBufferByEvent>();

    public virtual ICollection<RetroBufferByTime> RetroBufferByTimes { get; set; } = new List<RetroBufferByTime>();

    public virtual RetroCommission RetroCommission { get; set; } = null!;

    public virtual ICollection<RetroFacilityOverride> RetroFacilityOverrides { get; set; } = new List<RetroFacilityOverride>();

    public virtual ICollection<RetroInvestorReset> RetroInvestorResets { get; set; } = new List<RetroInvestorReset>();

    public virtual ICollection<RetroInvestorZone> RetroInvestorZones { get; set; } = new List<RetroInvestorZone>();

    public virtual ICollection<RetroZoneOverride> RetroZoneOverrides { get; set; } = new List<RetroZoneOverride>();

    public virtual Spinsurer Spinsurer { get; set; } = null!;
}
