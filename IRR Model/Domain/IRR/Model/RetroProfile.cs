using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RetroProfile
{
    public int RetroProfileId { get; set; }

    public string Name { get; set; } = null!;

    public string? RegisId { get; set; }

    public int ManagerId { get; set; }

    public int CompanyId { get; set; }

    public int OfficeId { get; set; }

    public int DeptId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual Dept Dept { get; set; } = null!;

    public virtual User Manager { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;

    public virtual ICollection<RetroProgram> RetroPrograms { get; set; } = new List<RetroProgram>();
}
