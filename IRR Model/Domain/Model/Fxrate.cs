﻿using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class Fxrate
{
    public int FxrateId { get; set; }

    public string BaseCurrency { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public DateTime Fxdate { get; set; }

    public decimal Rate { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;
}
