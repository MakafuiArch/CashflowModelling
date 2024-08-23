using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class ClientMemo
{
    public int ClientMemoId { get; set; }

    public int? BrokerId { get; set; }

    public string? Conference { get; set; }

    public string? MeetEvent { get; set; }

    public DateTime MeetDate { get; set; }

    public string? BrokerRep { get; set; }

    public string? ArchRep { get; set; }

    public int UserId { get; set; }

    public string? Unit { get; set; }

    public string? Lob { get; set; }

    public string? Location { get; set; }

    public string? LocationFollowup { get; set; }

    public string? MonthFollowup { get; set; }

    public string? Memo { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Broker? Broker { get; set; }

    public virtual ICollection<ClientMemoCedent> ClientMemoCedents { get; set; } = new List<ClientMemoCedent>();

    public virtual ICollection<ClientMemoDoc> ClientMemoDocs { get; set; } = new List<ClientMemoDoc>();

    public virtual User User { get; set; } = null!;
}
