using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class MajorZone
{
    public int MajorZoneId { get; set; }

    public string? Name { get; set; }

    public double StdvFactor { get; set; }

    public virtual ICollection<ZoneGeography> ZoneGeographies { get; set; } = new List<ZoneGeography>();
}
