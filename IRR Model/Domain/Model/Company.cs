using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class Company
{
    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string LegalEntCode { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public int SortOrder { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string DefaultEmail { get; set; } = null!;

    public string DefaultDomain { get; set; } = null!;

    public int? DefaultReinsurerId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? LegalRegion { get; set; }

    public virtual ICollection<Office> Offices { get; set; } = new List<Office>();

    public virtual ICollection<Programme> Programs { get; set; } = new List<Programme>();

    public virtual ICollection<RetroProfile> RetroProfiles { get; set; } = new List<RetroProfile>();
}
