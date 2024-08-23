using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class Broker
{
    public int BrokerId { get; set; }

    public string Name { get; set; } = null!;

    public int BrokerGroupId { get; set; }

    public string? RegisId { get; set; }

    public string? StreetAddress { get; set; }

    public string? StreetAddress2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Region { get; set; }

    public string? Zip { get; set; }

    public string? Website { get; set; }

    public string? DomicileCountry { get; set; }

    public string? DomicileState { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? ArchAffiliate { get; set; }

    public bool IsApproved { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? ApprovalComments { get; set; }

    public string? IrisbrokerCode { get; set; }

    public virtual ICollection<BrokerContact> BrokerContacts { get; set; } = new List<BrokerContact>();

    public virtual BrokerGroup BrokerGroup { get; set; } = null!;

    public virtual ICollection<ClientMemo> ClientMemos { get; set; } = new List<ClientMemo>();

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();

    public virtual ICollection<RetroCommission> RetroCommissions { get; set; } = new List<RetroCommission>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
