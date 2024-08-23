using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class VwUserImplicitPermission
{
    public string Username { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string Dept { get; set; } = null!;

    public string Office { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string LegalEntCode { get; set; } = null!;

    public string? Role { get; set; }

    public string? Permission { get; set; }

    public string? PermissionDesc { get; set; }

    public string PermissionState { get; set; } = null!;

    public int PermissionId { get; set; }

    public int UserId { get; set; }
}
