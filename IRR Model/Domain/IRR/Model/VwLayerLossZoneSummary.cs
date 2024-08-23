using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class VwLayerLossZoneSummary
{
    public int? LayerLossZoneSummaryId { get; set; }

    public int LayerId { get; set; }

    public int LossZoneId { get; set; }

    public int LossView { get; set; }

    public double El { get; set; }
}
