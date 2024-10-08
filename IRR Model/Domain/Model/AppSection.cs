﻿using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class AppSection
{
    public int AppSectionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? DataType { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsEditable { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AppPref> AppPrefs { get; set; } = new List<AppPref>();
}
