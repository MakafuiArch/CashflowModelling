using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class Geography
{
    public int GeographyId { get; set; }

    public int? ParentGeographyId { get; set; }

    public string? GeoLevelCode { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public string? Crestacode { get; set; }

    public string? Crestaname { get; set; }

    public string? AreaCode { get; set; }

    public string? AreaName { get; set; }

    public string? SubareaCode { get; set; }

    public string? SubareaName { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? CityName { get; set; }

    public virtual ICollection<ExperienceLoss> ExperienceLosses { get; set; } = new List<ExperienceLoss>();

    public virtual ICollection<IndustryLossSubRegion> IndustryLossSubRegions { get; set; } = new List<IndustryLossSubRegion>();

    public virtual ICollection<IndustryLoss> IndustryLosses { get; set; } = new List<IndustryLoss>();

    public virtual ICollection<Geography> InverseParentGeography { get; set; } = new List<Geography>();

    public virtual Geography? ParentGeography { get; set; }

    public virtual ICollection<ZoneGeography> ZoneGeographies { get; set; } = new List<ZoneGeography>();
}
