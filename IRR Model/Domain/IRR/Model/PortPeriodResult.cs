using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PortPeriodResult
{
    public int PortPeriodResultId { get; set; }

    public int PortLayerId { get; set; }

    public DateTime InforceInception { get; set; }

    public DateTime InforceExpiration { get; set; }

    public DateTime Next12Inception { get; set; }

    public DateTime Next12Expiration { get; set; }

    public DateTime CurrentYearInception { get; set; }

    public DateTime CurrentYearExpiration { get; set; }

    public DateTime NextYearInception { get; set; }

    public DateTime NextYearExpiration { get; set; }

    public virtual PortLayer PortLayer { get; set; } = null!;
}
