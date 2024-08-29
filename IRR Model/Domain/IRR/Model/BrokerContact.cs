using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class BrokerContact
{
    public int BrokerContactId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? PhoneCell { get; set; }

    public string? Email { get; set; }

    public string? EmailPers { get; set; }

    public int BrokerId { get; set; }

    public string? RegisId { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Broker Broker { get; set; } = null!;

    public virtual ICollection<RetroCommission> RetroCommissions { get; set; } = new List<RetroCommission>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
