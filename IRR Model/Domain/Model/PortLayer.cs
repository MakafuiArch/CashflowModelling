using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortLayer
{
    public int PortLayerId { get; set; }

    public int LayerId { get; set; }

    public int PortfolioId { get; set; }

    public decimal Share { get; set; }

    public decimal Rol { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public decimal ShareAdjusted { get; set; }

    public decimal Roladjusted { get; set; }

    public decimal Premium { get; set; }

    public decimal PremiumAdjusted { get; set; }

    public bool IsManualAdjustment { get; set; }

    public string? ReasonStale { get; set; }

    public string? PxMessage { get; set; }

    public int JobStatus { get; set; }

    public DateTime? RunStartDate { get; set; }

    public DateTime? RunEndDate { get; set; }

    public decimal Share2Adjusted { get; set; }

    public decimal Rol2adjusted { get; set; }

    public decimal Premium2Adjusted { get; set; }

    public int? PortLayerProjectedCessionPeriodId { get; set; }

    public virtual Layer Layer { get; set; } = null!;

    public virtual ICollection<PortLayerCessionDuration> PortLayerCessionDurations { get; set; } = new List<PortLayerCessionDuration>();

    public virtual ICollection<PortLayerCession> PortLayerCessions { get; set; } = new List<PortLayerCession>();

    public virtual ICollection<PortLayerEarnPattern> PortLayerEarnPatterns { get; set; } = new List<PortLayerEarnPattern>();

    public virtual ICollection<PortLayerFieldSelectionPerTypeResult> PortLayerFieldSelectionPerTypeResults { get; set; } = new List<PortLayerFieldSelectionPerTypeResult>();

    public virtual ICollection<PortLayerLossDuration> PortLayerLossDurations { get; set; } = new List<PortLayerLossDuration>();

    public virtual ICollection<PortLayerPriceResult> PortLayerPriceResults { get; set; } = new List<PortLayerPriceResult>();

    public virtual PortLayerProjectedCessionPeriod? PortLayerProjectedCessionPeriod { get; set; }

    public virtual ICollection<PortPeriodResult> PortPeriodResults { get; set; } = new List<PortPeriodResult>();

    public virtual Portfolio Portfolio { get; set; } = null!;
}
