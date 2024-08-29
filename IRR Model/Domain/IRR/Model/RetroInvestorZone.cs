using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RetroInvestorZone
{
    public int RetroInvestorZoneId { get; set; }

    public int RetroInvestorId { get; set; }

    public DateTime StartDate { get; set; }

    public int TopUpZoneId { get; set; }

    public double CessionCapInitial { get; set; }

    public double CessionCapAdjusted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RetroInvestor RetroInvestor { get; set; } = null!;
}
