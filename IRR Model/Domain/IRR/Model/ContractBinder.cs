using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class ContractBinder
{
    public int ContractBinderId { get; set; }

    public int SubmissionId { get; set; }

    public string? SubmissionName { get; set; }

    public int BrokerId { get; set; }

    public string? BrokerName { get; set; }

    public string? BrokerOfficeName { get; set; }

    public int? BrokerContactId { get; set; }

    public string? BrokerContactName { get; set; }

    public int? ActuaryId { get; set; }

    public string? ActuaryName { get; set; }

    public int? AnalystId { get; set; }

    public string? AnalystName { get; set; }

    public int? ModelerId { get; set; }

    public string? ModelerName { get; set; }

    public int UnderwriterId { get; set; }

    public string? UnderwriterName { get; set; }

    public int? RelshipUnderwriterId { get; set; }

    public string? RelshipUnderwriterName { get; set; }

    public string? StrategicNotes { get; set; }

    public int? UwyearDefaultExpiring { get; set; }

    public string BaseCurrency { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public decimal Fxrate { get; set; }

    public DateTime Fxdate { get; set; }

    public string TranType { get; set; } = null!;

    public DateTime InceptionDefault { get; set; }

    public DateTime ExpirationDefault { get; set; }

    public int UwyearDefault { get; set; }

    public bool IsMultiyear { get; set; }

    public bool IsCancellable { get; set; }

    public string? RefId { get; set; }

    public string? SubmissionStatus { get; set; }

    public bool IsRenewal { get; set; }

    public string? ModelingStatus { get; set; }

    public string? ActuarialStatus { get; set; }

    public string? Priority { get; set; }

    public int? ExpiringSubmissionId { get; set; }

    public string? ExpiringSubmissionName { get; set; }

    public DateTime? MdlStatusDate { get; set; }

    public DateTime? CorreAuthDeadline { get; set; }

    public string? CorreStatus { get; set; }

    public DateTime? ActuarialDeadline { get; set; }

    public string? Source { get; set; }

    public string? ActuarialPriority { get; set; }

    public string? ModelingComplexity { get; set; }

    public string? ActuarialRanking { get; set; }

    public int ProgramId { get; set; }

    public string? ProgramName { get; set; }

    public int CedentId { get; set; }

    public string? CedentName { get; set; }

    public int ReinsurerId { get; set; }

    public string? ReinsurerName { get; set; }

    public string? ExtName { get; set; }

    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public int OfficeId { get; set; }

    public string? OfficeName { get; set; }

    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public string? Insured { get; set; }

    public string? InsType { get; set; }

    public bool QsofXs { get; set; }

    public int ContractBinderType { get; set; }

    public int Status { get; set; }

    public string? ContractBinderNotes { get; set; }

    public long YoySummaryDivisor { get; set; }

    public string? YoySummaryCurrencyAndAmountSymbol { get; set; }

    public decimal GrossLimitQuote { get; set; }

    public decimal GrossLimitAuth { get; set; }

    public decimal GrossLimitMultiYrIf { get; set; }

    public decimal GrossLimitBoundNew { get; set; }

    public decimal GrossLimitTotalIf { get; set; }

    public decimal GrossPremQuote { get; set; }

    public decimal GrossPremAuth { get; set; }

    public decimal GrossPremMultiYrIf { get; set; }

    public decimal GrossPremBoundNew { get; set; }

    public decimal GrossPremTotalIf { get; set; }

    public decimal NetLimitQuote { get; set; }

    public decimal NetLimitAuth { get; set; }

    public decimal NetLimitMultiYrIf { get; set; }

    public decimal NetLimitBoundNew { get; set; }

    public decimal NetLimitTotalIf { get; set; }

    public decimal NetPremQuote { get; set; }

    public decimal NetPremAuth { get; set; }

    public decimal NetPremMultiYrIf { get; set; }

    public decimal NetPremBoundNew { get; set; }

    public decimal NetPremTotalIf { get; set; }

    public decimal? GrossLimitQuoteExpiring { get; set; }

    public decimal? GrossLimitAuthExpiring { get; set; }

    public decimal? GrossLimitMultiYrIfExpiring { get; set; }

    public decimal? GrossLimitBoundNewExpiring { get; set; }

    public decimal? GrossLimitTotalIfExpiring { get; set; }

    public decimal? GrossPremQuoteExpiring { get; set; }

    public decimal? GrossPremAuthExpiring { get; set; }

    public decimal? GrossPremMultiYrIfExpiring { get; set; }

    public decimal? GrossPremBoundNewExpiring { get; set; }

    public decimal? GrossPremTotalIfExpiring { get; set; }

    public decimal? NetLimitQuoteExpiring { get; set; }

    public decimal? NetLimitAuthExpiring { get; set; }

    public decimal? NetLimitMultiYrIfExpiring { get; set; }

    public decimal? NetLimitBoundNewExpiring { get; set; }

    public decimal? NetLimitTotalIfExpiring { get; set; }

    public decimal? NetPremQuoteExpiring { get; set; }

    public decimal? NetPremAuthExpiring { get; set; }

    public decimal? NetPremMultiYrIfExpiring { get; set; }

    public decimal? NetPremBoundNewExpiring { get; set; }

    public decimal? NetPremTotalIfExpiring { get; set; }

    public string? CancelReason { get; set; }

    public string? Warnings { get; set; }

    public string? RegisId { get; set; }

    public string? RegisNbr { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public decimal? FxRateSbfusd { get; set; }

    public decimal? FxRateSbfgbp { get; set; }

    public DateTime? FxDateSbf { get; set; }

    public string? Rationale { get; set; }

    public int? DocId { get; set; }

    public int? ChangeType { get; set; }

    public int BrokerRating { get; set; }

    public string? BrokerRationale { get; set; }

    public int ClientAdvocacyRating { get; set; }

    public string? ClientAdvocacyRationale { get; set; }

    public virtual ICollection<ContractReviewer> ContractReviewers { get; set; } = new List<ContractReviewer>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Doc? Doc { get; set; }

    public virtual ICollection<SubDeltaPxResultContract> SubDeltaPxResultContracts { get; set; } = new List<SubDeltaPxResultContract>();

    public virtual Submission Submission { get; set; } = null!;
}
