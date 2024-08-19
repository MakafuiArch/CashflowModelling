using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class Cedent
{
    public int CedentId { get; set; }

    public string Name { get; set; } = null!;

    public int CedentGroupId { get; set; }

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

    public string? FormerName { get; set; }

    public DateTime? NameChangeDate { get; set; }

    public string? Notes { get; set; }

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

    public virtual ICollection<CedentContact> CedentContacts { get; set; } = new List<CedentContact>();

    public virtual CedentGroup CedentGroup { get; set; } = null!;

    public virtual ICollection<ClientMemoCedent> ClientMemoCedents { get; set; } = new List<ClientMemoCedent>();

    public virtual ICollection<LossEvent> LossEvents { get; set; } = new List<LossEvent>();

    public virtual ICollection<Programme> ProgramCedents { get; set; } = new List<Programme>();

    public virtual ICollection<Programme> ProgramReinsurers { get; set; } = new List<Programme>();

    public virtual ICollection<Spinsurer> Spinsurers { get; set; } = new List<Spinsurer>();
}
