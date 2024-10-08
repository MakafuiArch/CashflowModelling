﻿using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortLayerLossDuration
{
    public int PortLayerLossDurationId { get; set; }

    public int PortLayerId { get; set; }

    public int LossView { get; set; }

    public int Type { get; set; }

    public int DayStart { get; set; }

    public int DayEnd { get; set; }

    public virtual PortLayer PortLayer { get; set; } = null!;
}
