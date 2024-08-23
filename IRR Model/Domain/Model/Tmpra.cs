using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class Tmpra
{
    public long EventId { get; set; }

    public string Peril { get; set; } = null!;

    public int Year { get; set; }

    public short Day { get; set; }

    public string? MajorZone { get; set; }

    public double? Loss { get; set; }

    public double? DefaultMajorZonePct { get; set; }
}
