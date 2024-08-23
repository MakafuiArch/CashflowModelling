using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class GuCurveAdjPmlSrc
{
    public int GuCurveAdjPmlSrcId { get; set; }

    public int GuCurveAdjDefId { get; set; }

    public int ReturnPeriod { get; set; }

    public double Oep { get; set; }

    public double Aep { get; set; }

    public string? Peril { get; set; }

    public double FrequencyFactor { get; set; }

    public double SeverityFactor { get; set; }

    public string? MajorZone { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual GuCurveAdjDef GuCurveAdjDef { get; set; } = null!;
}
