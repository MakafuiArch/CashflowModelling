using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class PremiumSurplusRatio
{
    public int PremiumSurplusId { get; set; }

    public decimal Rol { get; set; }

    public decimal SurplusRatio { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
