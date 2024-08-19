using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class Dbfile
{
    public int DbfileId { get; set; }

    public string? Name { get; set; }

    public byte[]? FileData { get; set; }

    public virtual ICollection<ClientMemoDoc> ClientMemoDocs { get; set; } = new List<ClientMemoDoc>();

    public virtual ICollection<RetroDoc> RetroDocs { get; set; } = new List<RetroDoc>();
}
