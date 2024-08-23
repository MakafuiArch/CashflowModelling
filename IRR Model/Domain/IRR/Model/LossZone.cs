using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class LossZone
{
    public int LossZoneId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TargetPmldef> TargetPmldefs { get; set; } = new List<TargetPmldef>();

    public virtual ICollection<ZoneGeography> ZoneGeographies { get; set; } = new List<ZoneGeography>();
}
