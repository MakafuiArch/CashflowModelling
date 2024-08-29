using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class RetroAllocation
{
    public int RetroAllocationId { get; set; }

    public decimal Rol { get; set; }

    public decimal El { get; set; }

    public string? Zone { get; set; }

    public string? Message { get; set; }

    public int LayerId { get; set; }

    public int RetroInvestorId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int RegisStatus { get; set; }

    public string? RegisMessage { get; set; }

    public decimal CessionNet { get; set; }

    public decimal CessionDemand { get; set; }

    public decimal CessionGross { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public decimal CessionCapFactor { get; set; }

    public decimal? CessionCapFactorSent { get; set; }

    public decimal? CessionGrossFinalSent { get; set; }

    public decimal? CessionNetFinalSent { get; set; }

    public int AllocationStatus { get; set; }

    public decimal? Override { get; set; }

    public decimal? Brokerage { get; set; }

    public decimal? Taxes { get; set; }

    public decimal? OverrideSent { get; set; }

    public decimal? BrokerageSent { get; set; }

    public decimal? TaxesSent { get; set; }

    public decimal? ManagementFee { get; set; }

    public decimal? TailFee { get; set; }

    public bool IsPortInExpiredLayer { get; set; }

    public int? TopUpZoneId { get; set; }

    public decimal CessionPlaced { get; set; }

    public virtual Layer Layer { get; set; } = null!;

    public virtual RetroInvestor RetroInvestor { get; set; } = null!;
}
