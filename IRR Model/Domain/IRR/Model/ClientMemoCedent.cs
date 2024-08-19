using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class ClientMemoCedent
{
    public int ClientMemoCedentId { get; set; }

    public int ClientMemoId { get; set; }

    public int CedentId { get; set; }

    public string? ClientRep { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Cedent Cedent { get; set; } = null!;

    public virtual ClientMemo ClientMemo { get; set; } = null!;
}
