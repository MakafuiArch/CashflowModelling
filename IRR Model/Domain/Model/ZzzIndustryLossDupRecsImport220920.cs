using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class ZzzIndustryLossDupRecsImport220920
{
    public int LossEventId { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? EstType { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int? RecCount { get; set; }
}
