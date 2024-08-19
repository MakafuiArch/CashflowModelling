using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class AuditDetail
{
    public int AuditDetailId { get; set; }

    public int AuditEventId { get; set; }

    public string Property { get; set; } = null!;

    public string? OrigValue { get; set; }

    public string? NewValue { get; set; }

    public virtual AuditEvent AuditEvent { get; set; } = null!;
}
