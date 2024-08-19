
namespace CashflowModelling.Domain.IRR.Model;

public partial class Programme
{
    public int ProgramId { get; set; }

    public int CedentId { get; set; }

    public bool IsFac { get; set; }

    public string? RegisId { get; set; }

    public string? RegisNbr { get; set; }

    public string? Name { get; set; }

    public string FacilityDefault { get; set; } = null!;

    public string SegmentDefault { get; set; } = null!;

    public string Lobdefault { get; set; } = null!;

    public int ContractTypeDefault { get; set; }

    public int LimitBasisDefault { get; set; }

    public string? ExtName { get; set; }

    public string? Notes { get; set; }

    public int CompanyId { get; set; }

    public int OfficeId { get; set; }

    public int DeptId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int ReinsurerId { get; set; }

    public string? Insured { get; set; }

    public int InsType { get; set; }

    public bool QsofXs { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int? Occupancy { get; set; }

    public virtual Cedent Cedent { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual Dept Dept { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;

    public virtual Cedent Reinsurer { get; set; } = null!;

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
