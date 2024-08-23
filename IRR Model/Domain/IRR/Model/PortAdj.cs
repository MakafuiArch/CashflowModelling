using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class PortAdj
{
    public int PortAdjId { get; set; }

    public int PortfolioId { get; set; }

    public string? Name { get; set; }

    public string? FilterString { get; set; }

    public bool IsEnabled { get; set; }

    public int SortOrder { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<PortAdjAction> PortAdjActions { get; set; } = new List<PortAdjAction>();

    public virtual Portfolio Portfolio { get; set; } = null!;
}
