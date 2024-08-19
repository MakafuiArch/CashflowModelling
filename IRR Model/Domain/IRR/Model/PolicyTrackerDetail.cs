using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PolicyTrackerDetail
{
    public int PolicyTrackerDetailId { get; set; }

    public int PolicyTrackerId { get; set; }

    public string? RevoFieldName { get; set; }

    public int? ChildKey { get; set; }

    public int ChildKeyType { get; set; }

    public string? FieldName { get; set; }

    public string? FieldValueNew { get; set; }

    public string? ChangeUser { get; set; }

    public DateTime ChangeDate { get; set; }

    public int PolicyTrackerDetailStatus { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PolicyTracker PolicyTracker { get; set; } = null!;
}
