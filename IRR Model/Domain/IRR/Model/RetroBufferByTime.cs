using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RetroBufferByTime
{
    public int RetroBufferByTimeId { get; set; }

    public int RetroInvestorId { get; set; }

    public int Period { get; set; }

    public DateTime PeriodStart { get; set; }

    public DateTime PeriodEnd { get; set; }

    public double BufferPct { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RetroInvestor RetroInvestor { get; set; } = null!;
}
