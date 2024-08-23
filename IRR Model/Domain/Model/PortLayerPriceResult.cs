using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortLayerPriceResult
{
    public int PortLayerPriceResultId { get; set; }

    public int PortLayerId { get; set; }

    public int LossView { get; set; }

    public double? EarnPatternPctInforce { get; set; }

    public double? EarnPatternPctProjected { get; set; }

    public double? EarnPatternPctProjected2 { get; set; }

    public virtual PortLayer PortLayer { get; set; } = null!;
}
