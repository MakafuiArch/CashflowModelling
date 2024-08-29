using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class UserSubscription
{
    public int UserSubscriptionId { get; set; }

    public int SubscriptionId { get; set; }

    public int? UserId { get; set; }

    public string? Email { get; set; }

    public string? FilterCriteria { get; set; }

    public int ReceiveAs { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Subscription Subscription { get; set; } = null!;

    public virtual User? User { get; set; }
}
