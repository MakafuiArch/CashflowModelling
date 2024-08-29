using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class ClientMemoDoc
{
    public int ClientMemoDocId { get; set; }

    public string? Name { get; set; }

    public int ClientMemoId { get; set; }

    public int DbfileId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ClientMemo ClientMemo { get; set; } = null!;

    public virtual Dbfile Dbfile { get; set; } = null!;
}
