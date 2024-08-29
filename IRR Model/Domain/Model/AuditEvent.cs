using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class AuditEvent
{
    public int AuditEventId { get; set; }

    public int AuditTxnId { get; set; }

    public int EventType { get; set; }

    public string ObjectType { get; set; } = null!;

    public int ObjectId { get; set; }

    public virtual ICollection<AuditDetail> AuditDetails { get; set; } = new List<AuditDetail>();

    public virtual AuditTxn AuditTxn { get; set; } = null!;
}
