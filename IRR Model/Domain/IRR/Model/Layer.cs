using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class Layer
{
    public int LayerId { get; set; }

    public int SubmissionId { get; set; }

    public int LayerNum { get; set; }

    public int SubLayerNum { get; set; }

    public int ReinstCount { get; set; }

    public decimal Placement { get; set; }

    public decimal OccLimit { get; set; }

    public decimal OccRetention { get; set; }

    public decimal CascadeRetention { get; set; }

    public decimal Aad { get; set; }

    public decimal Var1Retention { get; set; }

    public decimal Var2Retention { get; set; }

    public decimal AggLimit { get; set; }

    public decimal AggRetention { get; set; }

    public decimal Franchise { get; set; }

    public decimal FranchiseReverse { get; set; }

    public decimal RiskLimit { get; set; }

    public DateTime Inception { get; set; }

    public int Uwyear { get; set; }

    public DateTime Expiration { get; set; }

    public DateTime? ExpirationFinal { get; set; }

    public string Facility { get; set; } = null!;

    public string Segment { get; set; } = null!;

    public string Lob { get; set; } = null!;

    public int ContractType { get; set; }

    public int LimitBasis { get; set; }

    public int AttachBasis { get; set; }

    public int Laeterm { get; set; }

    public int LossTrigger { get; set; }

    public decimal Rol { get; set; }

    public decimal QuoteRol { get; set; }

    public decimal? Erc { get; set; }

    public decimal Ercmodel { get; set; }

    public decimal Ercmid { get; set; }

    public decimal Ercpareto { get; set; }

    public string? RegisId { get; set; }

    public string? RegisNbr { get; set; }

    public string? RegisMkey { get; set; }

    public string? RegisIdCt { get; set; }

    public string? RegisNbrCt { get; set; }

    public decimal BurnReported { get; set; }

    public decimal BurnTrended { get; set; }

    public int YearPeriodSelected { get; set; }

    public int YearPeriodLoss { get; set; }

    public decimal CatLoss1 { get; set; }

    public decimal CatLoss2 { get; set; }

    public decimal CatLoss3 { get; set; }

    public decimal EstimatedShare { get; set; }

    public decimal SignedShare { get; set; }

    public decimal AuthShare { get; set; }

    public decimal QuotedShare { get; set; }

    public int Status { get; set; }

    public string? LayerDesc { get; set; }

    public string? Notes { get; set; }

    public string? RegisMsg { get; set; }

    public int? ExpiringLayerId { get; set; }

    public decimal Commission { get; set; }

    public decimal CommOverride { get; set; }

    public decimal Brokerage { get; set; }

    public decimal Tax { get; set; }

    public decimal OtherExpenses { get; set; }

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

    public decimal ComAccountProtect { get; set; }

    public decimal ProfitCommissionExpAllowance { get; set; }

    public decimal Rate { get; set; }

    public int PremiumFreq { get; set; }

    public int AdjustmentBaseType { get; set; }

    public int LayerType { get; set; }

    public int Fhcfband { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? TopUpZoneId { get; set; }

    public decimal? Ercquote { get; set; }

    public string? DeclineReason { get; set; }

    public decimal InuringLimit { get; set; }

    public decimal RiskRetention { get; set; }

    public decimal ReinsurerExpenses { get; set; }

    public int LayerCategory { get; set; }

    public string? LayerCatalog { get; set; }

    public decimal Premium { get; set; }

    public decimal QuotePremium { get; set; }

    public int? RiskZoneId { get; set; }

    public decimal RelShare { get; set; }

    public decimal TargetNetShare { get; set; }

    public string? RegisLayerCode { get; set; }

    public int? SnpLobId { get; set; }

    public decimal InvestmentReturn { get; set; }

    public decimal NonCatMarginAllowance { get; set; }

    public decimal LossDuration { get; set; }

    public decimal DiversificationFactor { get; set; }

    public int EarningType { get; set; }

    public string? SourceId { get; set; }

    public decimal OrderPct { get; set; }

    public string? BrokerRef { get; set; }

    public int? AcctBrokerId { get; set; }

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

    public int SharedToCorre { get; set; }

    public decimal SignedCorreShare { get; set; }

    public decimal QuotedCorreShare { get; set; }

    public decimal AuthCorreShare { get; set; }

    public decimal FrontingFee { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public decimal? NonCatWeightPc { get; set; }

    public decimal? NonCatWeightSs { get; set; }

    public decimal? BoundFxrate { get; set; }

    public DateTime? BoundFxdate { get; set; }

    public int RegisStatus { get; set; }

    public bool IsDifferentialTerms { get; set; }

    public decimal RolRpp { get; set; }

    public int Wilresolution { get; set; }

    public bool IsParametric { get; set; }

    public int PricingSource { get; set; }

    public string? IrispolicySeqNumber { get; set; }

    public int Irisstatus { get; set; }

    public string? Iriscomments { get; set; }

    public int IrisrefId { get; set; }

    public string? IrisclassCode { get; set; }

    public string? IrisbranchCode { get; set; }

    public string? IristradeCode { get; set; }

    public string? IrisplacingCode { get; set; }

    public double ExpectedGrossNetPremiumGbp { get; set; }

    public string? IrisproductCode { get; set; }

    public decimal StopLossBufferPct { get; set; }

    public decimal? Ercactual { get; set; }

    public string? ErcactualSource { get; set; }

    public decimal? ElmarketShare { get; set; }

    public decimal? ElhistoricalBurn { get; set; }

    public decimal? Elbroker { get; set; }

    public int? Maol { get; set; }

    public bool Ncbr { get; set; }

    public bool IsTerrorismSubLimitAppl { get; set; }

    public decimal? TerrorismSubLimit { get; set; }

    public string? TerrorismSubLimitComments { get; set; }

    public decimal? LloydsCapital { get; set; }

    public decimal? LloydsRoc { get; set; }

    public DateTime? QuoteExpire { get; set; }

    public DateTime? AuthExpire { get; set; }

    public decimal MktRol { get; set; }

    public bool IsHidden { get; set; }

    public decimal? Cloud { get; set; }

    public decimal? Ransom { get; set; }

    public virtual Broker? AcctBroker { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<DeltaPxResult> DeltaPxResults { get; set; } = new List<DeltaPxResult>();

    public virtual Layer? ExpiringLayer { get; set; }

    public virtual ICollection<Layer> InverseExpiringLayer { get; set; } = new List<Layer>();

    public virtual ICollection<LayerLossAnalysis> LayerLossAnalyses { get; set; } = new List<LayerLossAnalysis>();

    public virtual ICollection<LayerLossEstScenario> LayerLossEstScenarios { get; set; } = new List<LayerLossEstScenario>();

    public virtual ICollection<LloydsRiskCode> LloydsRiskCodes { get; set; } = new List<LloydsRiskCode>();

    public virtual ICollection<LossViewResult> LossViewResults { get; set; } = new List<LossViewResult>();

    public virtual ICollection<MultiyearShare> MultiyearShares { get; set; } = new List<MultiyearShare>();

    public virtual ICollection<PolicyTracker> PolicyTrackers { get; set; } = new List<PolicyTracker>();

    public virtual ICollection<PolicyUpdate> PolicyUpdates { get; set; } = new List<PolicyUpdate>();

    public virtual ICollection<PortLayer> PortLayers { get; set; } = new List<PortLayer>();

    public virtual ICollection<PortRoeResult> PortRoeResults { get; set; } = new List<PortRoeResult>();

    public virtual PremiumBase? PremiumBase { get; set; }

    public virtual ICollection<PxSection> PxSectionLayers { get; set; } = new List<PxSection>();

    public virtual ICollection<PxSection> PxSectionPxLayers { get; set; } = new List<PxSection>();

    public virtual ICollection<Reinstatement> Reinstatements { get; set; } = new List<Reinstatement>();

    public virtual ICollection<RetroAllocation> RetroAllocations { get; set; } = new List<RetroAllocation>();

    public virtual RiskZone? RiskZone { get; set; }

    public virtual ICollection<RoeAssumption> RoeAssumptions { get; set; } = new List<RoeAssumption>();

    public virtual ICollection<RoeCapitalResult> RoeCapitalResults { get; set; } = new List<RoeCapitalResult>();

    public virtual ICollection<Sspoint> Sspoints { get; set; } = new List<Sspoint>();

    public virtual Submission Submission { get; set; } = null!;
}
