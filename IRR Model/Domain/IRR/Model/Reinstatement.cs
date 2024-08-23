using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class Reinstatement
{
    public int ReinstatementId { get; set; }

    public int LayerId { get; set; }

    public int Order { get; set; }

    public int Quantity { get; set; }

    public decimal Premium { get; set; }

    public decimal Brokerage { get; set; }

    public string? Description { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsProRata { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Layer Layer { get; set; } = null!;
}
