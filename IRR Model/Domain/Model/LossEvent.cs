using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class LossEvent
{
    public int LossEventId { get; set; }

    public string EventCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string? EventType { get; set; }

    public string? Peril { get; set; }

    public string? Region { get; set; }

    public int? PcscatNum { get; set; }

    public int? AireventId { get; set; }

    public int? RmseventId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? CedentId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int EventYear { get; set; }

    public string IndustryEventCode { get; set; } = null!;

    public virtual Cedent? Cedent { get; set; }

    public virtual ICollection<ExperienceLoss> ExperienceLosses { get; set; } = new List<ExperienceLoss>();

    public virtual ICollection<IndustryLoss> IndustryLosses { get; set; } = new List<IndustryLoss>();
}
