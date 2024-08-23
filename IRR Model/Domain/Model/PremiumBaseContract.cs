using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class PremiumBaseContract
{
    public int PremiumBaseContractId { get; set; }

    public string? PremiumMethod { get; set; }

    public decimal Spiest { get; set; }

    public decimal Spiact { get; set; }

    public decimal SpiestExp { get; set; }

    public decimal SpiactExp { get; set; }

    public decimal Siest { get; set; }

    public decimal Siact { get; set; }

    public decimal SiestExp { get; set; }

    public decimal SiactExp { get; set; }

    public decimal EqEst { get; set; }

    public decimal EqAct { get; set; }

    public decimal EqEstExp { get; set; }

    public decimal EqActExp { get; set; }

    public decimal WdEst { get; set; }

    public decimal WdAct { get; set; }

    public decimal WdEstExp { get; set; }

    public decimal WdActExp { get; set; }

    public decimal MdEst { get; set; }

    public decimal MdAct { get; set; }

    public decimal MdEstExp { get; set; }

    public decimal MdActExp { get; set; }

    public decimal Flat { get; set; }

    public decimal DepositPct { get; set; }

    public decimal DepositAmt { get; set; }

    public decimal MinPct { get; set; }

    public decimal MinAmt { get; set; }

    public decimal NcbPct { get; set; }

    public DateTime? AdjustmentDate { get; set; }

    public decimal Adjustment { get; set; }

    public decimal EstUltPremium { get; set; }

    public string? Notes { get; set; }

    public bool IsAsCollected { get; set; }

    public bool IsPremiumPort { get; set; }

    public bool IsEqualInstallments { get; set; }

    public bool IsAccruals { get; set; }

    public int? NumberOfInstallments { get; set; }

    public int SettlementDays { get; set; }

    public int ReportingDays { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Contract PremiumBaseContractNavigation { get; set; } = null!;

    public virtual ICollection<PremiumInstallmentContract> PremiumInstallmentContracts { get; set; } = new List<PremiumInstallmentContract>();
}
