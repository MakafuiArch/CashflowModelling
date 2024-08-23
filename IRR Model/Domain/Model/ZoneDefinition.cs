using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class ZoneDefinition
{
    public int ZoneDefinitionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<GuAnalysis> GuAnalyses { get; set; } = new List<GuAnalysis>();

    public virtual ICollection<ZoneGeography> ZoneGeographies { get; set; } = new List<ZoneGeography>();
}
