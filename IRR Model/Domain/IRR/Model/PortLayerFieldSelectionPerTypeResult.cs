using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PortLayerFieldSelectionPerTypeResult
{
    public int PortLayerFieldSelectionPerTypeResultId { get; set; }

    public int PortLayerId { get; set; }

    public int Inforce { get; set; }

    public int Next12 { get; set; }

    public int CurrentYear { get; set; }

    public int NextYear { get; set; }

    public virtual PortLayer PortLayer { get; set; } = null!;
}
