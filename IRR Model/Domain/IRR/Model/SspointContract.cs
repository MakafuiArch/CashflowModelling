using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class SspointContract
{
    public int SspointContractId { get; set; }

    public int ContractId { get; set; }

    public decimal LossRatioFrom { get; set; }

    public decimal LossRatioTo { get; set; }

    public decimal Commission { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
