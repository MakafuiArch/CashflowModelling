using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class VwLayer
{
    public int LayerId { get; set; }

    public int LossAnalysisId { get; set; }

    public decimal? ContractLimitUsd { get; set; }
}
