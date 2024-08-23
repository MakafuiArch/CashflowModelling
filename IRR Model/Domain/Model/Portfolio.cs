using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class Portfolio
{
    public int PortfolioId { get; set; }

    public string? Name { get; set; }

    public int Uwyear { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int PortfolioType { get; set; }

    public string? Notes { get; set; }

    public DateTime? LastPricedDate { get; set; }

    public string? LastPricedUser { get; set; }

    public int LossView { get; set; }

    public string Currency { get; set; } = null!;

    public DateTime Fxdate { get; set; }

    public int JobStatus { get; set; }

    public DateTime? RunStartDate { get; set; }

    public DateTime? RunEndDate { get; set; }

    public string? JobId { get; set; }

    public string? JobMessage { get; set; }

    public DateTime CessionAsOfDate { get; set; }

    public double GrossRoe { get; set; }

    public double GrossCapital { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime Inception { get; set; }

    public DateTime Expiration { get; set; }

    public int Attachment { get; set; }

    public int EarningType { get; set; }

    public string? FilterString { get; set; }

    public string? RetroProgramIds { get; set; }

    public bool HasRetroSelection { get; set; }

    public bool UseCessionGross { get; set; }

    public bool ShouldStorePortfolioYelt { get; set; }

    public bool ShouldStorePortfolioYlt { get; set; }

    public bool ShouldStorePortMetricYlt { get; set; }

    public bool IsVerboseLoggingEnabled { get; set; }

    public DateTime AsOfDate { get; set; }

    public bool UseRevised { get; set; }

    public virtual ICollection<PortAdj> PortAdjs { get; set; } = new List<PortAdj>();

    public virtual ICollection<PortLayer> PortLayers { get; set; } = new List<PortLayer>();

    public virtual ICollection<PortMetric> PortMetrics { get; set; } = new List<PortMetric>();

    public virtual ICollection<PortProjectedRetro> PortProjectedRetros { get; set; } = new List<PortProjectedRetro>();

    public virtual ICollection<PortRoeResult> PortRoeResults { get; set; } = new List<PortRoeResult>();

    public virtual ICollection<PortfolioFx> PortfolioFxes { get; set; } = new List<PortfolioFx>();

    public virtual ICollection<SubmissionPxPortfolio> SubmissionPxPortfolios { get; set; } = new List<SubmissionPxPortfolio>();
}
