using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class Rcsspoint
{
    public int RcsspointId { get; set; }

    public int RetroCommissionId { get; set; }

    public decimal LossRatioFrom { get; set; }

    public decimal LossRatioTo { get; set; }

    public decimal Commission { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual RetroCommission RetroCommission { get; set; } = null!;
}
