using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class LegalTermClause
{
    public int LegalTermClauseId { get; set; }

    public int ContractClauseId { get; set; }

    public int LegalTermsId { get; set; }

    public string? CommentsTa { get; set; }

    public string? CommentsLegal { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool Applicable { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ContractClause ContractClause { get; set; } = null!;

    public virtual LegalTerm LegalTerms { get; set; } = null!;
}
