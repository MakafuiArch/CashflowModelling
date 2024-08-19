using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RetroProgramReset
{
    public int RetroProgramResetId { get; set; }

    public int RetroProgramId { get; set; }

    public DateTime StartDate { get; set; }

    public decimal TargetCollateral { get; set; }

    public decimal TargetPremium { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<RetroInvestorReset> RetroInvestorResets { get; set; } = new List<RetroInvestorReset>();

    public virtual RetroProgram RetroProgram { get; set; } = null!;
}
