using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class LossViewResultContract
{
    public int LossViewResultContractId { get; set; }

    public int ContractId { get; set; }

    public string? LossView { get; set; }

    public double? Rp { get; set; }

    public double? El { get; set; }

    public double? Elamount { get; set; }

    public double? Elatt { get; set; }

    public double? EllargeLoss { get; set; }

    public double? Elmodeled { get; set; }

    public double? ElnonModeled { get; set; }

    public double? StdvAdj { get; set; }

    public double? Rb { get; set; }

    public double? ProfitComm { get; set; }

    public double? Ncbcomm { get; set; }

    public double? Sscomm { get; set; }

    public double? TotalExp { get; set; }

    public double? Er { get; set; }

    public double? TotalPremium { get; set; }

    public double? ReinstPremAmount { get; set; }

    public double? Ptm { get; set; }

    public double? Lr { get; set; }

    public double? Lratt { get; set; }

    public double? LrlargeLoss { get; set; }

    public double? Lrmodeled { get; set; }

    public double? LrnonModeled { get; set; }

    public double? Cr { get; set; }

    public double? StandaloneCapital { get; set; }

    public double? StandaloneRoe { get; set; }

    public double? StandaloneRoecorre { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public double? CatPml { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
