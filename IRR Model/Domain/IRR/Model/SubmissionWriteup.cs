using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class SubmissionWriteup
{
    public int SubmissionWriteupId { get; set; }

    public string? RiskFlowNotes { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[]? SpreadsheetData { get; set; }

    public byte[]? UwspreadsheetData { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
