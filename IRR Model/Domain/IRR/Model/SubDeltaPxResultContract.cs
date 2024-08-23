using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class SubDeltaPxResultContract
{
    public int SubDeltaPxResultContractId { get; set; }

    public int ContractBinderId { get; set; }

    public int PortfolioId { get; set; }

    public string? PortfolioName { get; set; }

    public string? LossView { get; set; }

    public double? GrossCapitalVar { get; set; }

    public double? NetCapitalVar { get; set; }

    public double? NetExcessReturn { get; set; }

    public double? NetExcessReturnWithFees { get; set; }

    public double? GrossCapitalTvar { get; set; }

    public double? GrossRoevar { get; set; }

    public double? NetRoevar { get; set; }

    public double? NetRoevarWithFees { get; set; }

    public double? GrossRoetvar { get; set; }

    public double? TargetRoe { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ContractBinder ContractBinder { get; set; } = null!;
}
