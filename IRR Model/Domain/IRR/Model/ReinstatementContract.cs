using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class ReinstatementContract
{
    public int ReinstatementContractId { get; set; }

    public int ContractId { get; set; }

    public int Order { get; set; }

    public int Quantity { get; set; }

    public decimal Premium { get; set; }

    public decimal Brokerage { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
