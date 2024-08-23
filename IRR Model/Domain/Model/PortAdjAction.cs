using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PortAdjAction
{
    public int PortAdjActionId { get; set; }

    public int PortAdjId { get; set; }

    public int ActionType { get; set; }

    public string? Prop { get; set; }

    public string? StringParam { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PortAdj PortAdj { get; set; } = null!;
}
