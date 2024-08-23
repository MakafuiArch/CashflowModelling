using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class LegalTerm
{
    public int LegalTermsId { get; set; }

    public string? AddnlComments { get; set; }

    public DateTime? WordingReceived { get; set; }

    public DateTime? WordingReturned { get; set; }

    public string? OsReason { get; set; }

    public DateTime? OsAsOf { get; set; }

    public bool Wind { get; set; }

    public int WindHours { get; set; }

    public string? WindComments { get; set; }

    public bool Quake { get; set; }

    public int QuakeHours { get; set; }

    public string? QuakeComments { get; set; }

    public bool Riot { get; set; }

    public int RiotHours { get; set; }

    public string? RiotComments { get; set; }

    public bool Flood { get; set; }

    public int FloodHours { get; set; }

    public string? FloodComments { get; set; }

    public bool OtherNat { get; set; }

    public int OtherNatHours { get; set; }

    public string? OtherNatComments { get; set; }

    public bool BrushFire { get; set; }

    public int BrushFireHours { get; set; }

    public string? BrushFireComments { get; set; }

    public bool TerrCert { get; set; }

    public bool ForeignIncl { get; set; }

    public bool Nbc { get; set; }

    public bool Personal { get; set; }

    public bool Commercial { get; set; }

    public string? State { get; set; }

    public string? TerrorComments { get; set; }

    public string? Cyber { get; set; }

    public bool CyberColltzd { get; set; }

    public string? CyberComments { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool Freeze { get; set; }

    public int FreezeHours { get; set; }

    public string? FreezeComments { get; set; }

    public int? ReviewerId { get; set; }

    public string? LegalReview { get; set; }

    public string? ContractTerm { get; set; }

    public string? CommDiseaseExcl { get; set; }

    public string? CommDiseaseComments { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? ContractClauseSet { get; set; }

    public string? EmailNotes { get; set; }

    public DateTime? DateCompleted { get; set; }

    public DateTime? UnderwriterDueDate { get; set; }

    public int UnderwriterStatus { get; set; }

    public int? LegalReviewerId { get; set; }

    public DateTime? LegalDueDate { get; set; }

    public string? Priority { get; set; }

    public string? LegalDataLinkNotes { get; set; }

    public int? TareviewerId { get; set; }

    public int WordingStatus { get; set; }

    public string? ReviewerComments { get; set; }

    public decimal? EmployerLiabilityLimit { get; set; }

    public decimal? EcoXplPct { get; set; }

    public bool IsOccupationDisease { get; set; }

    public int? OccupationDiseaseHours { get; set; }

    public bool IsOccupationDiseasePerEmployee { get; set; }

    public bool IsOccupationDiseasePerEmployer { get; set; }

    public int? SunsetTerm { get; set; }

    public int? CommutationTerm { get; set; }

    public bool IsAffirmativeTerrorism { get; set; }

    public bool IsAbsoluteExclusion { get; set; }

    public bool IsPartialExclusion { get; set; }

    public bool IsNcbrexcluded { get; set; }

    public bool IsGovernmentalPoolBenefit { get; set; }

    public bool IsOtherInuringBenefitToReinsure { get; set; }

    public string? Territory { get; set; }

    public bool IsSilent { get; set; }

    public DateTime? ReviewedDate { get; set; }

    public virtual User? LegalReviewer { get; set; }

    public virtual ICollection<LegalTermClause> LegalTermClauses { get; set; } = new List<LegalTermClause>();

    public virtual User? Reviewer { get; set; }

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual User? Tareviewer { get; set; }
}
