using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortRoeResult
{
    public int PortRoeResultId { get; set; }

    public int LayerId { get; set; }

    public int PortfolioId { get; set; }

    public double? GrossCapitalVar { get; set; }

    public double? NetCapitalVar { get; set; }

    public double? NetExcessReturn { get; set; }

    public double? NetExcessReturnWithFees { get; set; }

    public double? GrossCapitalTvar { get; set; }

    public double? GrossRoevar { get; set; }

    public double? NetRoevar { get; set; }

    public double? NetRoevarWithFees { get; set; }

    public double? GrossRoetvar { get; set; }

    public double? GrossCatPmlVarArl { get; set; }

    public double? NetCatPmlArl { get; set; }

    public double? GrossCatPmlTvarArl { get; set; }

    public double? TargetRoe { get; set; }

    public string? Message { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Layer Layer { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;
}
