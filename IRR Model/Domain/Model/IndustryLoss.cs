using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class IndustryLoss
{
    public int IndustryLossId { get; set; }

    public int LossEventId { get; set; }

    public string? Source { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? Currency { get; set; }

    public string? EstType { get; set; }

    public double EstInsPmt { get; set; }

    public double? ComAvgPmt { get; set; }

    public double? ComLoss { get; set; }

    public double? ComClaimCount { get; set; }

    public double? PersLoss { get; set; }

    public double? PersClaimCount { get; set; }

    public double? PersAvgPmt { get; set; }

    public double? AutoClaimCount { get; set; }

    public double? AutoAvgPmt { get; set; }

    public double? AutoLoss { get; set; }

    public double? WcclaimCount { get; set; }

    public double? WcavgPmt { get; set; }

    public double? Wcloss { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public int? JobId { get; set; }

    public int GeographyId { get; set; }

    public DateTime OnLevelDate { get; set; }

    public double OnLevelLoss { get; set; }

    public virtual Geography Geography { get; set; } = null!;

    public virtual ICollection<IndustryOnLevelLoss> IndustryOnLevelLosses { get; set; } = new List<IndustryOnLevelLoss>();

    public virtual LossEvent LossEvent { get; set; } = null!;

    public virtual ICollection<MarketShareLoss> MarketShareLosses { get; set; } = new List<MarketShareLoss>();
}
