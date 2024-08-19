using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class Dept
{
    public int DeptId { get; set; }

    public string Name { get; set; } = null!;

    public int OfficeId { get; set; }

    public string? RegisId { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? DeptEmail { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;

    public virtual ICollection<Programme> Programs { get; set; } = new List<Programme>();

    public virtual ICollection<RetroProfile> RetroProfiles { get; set; } = new List<RetroProfile>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
