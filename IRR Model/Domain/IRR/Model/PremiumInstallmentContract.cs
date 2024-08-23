using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class PremiumInstallmentContract
{
    public int PremiumInstallmentContractId { get; set; }

    public int PremiumBaseContractId { get; set; }

    public string Currency { get; set; } = null!;

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime DueDate { get; set; }

    public decimal InstallmentPct { get; set; }

    public decimal InstallmentAmt { get; set; }

    public decimal Brokerage { get; set; }

    public decimal Tax { get; set; }

    public decimal Commission { get; set; }

    public decimal Override { get; set; }

    public decimal Ncb { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PremiumBaseContract PremiumBaseContract { get; set; } = null!;
}
