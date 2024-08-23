using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class IndustryLossFilter
{
    public int IndustryLossFilterId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? SelectedGeographyIds { get; set; }

    public string? PerilCodes { get; set; }

    public int StartYear { get; set; }

    public int EndYear { get; set; }

    public decimal? EventThreshold { get; set; }

    public virtual ICollection<LossEstScenario> LossEstScenarios { get; set; } = new List<LossEstScenario>();
}
