using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class RetroDoc
{
    public int RetroDocId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? DocType { get; set; }

    public int RetroProgramId { get; set; }

    public int DbfileId { get; set; }

    public bool IsFinal { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Dbfile Dbfile { get; set; } = null!;

    public virtual RetroProgram RetroProgram { get; set; } = null!;
}
