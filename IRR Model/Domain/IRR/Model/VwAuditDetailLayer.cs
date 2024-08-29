using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class VwAuditDetailLayer
{
    public int AuditTxnId { get; set; }

    public string Username { get; set; } = null!;

    public DateTime Date { get; set; }

    public string ServerName { get; set; } = null!;

    public int AuditEventId { get; set; }

    public int EventType { get; set; }

    public int LayerId { get; set; }

    public int AuditDetailId { get; set; }

    public string Property { get; set; } = null!;

    public string? OrigValue { get; set; }

    public string? NewValue { get; set; }
}
