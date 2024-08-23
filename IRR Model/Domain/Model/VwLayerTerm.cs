using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class VwLayerTerm
{
    public int LayerId { get; set; }

    public int SubmissionId { get; set; }

    public decimal? ContractLimit { get; set; }

    public decimal OccLimit { get; set; }

    public decimal OccRetention { get; set; }

    public decimal AggLimit { get; set; }

    public decimal AggRetention { get; set; }

    public decimal SignedShare { get; set; }

    public decimal Rol { get; set; }

    public decimal Premium { get; set; }

    public string Currency { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public decimal Fxrate { get; set; }

    public int LimitBasis { get; set; }

    public decimal Placement { get; set; }

    public decimal QuoteRol { get; set; }

    public decimal QuotePremium { get; set; }

    public decimal QuotedShare { get; set; }

    public DateTime Inception { get; set; }

    public DateTime Expiration { get; set; }

    public int Status { get; set; }

    public decimal? NotionalLimit { get; set; }

    public decimal? NotionalRol { get; set; }
}
