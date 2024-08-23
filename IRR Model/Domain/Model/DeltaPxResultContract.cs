using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class DeltaPxResultContract
{
    public int DeltaPxResultContractId { get; set; }

    public int ContractId { get; set; }

    public int PortfolioId { get; set; }

    public string? PortfolioName { get; set; }

    public string? LossView { get; set; }

    public string? ReasonStale { get; set; }

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

    public double? GrossRoevarCorre { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public double? NetMinCapitalVar { get; set; }

    public double? NetMinRoevar { get; set; }

    public double? MaxCatPts { get; set; }

    public double? NetRoetvar { get; set; }

    public double? NetCapitalTvar { get; set; }

    public double? GrossCatPmlVarArl { get; set; }

    public double? GrossCatPmlTvarArl { get; set; }

    public double? NetCatPmlArl { get; set; }

    public double? NetCatPmlTvarArl { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
