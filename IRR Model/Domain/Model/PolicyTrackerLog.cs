﻿using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PolicyTrackerLog
{
    public int PolicyTrackerLogId { get; set; }

    public string? RegisMkey { get; set; }

    public string? RegisContractId { get; set; }

    public string? UpdatedFields { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
