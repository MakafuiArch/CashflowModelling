using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class RetroBufferByEvent
{
    public int RetroBufferByEventId { get; set; }

    public int RetroInvestorId { get; set; }

    public int SortIndex { get; set; }

    public int DayStart { get; set; }

    public int DayEnd { get; set; }

    public string? EventType { get; set; }

    public double MultiplierPct { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RetroInvestor RetroInvestor { get; set; } = null!;
}
