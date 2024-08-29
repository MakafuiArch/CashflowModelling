using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class MultiyearShare
{
    public int MultiyearShareId { get; set; }

    public int LayerId { get; set; }

    public int Uwyear { get; set; }

    public DateTime Inception { get; set; }

    public decimal Placement { get; set; }

    public decimal EstimatedShare { get; set; }

    public decimal SignedShare { get; set; }

    public decimal AuthShare { get; set; }

    public decimal QuotedShare { get; set; }

    public decimal Rol { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int BindYear { get; set; }

    public decimal Premium { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Layer Layer { get; set; } = null!;
}
