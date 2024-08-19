using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PortProjectedRetro
{
    public int PortProjectedRetroId { get; set; }

    public int PortfolioId { get; set; }

    public int RetroProgramId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual RetroProgram RetroProgram { get; set; } = null!;
}
