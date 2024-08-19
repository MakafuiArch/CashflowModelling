using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class VwLayerLossSummary
{
    public int LayerLossSummaryId { get; set; }

    public double? ArlEl { get; set; }

    public double? AirEl { get; set; }

    public double? RmsEl { get; set; }

    public double? Lr { get; set; }

    public double? Er { get; set; }

    public double? Cr { get; set; }

    public double? ExpectedRpamt { get; set; }

    public double? ExpectedRp { get; set; }

    public double? Rb { get; set; }

    public double? StandaloneRoe { get; set; }

    public double? GrossRoevarSigned { get; set; }

    public double? NetRoevarSigned { get; set; }
}
