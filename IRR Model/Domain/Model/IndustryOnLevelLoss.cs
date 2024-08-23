using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class IndustryOnLevelLoss
{
    public int IndustryOnLevelLossId { get; set; }

    public int IndustryLossId { get; set; }

    public DateTime OnLevelDate { get; set; }

    public double OnLevelLoss { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual IndustryLoss IndustryLoss { get; set; } = null!;
}
