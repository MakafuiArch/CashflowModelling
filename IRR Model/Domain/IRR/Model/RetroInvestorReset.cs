using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RetroInvestorReset
{
    public int RetroInvestorResetId { get; set; }

    public int RetroInvestorId { get; set; }

    public int RetroProgramResetId { get; set; }

    public DateTime StartDate { get; set; }

    public decimal TargetCollateral { get; set; }

    public decimal TargetPremium { get; set; }

    public decimal InvestmentSignedAmt { get; set; }

    public decimal InvestmentSigned { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RetroInvestor RetroInvestor { get; set; } = null!;

    public virtual RetroProgramReset RetroProgramReset { get; set; } = null!;
}
