using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class Contract
{
    public int ContractId { get; set; }

    public int ContractBinderId { get; set; }

    public int ContractBinderType { get; set; }

    public int LayerId { get; set; }

    public string? LayerName { get; set; }

    public int LayerNum { get; set; }

    public int SubLayerNum { get; set; }

    public string? LayerCategory { get; set; }

    public string? LayerCatalog { get; set; }

    public DateTime Inception { get; set; }

    public DateTime Expiration { get; set; }

    public DateTime? ExpirationFinal { get; set; }

    public int Uwyear { get; set; }

    public string? LayerDesc { get; set; }

    public string? Notes { get; set; }

    public string? RegisMsg { get; set; }

    public int? ExpiringLayerId { get; set; }

    public string? ExpiringLayerName { get; set; }

    public decimal Placement { get; set; }

    public decimal ContractLimit { get; set; }

    public decimal OccLimit { get; set; }

    public decimal OccRetention { get; set; }

    public decimal AggLimit { get; set; }

    public decimal AggRetention { get; set; }

    public decimal RiskLimit { get; set; }

    public decimal RiskRetention { get; set; }

    public int RiskZoneId { get; set; }

    public string? RiskZoneName { get; set; }

    public decimal Franchise { get; set; }

    public decimal FranchiseReverse { get; set; }

    public decimal CessionTotal { get; set; }

    public int? TopUpZoneId { get; set; }

    public string? TopUpZone { get; set; }

    public string? ReinstatementsDisplayShort { get; set; }

    public string? ReinstatementsDisplayFull { get; set; }

    public string Facility { get; set; } = null!;

    public string Segment { get; set; } = null!;

    public string Lob { get; set; } = null!;

    public string? ContractType { get; set; }

    public string? LimitBasis { get; set; }

    public string? AttachBasis { get; set; }

    public string? Laeterm { get; set; }

    public string? LossTrigger { get; set; }

    public string? SourceId { get; set; }

    public string? RegisId { get; set; }

    public string? RegisNbr { get; set; }

    public string? RegisMkey { get; set; }

    public int? SnpLobId { get; set; }

    public decimal? PremiumFactor { get; set; }

    public decimal? ReserveFactor { get; set; }

    public string? SnpLobName { get; set; }

    public decimal InvestmentReturn { get; set; }

    public decimal NonCatMarginAllowance { get; set; }

    public decimal LossDuration { get; set; }

    public decimal DiversificationFactor { get; set; }

    public decimal Commission { get; set; }

    public decimal CommOverride { get; set; }

    public decimal Brokerage { get; set; }

    public decimal Tax { get; set; }

    public decimal OtherExpenses { get; set; }

    public decimal ReinsurerExpenses { get; set; }

    public bool IsVarComm { get; set; }

    public decimal VarCommHi { get; set; }

    public decimal VarCommLow { get; set; }

    public bool IsGrossUpComm { get; set; }

    public decimal GrossUpFactor { get; set; }

    public bool IsSlidingScale { get; set; }

    public decimal SscommProv { get; set; }

    public decimal SscommMax { get; set; }

    public decimal SscommMin { get; set; }

    public decimal SslossRatioProv { get; set; }

    public decimal SslossRatioMax { get; set; }

    public decimal SslossRatioMin { get; set; }

    public bool IsProfitComm { get; set; }

    public decimal ProfitComm { get; set; }

    public int Ccfyears { get; set; }

    public int Dcfyears { get; set; }

    public int Dcfamount { get; set; }

    public DateTime? PcstartDate { get; set; }

    public decimal Rate { get; set; }

    public string? PremiumFreq { get; set; }

    public string? AdjustmentBaseType { get; set; }

    public string? EarningType { get; set; }

    public string? BrokerRef { get; set; }

    public int? AcctBrokerId { get; set; }

    public string? AcctBrokerName { get; set; }

    public string? LayerType { get; set; }

    public string? Fhcfband { get; set; }

    public bool IsAdditionalPremium { get; set; }

    public bool IsCommonAcct { get; set; }

    public string? EventNumber { get; set; }

    public bool IsStopLoss { get; set; }

    public decimal StopLossLimitPct { get; set; }

    public decimal StopLossAttachPct { get; set; }

    public bool IsLossCorridor { get; set; }

    public decimal LossCorridorBeginPct { get; set; }

    public decimal LossCorridorEndPct { get; set; }

    public decimal LossCorridorCedePct { get; set; }

    public decimal? OccLimitInPct { get; set; }

    public decimal? OccRetnInPct { get; set; }

    public decimal ExpiringCorreShare { get; set; }

    public decimal CorreAuthMin { get; set; }

    public decimal CorreAuthTarget { get; set; }

    public decimal CorreAuthMax { get; set; }

    public decimal CorreRenewalMin { get; set; }

    public string? SharedToCorre { get; set; }

    public decimal FrontingFee { get; set; }

    public decimal Rol { get; set; }

    public decimal Premium { get; set; }

    public decimal? Erc { get; set; }

    public decimal Share { get; set; }

    public decimal ShareLimit { get; set; }

    public decimal SharePremium { get; set; }

    public decimal CorreShare { get; set; }

    public string? Warnings { get; set; }

    public decimal? BoundFxrate { get; set; }

    public DateTime? BoundFxdate { get; set; }

    public int RegisStatus { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsApprovalRequired { get; set; }

    public bool IsOccUnlimited { get; set; }

    public bool IsAggUnlimited { get; set; }

    public decimal? DisplayShareLimit { get; set; }

    public virtual ContractBinder ContractBinder { get; set; } = null!;

    public virtual ICollection<DeltaPxResultContract> DeltaPxResultContracts { get; set; } = new List<DeltaPxResultContract>();

    public virtual Layer Layer { get; set; } = null!;

    public virtual ICollection<LayerTopUpLossContract> LayerTopUpLossContracts { get; set; } = new List<LayerTopUpLossContract>();

    public virtual ICollection<LossViewResultContract> LossViewResultContracts { get; set; } = new List<LossViewResultContract>();

    public virtual PremiumBaseContract? PremiumBaseContract { get; set; }

    public virtual ICollection<PxSectionContract> PxSectionContracts { get; set; } = new List<PxSectionContract>();

    public virtual ICollection<ReinstatementContract> ReinstatementContracts { get; set; } = new List<ReinstatementContract>();

    public virtual ICollection<SspointContract> SspointContracts { get; set; } = new List<SspointContract>();
}
