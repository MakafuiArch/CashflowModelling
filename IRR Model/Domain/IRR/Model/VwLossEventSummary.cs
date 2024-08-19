using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class VwLossEventSummary
{
    public int LossEventId { get; set; }

    public string? GeographyIds { get; set; }

    public string EventCode { get; set; } = null!;

    public string IndustryEventCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public int EventYear { get; set; }

    public string? Peril { get; set; }

    public string? Region { get; set; }

    public int? PcscatNum { get; set; }

    public string? Currency { get; set; }

    public DateTime ModifyDate { get; set; }

    public double? IndustryLoss { get; set; }

    public DateTime? ValuationDate { get; set; }
}
