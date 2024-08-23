using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortLayerProjectedCessionPeriod
{
    public int PortLayerProjectedCessionPeriodId { get; set; }

    public DateTime Projected1OrigInception { get; set; }

    public DateTime Projected1Expiration { get; set; }

    public DateTime Projected2OrigInception { get; set; }

    public DateTime Projected2Expiration { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<PortLayer> PortLayers { get; set; } = new List<PortLayer>();
}
