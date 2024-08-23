using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class PresetLdp
{
    public int PresetLdpid { get; set; }

    public string Name { get; set; } = null!;

    public int SortOrder { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<PresetLdpdist> PresetLdpdists { get; set; } = new List<PresetLdpdist>();

    public virtual ICollection<RoeAssumption> RoeAssumptions { get; set; } = new List<RoeAssumption>();
}
