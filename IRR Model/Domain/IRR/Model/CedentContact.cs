using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class CedentContact
{
    public int CedentContactId { get; set; }

    public int CedentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Cell { get; set; }

    public string? Email { get; set; }

    public string? Events { get; set; }

    public string? Interests { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Cedent Cedent { get; set; } = null!;

    public virtual ICollection<Submission> SubmissionGroupBuyers { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionLocalBuyers { get; set; } = new List<Submission>();
}
