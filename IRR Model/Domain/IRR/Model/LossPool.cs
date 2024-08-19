using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class LossPool
{
    public int LossPoolId { get; set; }

    public string? Name { get; set; }

    public string? LegalEntity { get; set; }

    public string? StateCode { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<PoolGuAnalysis> PoolGuAnalyses { get; set; } = new List<PoolGuAnalysis>();
}
