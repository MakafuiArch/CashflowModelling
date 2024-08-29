using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortLayerEarnPattern
{
    public int PortLayerEarnPatternId { get; set; }

    public int PortLayerId { get; set; }

    public int LossView { get; set; }

    public short Day { get; set; }

    public double OccLoss { get; set; }

    public virtual PortLayer PortLayer { get; set; } = null!;
}
