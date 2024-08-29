using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class RetroProgram
{
    public int RetroProgramId { get; set; }

    public int RetroProfileId { get; set; }

    public string Name { get; set; } = null!;

    public int Uwyear { get; set; }

    public DateTime Inception { get; set; }

    public DateTime Expiration { get; set; }

    public int RetroProgramType { get; set; }

    public int RetroLevelType { get; set; }

    public int CedeSelectionType { get; set; }

    public int CessionType { get; set; }

    public int Status { get; set; }

    public string Currency { get; set; } = null!;

    public string? SubjectOfficeIds { get; set; }

    public string? SubjectFacilities { get; set; }

    public decimal TgtInvestorColl { get; set; }

    public decimal TgtPremExp { get; set; }

    public decimal TgtPayCapacity { get; set; }

    public decimal EstInvestorColl { get; set; }

    public decimal EstPremExp { get; set; }

    public decimal EstPayCapacity { get; set; }

    public decimal CmtdInvestorColl { get; set; }

    public decimal CmtdPremExp { get; set; }

    public decimal CmtdPayCapacity { get; set; }

    public decimal SignedInvestorColl { get; set; }

    public decimal SignedPremExp { get; set; }

    public decimal SignedPayCapacity { get; set; }

    public string? Notes { get; set; }

    public int DefaultRetroCommissionId { get; set; }

    public bool CanApplyZonalCession { get; set; }

    public bool CanApplyZonalRol { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int RegisSetupStatus { get; set; }

    public string? RegisSetupStatusMessage { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public decimal CessionCapBuffer { get; set; }

    public bool CanAttachCededContracts { get; set; }

    public string? SubjectLobs { get; set; }

    public bool IsPortIn { get; set; }

    public bool IsPortOut { get; set; }

    public decimal OriginalDeductions { get; set; }

    public decimal Override { get; set; }

    public decimal ManagementFee { get; set; }

    public decimal ProfitComm { get; set; }

    public decimal Rhoe { get; set; }

    public decimal PerformanceFee { get; set; }

    public decimal HurdleRate { get; set; }

    public bool CanPortInExpiredLayers { get; set; }

    public bool HasSentPortInExpiredLayers { get; set; }

    public int JobStatus { get; set; }

    public DateTime LastFinalizeDate { get; set; }

    public bool AllowAutoFinalize { get; set; }

    public bool IsProjected { get; set; }

    public bool IsCededContractsIncludedInRunRules { get; set; }

    public bool IsReplicated { get; set; }

    public virtual RetroCommission DefaultRetroCommission { get; set; } = null!;

    public virtual ICollection<PortLayerCessionDuration> PortLayerCessionDurations { get; set; } = new List<PortLayerCessionDuration>();

    public virtual ICollection<PortLayerCession> PortLayerCessions { get; set; } = new List<PortLayerCession>();

    public virtual ICollection<PortProjectedRetro> PortProjectedRetros { get; set; } = new List<PortProjectedRetro>();

    public virtual ICollection<RetroCommission> RetroCommissions { get; set; } = new List<RetroCommission>();

    public virtual ICollection<RetroDoc> RetroDocs { get; set; } = new List<RetroDoc>();

    public virtual RetroProfile RetroProfile { get; set; } = null!;

    public virtual ICollection<RetroProgramReset> RetroProgramResets { get; set; } = new List<RetroProgramReset>();

    public virtual ICollection<RetroZone> RetroZones { get; set; } = new List<RetroZone>();

    public virtual ICollection<Spinsurer> Spinsurers { get; set; } = new List<Spinsurer>();
}
