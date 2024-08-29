using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RiskZone
{
    public int RiskZoneId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? RegisId { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string Region { get; set; } = null!;

    public string RegisName { get; set; } = null!;

    public byte[] RowVersion { get; set; } = null!;

    public string? IristerritoryCode { get; set; }

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
