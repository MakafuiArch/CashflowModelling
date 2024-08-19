using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class TopUpZoneGeoMap
{
    public int TopUpZoneGeoMapId { get; set; }

    public int TopUpZoneId { get; set; }

    public string? GeoLevelCode { get; set; }

    public string? CountryCode { get; set; }

    public string? AreaCode { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual TopUpZone TopUpZone { get; set; } = null!;
}
