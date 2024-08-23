using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortLayerCessionDuration
{
    public int PortLayerCessionDurationId { get; set; }

    public int LossView { get; set; }

    public int PortLayerId { get; set; }

    public int RetroProgramId { get; set; }

    public int DayStart { get; set; }

    public int DayEnd { get; set; }

    public double CessionNet { get; set; }

    public double EarnPatternWeightPct { get; set; }

    public virtual PortLayer PortLayer { get; set; } = null!;

    public virtual RetroProgram RetroProgram { get; set; } = null!;
}
