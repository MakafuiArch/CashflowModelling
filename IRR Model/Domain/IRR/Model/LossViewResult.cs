using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class LossViewResult
{
    public int LossViewResultId { get; set; }

    public int LayerId { get; set; }

    public int LossView { get; set; }

    public double? Rp { get; set; }

    public double? El { get; set; }

    public double? Elatt { get; set; }

    public double? EllargeLoss { get; set; }

    public double? Elmodeled { get; set; }

    public double? ElnonModeled { get; set; }

    public double? StdvAdj { get; set; }

    public double? Ptm { get; set; }

    public double? Ptmquote { get; set; }

    public double? Lr { get; set; }

    public double? Lratt { get; set; }

    public double? LrlargeLoss { get; set; }

    public double? Lrmodeled { get; set; }

    public double? LrnonModeled { get; set; }

    public double? Cr { get; set; }

    public double? Rb { get; set; }

    public double? ProfitComm { get; set; }

    public double? Ncbcomm { get; set; }

    public double? Sscomm { get; set; }

    public double? TotalExp { get; set; }

    public double? CatPml { get; set; }

    public double? StandaloneCapital { get; set; }

    public double? StandaloneRoe { get; set; }

    public double? StandaloneRoequote { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public double? CatPmlQuote { get; set; }

    public double? StandaloneRoecorreAuth { get; set; }

    public double? StandaloneRoecorreQuote { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Layer Layer { get; set; } = null!;
}
