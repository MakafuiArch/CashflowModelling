using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class ProgramRoeResult
{
    public int ProgramRoeResultId { get; set; }

    public int SubmissionId { get; set; }

    public int LossView { get; set; }

    public double? CatPml { get; set; }

    public double? CatPmlAuth { get; set; }

    public double? CatPmlQuote { get; set; }

    public double? StandaloneRoe { get; set; }

    public double? StandaloneRoeauth { get; set; }

    public double? StandaloneRoequote { get; set; }

    public double? StandaloneCapital { get; set; }

    public double? StandaloneCapitalAuth { get; set; }

    public double? StandaloneCapitalQuote { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Submission Submission { get; set; } = null!;
}
