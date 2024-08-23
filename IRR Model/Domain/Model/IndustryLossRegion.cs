using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class IndustryLossRegion
{
    public int IndustryLossRegionId { get; set; }

    public string? Name { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<IndustryLossSubRegion> IndustryLossSubRegions { get; set; } = new List<IndustryLossSubRegion>();
}
