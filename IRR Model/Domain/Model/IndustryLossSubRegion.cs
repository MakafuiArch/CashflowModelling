using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class IndustryLossSubRegion
{
    public int IndustryLossSubRegionId { get; set; }

    public int IndustryLossRegionId { get; set; }

    public int GeographyId { get; set; }

    public string? Name { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Geography Geography { get; set; } = null!;

    public virtual IndustryLossRegion IndustryLossRegion { get; set; } = null!;

    public virtual ICollection<MarketShareFactor> MarketShareFactors { get; set; } = new List<MarketShareFactor>();
}
