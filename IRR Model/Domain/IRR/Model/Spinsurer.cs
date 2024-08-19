using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class Spinsurer
{
    public int SpinsurerId { get; set; }

    public int RetroProgramId { get; set; }

    public string SegregatedAccount { get; set; } = null!;

    public string? ContractId { get; set; }

    public int InsurerId { get; set; }

    public string? TrustBank { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? TrustAccountNumber { get; set; }

    public string? FundsWithheldAccountNumber { get; set; }

    public DateTime? InitialCommutationDate { get; set; }

    public DateTime? FinalCommutationDate { get; set; }

    public virtual Cedent Insurer { get; set; } = null!;

    public virtual ICollection<RetroInvestor> RetroInvestors { get; set; } = new List<RetroInvestor>();

    public virtual RetroProgram RetroProgram { get; set; } = null!;
}
