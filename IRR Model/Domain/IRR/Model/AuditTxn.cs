using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class AuditTxn
{
    public int AuditTxnId { get; set; }

    public string Username { get; set; } = null!;

    public DateTime Date { get; set; }

    public string ServerName { get; set; } = null!;

    public virtual ICollection<AuditEvent> AuditEvents { get; set; } = new List<AuditEvent>();
}
