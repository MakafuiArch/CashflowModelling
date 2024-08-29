using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class VwLayer
{
    public int LayerId { get; set; }

    public int LossAnalysisId { get; set; }

    public decimal? ContractLimitUsd { get; set; }
}
