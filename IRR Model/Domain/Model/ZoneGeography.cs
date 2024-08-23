using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class ZoneGeography
{
    public int ZoneGeographyId { get; set; }

    public int ZoneDefinitionId { get; set; }

    public int GeographyId { get; set; }

    public string? Peril { get; set; }

    public int LossZoneId { get; set; }

    public int MajorZoneId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Geography Geography { get; set; } = null!;

    public virtual LossZone LossZone { get; set; } = null!;

    public virtual MajorZone MajorZone { get; set; } = null!;

    public virtual ZoneDefinition ZoneDefinition { get; set; } = null!;
}
