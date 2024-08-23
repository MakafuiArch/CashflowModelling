using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class CedentGroup
{
    public int CedentGroupId { get; set; }

    public string Name { get; set; } = null!;

    public string? RegisId { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Cedent> Cedents { get; set; } = new List<Cedent>();
}
