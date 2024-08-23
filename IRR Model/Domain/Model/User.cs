using System;
using System.Collections.Generic;

namespace IRR.Domain.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? NickName { get; set; }

    public string? Email { get; set; }

    public string? RegisStaffCode { get; set; }

    public string? RegisId { get; set; }

    public int DeptId { get; set; }

    public int RoleId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int DefaultUserLayoutId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? ProvisionedCompanies { get; set; }

    public string? AdminComments { get; set; }

    public string? Irisuwcode { get; set; }

    public string? ExcludedOffices { get; set; }

    public string? Upn { get; set; }

    public virtual ICollection<AppPref> AppPrefs { get; set; } = new List<AppPref>();

    public virtual ICollection<ClientMemo> ClientMemos { get; set; } = new List<ClientMemo>();

    public virtual ICollection<ContractReviewerRule> ContractReviewerRules { get; set; } = new List<ContractReviewerRule>();

    public virtual ICollection<ContractReviewer> ContractReviewers { get; set; } = new List<ContractReviewer>();

    public virtual Dept Dept { get; set; } = null!;

    public virtual ICollection<LegalTerm> LegalTermLegalReviewers { get; set; } = new List<LegalTerm>();

    public virtual ICollection<LegalTerm> LegalTermReviewers { get; set; } = new List<LegalTerm>();

    public virtual ICollection<LegalTerm> LegalTermTareviewers { get; set; } = new List<LegalTerm>();

    public virtual ICollection<RetroProfile> RetroProfiles { get; set; } = new List<RetroProfile>();

    public virtual ICollection<RiskTransferAnalysisReviewer> RiskTransferAnalysisReviewers { get; set; } = new List<RiskTransferAnalysisReviewer>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Submission> SubmissionActuaries { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionActuaryPeerReviewers { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionAnalysts { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionLastRegisSyncByUsers { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionModelers { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionRelshipUnderwriters { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionUnderwriters { get; set; } = new List<Submission>();

    public virtual ICollection<UserLayout> UserLayouts { get; set; } = new List<UserLayout>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
}
