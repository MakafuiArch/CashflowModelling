using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class RetroFacilityOverride
{
    public int RetroFacilityOverrideId { get; set; }

    public int RetroInvestorId { get; set; }

    public string Facility { get; set; } = null!;

    public decimal Cession { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual RetroInvestor RetroInvestor { get; set; } = null!;
}
