using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class VwRolePermission
{
    public int RoleId { get; set; }

    public string? UserRole { get; set; }

    public int State { get; set; }

    public string PermissionState { get; set; } = null!;

    public string? Permission { get; set; }

    public string? PermissionDesc { get; set; }

    public int AccessLevel { get; set; }

    public int RolePermissionId { get; set; }

    public int PermissionId { get; set; }
}
