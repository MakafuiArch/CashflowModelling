using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class ContractClause
{
    public int ContractClauseId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Desc { get; set; }

    public int ClauseType { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<LegalTermClause> LegalTermClauses { get; set; } = new List<LegalTermClause>();
}
