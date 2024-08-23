using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class Doc
{
    public int DocId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? DocType { get; set; }

    public int SubmissionId { get; set; }

    public int DbfileId { get; set; }

    public bool IsFinal { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? Category { get; set; }

    public string? Layers { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool IsStale { get; set; }

    public virtual ICollection<ContractBinder> ContractBinders { get; set; } = new List<ContractBinder>();

    public virtual Submission Submission { get; set; } = null!;
}
