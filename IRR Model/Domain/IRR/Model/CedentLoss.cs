using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class CedentLoss
{
    public int CedentLossId { get; set; }

    public int LossEventId { get; set; }

    public int SubmissionId { get; set; }

    public string? Division { get; set; }

    public string? Product { get; set; }

    public string? Region { get; set; }

    public string? Country { get; set; }

    public string? Currency { get; set; }

    public DateTime ValuationDate { get; set; }

    public double PaidLoss { get; set; }

    public bool IsOpen { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public double IncurredLoss { get; set; }

    public int? ClaimCount { get; set; }

    public string? Notes { get; set; }

    public byte[] RowVersion { get; set; } = null!;
}
