using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class UserLayout
{
    public int UserLayoutId { get; set; }

    public string? Name { get; set; }

    public string? Layout { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
