using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class RetroCommission
{
    public int RetroCommissionId { get; set; }

    public string Name { get; set; } = null!;

    public int BrokerId { get; set; }

    public int? BrokerContactId { get; set; }

    public int BrokerageBasis { get; set; }

    public decimal Brokerage { get; set; }

    public decimal Taxes { get; set; }

    public decimal Other { get; set; }

    public int OverridePremBasisType { get; set; }

    public bool IsProfitComm { get; set; }

    public bool IsNoClaimBonus { get; set; }

    public decimal ProfitComm2 { get; set; }

    public decimal Rhoe2 { get; set; }

    public decimal Pcshare { get; set; }

    public decimal Pcshare2 { get; set; }

    public int Ccfyears { get; set; }

    public int Dcfyears { get; set; }

    public int Dcfamount { get; set; }

    public DateTime? PcstartDate { get; set; }

    public bool IsSlidingScale { get; set; }

    public decimal SscommProv { get; set; }

    public decimal SscommMin { get; set; }

    public decimal SslossRatioMin { get; set; }

    public decimal SscommMax { get; set; }

    public decimal SslossRatioMax { get; set; }

    public int? RetroProgramId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int CommissionBasis { get; set; }

    public int TailFeeBasis { get; set; }

    public decimal TailFee { get; set; }

    public int HurdleType { get; set; }

    public bool IsHighWaterMark { get; set; }

    public decimal HighWaterMark { get; set; }

    public virtual Broker Broker { get; set; } = null!;

    public virtual BrokerContact? BrokerContact { get; set; }

    public virtual ICollection<Rcsspoint> Rcsspoints { get; set; } = new List<Rcsspoint>();

    public virtual ICollection<RetroInvestor> RetroInvestors { get; set; } = new List<RetroInvestor>();

    public virtual RetroProgram? RetroProgram { get; set; }

    public virtual ICollection<RetroProgram> RetroPrograms { get; set; } = new List<RetroProgram>();
}
