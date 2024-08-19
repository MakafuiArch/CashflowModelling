using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class VwUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? NickName { get; set; }

    public string? Email { get; set; }

    public string Domain { get; set; } = null!;

    public string? Role { get; set; }

    public string? RegisStaffCode { get; set; }

    public string Dept { get; set; } = null!;

    public string Office { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string? OfficeCode { get; set; }

    public string LegalEntCode { get; set; } = null!;

    public int RoleId { get; set; }

    public int OfficeId { get; set; }

    public int CompanyId { get; set; }

    public DateTime CreateDate { get; set; }
}
