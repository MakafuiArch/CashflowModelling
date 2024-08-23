using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class NotificationEvent
{
    public int NotificationEventId { get; set; }

    public string? Description { get; set; }

    public int EventLevel { get; set; }

    public string? AlertRule { get; set; }

    public int EventType { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
