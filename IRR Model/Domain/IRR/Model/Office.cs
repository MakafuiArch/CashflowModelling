using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class Office
{
    public int OfficeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public int CompanyId { get; set; }

    public string? RegisId { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Dept> Depts { get; set; } = new List<Dept>();

    public virtual ICollection<Programme> Programs { get; set; } = new List<Programme>();

    public virtual ICollection<RetroProfile> RetroProfiles { get; set; } = new List<RetroProfile>();
}
