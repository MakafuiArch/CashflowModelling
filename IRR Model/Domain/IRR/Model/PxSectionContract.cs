using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PxSectionContract
{
    public int PxSectionContractId { get; set; }

    public int ContractId { get; set; }

    public int RollupOrder { get; set; }

    public string? Yltrollup { get; set; }

    public int LayerId { get; set; }

    public string? LayerName { get; set; }

    public int PxLayerId { get; set; }

    public string? PxLayerName { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
