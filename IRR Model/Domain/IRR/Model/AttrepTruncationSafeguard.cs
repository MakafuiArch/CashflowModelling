using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class AttrepTruncationSafeguard
{
    public string LatchTaskName { get; set; } = null!;

    public string LatchMachineGuid { get; set; } = null!;

    public string LatchKey { get; set; } = null!;

    public DateTime LatchLocker { get; set; }
}
