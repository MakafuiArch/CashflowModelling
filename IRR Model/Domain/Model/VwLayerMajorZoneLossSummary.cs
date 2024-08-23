using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class VwLayerMajorZoneLossSummary
{
    public int? LayerMajorZoneLossSummaryId { get; set; }

    public int LayerId { get; set; }

    public int MajorZoneId { get; set; }

    public int LossView { get; set; }

    public double El { get; set; }
}
