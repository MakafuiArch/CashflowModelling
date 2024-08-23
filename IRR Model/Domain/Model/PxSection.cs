using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class PxSection
{
    public int PxSectionId { get; set; }

    public int RollupOrder { get; set; }

    public int Yltrollup { get; set; }

    public int LayerId { get; set; }

    public int PxLayerId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Layer Layer { get; set; } = null!;

    public virtual Layer PxLayer { get; set; } = null!;
}
