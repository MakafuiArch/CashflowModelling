using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class LayerTopUpLossContract
{
    public int LayerTopUpLossContractId { get; set; }

    public int ContractId { get; set; }

    public int TopUpZoneId { get; set; }

    public string? Zone { get; set; }

    public double ZoneLoss { get; set; }

    public decimal ZoneLossPercent { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
