using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PolicyUpdateDetail
{
    public int PolicyUpdateDetailId { get; set; }

    public int PolicyUpdateId { get; set; }

    public string? RevoFieldName { get; set; }

    public int? ChildKey { get; set; }

    public int ChildKeyType { get; set; }

    public string? PreviousValue { get; set; }

    public string? RevisedValue { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PolicyUpdate PolicyUpdate { get; set; } = null!;
}
