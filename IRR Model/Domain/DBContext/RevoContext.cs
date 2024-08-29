
using IRR.Domain.Model;
using Microsoft.EntityFrameworkCore;



namespace IRR.Domain.DBContext
{

    public partial class RevoContext : DbContext
    {
        public RevoContext()
        {
        }

        public RevoContext(DbContextOptions<RevoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlphaGuAnalysis> AlphaGuAnalyses { get; set; }

        public virtual DbSet<AlphaModelAnalysis> AlphaModelAnalyses { get; set; }

        public virtual DbSet<AppPref> AppPrefs { get; set; }

        public virtual DbSet<AppSection> AppSections { get; set; }

        public virtual DbSet<AttrepTruncationSafeguard> AttrepTruncationSafeguards { get; set; }

        public virtual DbSet<AuditDetail> AuditDetails { get; set; }

        public virtual DbSet<AuditEvent> AuditEvents { get; set; }

        public virtual DbSet<AuditTxn> AuditTxns { get; set; }

        public virtual DbSet<Broker> Brokers { get; set; }

        public virtual DbSet<BrokerContact> BrokerContacts { get; set; }

        public virtual DbSet<BrokerGroup> BrokerGroups { get; set; }

        public virtual DbSet<Cedent> Cedents { get; set; }

        public virtual DbSet<CedentContact> CedentContacts { get; set; }

        public virtual DbSet<CedentGroup> CedentGroups { get; set; }

        public virtual DbSet<CedentLoss> CedentLosses { get; set; }

        public virtual DbSet<ClientMemo> ClientMemos { get; set; }

        public virtual DbSet<ClientMemoCedent> ClientMemoCedents { get; set; }

        public virtual DbSet<ClientMemoDoc> ClientMemoDocs { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Contract> Contracts { get; set; }

        public virtual DbSet<ContractBinder> ContractBinders { get; set; }

        public virtual DbSet<ContractClause> ContractClauses { get; set; }

        public virtual DbSet<ContractReviewer> ContractReviewers { get; set; }

        public virtual DbSet<ContractReviewerCriterion> ContractReviewerCriteria { get; set; }

        public virtual DbSet<ContractReviewerRule> ContractReviewerRules { get; set; }

        public virtual DbSet<Dbfile> Dbfiles { get; set; }

        public virtual DbSet<DeltaPxResult> DeltaPxResults { get; set; }

        public virtual DbSet<DeltaPxResultContract> DeltaPxResultContracts { get; set; }

        public virtual DbSet<Dept> Depts { get; set; }

        public virtual DbSet<Doc> Docs { get; set; }

        public virtual DbSet<ExperienceLoss> ExperienceLosses { get; set; }

        public virtual DbSet<FxRateSbf> FxRateSbfs { get; set; }

        public virtual DbSet<Fxrate> Fxrates { get; set; }

        public virtual DbSet<Geography> Geographies { get; set; }

        public virtual DbSet<GuAnalysis> GuAnalyses { get; set; }

        public virtual DbSet<GuCurveAdjDef> GuCurveAdjDefs { get; set; }

        public virtual DbSet<GuCurveAdjPmlSrc> GuCurveAdjPmlSrcs { get; set; }

        public virtual DbSet<IndustryCalibrationAnalysis> IndustryCalibrationAnalyses { get; set; }

        public virtual DbSet<IndustryCalibrationDef> IndustryCalibrationDefs { get; set; }

        public virtual DbSet<IndustryGuAnalysis> IndustryGuAnalyses { get; set; }

        public virtual DbSet<IndustryLoss> IndustryLosses { get; set; }

        public virtual DbSet<IndustryLossFilter> IndustryLossFilters { get; set; }

        public virtual DbSet<IndustryLossRegion> IndustryLossRegions { get; set; }

        public virtual DbSet<IndustryLossSubRegion> IndustryLossSubRegions { get; set; }

        public virtual DbSet<IndustryOnLevelLoss> IndustryOnLevelLosses { get; set; }

        public virtual DbSet<Layer> Layers { get; set; }

        public virtual DbSet<LayerExperienceLoss> LayerExperienceLosses { get; set; }

        public virtual DbSet<LayerLossAnalysis> LayerLossAnalyses { get; set; }

        public virtual DbSet<LayerLossEstScenario> LayerLossEstScenarios { get; set; }

        public virtual DbSet<LayerMarketShareFactor> LayerMarketShareFactors { get; set; }

        public virtual DbSet<LayerMarketShareLoss> LayerMarketShareLosses { get; set; }

        public virtual DbSet<LayerTopUpLossContract> LayerTopUpLossContracts { get; set; }

        public virtual DbSet<LegalTerm> LegalTerms { get; set; }

        public virtual DbSet<LegalTermClause> LegalTermClauses { get; set; }

        public virtual DbSet<LloydsRiskCode> LloydsRiskCodes { get; set; }

        public virtual DbSet<LossAnalysis> LossAnalyses { get; set; }

        public virtual DbSet<LossEstScenario> LossEstScenarios { get; set; }

        public virtual DbSet<LossEvent> LossEvents { get; set; }

        public virtual DbSet<LossPool> LossPools { get; set; }

        public virtual DbSet<LossTrendFactor> LossTrendFactors { get; set; }

        public virtual DbSet<LossViewResult> LossViewResults { get; set; }

        public virtual DbSet<LossViewResultContract> LossViewResultContracts { get; set; }

        public virtual DbSet<LossZone> LossZones { get; set; }

        public virtual DbSet<MajorZone> MajorZones { get; set; }

        public virtual DbSet<MarketShareFactor> MarketShareFactors { get; set; }

        public virtual DbSet<MarketShareLoss> MarketShareLosses { get; set; }

        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

        public virtual DbSet<ModelAnalysis> ModelAnalyses { get; set; }

        public virtual DbSet<MultiyearShare> MultiyearShares { get; set; }

        public virtual DbSet<NotificationEvent> NotificationEvents { get; set; }

        public virtual DbSet<Office> Offices { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<PmlMatchingDef> PmlMatchingDefs { get; set; }

        public virtual DbSet<PolicyTracker> PolicyTrackers { get; set; }

        public virtual DbSet<PolicyTrackerDetail> PolicyTrackerDetails { get; set; }

        public virtual DbSet<PolicyTrackerLog> PolicyTrackerLogs { get; set; }

        public virtual DbSet<PolicyUpdate> PolicyUpdates { get; set; }

        public virtual DbSet<PolicyUpdateDetail> PolicyUpdateDetails { get; set; }

        public virtual DbSet<PoolGuAnalysis> PoolGuAnalyses { get; set; }

        public virtual DbSet<PortAdj> PortAdjs { get; set; }

        public virtual DbSet<PortAdjAction> PortAdjActions { get; set; }

        public virtual DbSet<PortLayer> PortLayers { get; set; }

        public virtual DbSet<PortLayerCession> PortLayerCessions { get; set; }

        public virtual DbSet<PortLayerCessionDuration> PortLayerCessionDurations { get; set; }

        public virtual DbSet<PortLayerEarnPattern> PortLayerEarnPatterns { get; set; }

        public virtual DbSet<PortLayerFieldSelectionPerTypeResult> PortLayerFieldSelectionPerTypeResults { get; set; }

        public virtual DbSet<PortLayerLossDuration> PortLayerLossDurations { get; set; }

        public virtual DbSet<PortLayerPriceResult> PortLayerPriceResults { get; set; }

        public virtual DbSet<PortLayerProjectedCessionPeriod> PortLayerProjectedCessionPeriods { get; set; }

        public virtual DbSet<PortMetric> PortMetrics { get; set; }

        public virtual DbSet<PortPeriodResult> PortPeriodResults { get; set; }

        public virtual DbSet<PortProjectedRetro> PortProjectedRetros { get; set; }

        public virtual DbSet<PortRoeResult> PortRoeResults { get; set; }

        public virtual DbSet<Portfolio> Portfolios { get; set; }

        public virtual DbSet<PortfolioFx> PortfolioFxes { get; set; }

        public virtual DbSet<PremiumBase> PremiumBases { get; set; }

        public virtual DbSet<PremiumBaseContract> PremiumBaseContracts { get; set; }

        public virtual DbSet<PremiumInstallment> PremiumInstallments { get; set; }

        public virtual DbSet<PremiumInstallmentContract> PremiumInstallmentContracts { get; set; }

        public virtual DbSet<PremiumSurplusRatio> PremiumSurplusRatios { get; set; }

        public virtual DbSet<PresetLdp> PresetLdps { get; set; }

        public virtual DbSet<PresetLdpdist> PresetLdpdists { get; set; }

        public virtual DbSet<Programme> Programs { get; set; }

        public virtual DbSet<ProgramRoeResult> ProgramRoeResults { get; set; }

        public virtual DbSet<PxSection> PxSections { get; set; }

        public virtual DbSet<PxSectionContract> PxSectionContracts { get; set; }

        public virtual DbSet<Rcsspoint> Rcsspoints { get; set; }

        public virtual DbSet<Reinstatement> Reinstatements { get; set; }

        public virtual DbSet<ReinstatementContract> ReinstatementContracts { get; set; }

        public virtual DbSet<RetroAllocation> RetroAllocations { get; set; }

        public virtual DbSet<RetroBufferByEvent> RetroBufferByEvents { get; set; }

        public virtual DbSet<RetroBufferByTime> RetroBufferByTimes { get; set; }

        public virtual DbSet<RetroCommission> RetroCommissions { get; set; }

        public virtual DbSet<RetroDoc> RetroDocs { get; set; }

        public virtual DbSet<RetroFacilityOverride> RetroFacilityOverrides { get; set; }

        public virtual DbSet<RetroInvestor> RetroInvestors { get; set; }

        public virtual DbSet<RetroInvestorReset> RetroInvestorResets { get; set; }

        public virtual DbSet<RetroInvestorZone> RetroInvestorZones { get; set; }

        public virtual DbSet<RetroProfile> RetroProfiles { get; set; }

        public virtual DbSet<RetroProgram> RetroPrograms { get; set; }

        public virtual DbSet<RetroProgramReset> RetroProgramResets { get; set; }

        public virtual DbSet<RetroZone> RetroZones { get; set; }

        public virtual DbSet<RetroZoneOverride> RetroZoneOverrides { get; set; }

        public virtual DbSet<RiskTransferAnalysis> RiskTransferAnalyses { get; set; }

        public virtual DbSet<RiskTransferAnalysisReviewer> RiskTransferAnalysisReviewers { get; set; }

        public virtual DbSet<RiskZone> RiskZones { get; set; }

        public virtual DbSet<RoeAssumption> RoeAssumptions { get; set; }

        public virtual DbSet<RoeCapitalResult> RoeCapitalResults { get; set; }

        public virtual DbSet<RoeLeverageFactor> RoeLeverageFactors { get; set; }

        public virtual DbSet<RoeLossDevPattern> RoeLossDevPatterns { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<RolePermission> RolePermissions { get; set; }

        public virtual DbSet<SnpLob> SnpLobs { get; set; }

        public virtual DbSet<Spinsurer> Spinsurers { get; set; }

        public virtual DbSet<Sspoint> Sspoints { get; set; }

        public virtual DbSet<SspointContract> SspointContracts { get; set; }

        public virtual DbSet<SubDeltaPxResult> SubDeltaPxResults { get; set; }

        public virtual DbSet<SubDeltaPxResultContract> SubDeltaPxResultContracts { get; set; }

        public virtual DbSet<Submission> Submissions { get; set; }

        public virtual DbSet<SubmissionGuAnalysis> SubmissionGuAnalyses { get; set; }

        public virtual DbSet<SubmissionPxPortfolio> SubmissionPxPortfolios { get; set; }

        public virtual DbSet<SubmissionWriteup> SubmissionWriteups { get; set; }

        public virtual DbSet<Subscription> Subscriptions { get; set; }

        public virtual DbSet<TargetPmldef> TargetPmldefs { get; set; }

        public virtual DbSet<Tmpla> Tmplas { get; set; }

        public virtual DbSet<Tmpra> Tmpras { get; set; }

        public virtual DbSet<TopUpZone> TopUpZones { get; set; }

        public virtual DbSet<TopUpZoneGeoMap> TopUpZoneGeoMaps { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserLayout> UserLayouts { get; set; }

        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }

        public virtual DbSet<VwAuditDetail> VwAuditDetails { get; set; }

        public virtual DbSet<VwAuditDetailLayer> VwAuditDetailLayers { get; set; }

        public virtual DbSet<VwAuditDetailProgram> VwAuditDetailPrograms { get; set; }

        public virtual DbSet<VwAuditDetailSubmission> VwAuditDetailSubmissions { get; set; }

        public virtual DbSet<VwContractReviewerPending> VwContractReviewerPendings { get; set; }

        public virtual DbSet<VwLayer> VwLayers { get; set; }

        public virtual DbSet<VwLayerLossSummary> VwLayerLossSummaries { get; set; }

        public virtual DbSet<VwLayerLossZoneSummary> VwLayerLossZoneSummaries { get; set; }

        public virtual DbSet<VwLayerMajorZoneLossSummary> VwLayerMajorZoneLossSummaries { get; set; }

        public virtual DbSet<VwLayerTerm> VwLayerTerms { get; set; }

        public virtual DbSet<VwLossEventSummary> VwLossEventSummaries { get; set; }

        public virtual DbSet<VwRolePermission> VwRolePermissions { get; set; }

        public virtual DbSet<VwUser> VwUsers { get; set; }

        public virtual DbSet<VwUserImplicitPermission> VwUserImplicitPermissions { get; set; }

        public virtual DbSet<VwUserPermission> VwUserPermissions { get; set; }

        public virtual DbSet<ZoneDefinition> ZoneDefinitions { get; set; }

        public virtual DbSet<ZoneGeography> ZoneGeographies { get; set; }

        public virtual DbSet<ZzzIndustryLossDupRecsImport220920> ZzzIndustryLossDupRecsImport220920s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Revoreader");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlphaGuAnalysis>(entity =>
            {
                entity.HasKey(e => e.AlphaGuAnalysisId).HasName("PK_dbo.AlphaGuAnalysis");

                entity.ToTable("AlphaGuAnalysis");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Platform).HasMaxLength(25);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<AlphaModelAnalysis>(entity =>
            {
                entity.HasKey(e => e.AlphaModelAnalysisId).HasName("PK_dbo.AlphaModelAnalysis");

                entity.ToTable("AlphaModelAnalysis");

                entity.HasIndex(e => e.AlphaGuAnalysisId, "IX_AlphaGuAnalysisId");

                entity.Property(e => e.Alpha).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.AttachmentPoint).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Cv)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CV");
                entity.Property(e => e.DistributionLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Peril).HasMaxLength(2);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.TargetEl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("TargetEL");
                entity.Property(e => e.TargetLr)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("TargetLR");

                entity.HasOne(d => d.AlphaGuAnalysis).WithMany(p => p.AlphaModelAnalyses)
                    .HasForeignKey(d => d.AlphaGuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AlphaModelAnalysis_dbo.AlphaGuAnalysis_AlphaGuAnalysisId");
            });

            modelBuilder.Entity<AppPref>(entity =>
            {
                entity.HasKey(e => e.AppPrefId).HasName("PK_dbo.AppPref");

                entity.ToTable("AppPref");

                entity.HasIndex(e => new { e.Name, e.LegalRegion, e.AppSectionId, e.UserId }, "UQ_PrefName").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.LegalRegion).HasMaxLength(100);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.RegisId).HasMaxLength(50);
                entity.Property(e => e.RegisValue).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Value).HasMaxLength(50);
                entity.Property(e => e.Value2).HasMaxLength(500);
                entity.Property(e => e.Value3).HasMaxLength(4000);

                entity.HasOne(d => d.AppSection).WithMany(p => p.AppPrefs)
                    .HasForeignKey(d => d.AppSectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppPref_dbo.AppSection_AppSectionId");

                entity.HasOne(d => d.User).WithMany(p => p.AppPrefs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AppPref_dbo.User_UserId");
            });

            modelBuilder.Entity<AppSection>(entity =>
            {
                entity.HasKey(e => e.AppSectionId).HasName("PK_dbo.AppSection");

                entity.ToTable("AppSection");

                entity.HasIndex(e => e.Name, "UQ_SectionName").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DataType).HasMaxLength(150);
                entity.Property(e => e.Description).HasMaxLength(150);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<AttrepTruncationSafeguard>(entity =>
            {
                entity.HasKey(e => new { e.LatchTaskName, e.LatchMachineGuid, e.LatchKey }).HasName("PK__attrep_t__65C99AC86CCB78C8");

                entity.ToTable("attrep_truncation_safeguard");

                entity.Property(e => e.LatchTaskName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("latchTaskName");
                entity.Property(e => e.LatchMachineGuid)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("latchMachineGUID");
                entity.Property(e => e.LatchKey)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.LatchLocker)
                    .HasColumnType("datetime")
                    .HasColumnName("latchLocker");
            });

            modelBuilder.Entity<AuditDetail>(entity =>
            {
                entity.HasKey(e => e.AuditDetailId).HasName("PK_dbo.AuditDetail");

                entity.ToTable("AuditDetail");

                entity.HasIndex(e => e.AuditEventId, "IX_AuditEventId");

                entity.Property(e => e.Property).HasMaxLength(256);

                entity.HasOne(d => d.AuditEvent).WithMany(p => p.AuditDetails)
                    .HasForeignKey(d => d.AuditEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AuditDetail_dbo.AuditEvent_AuditEventId");
            });

            modelBuilder.Entity<AuditEvent>(entity =>
            {
                entity.HasKey(e => e.AuditEventId).HasName("PK_dbo.AuditEvent");

                entity.ToTable("AuditEvent");

                entity.HasIndex(e => e.AuditTxnId, "IX_AuditTxnId");

                entity.Property(e => e.ObjectType).HasMaxLength(512);

                entity.HasOne(d => d.AuditTxn).WithMany(p => p.AuditEvents)
                    .HasForeignKey(d => d.AuditTxnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AuditEvent_dbo.AuditTxn_AuditTxnId");
            });

            modelBuilder.Entity<AuditTxn>(entity =>
            {
                entity.HasKey(e => e.AuditTxnId).HasName("PK_dbo.AuditTxn");

                entity.ToTable("AuditTxn");

                entity.Property(e => e.ServerName).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Broker>(entity =>
            {
                entity.HasKey(e => e.BrokerId).HasName("PK_dbo.Broker");

                entity.ToTable("Broker");

                entity.HasIndex(e => e.BrokerGroupId, "IX_BrokerGroupId");

                entity.HasIndex(e => e.RegisId, "UQ_RegisIdBroker")
                    .IsUnique()
                    .HasFilter("([RegisId] IS NOT NULL AND [RegisId]<>'')");

                entity.Property(e => e.ApprovalComments).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(120);
                entity.Property(e => e.Country).HasMaxLength(60);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DomicileCountry).HasMaxLength(60);
                entity.Property(e => e.DomicileState).HasMaxLength(20);
                entity.Property(e => e.IrisbrokerCode).HasColumnName("IRISBrokerCode");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Region).HasMaxLength(80);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.State).HasMaxLength(120);
                entity.Property(e => e.StreetAddress).HasMaxLength(150);
                entity.Property(e => e.StreetAddress2).HasMaxLength(150);
                entity.Property(e => e.Website).HasMaxLength(120);
                entity.Property(e => e.Zip).HasMaxLength(50);

                entity.HasOne(d => d.BrokerGroup).WithMany(p => p.Brokers)
                    .HasForeignKey(d => d.BrokerGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Broker_dbo.BrokerGroup_BrokerGroupId");
            });

            modelBuilder.Entity<BrokerContact>(entity =>
            {
                entity.HasKey(e => e.BrokerContactId).HasName("PK_dbo.BrokerContact");

                entity.ToTable("BrokerContact");

                entity.HasIndex(e => e.BrokerId, "IX_BrokerId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.EmailPers).HasMaxLength(100);
                entity.Property(e => e.Fax).HasMaxLength(50);
                entity.Property(e => e.FirstName).HasMaxLength(150);
                entity.Property(e => e.LastName).HasMaxLength(150);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.PhoneCell).HasMaxLength(50);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Broker).WithMany(p => p.BrokerContacts)
                    .HasForeignKey(d => d.BrokerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.BrokerContact_dbo.Broker_BrokerId");
            });

            modelBuilder.Entity<BrokerGroup>(entity =>
            {
                entity.HasKey(e => e.BrokerGroupId).HasName("PK_dbo.BrokerGroup");

                entity.ToTable("BrokerGroup");

                entity.HasIndex(e => e.RegisId, "UQ_RegisIdBrokerGroup")
                    .IsUnique()
                    .HasFilter("([RegisId] IS NOT NULL AND [RegisId]<>'')");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Cedent>(entity =>
            {
                entity.HasKey(e => e.CedentId).HasName("PK_dbo.Cedent");

                entity.ToTable("Cedent");

                entity.HasIndex(e => e.CedentGroupId, "IX_CedentGroupId");

                entity.HasIndex(e => e.RegisId, "UQ_RegisIdCedent")
                    .IsUnique()
                    .HasFilter("([RegisId] IS NOT NULL AND [RegisId]<>'')");

                entity.Property(e => e.ApprovalComments).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(120);
                entity.Property(e => e.Country).HasMaxLength(60);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DomicileCountry).HasMaxLength(60);
                entity.Property(e => e.DomicileState).HasMaxLength(20);
                entity.Property(e => e.FormerName).HasMaxLength(200);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.Region).HasMaxLength(80);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.State).HasMaxLength(120);
                entity.Property(e => e.StreetAddress).HasMaxLength(150);
                entity.Property(e => e.StreetAddress2).HasMaxLength(150);
                entity.Property(e => e.Website).HasMaxLength(120);
                entity.Property(e => e.Zip).HasMaxLength(50);

                entity.HasOne(d => d.CedentGroup).WithMany(p => p.Cedents)
                    .HasForeignKey(d => d.CedentGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Cedent_dbo.CedentGroup_CedentGroupId");
            });

            modelBuilder.Entity<CedentContact>(entity =>
            {
                entity.HasKey(e => e.CedentContactId).HasName("PK_dbo.CedentContact");

                entity.ToTable("CedentContact");

                entity.HasIndex(e => e.CedentId, "IX_CedentId");

                entity.Property(e => e.Cell).HasMaxLength(50);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Events).HasMaxLength(150);
                entity.Property(e => e.FirstName).HasMaxLength(150);
                entity.Property(e => e.Interests).HasMaxLength(150);
                entity.Property(e => e.LastName).HasMaxLength(150);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(250);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Cedent).WithMany(p => p.CedentContacts)
                    .HasForeignKey(d => d.CedentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CedentContact_dbo.Cedent_CedentId");
            });

            modelBuilder.Entity<CedentGroup>(entity =>
            {
                entity.HasKey(e => e.CedentGroupId).HasName("PK_dbo.CedentGroup");

                entity.ToTable("CedentGroup");

                entity.HasIndex(e => e.RegisId, "UQ_RegisIdCedentGroup")
                    .IsUnique()
                    .HasFilter("([RegisId] IS NOT NULL AND [RegisId]<>'')");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<CedentLoss>(entity =>
            {
                entity.HasKey(e => e.CedentLossId).HasName("PK_dbo.CedentLoss");

                entity.ToTable("CedentLoss");

                entity.Property(e => e.Country).HasMaxLength(2);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Division).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(50);
                entity.Property(e => e.Product).HasMaxLength(50);
                entity.Property(e => e.Region).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ClientMemo>(entity =>
            {
                entity.HasKey(e => e.ClientMemoId).HasName("PK_dbo.ClientMemo");

                entity.ToTable("ClientMemo");

                entity.HasIndex(e => e.BrokerId, "IX_BrokerId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.ArchRep).HasMaxLength(250);
                entity.Property(e => e.BrokerRep).HasMaxLength(250);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Lob)
                    .HasMaxLength(250)
                    .HasColumnName("LOB");
                entity.Property(e => e.Location).HasMaxLength(50);
                entity.Property(e => e.LocationFollowup).HasMaxLength(50);
                entity.Property(e => e.MeetEvent).HasMaxLength(50);
                entity.Property(e => e.Memo).HasColumnType("ntext");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.MonthFollowup).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Unit).HasMaxLength(250);

                entity.HasOne(d => d.Broker).WithMany(p => p.ClientMemos)
                    .HasForeignKey(d => d.BrokerId)
                    .HasConstraintName("FK_dbo.ClientMemo_dbo.Broker_BrokerId");

                entity.HasOne(d => d.User).WithMany(p => p.ClientMemos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ClientMemo_dbo.User_UserId");
            });

            modelBuilder.Entity<ClientMemoCedent>(entity =>
            {
                entity.HasKey(e => e.ClientMemoCedentId).HasName("PK_dbo.ClientMemoCedent");

                entity.ToTable("ClientMemoCedent");

                entity.HasIndex(e => e.CedentId, "IX_CedentId");

                entity.HasIndex(e => e.ClientMemoId, "IX_ClientMemoId");

                entity.Property(e => e.ClientRep).HasMaxLength(250);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Cedent).WithMany(p => p.ClientMemoCedents)
                    .HasForeignKey(d => d.CedentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ClientMemoCedent_dbo.Cedent_CedentId");

                entity.HasOne(d => d.ClientMemo).WithMany(p => p.ClientMemoCedents)
                    .HasForeignKey(d => d.ClientMemoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ClientMemoCedent_dbo.ClientMemo_ClientMemoId");
            });

            modelBuilder.Entity<ClientMemoDoc>(entity =>
            {
                entity.HasKey(e => e.ClientMemoDocId).HasName("PK_dbo.ClientMemoDoc");

                entity.ToTable("ClientMemoDoc");

                entity.HasIndex(e => e.ClientMemoId, "IX_ClientMemoId");

                entity.HasIndex(e => e.DbfileId, "IX_DBFileId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DbfileId).HasColumnName("DBFileId");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ClientMemo).WithMany(p => p.ClientMemoDocs)
                    .HasForeignKey(d => d.ClientMemoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ClientMemoDoc_dbo.ClientMemo_ClientMemoId");

                entity.HasOne(d => d.Dbfile).WithMany(p => p.ClientMemoDocs)
                    .HasForeignKey(d => d.DbfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ClientMemoDoc_dbo.DBFile_DBFileId");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId).HasName("PK_dbo.Company");

                entity.ToTable("Company");

                entity.HasIndex(e => e.LegalEntCode, "IX_LegalEntCode").IsUnique();

                entity.HasIndex(e => e.Name, "IX_Name").IsUnique();

                entity.Property(e => e.BaseCurrency).HasMaxLength(3);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DefaultDomain)
                    .HasMaxLength(20)
                    .HasDefaultValue("");
                entity.Property(e => e.DefaultEmail)
                    .HasMaxLength(50)
                    .HasDefaultValue("");
                entity.Property(e => e.LegalEntCode).HasMaxLength(8);
                entity.Property(e => e.LegalRegion).HasMaxLength(10);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.ContractId).HasName("PK_dbo.Contract");

                entity.ToTable("Contract");

                entity.HasIndex(e => e.ContractBinderId, "IX_ContractBinderId");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.Property(e => e.AdjustmentBaseType).HasMaxLength(25);
                entity.Property(e => e.AggLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AggRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AttachBasis).HasMaxLength(25);
                entity.Property(e => e.BoundFxdate).HasColumnName("BoundFXDate");
                entity.Property(e => e.BoundFxrate)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BoundFXRate");
                entity.Property(e => e.BrokerRef).HasMaxLength(50);
                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Ccfyears).HasColumnName("CCFYears");
                entity.Property(e => e.CessionTotal).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CommOverride).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Commission).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ContractLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ContractType).HasMaxLength(25);
                entity.Property(e => e.CorreAuthMax).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreAuthMin).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreAuthTarget).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreRenewalMin).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Dcfamount).HasColumnName("DCFAmount");
                entity.Property(e => e.Dcfyears).HasColumnName("DCFYears");
                entity.Property(e => e.DisplayShareLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DiversificationFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.EarningType).HasMaxLength(25);
                entity.Property(e => e.Erc)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ERC");
                entity.Property(e => e.EventNumber).HasMaxLength(50);
                entity.Property(e => e.ExpiringCorreShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Facility).HasMaxLength(50);
                entity.Property(e => e.Fhcfband)
                    .HasMaxLength(25)
                    .HasColumnName("FHCFBand");
                entity.Property(e => e.Franchise).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FranchiseReverse).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FrontingFee).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossUpFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.InvestmentReturn).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Laeterm)
                    .HasMaxLength(25)
                    .HasColumnName("LAETerm");
                entity.Property(e => e.LayerCatalog).HasMaxLength(20);
                entity.Property(e => e.LayerCategory).HasMaxLength(25);
                entity.Property(e => e.LayerDesc).HasMaxLength(120);
                entity.Property(e => e.LayerType).HasMaxLength(30);
                entity.Property(e => e.LimitBasis).HasMaxLength(25);
                entity.Property(e => e.Lob)
                    .HasMaxLength(50)
                    .HasColumnName("LOB");
                entity.Property(e => e.LossCorridorBeginPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossCorridorCedePct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossCorridorEndPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossDuration).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossTrigger).HasMaxLength(20);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NonCatMarginAllowance).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.OccLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OccLimitInPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.OccRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OccRetnInPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.OtherExpenses).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.PcstartDate).HasColumnName("PCStartDate");
                entity.Property(e => e.Placement).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PremiumFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.PremiumFreq).HasMaxLength(25);
                entity.Property(e => e.ProfitComm).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Rate).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RegisMkey)
                    .HasMaxLength(20)
                    .HasColumnName("RegisMKey");
                entity.Property(e => e.RegisMsg).HasMaxLength(500);
                entity.Property(e => e.RegisNbr).HasMaxLength(20);
                entity.Property(e => e.ReinsurerExpenses).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ReserveFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RiskLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RiskRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Rol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Segment).HasMaxLength(50);
                entity.Property(e => e.Share).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ShareLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SharePremium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SharedToCorre).HasMaxLength(20);
                entity.Property(e => e.SourceId).HasMaxLength(50);
                entity.Property(e => e.SscommMax)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommMax");
                entity.Property(e => e.SscommMin)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommMin");
                entity.Property(e => e.SscommProv)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommProv");
                entity.Property(e => e.SslossRatioMax)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioMax");
                entity.Property(e => e.SslossRatioMin)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioMin");
                entity.Property(e => e.SslossRatioProv)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioProv");
                entity.Property(e => e.StopLossAttachPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.StopLossLimitPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.TopUpZone).HasMaxLength(500);
                entity.Property(e => e.Uwyear).HasColumnName("UWYear");
                entity.Property(e => e.VarCommHi).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.VarCommLow).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Warnings).HasMaxLength(4000);

                entity.HasOne(d => d.ContractBinder).WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ContractBinderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contract_dbo.ContractBinder_ContractBinderId");

                entity.HasOne(d => d.Layer).WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contract_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<ContractBinder>(entity =>
            {
                entity.HasKey(e => e.ContractBinderId).HasName("PK_dbo.ContractBinder");

                entity.ToTable("ContractBinder");

                entity.HasIndex(e => e.DocId, "IX_DocId");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.Property(e => e.ActuarialPriority).HasMaxLength(50);
                entity.Property(e => e.ActuarialRanking).HasMaxLength(50);
                entity.Property(e => e.ActuarialStatus).HasMaxLength(30);
                entity.Property(e => e.BaseCurrency).HasMaxLength(3);
                entity.Property(e => e.ContractBinderNotes).HasColumnType("ntext");
                entity.Property(e => e.CorreStatus).HasMaxLength(30);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.ExtName).HasMaxLength(50);
                entity.Property(e => e.FxDateSbf).HasColumnName("FxDateSBF");
                entity.Property(e => e.FxRateSbfgbp)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FxRateSBFGBP");
                entity.Property(e => e.FxRateSbfusd)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FxRateSBFUSD");
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.Fxrate)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FXRate");
                entity.Property(e => e.GrossLimitAuth).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitAuthExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitBoundNew).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitBoundNewExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitMultiYrIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitMultiYrIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitQuote).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitQuoteExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitTotalIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossLimitTotalIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremAuth).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremAuthExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremBoundNew).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremBoundNewExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremMultiYrIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremMultiYrIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremQuote).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremQuoteExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremTotalIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossPremTotalIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InsType).HasMaxLength(25);
                entity.Property(e => e.ModelingComplexity).HasMaxLength(20);
                entity.Property(e => e.ModelingStatus).HasMaxLength(30);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NetLimitAuth).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitAuthExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitBoundNew).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitBoundNewExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitMultiYrIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitMultiYrIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitQuote).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitQuoteExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitTotalIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetLimitTotalIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremAuth).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremAuthExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremBoundNew).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremBoundNewExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremMultiYrIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremMultiYrIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremQuote).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremQuoteExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremTotalIf).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NetPremTotalIfExpiring).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Priority).HasMaxLength(50);
                entity.Property(e => e.QsofXs).HasColumnName("QSofXS");
                entity.Property(e => e.RefId).HasMaxLength(20);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RegisNbr).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Source).HasMaxLength(50);
                entity.Property(e => e.StrategicNotes).HasColumnType("ntext");
                entity.Property(e => e.SubmissionStatus).HasMaxLength(25);
                entity.Property(e => e.TranType).HasMaxLength(20);
                entity.Property(e => e.UwyearDefault).HasColumnName("UWYearDefault");
                entity.Property(e => e.UwyearDefaultExpiring).HasColumnName("UWYearDefaultExpiring");
                entity.Property(e => e.Warnings).HasMaxLength(4000);

                entity.HasOne(d => d.Doc).WithMany(p => p.ContractBinders)
                    .HasForeignKey(d => d.DocId)
                    .HasConstraintName("FK_dbo.ContractBinder_dbo.Doc_DocId");

                entity.HasOne(d => d.Submission).WithMany(p => p.ContractBinders)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ContractBinder_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<ContractClause>(entity =>
            {
                entity.HasKey(e => e.ContractClauseId).HasName("PK_dbo.ContractClause");

                entity.ToTable("ContractClause");

                entity.HasIndex(e => e.Code, "UQ_ClauseCode").IsUnique();

                entity.HasIndex(e => e.Name, "UQ_ClauseName").IsUnique();

                entity.Property(e => e.Code).HasMaxLength(100);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Desc).HasMaxLength(250);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ContractReviewer>(entity =>
            {
                entity.HasKey(e => e.ContractReviewerId).HasName("PK_dbo.ContractReviewer");

                entity.ToTable("ContractReviewer");

                entity.HasIndex(e => e.ContractBinderId, "IX_ContractBinderId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ContractBinder).WithMany(p => p.ContractReviewers)
                    .HasForeignKey(d => d.ContractBinderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ContractReviewer_dbo.ContractBinder_ContractBinderId");

                entity.HasOne(d => d.User).WithMany(p => p.ContractReviewers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ContractReviewer_dbo.User_UserId");
            });

            modelBuilder.Entity<ContractReviewerCriterion>(entity =>
            {
                entity.HasKey(e => e.ContractReviewerCriteriaId).HasName("PK_dbo.ContractReviewerCriteria");

                entity.HasIndex(e => e.ContractReviewerRuleId, "IX_ContractReviewerRuleId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ContractReviewerRule).WithMany(p => p.ContractReviewerCriteria)
                    .HasForeignKey(d => d.ContractReviewerRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ContractReviewerCriteria_dbo.ContractReviewerRule_ContractReviewerRuleId");
            });

            modelBuilder.Entity<ContractReviewerRule>(entity =>
            {
                entity.HasKey(e => e.ContractReviewerRuleId).HasName("PK_dbo.ContractReviewerRule");

                entity.ToTable("ContractReviewerRule");

                entity.HasIndex(e => e.ReviewerId, "IX_ReviewerId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Reviewer).WithMany(p => p.ContractReviewerRules)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ContractReviewerRule_dbo.User_ReviewerId");
            });

            modelBuilder.Entity<Dbfile>(entity =>
            {
                entity.HasKey(e => e.DbfileId).HasName("PK_dbo.DBFile");

                entity.ToTable("DBFile");

                entity.Property(e => e.DbfileId).HasColumnName("DBFileId");
                entity.Property(e => e.FileData).HasColumnType("image");
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<DeltaPxResult>(entity =>
            {
                entity.HasKey(e => e.DeltaPxResultId).HasName("PK_dbo.DeltaPxResult");

                entity.ToTable("DeltaPxResult");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.HasIndex(e => e.SubmissionPxPortfolioId, "IX_SubmissionPxPortfolioId");

                entity.HasIndex(e => new { e.SubmissionPxPortfolioId, e.LayerId }, "UQ_DeltaPxResult")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1) AND [IsDeleted]=(0))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.GrossCapitalTvarAuth).HasColumnName("GrossCapitalTVarAuth");
                entity.Property(e => e.GrossCapitalTvarQuote).HasColumnName("GrossCapitalTVarQuote");
                entity.Property(e => e.GrossCapitalTvarSigned).HasColumnName("GrossCapitalTVarSigned");
                entity.Property(e => e.GrossCatPmlTvarArlAuth).HasColumnName("GrossCatPmlTVarArlAuth");
                entity.Property(e => e.GrossCatPmlTvarArlQuote).HasColumnName("GrossCatPmlTVarArlQuote");
                entity.Property(e => e.GrossCatPmlTvarArlSigned).HasColumnName("GrossCatPmlTVarArlSigned");
                entity.Property(e => e.GrossRoetvarAuth).HasColumnName("GrossROETVarAuth");
                entity.Property(e => e.GrossRoetvarQuote).HasColumnName("GrossROETVarQuote");
                entity.Property(e => e.GrossRoetvarSigned).HasColumnName("GrossROETVarSigned");
                entity.Property(e => e.GrossRoevarAuth).HasColumnName("GrossROEVarAuth");
                entity.Property(e => e.GrossRoevarCorreAuth).HasColumnName("GrossROEVarCorreAuth");
                entity.Property(e => e.GrossRoevarCorreQuote).HasColumnName("GrossROEVarCorreQuote");
                entity.Property(e => e.GrossRoevarQuote).HasColumnName("GrossROEVarQuote");
                entity.Property(e => e.GrossRoevarSigned).HasColumnName("GrossROEVarSigned");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NetCapitalTvarAuth).HasColumnName("NetCapitalTVarAuth");
                entity.Property(e => e.NetCapitalTvarQuote).HasColumnName("NetCapitalTVarQuote");
                entity.Property(e => e.NetCapitalTvarSigned).HasColumnName("NetCapitalTVarSigned");
                entity.Property(e => e.NetCatPmlTvarArlAuth).HasColumnName("NetCatPmlTVarArlAuth");
                entity.Property(e => e.NetCatPmlTvarArlQuote).HasColumnName("NetCatPmlTVarArlQuote");
                entity.Property(e => e.NetCatPmlTvarArlSigned).HasColumnName("NetCatPmlTVarArlSigned");
                entity.Property(e => e.NetMinRoevarAuth).HasColumnName("NetMinROEVarAuth");
                entity.Property(e => e.NetMinRoevarQuote).HasColumnName("NetMinROEVarQuote");
                entity.Property(e => e.NetMinRoevarSigned).HasColumnName("NetMinROEVarSigned");
                entity.Property(e => e.NetRoetvarAuth).HasColumnName("NetROETVarAuth");
                entity.Property(e => e.NetRoetvarQuote).HasColumnName("NetROETVarQuote");
                entity.Property(e => e.NetRoetvarSigned).HasColumnName("NetROETVarSigned");
                entity.Property(e => e.NetRoevarAuth).HasColumnName("NetROEVarAuth");
                entity.Property(e => e.NetRoevarQuote).HasColumnName("NetROEVarQuote");
                entity.Property(e => e.NetRoevarSigned).HasColumnName("NetROEVarSigned");
                entity.Property(e => e.NetRoevarWithFeesAuth).HasColumnName("NetROEVarWithFeesAuth");
                entity.Property(e => e.NetRoevarWithFeesQuote).HasColumnName("NetROEVarWithFeesQuote");
                entity.Property(e => e.NetRoevarWithFeesSigned).HasColumnName("NetROEVarWithFeesSigned");
                entity.Property(e => e.ReasonStaleAuth).HasMaxLength(4000);
                entity.Property(e => e.ReasonStaleQuote).HasMaxLength(4000);
                entity.Property(e => e.ReasonStaleSigned).HasMaxLength(4000);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.DeltaPxResults)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DeltaPxResult_dbo.Layer_LayerId");

                entity.HasOne(d => d.SubmissionPxPortfolio).WithMany(p => p.DeltaPxResults)
                    .HasForeignKey(d => d.SubmissionPxPortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DeltaPxResult_dbo.SubmissionPxPortfolio_SubmissionPxPortfolioId");
            });

            modelBuilder.Entity<DeltaPxResultContract>(entity =>
            {
                entity.HasKey(e => e.DeltaPxResultContractId).HasName("PK_dbo.DeltaPxResultContract");

                entity.ToTable("DeltaPxResultContract");

                entity.HasIndex(e => e.ContractId, "IX_ContractId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.GrossCapitalTvar).HasColumnName("GrossCapitalTVar");
                entity.Property(e => e.GrossCatPmlTvarArl).HasColumnName("GrossCatPmlTVarArl");
                entity.Property(e => e.GrossRoetvar).HasColumnName("GrossROETVar");
                entity.Property(e => e.GrossRoevar).HasColumnName("GrossROEVar");
                entity.Property(e => e.GrossRoevarCorre).HasColumnName("GrossROEVarCorre");
                entity.Property(e => e.LossView).HasMaxLength(25);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NetCapitalTvar).HasColumnName("NetCapitalTVar");
                entity.Property(e => e.NetCatPmlTvarArl).HasColumnName("NetCatPmlTVarArl");
                entity.Property(e => e.NetMinRoevar).HasColumnName("NetMinROEVar");
                entity.Property(e => e.NetRoetvar).HasColumnName("NetROETVar");
                entity.Property(e => e.NetRoevar).HasColumnName("NetROEVar");
                entity.Property(e => e.NetRoevarWithFees).HasColumnName("NetROEVarWithFees");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Contract).WithMany(p => p.DeltaPxResultContracts)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DeltaPxResultContract_dbo.Contract_ContractId");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.DeptId).HasName("PK_dbo.Dept");

                entity.ToTable("Dept");

                entity.HasIndex(e => new { e.Name, e.OfficeId }, "UQ_DeptOffice").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DeptEmail).HasMaxLength(150);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Office).WithMany(p => p.Depts)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Dept_dbo.Office_OfficeId");
            });

            modelBuilder.Entity<Doc>(entity =>
            {
                entity.HasKey(e => e.DocId).HasName("PK_dbo.Doc");

                entity.ToTable("Doc");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DbfileId).HasColumnName("DBFileId");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.DocType).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Submission).WithMany(p => p.Docs)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Doc_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<ExperienceLoss>(entity =>
            {
                entity.HasKey(e => e.ExperienceLossId).HasName("PK_dbo.ExperienceLoss");

                entity.ToTable("ExperienceLoss");

                entity.HasIndex(e => e.GeographyId, "IX_GeographyId");

                entity.HasIndex(e => e.LossEstScenarioId, "IX_LossEstScenarioId");

                entity.HasIndex(e => e.LossEventId, "IX_LossEventId");

                entity.HasIndex(e => new { e.LossEstScenarioId, e.LossEventId, e.DataSource, e.ValuationDate, e.EventYear, e.EventName, e.Peril, e.CountryCode, e.AreaCode, e.Division, e.LineOfBusiness }, "UQ_ExperienceLoss")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1) AND [LossEventId] IS NOT NULL)");

                entity.Property(e => e.AreaCode).HasMaxLength(100);
                entity.Property(e => e.CountryCode).HasMaxLength(10);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Division).HasMaxLength(100);
                entity.Property(e => e.EventCode).HasMaxLength(20);
                entity.Property(e => e.EventName).HasMaxLength(500);
                entity.Property(e => e.LineOfBusiness).HasMaxLength(100);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(50);
                entity.Property(e => e.PcscatNum).HasColumnName("PCSCatNum");
                entity.Property(e => e.Peril).HasMaxLength(2);
                entity.Property(e => e.ReportedPeril).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SubareaCode).HasMaxLength(100);

                entity.HasOne(d => d.Geography).WithMany(p => p.ExperienceLosses)
                    .HasForeignKey(d => d.GeographyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ExperienceLoss_dbo.Geography_GeographyId");

                entity.HasOne(d => d.LossEstScenario).WithMany(p => p.ExperienceLosses)
                    .HasForeignKey(d => d.LossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ExperienceLoss_dbo.LossEstScenario_LossEstScenarioId");

                entity.HasOne(d => d.LossEvent).WithMany(p => p.ExperienceLosses)
                    .HasForeignKey(d => d.LossEventId)
                    .HasConstraintName("FK_dbo.ExperienceLoss_dbo.LossEvent_LossEventId");
            });

            modelBuilder.Entity<FxRateSbf>(entity =>
            {
                entity.HasKey(e => e.FxRateSbfid).HasName("PK_dbo.FxRateSBF");

                entity.ToTable("FxRateSBF");

                entity.HasIndex(e => new { e.BaseCurrency, e.Currency, e.Fxdate }, "UQ_FXRateSBF").IsUnique();

                entity.Property(e => e.FxRateSbfid).HasColumnName("FxRateSBFId");
                entity.Property(e => e.BaseCurrency).HasMaxLength(3);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Rate).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Fxrate>(entity =>
            {
                entity.HasKey(e => e.FxrateId).HasName("PK_dbo.FXRate");

                entity.ToTable("FXRate");

                entity.HasIndex(e => new { e.BaseCurrency, e.Currency, e.Fxdate }, "UQ_FXRate").IsUnique();

                entity.Property(e => e.FxrateId).HasColumnName("FXRateId");
                entity.Property(e => e.BaseCurrency).HasMaxLength(3);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Rate).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Geography>(entity =>
            {
                entity.HasKey(e => e.GeographyId).HasName("PK_dbo.Geography");

                entity.ToTable("Geography");

                entity.HasIndex(e => new { e.SubareaCode, e.AreaCode }, "IXGeography_AreaSubArea");

                entity.HasIndex(e => e.ParentGeographyId, "IX_ParentGeographyId");

                entity.Property(e => e.AreaCode).HasMaxLength(100);
                entity.Property(e => e.AreaName).HasMaxLength(100);
                entity.Property(e => e.CityName).HasMaxLength(100);
                entity.Property(e => e.CountryCode).HasMaxLength(50);
                entity.Property(e => e.CountryName).HasMaxLength(100);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Crestacode)
                    .HasMaxLength(100)
                    .HasColumnName("CRESTACode");
                entity.Property(e => e.Crestaname)
                    .HasMaxLength(100)
                    .HasColumnName("CRESTAName");
                entity.Property(e => e.GeoLevelCode).HasMaxLength(10);
                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SubareaCode).HasMaxLength(100);
                entity.Property(e => e.SubareaName).HasMaxLength(100);

                entity.HasOne(d => d.ParentGeography).WithMany(p => p.InverseParentGeography)
                    .HasForeignKey(d => d.ParentGeographyId)
                    .HasConstraintName("FK_dbo.Geography_dbo.Geography_ParentGeographyId");
            });

            modelBuilder.Entity<GuAnalysis>(entity =>
            {
                entity.HasKey(e => e.GuAnalysisId).HasName("PK_dbo.GuAnalysis");

                entity.ToTable("GuAnalysis");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.HasIndex(e => e.ZoneDefinitionId, "IX_ZoneDefinitionId");

                entity.Property(e => e.CompatibleVersions).HasMaxLength(50);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Database).HasMaxLength(50);
                entity.Property(e => e.ExtJobId).HasMaxLength(50);
                entity.Property(e => e.ExtJobStatus).HasMaxLength(50);
                entity.Property(e => e.JobId).HasMaxLength(10);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Platform).HasMaxLength(25);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Server).HasMaxLength(50);
                entity.Property(e => e.Version).HasMaxLength(5);

                entity.HasOne(d => d.Submission).WithMany(p => p.GuAnalyses)
                    .HasForeignKey(d => d.SubmissionId)
                    .HasConstraintName("FK_dbo.GuAnalysis_dbo.Submission_SubmissionId");

                entity.HasOne(d => d.ZoneDefinition).WithMany(p => p.GuAnalyses)
                    .HasForeignKey(d => d.ZoneDefinitionId)
                    .HasConstraintName("FK_dbo.GuAnalysis_dbo.ZoneDefinition_ZoneDefinitionId");
            });

            modelBuilder.Entity<GuCurveAdjDef>(entity =>
            {
                entity.HasKey(e => e.GuCurveAdjDefId).HasName("PK_dbo.GuCurveAdjDef");

                entity.ToTable("GuCurveAdjDef");

                entity.HasIndex(e => e.SourceGuAnalysisId, "IX_SourceGuAnalysisId");

                entity.HasIndex(e => e.TargetGuAnalysisId, "IX_TargetGuAnalysisId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.FileName).HasMaxLength(100);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.PmlType).HasMaxLength(100);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.SourceGuAnalysis).WithMany(p => p.GuCurveAdjDefSourceGuAnalyses)
                    .HasForeignKey(d => d.SourceGuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.GuCurveAdjDef_dbo.GuAnalysis_SourceGuAnalysisId");

                entity.HasOne(d => d.TargetGuAnalysis).WithMany(p => p.GuCurveAdjDefTargetGuAnalyses)
                    .HasForeignKey(d => d.TargetGuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.GuCurveAdjDef_dbo.GuAnalysis_TargetGuAnalysisId");
            });

            modelBuilder.Entity<GuCurveAdjPmlSrc>(entity =>
            {
                entity.HasKey(e => e.GuCurveAdjPmlSrcId).HasName("PK_dbo.GuCurveAdjPmlSrc");

                entity.ToTable("GuCurveAdjPmlSrc");

                entity.HasIndex(e => e.GuCurveAdjDefId, "IX_GuCurveAdjDefId");

                entity.Property(e => e.Aep).HasColumnName("AEP");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Oep).HasColumnName("OEP");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.GuCurveAdjDef).WithMany(p => p.GuCurveAdjPmlSrcs)
                    .HasForeignKey(d => d.GuCurveAdjDefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.GuCurveAdjPmlSrc_dbo.GuCurveAdjDef_GuCurveAdjDefId");
            });

            modelBuilder.Entity<IndustryCalibrationAnalysis>(entity =>
            {
                entity.HasKey(e => e.IndustryCalibrationAnalysisId).HasName("PK_dbo.IndustryCalibrationAnalysis");

                entity.ToTable("IndustryCalibrationAnalysis");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Peril).HasMaxLength(100);
                entity.Property(e => e.Platform).HasMaxLength(25);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Version).HasMaxLength(5);
            });

            modelBuilder.Entity<IndustryCalibrationDef>(entity =>
            {
                entity.HasKey(e => e.IndustryCalibrationDefId).HasName("PK_dbo.IndustryCalibrationDef");

                entity.ToTable("IndustryCalibrationDef");

                entity.HasIndex(e => e.SourceGuAnalysisId, "IX_SourceGuAnalysisId");

                entity.HasIndex(e => e.SourceIndustryCalibrationAnalysisId, "IX_SourceIndustryCalibrationAnalysisId");

                entity.HasIndex(e => e.TargetGuAnalysisId, "IX_TargetGuAnalysisId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.SourceGuAnalysis).WithMany(p => p.IndustryCalibrationDefSourceGuAnalyses)
                    .HasForeignKey(d => d.SourceGuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryCalibrationDef_dbo.GuAnalysis_SourceGuAnalysisId");

                entity.HasOne(d => d.SourceIndustryCalibrationAnalysis).WithMany(p => p.IndustryCalibrationDefs)
                    .HasForeignKey(d => d.SourceIndustryCalibrationAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryCalibrationDef_dbo.IndustryCalibrationAnalysis_SourceIndustryCalibrationAnalysisId");

                entity.HasOne(d => d.TargetGuAnalysis).WithMany(p => p.IndustryCalibrationDefTargetGuAnalyses)
                    .HasForeignKey(d => d.TargetGuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryCalibrationDef_dbo.GuAnalysis_TargetGuAnalysisId");
            });

            modelBuilder.Entity<IndustryGuAnalysis>(entity =>
            {
                entity.HasKey(e => e.IndustryGuAnalysisId).HasName("PK_dbo.IndustryGuAnalysis");

                entity.ToTable("IndustryGuAnalysis");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Peril).HasMaxLength(100);
                entity.Property(e => e.Platform).HasMaxLength(25);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Version).HasMaxLength(5);
            });

            modelBuilder.Entity<IndustryLoss>(entity =>
            {
                entity.HasKey(e => e.IndustryLossId).HasName("PK_dbo.IndustryLoss");

                entity.ToTable("IndustryLoss");

                entity.HasIndex(e => e.GeographyId, "IX_GeographyId");

                entity.HasIndex(e => e.LossEventId, "IX_LossEventId");

                entity.Property(e => e.Country).HasMaxLength(2);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.EstType).HasMaxLength(3);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.OnLevelDate).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
                entity.Property(e => e.ReleaseDate).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Source).HasMaxLength(10);
                entity.Property(e => e.State).HasMaxLength(20);
                entity.Property(e => e.WcavgPmt).HasColumnName("WCAvgPmt");
                entity.Property(e => e.WcclaimCount).HasColumnName("WCClaimCount");
                entity.Property(e => e.Wcloss).HasColumnName("WCLoss");

                entity.HasOne(d => d.Geography).WithMany(p => p.IndustryLosses)
                    .HasForeignKey(d => d.GeographyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryLoss_dbo.Geography_GeographyId");

                entity.HasOne(d => d.LossEvent).WithMany(p => p.IndustryLosses)
                    .HasForeignKey(d => d.LossEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryLoss_dbo.LossEvent_LossEventId");
            });

            modelBuilder.Entity<IndustryLossFilter>(entity =>
            {
                entity.HasKey(e => e.IndustryLossFilterId).HasName("PK_dbo.IndustryLossFilter");

                entity.ToTable("IndustryLossFilter");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.EventThreshold).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<IndustryLossRegion>(entity =>
            {
                entity.HasKey(e => e.IndustryLossRegionId).HasName("PK_dbo.IndustryLossRegion");

                entity.ToTable("IndustryLossRegion");

                entity.HasIndex(e => e.Name, "UQ_IndustryLossRegion").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<IndustryLossSubRegion>(entity =>
            {
                entity.HasKey(e => e.IndustryLossSubRegionId).HasName("PK_dbo.IndustryLossSubRegion");

                entity.ToTable("IndustryLossSubRegion");

                entity.HasIndex(e => new { e.IndustryLossRegionId, e.GeographyId, e.Name }, "UQ_IndustryLossSubRegion").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Geography).WithMany(p => p.IndustryLossSubRegions)
                    .HasForeignKey(d => d.GeographyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryLossSubRegion_dbo.Geography_GeographyId");

                entity.HasOne(d => d.IndustryLossRegion).WithMany(p => p.IndustryLossSubRegions)
                    .HasForeignKey(d => d.IndustryLossRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryLossSubRegion_dbo.IndustryLossRegion_IndustryLossRegionId");
            });

            modelBuilder.Entity<IndustryOnLevelLoss>(entity =>
            {
                entity.HasKey(e => e.IndustryOnLevelLossId).HasName("PK_dbo.IndustryOnLevelLoss");

                entity.ToTable("IndustryOnLevelLoss");

                entity.HasIndex(e => e.IndustryLossId, "IX_IndustryLossId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IndustryLoss).WithMany(p => p.IndustryOnLevelLosses)
                    .HasForeignKey(d => d.IndustryLossId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IndustryOnLevelLoss_dbo.IndustryLoss_IndustryLossId");
            });

            modelBuilder.Entity<Layer>(entity =>
            {
                entity.HasKey(e => e.LayerId).HasName("PK_dbo.Layer");

                entity.ToTable("Layer");

                entity.HasIndex(e => e.AcctBrokerId, "IX_AcctBrokerId");

                entity.HasIndex(e => e.ExpiringLayerId, "IX_ExpiringLayerId");

                entity.HasIndex(e => e.RiskZoneId, "IX_RiskZoneId");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.HasIndex(e => e.RegisId, "UQ_RegisIdLayer")
                    .IsUnique()
                    .HasFilter("([RegisId] IS NOT NULL AND [RegisId]<>'' AND [RegisId]<>'0' AND [IsDeleted]=(0) AND [IsActive]=(1))");

                entity.HasIndex(e => e.SourceId, "UQ_SourceId")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1) AND [IsDeleted]=(0) AND ([SourceId] IS NOT NULL AND [SourceId]<>''))");

                entity.Property(e => e.Aad)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("AAD");
                entity.Property(e => e.AggLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AggRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AuthCorreShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.AuthShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.BoundFxdate).HasColumnName("BoundFXDate");
                entity.Property(e => e.BoundFxrate)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("BoundFXRate");
                entity.Property(e => e.BrokerRef).HasMaxLength(50);
                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.BurnReported).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.BurnTrended).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CascadeRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CatLoss1).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CatLoss2).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CatLoss3).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Ccfyears).HasColumnName("CCFYears");
                entity.Property(e => e.Cloud).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ComAccountProtect).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CommOverride).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Commission).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreAuthMax).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreAuthMin).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreAuthTarget).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CorreRenewalMin).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Dcfamount).HasColumnName("DCFAmount");
                entity.Property(e => e.Dcfyears).HasColumnName("DCFYears");
                entity.Property(e => e.DeclineReason).HasMaxLength(250);
                entity.Property(e => e.DiversificationFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Elbroker)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELBroker");
                entity.Property(e => e.ElhistoricalBurn)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELHistoricalBurn");
                entity.Property(e => e.ElmarketShare)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELMarketShare");
                entity.Property(e => e.Erc)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ERC");
                entity.Property(e => e.Ercactual)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ERCActual");
                entity.Property(e => e.ErcactualSource).HasColumnName("ERCActualSource");
                entity.Property(e => e.Ercmid)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ERCMid");
                entity.Property(e => e.Ercmodel)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ERCModel");
                entity.Property(e => e.Ercpareto)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ERCPareto");
                entity.Property(e => e.Ercquote)
                    .HasDefaultValue(0m)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ERCQuote");
                entity.Property(e => e.EstimatedShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.EventNumber).HasMaxLength(50);
                entity.Property(e => e.ExpectedGrossNetPremiumGbp).HasColumnName("ExpectedGrossNetPremiumGBP");
                entity.Property(e => e.ExpiringCorreShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Facility).HasMaxLength(50);
                entity.Property(e => e.Fhcfband).HasColumnName("FHCFBand");
                entity.Property(e => e.Franchise).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FranchiseReverse).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FrontingFee).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GrossUpFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.InuringLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InvestmentReturn).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.IrisbranchCode).HasColumnName("IRISBranchCode");
                entity.Property(e => e.IrisclassCode).HasColumnName("IRISClassCode");
                entity.Property(e => e.Iriscomments).HasColumnName("IRISComments");
                entity.Property(e => e.IrisplacingCode).HasColumnName("IRISPlacingCode");
                entity.Property(e => e.IrispolicySeqNumber)
                    .HasMaxLength(2)
                    .HasColumnName("IRISPolicySeqNumber");
                entity.Property(e => e.IrisproductCode).HasColumnName("IRISProductCode");
                entity.Property(e => e.IrisrefId).HasColumnName("IRISRefId");
                entity.Property(e => e.Irisstatus).HasColumnName("IRISStatus");
                entity.Property(e => e.IristradeCode).HasColumnName("IRISTradeCode");
                entity.Property(e => e.Laeterm).HasColumnName("LAETerm");
                entity.Property(e => e.LayerCatalog).HasMaxLength(20);
                entity.Property(e => e.LayerDesc).HasMaxLength(120);
                entity.Property(e => e.LloydsCapital).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LloydsRoc)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LloydsROC");
                entity.Property(e => e.Lob)
                    .HasMaxLength(50)
                    .HasColumnName("LOB");
                entity.Property(e => e.LossCorridorBeginPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossCorridorCedePct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossCorridorEndPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossDuration).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Maol).HasColumnName("MAOL");
                entity.Property(e => e.MktRol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("MktROL");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Ncbr).HasColumnName("NCBR");
                entity.Property(e => e.NonCatMarginAllowance).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.NonCatWeightPc)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("NonCatWeightPC");
                entity.Property(e => e.NonCatWeightSs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("NonCatWeightSS");
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.OccLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OccLimitInPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.OccRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OccRetnInPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.OrderPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.OtherExpenses).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.PcstartDate).HasColumnName("PCStartDate");
                entity.Property(e => e.Placement).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ProfitComm).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ProfitCommissionExpAllowance).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.QuotePremium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.QuoteRol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("QuoteROL");
                entity.Property(e => e.QuotedCorreShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.QuotedShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Ransom).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Rate).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RegisIdCt).HasMaxLength(20);
                entity.Property(e => e.RegisLayerCode).HasMaxLength(10);
                entity.Property(e => e.RegisMkey)
                    .HasMaxLength(20)
                    .HasColumnName("RegisMKey");
                entity.Property(e => e.RegisMsg).HasMaxLength(500);
                entity.Property(e => e.RegisNbr).HasMaxLength(20);
                entity.Property(e => e.RegisNbrCt).HasMaxLength(20);
                entity.Property(e => e.ReinsurerExpenses).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RelShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RiskLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RiskRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Rol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL");
                entity.Property(e => e.RolRpp).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Segment).HasMaxLength(50);
                entity.Property(e => e.SignedCorreShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.SignedShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.SourceId).HasMaxLength(50);
                entity.Property(e => e.SscommMax)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommMax");
                entity.Property(e => e.SscommMin)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommMin");
                entity.Property(e => e.SscommProv)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommProv");
                entity.Property(e => e.SslossRatioMax)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioMax");
                entity.Property(e => e.SslossRatioMin)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioMin");
                entity.Property(e => e.SslossRatioProv)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioProv");
                entity.Property(e => e.StopLossAttachPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.StopLossBufferPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.StopLossLimitPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.TargetNetShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.TerrorismSubLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TopUpZoneId).HasDefaultValue(0);
                entity.Property(e => e.Uwyear).HasColumnName("UWYear");
                entity.Property(e => e.Var1Retention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Var2Retention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.VarCommHi).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.VarCommLow).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Wilresolution).HasColumnName("WILResolution");

                entity.HasOne(d => d.AcctBroker).WithMany(p => p.Layers)
                    .HasForeignKey(d => d.AcctBrokerId)
                    .HasConstraintName("FK_dbo.Layer_dbo.Broker_AcctBrokerId");

                entity.HasOne(d => d.ExpiringLayer).WithMany(p => p.InverseExpiringLayer)
                    .HasForeignKey(d => d.ExpiringLayerId)
                    .HasConstraintName("FK_dbo.Layer_dbo.Layer_ExpiringLayerId");

                entity.HasOne(d => d.RiskZone).WithMany(p => p.Layers)
                    .HasForeignKey(d => d.RiskZoneId)
                    .HasConstraintName("FK_dbo.Layer_dbo.RiskZone_RiskZoneId");

                entity.HasOne(d => d.Submission).WithMany(p => p.Layers)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Layer_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<LayerExperienceLoss>(entity =>
            {
                entity.HasKey(e => e.LayerExperienceLossId).HasName("PK_dbo.LayerExperienceLoss");

                entity.ToTable("LayerExperienceLoss");

                entity.HasIndex(e => e.ExperienceLossId, "IX_ExperienceLossId");

                entity.HasIndex(e => e.LayerLossEstScenarioId, "IX_LayerLossEstScenarioId");

                entity.HasIndex(e => new { e.ExperienceLossId, e.LayerLossEstScenarioId }, "UQ_LayerExperienceLoss")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ExperienceLoss).WithMany(p => p.LayerExperienceLosses)
                    .HasForeignKey(d => d.ExperienceLossId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerExperienceLoss_dbo.ExperienceLoss_ExperienceLossId");

                entity.HasOne(d => d.LayerLossEstScenario).WithMany(p => p.LayerExperienceLosses)
                    .HasForeignKey(d => d.LayerLossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerExperienceLoss_dbo.LayerLossEstScenario_LayerLossEstScenarioId");
            });

            modelBuilder.Entity<LayerLossAnalysis>(entity =>
            {
                entity.HasKey(e => e.LayerLossAnalysisId).HasName("PK_dbo.LayerLossAnalysis");

                entity.ToTable("LayerLossAnalysis");

                entity.HasIndex(e => e.AlphaGuAnalysisId, "IX_AlphaGuAnalysisId");

                entity.HasIndex(e => e.GuAnalysisId, "IX_GuAnalysisId");

                entity.HasIndex(e => e.LossAnalysisId, "IX_LossAnalysisId");

                entity.Property(e => e.CedentCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentCS");
                entity.Property(e => e.CedentEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentEQ");
                entity.Property(e => e.CedentFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentFL");
                entity.Property(e => e.CedentWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentWF");
                entity.Property(e => e.CedentWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentWS");
                entity.Property(e => e.CedentWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentWT");
                entity.Property(e => e.Cr)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CR");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.El).HasColumnName("EL");
                entity.Property(e => e.Elattritional)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELAttritional");
                entity.Property(e => e.EllargeLoss)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELLargeLoss");
                entity.Property(e => e.Elmodeled)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELModeled");
                entity.Property(e => e.ElnonModeled)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELNonModeled");
                entity.Property(e => e.Er)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ER");
                entity.Property(e => e.GrowthCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthCS");
                entity.Property(e => e.GrowthEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthEQ");
                entity.Property(e => e.GrowthFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthFL");
                entity.Property(e => e.GrowthWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthWF");
                entity.Property(e => e.GrowthWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthWS");
                entity.Property(e => e.GrowthWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthWT");
                entity.Property(e => e.Inflation).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LaeCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeCS");
                entity.Property(e => e.LaeEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeEQ");
                entity.Property(e => e.LaeFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeFL");
                entity.Property(e => e.LaeWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeWF");
                entity.Property(e => e.LaeWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeWS");
                entity.Property(e => e.LaeWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeWT");
                entity.Property(e => e.Lr)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LR");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.PerilCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilCS");
                entity.Property(e => e.PerilEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilEQ");
                entity.Property(e => e.PerilFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilFL");
                entity.Property(e => e.PerilWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilWF");
                entity.Property(e => e.PerilWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilWS");
                entity.Property(e => e.PerilWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilWT");
                entity.Property(e => e.Rb).HasColumnName("RB");
                entity.Property(e => e.ReasonStale).HasMaxLength(4000);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Rp).HasColumnName("RP");
                entity.Property(e => e.SocialCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialCS");
                entity.Property(e => e.SocialEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialEQ");
                entity.Property(e => e.SocialFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialFL");
                entity.Property(e => e.SocialWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialWF");
                entity.Property(e => e.SocialWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialWS");
                entity.Property(e => e.SocialWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialWT");
                entity.Property(e => e.StandaloneRoe).HasColumnName("StandaloneROE");
                entity.Property(e => e.StandaloneRoequote).HasColumnName("StandaloneROEQuote");

                entity.HasOne(d => d.AlphaGuAnalysis).WithMany(p => p.LayerLossAnalyses)
                    .HasForeignKey(d => d.AlphaGuAnalysisId)
                    .HasConstraintName("FK_dbo.LayerLossAnalysis_dbo.AlphaGuAnalysis_AlphaGuAnalysisId");

                entity.HasOne(d => d.GuAnalysis).WithMany(p => p.LayerLossAnalyses)
                    .HasForeignKey(d => d.GuAnalysisId)
                    .HasConstraintName("FK_dbo.LayerLossAnalysis_dbo.GuAnalysis_GuAnalysisId");

                entity.HasOne(d => d.Layer).WithMany(p => p.LayerLossAnalyses)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerLossAnalysis_dbo.Layer_LayerId");

                entity.HasOne(d => d.LossAnalysis).WithMany(p => p.LayerLossAnalyses)
                    .HasForeignKey(d => d.LossAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerLossAnalysis_dbo.LossAnalysis_LossAnalysisId");
            });

            modelBuilder.Entity<LayerLossEstScenario>(entity =>
            {
                entity.HasKey(e => e.LayerLossEstScenarioId).HasName("PK_dbo.LayerLossEstScenario");

                entity.ToTable("LayerLossEstScenario");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.HasIndex(e => e.LossEstScenarioId, "IX_LossEstScenarioId");

                entity.HasIndex(e => new { e.LossEstScenarioId, e.LayerId }, "UQ_LayerLossEstScenario")
                    .IsUnique()
                    .HasFilter("([LayerId] IS NOT NULL AND [ISActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.LayerLossEstScenarios)
                    .HasForeignKey(d => d.LayerId)
                    .HasConstraintName("FK_dbo.LayerLossEstScenario_dbo.Layer_LayerId");

                entity.HasOne(d => d.LossEstScenario).WithMany(p => p.LayerLossEstScenarios)
                    .HasForeignKey(d => d.LossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerLossEstScenario_dbo.LossEstScenario_LossEstScenarioId");
            });

            modelBuilder.Entity<LayerMarketShareFactor>(entity =>
            {
                entity.HasKey(e => e.LayerMarketShareFactorId).HasName("PK_dbo.LayerMarketShareFactor");

                entity.ToTable("LayerMarketShareFactor");

                entity.HasIndex(e => e.LayerLossEstScenarioId, "IX_LayerLossEstScenarioId");

                entity.HasIndex(e => e.MarketShareFactorId, "IX_MarketShareFactorId");

                entity.HasIndex(e => new { e.MarketShareFactorId, e.LayerLossEstScenarioId }, "UQ_LayerMarketShareFactor")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.LayerLossEstScenario).WithMany(p => p.LayerMarketShareFactors)
                    .HasForeignKey(d => d.LayerLossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerMarketShareFactor_dbo.LayerLossEstScenario_LayerLossEstScenarioId");

                entity.HasOne(d => d.MarketShareFactor).WithMany(p => p.LayerMarketShareFactors)
                    .HasForeignKey(d => d.MarketShareFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerMarketShareFactor_dbo.MarketShareFactor_MarketShareFactorId");
            });

            modelBuilder.Entity<LayerMarketShareLoss>(entity =>
            {
                entity.HasKey(e => e.LayerMarketShareLossId).HasName("PK_dbo.LayerMarketShareLoss");

                entity.ToTable("LayerMarketShareLoss");

                entity.HasIndex(e => e.LayerLossEstScenarioId, "IX_LayerLossEstScenarioId");

                entity.HasIndex(e => e.MarketShareLossId, "IX_MarketShareLossId");

                entity.HasIndex(e => new { e.MarketShareLossId, e.LayerLossEstScenarioId }, "UQ_LayerMarketShareLoss")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.LayerLossEstScenario).WithMany(p => p.LayerMarketShareLosses)
                    .HasForeignKey(d => d.LayerLossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerMarketShareLoss_dbo.LayerLossEstScenario_LayerLossEstScenarioId");

                entity.HasOne(d => d.MarketShareLoss).WithMany(p => p.LayerMarketShareLosses)
                    .HasForeignKey(d => d.MarketShareLossId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerMarketShareLoss_dbo.MarketShareLoss_MarketShareLossId");
            });

            modelBuilder.Entity<LayerTopUpLossContract>(entity =>
            {
                entity.HasKey(e => e.LayerTopUpLossContractId).HasName("PK_dbo.LayerTopUpLossContract");

                entity.ToTable("LayerTopUpLossContract");

                entity.HasIndex(e => e.ContractId, "IX_ContractId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.ZoneLossPercent).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.Contract).WithMany(p => p.LayerTopUpLossContracts)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LayerTopUpLossContract_dbo.Contract_ContractId");
            });

            modelBuilder.Entity<LegalTerm>(entity =>
            {
                entity.HasKey(e => e.LegalTermsId).HasName("PK_dbo.LegalTerms");

                entity.HasIndex(e => e.LegalReviewerId, "IX_LegalReviewerId");

                entity.HasIndex(e => e.ReviewerId, "IX_ReviewerId");

                entity.HasIndex(e => e.TareviewerId, "IX_TAReviewerId");

                entity.Property(e => e.AddnlComments).HasMaxLength(1000);
                entity.Property(e => e.BrushFireComments).HasMaxLength(250);
                entity.Property(e => e.CommDiseaseComments).HasMaxLength(500);
                entity.Property(e => e.ContractClauseSet).HasMaxLength(50);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Cyber).HasMaxLength(50);
                entity.Property(e => e.CyberComments).HasMaxLength(200);
                entity.Property(e => e.EcoXplPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.EmployerLiabilityLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FloodComments).HasMaxLength(250);
                entity.Property(e => e.FreezeComments).HasMaxLength(250);
                entity.Property(e => e.IsNcbrexcluded).HasColumnName("IsNCBRExcluded");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Nbc).HasColumnName("NBC");
                entity.Property(e => e.OsReason).HasMaxLength(50);
                entity.Property(e => e.OtherNatComments).HasMaxLength(250);
                entity.Property(e => e.Priority).HasMaxLength(50);
                entity.Property(e => e.QuakeComments).HasMaxLength(250);
                entity.Property(e => e.RiotComments).HasMaxLength(250);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.State).HasMaxLength(10);
                entity.Property(e => e.TareviewerId).HasColumnName("TAReviewerId");
                entity.Property(e => e.Territory).HasMaxLength(250);
                entity.Property(e => e.TerrorComments).HasMaxLength(200);
                entity.Property(e => e.WindComments).HasMaxLength(250);

                entity.HasOne(d => d.LegalReviewer).WithMany(p => p.LegalTermLegalReviewers)
                    .HasForeignKey(d => d.LegalReviewerId)
                    .HasConstraintName("FK_dbo.LegalTerms_dbo.User_LegalReviewerId");

                entity.HasOne(d => d.Reviewer).WithMany(p => p.LegalTermReviewers)
                    .HasForeignKey(d => d.ReviewerId)
                    .HasConstraintName("FK_dbo.LegalTerms_dbo.User_ReviewerId");

                entity.HasOne(d => d.Tareviewer).WithMany(p => p.LegalTermTareviewers)
                    .HasForeignKey(d => d.TareviewerId)
                    .HasConstraintName("FK_dbo.LegalTerms_dbo.User_TAReviewerId");
            });

            modelBuilder.Entity<LegalTermClause>(entity =>
            {
                entity.HasKey(e => e.LegalTermClauseId).HasName("PK_dbo.LegalTermClause");

                entity.ToTable("LegalTermClause");

                entity.HasIndex(e => new { e.LegalTermsId, e.ContractClauseId }, "UQ_LegalTermClause")
                    .IsUnique()
                    .HasFilter("([IsDeleted]=(0) AND [IsActive]=(1))");

                entity.Property(e => e.CommentsTa).HasColumnName("CommentsTA");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ContractClause).WithMany(p => p.LegalTermClauses)
                    .HasForeignKey(d => d.ContractClauseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LegalTermClause_dbo.ContractClause_ContractClauseId");

                entity.HasOne(d => d.LegalTerms).WithMany(p => p.LegalTermClauses)
                    .HasForeignKey(d => d.LegalTermsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LegalTermClause_dbo.LegalTerms_LegalTermsId");
            });

            modelBuilder.Entity<LloydsRiskCode>(entity =>
            {
                entity.HasKey(e => e.LloydsRiskCodeId).HasName("PK_dbo.LloydsRiskCode");

                entity.ToTable("LloydsRiskCode");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.Layer).WithMany(p => p.LloydsRiskCodes)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LloydsRiskCode_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<LossAnalysis>(entity =>
            {
                entity.HasKey(e => e.LossAnalysisId).HasName("PK_dbo.LossAnalysis");

                entity.ToTable("LossAnalysis");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.HasIndex(e => new { e.Name, e.SubmissionId, e.Model }, "UQ_LossAnalysis_Name")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1) AND [IsDeleted]=(0))");

                entity.HasIndex(e => new { e.SubmissionId, e.LossView }, "UQ_LossView")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1) AND ([LossView] IN ((1), (2), (3))))");

                entity.Property(e => e.CedentCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentCS");
                entity.Property(e => e.CedentEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentEQ");
                entity.Property(e => e.CedentFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentFL");
                entity.Property(e => e.CedentWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentWF");
                entity.Property(e => e.CedentWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentWS");
                entity.Property(e => e.CedentWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("CedentWT");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.GrowthCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthCS");
                entity.Property(e => e.GrowthEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthEQ");
                entity.Property(e => e.GrowthFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthFL");
                entity.Property(e => e.GrowthWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthWF");
                entity.Property(e => e.GrowthWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthWS");
                entity.Property(e => e.GrowthWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("GrowthWT");
                entity.Property(e => e.Inflation).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.JobId).HasMaxLength(10);
                entity.Property(e => e.LaeCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeCS");
                entity.Property(e => e.LaeEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeEQ");
                entity.Property(e => e.LaeFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeFL");
                entity.Property(e => e.LaeWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeWF");
                entity.Property(e => e.LaeWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeWS");
                entity.Property(e => e.LaeWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("LaeWT");
                entity.Property(e => e.Model).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Notes).HasMaxLength(1000);
                entity.Property(e => e.PerilCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilCS");
                entity.Property(e => e.PerilEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilEQ");
                entity.Property(e => e.PerilFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilFL");
                entity.Property(e => e.PerilWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilWF");
                entity.Property(e => e.PerilWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilWS");
                entity.Property(e => e.PerilWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PerilWT");
                entity.Property(e => e.ReasonStale).HasMaxLength(4000);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SocialCs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialCS");
                entity.Property(e => e.SocialEq)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialEQ");
                entity.Property(e => e.SocialFl)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialFL");
                entity.Property(e => e.SocialWf)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialWF");
                entity.Property(e => e.SocialWs)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialWS");
                entity.Property(e => e.SocialWt)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SocialWT");

                entity.HasOne(d => d.GuAnalysis).WithMany(p => p.LossAnalyses)
                    .HasForeignKey(d => d.GuAnalysisId)
                    .HasConstraintName("FK_dbo.LossAnalysis_dbo.GuAnalysis_GuAnalysisId");

                entity.HasOne(d => d.Submission).WithMany(p => p.LossAnalyses)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LossAnalysis_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<LossEstScenario>(entity =>
            {
                entity.HasKey(e => e.LossEstScenarioId).HasName("PK_dbo.LossEstScenario");

                entity.ToTable("LossEstScenario");

                entity.HasIndex(e => e.IndustryLossFilterId, "IX_IndustryLossFilterId");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Fxdate)
                    .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                    .HasColumnName("FXDate");
                entity.Property(e => e.IndLossFxRateUsd)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("IndLossFxRateUSD");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IndustryLossFilter).WithMany(p => p.LossEstScenarios)
                    .HasForeignKey(d => d.IndustryLossFilterId)
                    .HasConstraintName("FK_dbo.LossEstScenario_dbo.IndustryLossFilter_IndustryLossFilterId");

                entity.HasOne(d => d.Submission).WithMany(p => p.LossEstScenarios)
                    .HasForeignKey(d => d.SubmissionId)
                    .HasConstraintName("FK_dbo.LossEstScenario_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<LossEvent>(entity =>
            {
                entity.HasKey(e => e.LossEventId).HasName("PK_dbo.LossEvent");

                entity.ToTable("LossEvent");

                entity.HasIndex(e => e.CedentId, "IX_CedentId");

                entity.HasIndex(e => e.EventCode, "UQ_LossEventCode").IsUnique();

                entity.Property(e => e.AireventId).HasColumnName("AIREventId");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.EventCode).HasMaxLength(20);
                entity.Property(e => e.EventType).HasMaxLength(1);
                entity.Property(e => e.IndustryEventCode).HasDefaultValue("");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.PcscatNum).HasColumnName("PCSCatNum");
                entity.Property(e => e.Peril).HasMaxLength(10);
                entity.Property(e => e.Region).HasMaxLength(50);
                entity.Property(e => e.RmseventId).HasColumnName("RMSEventId");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Cedent).WithMany(p => p.LossEvents)
                    .HasForeignKey(d => d.CedentId)
                    .HasConstraintName("FK_dbo.LossEvent_dbo.Cedent_CedentId");
            });

            modelBuilder.Entity<LossPool>(entity =>
            {
                entity.HasKey(e => e.LossPoolId).HasName("PK_dbo.LossPool");

                entity.ToTable("LossPool");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.LegalEntity).HasMaxLength(100);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<LossTrendFactor>(entity =>
            {
                entity.HasKey(e => e.LossTrendFactorId).HasName("PK_dbo.LossTrendFactor");

                entity.ToTable("LossTrendFactor");

                entity.HasIndex(e => e.LossEstScenarioId, "IX_LossEstScenarioId");

                entity.HasIndex(e => new { e.LossEstScenarioId, e.ExposureYear }, "UQ_LossTrendFactor")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ExposureTrend).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.HistPremFacultative).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistPremProportional).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistPremTotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistPremXol).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistTivFacultative).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistTivProportional).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistTivTotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistTivXol).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HistoricalPremium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.IncurredLdfs).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RateChange).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SeverityTrend).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.LossEstScenario).WithMany(p => p.LossTrendFactors)
                    .HasForeignKey(d => d.LossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LossTrendFactor_dbo.LossEstScenario_LossEstScenarioId");
            });

            modelBuilder.Entity<LossViewResult>(entity =>
            {
                entity.HasKey(e => e.LossViewResultId).HasName("PK_dbo.LossViewResult");

                entity.ToTable("LossViewResult");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.HasIndex(e => new { e.LayerId, e.LossView }, "UQ_LossView")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.Cr).HasColumnName("CR");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.El).HasColumnName("EL");
                entity.Property(e => e.Elatt).HasColumnName("ELAtt");
                entity.Property(e => e.EllargeLoss).HasColumnName("ELLargeLoss");
                entity.Property(e => e.Elmodeled).HasColumnName("ELModeled");
                entity.Property(e => e.ElnonModeled).HasColumnName("ELNonModeled");
                entity.Property(e => e.Lr).HasColumnName("LR");
                entity.Property(e => e.Lratt).HasColumnName("LRAtt");
                entity.Property(e => e.LrlargeLoss).HasColumnName("LRLargeLoss");
                entity.Property(e => e.Lrmodeled).HasColumnName("LRModeled");
                entity.Property(e => e.LrnonModeled).HasColumnName("LRNonModeled");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Ncbcomm).HasColumnName("NCBComm");
                entity.Property(e => e.Ptm).HasColumnName("PTM");
                entity.Property(e => e.Ptmquote).HasColumnName("PTMQuote");
                entity.Property(e => e.Rb).HasColumnName("RB");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Rp).HasColumnName("RP");
                entity.Property(e => e.Sscomm).HasColumnName("SSComm");
                entity.Property(e => e.StandaloneRoe).HasColumnName("StandaloneROE");
                entity.Property(e => e.StandaloneRoecorreAuth).HasColumnName("StandaloneROECorreAuth");
                entity.Property(e => e.StandaloneRoecorreQuote).HasColumnName("StandaloneROECorreQuote");
                entity.Property(e => e.StandaloneRoequote).HasColumnName("StandaloneROEQuote");

                entity.HasOne(d => d.Layer).WithMany(p => p.LossViewResults)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LossViewResult_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<LossViewResultContract>(entity =>
            {
                entity.HasKey(e => e.LossViewResultContractId).HasName("PK_dbo.LossViewResultContract");

                entity.ToTable("LossViewResultContract");

                entity.HasIndex(e => e.ContractId, "IX_ContractId");

                entity.Property(e => e.Cr).HasColumnName("CR");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.El).HasColumnName("EL");
                entity.Property(e => e.Elamount).HasColumnName("ELAmount");
                entity.Property(e => e.Elatt).HasColumnName("ELAtt");
                entity.Property(e => e.EllargeLoss).HasColumnName("ELLargeLoss");
                entity.Property(e => e.Elmodeled).HasColumnName("ELModeled");
                entity.Property(e => e.ElnonModeled).HasColumnName("ELNonModeled");
                entity.Property(e => e.Er).HasColumnName("ER");
                entity.Property(e => e.LossView).HasMaxLength(25);
                entity.Property(e => e.Lr).HasColumnName("LR");
                entity.Property(e => e.Lratt).HasColumnName("LRAtt");
                entity.Property(e => e.LrlargeLoss).HasColumnName("LRLargeLoss");
                entity.Property(e => e.Lrmodeled).HasColumnName("LRModeled");
                entity.Property(e => e.LrnonModeled).HasColumnName("LRNonModeled");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Ncbcomm).HasColumnName("NCBComm");
                entity.Property(e => e.Ptm).HasColumnName("PTM");
                entity.Property(e => e.Rb).HasColumnName("RB");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Rp).HasColumnName("RP");
                entity.Property(e => e.Sscomm).HasColumnName("SSComm");
                entity.Property(e => e.StandaloneRoe).HasColumnName("StandaloneROE");
                entity.Property(e => e.StandaloneRoecorre).HasColumnName("StandaloneROECorre");

                entity.HasOne(d => d.Contract).WithMany(p => p.LossViewResultContracts)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LossViewResultContract_dbo.Contract_ContractId");
            });

            modelBuilder.Entity<LossZone>(entity =>
            {
                entity.HasKey(e => e.LossZoneId).HasName("PK_dbo.LossZone");

                entity.ToTable("LossZone");

                entity.HasIndex(e => e.Name, "UQ_LossZoneName").IsUnique();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<MajorZone>(entity =>
            {
                entity.HasKey(e => e.MajorZoneId).HasName("PK_dbo.MajorZone");

                entity.ToTable("MajorZone");

                entity.HasIndex(e => e.Name, "UQ_MajorZoneName").IsUnique();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<MarketShareFactor>(entity =>
            {
                entity.HasKey(e => e.MarketShareFactorId).HasName("PK_dbo.MarketShareFactor");

                entity.ToTable("MarketShareFactor");

                entity.HasIndex(e => e.IndustryLossSubRegionId, "IX_IndustryLossSubRegionId");

                entity.HasIndex(e => e.LossEstScenarioId, "IX_LossEstScenarioId");

                entity.HasIndex(e => new { e.LossEstScenarioId, e.IndustryLossSubRegionId, e.Peril }, "UQ_MarketShareFactor")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Peril).HasMaxLength(3);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IndustryLossSubRegion).WithMany(p => p.MarketShareFactors)
                    .HasForeignKey(d => d.IndustryLossSubRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MarketShareFactor_dbo.IndustryLossSubRegion_IndustryLossSubRegionId");

                entity.HasOne(d => d.LossEstScenario).WithMany(p => p.MarketShareFactors)
                    .HasForeignKey(d => d.LossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MarketShareFactor_dbo.LossEstScenario_LossEstScenarioId");
            });

            modelBuilder.Entity<MarketShareLoss>(entity =>
            {
                entity.HasKey(e => e.MarketShareLossId).HasName("PK_dbo.MarketShareLoss");

                entity.ToTable("MarketShareLoss");

                entity.HasIndex(e => e.IndustryLossId, "IX_IndustryLossId");

                entity.HasIndex(e => e.LossEstScenarioId, "IX_LossEstScenarioId");

                entity.HasIndex(e => e.MarketShareFactorId, "IX_MarketShareFactorId");

                entity.HasIndex(e => new { e.LossEstScenarioId, e.IndustryLossId }, "UQ_MarketShareLoss")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IndustryLoss).WithMany(p => p.MarketShareLosses)
                    .HasForeignKey(d => d.IndustryLossId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MarketShareLoss_dbo.IndustryLoss_IndustryLossId");

                entity.HasOne(d => d.LossEstScenario).WithMany(p => p.MarketShareLosses)
                    .HasForeignKey(d => d.LossEstScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MarketShareLoss_dbo.LossEstScenario_LossEstScenarioId");

                entity.HasOne(d => d.MarketShareFactor).WithMany(p => p.MarketShareLosses)
                    .HasForeignKey(d => d.MarketShareFactorId)
                    .HasConstraintName("FK_dbo.MarketShareLoss_dbo.MarketShareFactor_MarketShareFactorId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);
                entity.Property(e => e.ContextKey).HasMaxLength(300);
                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<ModelAnalysis>(entity =>
            {
                entity.HasKey(e => e.ModelAnalysisId).HasName("PK_dbo.ModelAnalysis");

                entity.ToTable("ModelAnalysis");

                entity.HasIndex(e => e.GuAnalysisId, "IX_GuAnalysisId");

                entity.Property(e => e.CedentShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Database).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.Property(e => e.FileName).HasMaxLength(150);
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.Fxrate)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FXRate");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Peril).HasMaxLength(100);
                entity.Property(e => e.Perspective).HasMaxLength(2);
                entity.Property(e => e.Platform).HasMaxLength(25);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Server).HasMaxLength(50);
                entity.Property(e => e.Version).HasMaxLength(5);
                entity.Property(e => e.Zones).HasMaxLength(2000);

                entity.HasOne(d => d.GuAnalysis).WithMany(p => p.ModelAnalyses)
                    .HasForeignKey(d => d.GuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ModelAnalysis_dbo.GuAnalysis_GuAnalysisId");
            });

            modelBuilder.Entity<MultiyearShare>(entity =>
            {
                entity.HasKey(e => e.MultiyearShareId).HasName("PK_dbo.MultiyearShare");

                entity.ToTable("MultiyearShare");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.Property(e => e.AuthShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.EstimatedShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Placement).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.QuotedShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Rol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SignedShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Uwyear).HasColumnName("UWYear");

                entity.HasOne(d => d.Layer).WithMany(p => p.MultiyearShares)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MultiyearShare_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<NotificationEvent>(entity =>
            {
                entity.HasKey(e => e.NotificationEventId).HasName("PK_dbo.NotificationEvent");

                entity.ToTable("NotificationEvent");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.OfficeId).HasName("PK_dbo.Office");

                entity.ToTable("Office");

                entity.HasIndex(e => e.CompanyId, "IX_CompanyId");

                entity.HasIndex(e => e.Name, "IX_Name").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Company).WithMany(p => p.Offices)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Office_dbo.Company_CompanyId");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissionId).HasName("PK_dbo.Permission");

                entity.ToTable("Permission");

                entity.HasIndex(e => e.Name, "UQ_Permission_Name").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Desc).HasMaxLength(100);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<PmlMatchingDef>(entity =>
            {
                entity.HasKey(e => e.PmlMatchingDefId).HasName("PK_dbo.PmlMatchingDef");

                entity.ToTable("PmlMatchingDef");

                entity.HasIndex(e => e.SourceGuAnalysisId, "IX_SourceGuAnalysisId");

                entity.HasIndex(e => e.SourceIndustryAnalysisId, "IX_SourceIndustryAnalysisId");

                entity.HasIndex(e => e.TargetGuAnalysisId, "IX_TargetGuAnalysisId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.SourceGuAnalysis).WithMany(p => p.PmlMatchingDefSourceGuAnalyses)
                    .HasForeignKey(d => d.SourceGuAnalysisId)
                    .HasConstraintName("FK_dbo.PmlMatchingDef_dbo.GuAnalysis_SourceGuAnalysisId");

                entity.HasOne(d => d.SourceIndustryAnalysis).WithMany(p => p.PmlMatchingDefs)
                    .HasForeignKey(d => d.SourceIndustryAnalysisId)
                    .HasConstraintName("FK_dbo.PmlMatchingDef_dbo.IndustryGuAnalysis_SourceIndustryAnalysisId");

                entity.HasOne(d => d.TargetGuAnalysis).WithMany(p => p.PmlMatchingDefTargetGuAnalyses)
                    .HasForeignKey(d => d.TargetGuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PmlMatchingDef_dbo.GuAnalysis_TargetGuAnalysisId");
            });

            modelBuilder.Entity<PolicyTracker>(entity =>
            {
                entity.HasKey(e => e.PolicyTrackerId).HasName("PK_dbo.PolicyTracker");

                entity.ToTable("PolicyTracker");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.Property(e => e.Comments).HasMaxLength(1000);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RegisContractId).HasMaxLength(20);
                entity.Property(e => e.RegisMkey)
                    .HasMaxLength(20)
                    .HasColumnName("RegisMKey");
                entity.Property(e => e.RegisNbr).HasMaxLength(20);
                entity.Property(e => e.RegisPgmNbr).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.PolicyTrackers)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PolicyTracker_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<PolicyTrackerDetail>(entity =>
            {
                entity.HasKey(e => e.PolicyTrackerDetailId).HasName("PK_dbo.PolicyTrackerDetail");

                entity.ToTable("PolicyTrackerDetail");

                entity.HasIndex(e => e.PolicyTrackerId, "IX_PolicyTrackerId");

                entity.Property(e => e.ChangeUser).HasMaxLength(100);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.FieldName).HasMaxLength(200);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RevoFieldName).HasMaxLength(200);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PolicyTracker).WithMany(p => p.PolicyTrackerDetails)
                    .HasForeignKey(d => d.PolicyTrackerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PolicyTrackerDetail_dbo.PolicyTracker_PolicyTrackerId");
            });

            modelBuilder.Entity<PolicyTrackerLog>(entity =>
            {
                entity.HasKey(e => e.PolicyTrackerLogId).HasName("PK_dbo.PolicyTrackerLog");

                entity.ToTable("PolicyTrackerLog");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RegisContractId).HasMaxLength(20);
                entity.Property(e => e.RegisMkey)
                    .HasMaxLength(20)
                    .HasColumnName("RegisMKey");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<PolicyUpdate>(entity =>
            {
                entity.HasKey(e => e.PolicyUpdateId).HasName("PK_dbo.PolicyUpdate");

                entity.ToTable("PolicyUpdate");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.HasIndex(e => e.PolicyTrackerId, "IX_PolicyTrackerId");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.Property(e => e.ChangeUser).HasMaxLength(100);
                entity.Property(e => e.Comments).HasMaxLength(1000);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.PolicyUpdates)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PolicyUpdate_dbo.Layer_LayerId");

                entity.HasOne(d => d.PolicyTracker).WithMany(p => p.PolicyUpdates)
                    .HasForeignKey(d => d.PolicyTrackerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PolicyUpdate_dbo.PolicyTracker_PolicyTrackerId");

                entity.HasOne(d => d.Submission).WithMany(p => p.PolicyUpdates)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PolicyUpdate_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<PolicyUpdateDetail>(entity =>
            {
                entity.HasKey(e => e.PolicyUpdateDetailId).HasName("PK_dbo.PolicyUpdateDetail");

                entity.ToTable("PolicyUpdateDetail");

                entity.HasIndex(e => e.PolicyUpdateId, "IX_PolicyUpdateId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RevoFieldName).HasMaxLength(200);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PolicyUpdate).WithMany(p => p.PolicyUpdateDetails)
                    .HasForeignKey(d => d.PolicyUpdateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PolicyUpdateDetail_dbo.PolicyUpdate_PolicyUpdateId");
            });

            modelBuilder.Entity<PoolGuAnalysis>(entity =>
            {
                entity.HasKey(e => e.PoolGuAnalysisId).HasName("PK_dbo.PoolGuAnalysis");

                entity.ToTable("PoolGuAnalysis");

                entity.HasIndex(e => e.LossPoolId, "IX_LossPoolId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Platform).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.LossPool).WithMany(p => p.PoolGuAnalyses)
                    .HasForeignKey(d => d.LossPoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PoolGuAnalysis_dbo.LossPool_LossPoolId");
            });

            modelBuilder.Entity<PortAdj>(entity =>
            {
                entity.HasKey(e => e.PortAdjId).HasName("PK_dbo.PortAdj");

                entity.ToTable("PortAdj");

                entity.HasIndex(e => e.PortfolioId, "IX_PortfolioId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Portfolio).WithMany(p => p.PortAdjs)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortAdj_dbo.Portfolio_PortfolioId");
            });

            modelBuilder.Entity<PortAdjAction>(entity =>
            {
                entity.HasKey(e => e.PortAdjActionId).HasName("PK_dbo.PortAdjAction");

                entity.ToTable("PortAdjAction");

                entity.HasIndex(e => e.PortAdjId, "IX_PortAdjId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PortAdj).WithMany(p => p.PortAdjActions)
                    .HasForeignKey(d => d.PortAdjId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortAdjAction_dbo.PortAdj_PortAdjId");
            });

            modelBuilder.Entity<PortLayer>(entity =>
            {
                entity.HasKey(e => e.PortLayerId).HasName("PK_dbo.PortLayer");

                entity.ToTable("PortLayer");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.HasIndex(e => e.PortLayerProjectedCessionPeriodId, "IX_PortLayerProjectedCessionPeriodId");

                entity.HasIndex(e => e.PortfolioId, "IX_PortfolioId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Premium2Adjusted).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PremiumAdjusted).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Rol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL");
                entity.Property(e => e.Rol2adjusted)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL2Adjusted");
                entity.Property(e => e.Roladjusted)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROLAdjusted");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Share).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Share2Adjusted).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ShareAdjusted).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.Layer).WithMany(p => p.PortLayers)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayer_dbo.Layer_LayerId");

                entity.HasOne(d => d.PortLayerProjectedCessionPeriod).WithMany(p => p.PortLayers)
                    .HasForeignKey(d => d.PortLayerProjectedCessionPeriodId)
                    .HasConstraintName("FK_dbo.PortLayer_dbo.PortLayerProjectedCessionPeriod_PortLayerProjectedCessionPeriodId");

                entity.HasOne(d => d.Portfolio).WithMany(p => p.PortLayers)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayer_dbo.Portfolio_PortfolioId");
            });

            modelBuilder.Entity<PortLayerCession>(entity =>
            {
                entity.HasKey(e => e.PortLayerCessionId).HasName("PK_dbo.PortLayerCession");

                entity.ToTable("PortLayerCession");

                entity.HasIndex(e => e.PortLayerId, "IX_PortLayerId");

                entity.HasIndex(e => e.RetroProgramId, "IX_RetroProgramId");

                entity.Property(e => e.CessionFeesRaw).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionGross).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionNet).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionNetAdjusted).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PortLayer).WithMany(p => p.PortLayerCessions)
                    .HasForeignKey(d => d.PortLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerCession_dbo.PortLayer_PortLayerId");

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.PortLayerCessions)
                    .HasForeignKey(d => d.RetroProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerCession_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<PortLayerCessionDuration>(entity =>
            {
                entity.HasKey(e => e.PortLayerCessionDurationId).HasName("PK_dbo.PortLayerCessionDuration");

                entity.ToTable("PortLayerCessionDuration");

                entity.HasIndex(e => e.PortLayerId, "IX_PortLayerId");

                entity.HasIndex(e => e.RetroProgramId, "IX_RetroProgramId");

                entity.HasOne(d => d.PortLayer).WithMany(p => p.PortLayerCessionDurations)
                    .HasForeignKey(d => d.PortLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerCessionDuration_dbo.PortLayer_PortLayerId");

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.PortLayerCessionDurations)
                    .HasForeignKey(d => d.RetroProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerCessionDuration_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<PortLayerEarnPattern>(entity =>
            {
                entity.HasKey(e => e.PortLayerEarnPatternId).HasName("PK_dbo.PortLayerEarnPattern");

                entity.ToTable("PortLayerEarnPattern");

                entity.HasIndex(e => e.PortLayerId, "IX_PortLayerId");

                entity.HasOne(d => d.PortLayer).WithMany(p => p.PortLayerEarnPatterns)
                    .HasForeignKey(d => d.PortLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerEarnPattern_dbo.PortLayer_PortLayerId");
            });

            modelBuilder.Entity<PortLayerFieldSelectionPerTypeResult>(entity =>
            {
                entity.HasKey(e => e.PortLayerFieldSelectionPerTypeResultId).HasName("PK_dbo.PortLayerFieldSelectionPerTypeResult");

                entity.ToTable("PortLayerFieldSelectionPerTypeResult");

                entity.HasIndex(e => e.PortLayerId, "IX_PortLayerId");

                entity.HasOne(d => d.PortLayer).WithMany(p => p.PortLayerFieldSelectionPerTypeResults)
                    .HasForeignKey(d => d.PortLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerFieldSelectionPerTypeResult_dbo.PortLayer_PortLayerId");
            });

            modelBuilder.Entity<PortLayerLossDuration>(entity =>
            {
                entity.HasKey(e => e.PortLayerLossDurationId).HasName("PK_dbo.PortLayerLossDuration");

                entity.ToTable("PortLayerLossDuration");

                entity.HasIndex(e => e.PortLayerId, "IX_PortLayerId");

                entity.HasOne(d => d.PortLayer).WithMany(p => p.PortLayerLossDurations)
                    .HasForeignKey(d => d.PortLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerLossDuration_dbo.PortLayer_PortLayerId");
            });

            modelBuilder.Entity<PortLayerPriceResult>(entity =>
            {
                entity.HasKey(e => e.PortLayerPriceResultId).HasName("PK_dbo.PortLayerPriceResult");

                entity.ToTable("PortLayerPriceResult");

                entity.HasIndex(e => e.PortLayerId, "IX_PortLayerId");

                entity.HasOne(d => d.PortLayer).WithMany(p => p.PortLayerPriceResults)
                    .HasForeignKey(d => d.PortLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortLayerPriceResult_dbo.PortLayer_PortLayerId");
            });

            modelBuilder.Entity<PortLayerProjectedCessionPeriod>(entity =>
            {
                entity.HasKey(e => e.PortLayerProjectedCessionPeriodId).HasName("PK_dbo.PortLayerProjectedCessionPeriod");

                entity.ToTable("PortLayerProjectedCessionPeriod");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<PortMetric>(entity =>
            {
                entity.HasKey(e => e.PortMetricId).HasName("PK_dbo.PortMetric");

                entity.ToTable("PortMetric");

                entity.HasIndex(e => e.PortfolioId, "IX_PortfolioId");

                entity.Property(e => e.Cr).HasColumnName("CR");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.El).HasColumnName("EL");
                entity.Property(e => e.Elamount).HasColumnName("ELAmount");
                entity.Property(e => e.ElattritionalAmount).HasColumnName("ELAttritionalAmount");
                entity.Property(e => e.EllargeLossAmount).HasColumnName("ELLargeLossAmount");
                entity.Property(e => e.ElmodeledAmount).HasColumnName("ELModeledAmount");
                entity.Property(e => e.Elmultiple).HasColumnName("ELMultiple");
                entity.Property(e => e.ElnonModeledAmount).HasColumnName("ELNonModeledAmount");
                entity.Property(e => e.Er).HasColumnName("ER");
                entity.Property(e => e.Lr).HasColumnName("LR");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NcbcommAmount).HasColumnName("NCBCommAmount");
                entity.Property(e => e.Rbamount).HasColumnName("RBAmount");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Rpamount).HasColumnName("RPAmount");
                entity.Property(e => e.SscommAmount).HasColumnName("SSCommAmount");
                entity.Property(e => e.StandalonePml).HasColumnName("StandalonePML");
                entity.Property(e => e.StandaloneRoe).HasColumnName("StandaloneROE");

                entity.HasOne(d => d.Portfolio).WithMany(p => p.PortMetrics)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortMetric_dbo.Portfolio_PortfolioId");
            });

            modelBuilder.Entity<PortPeriodResult>(entity =>
            {
                entity.HasKey(e => e.PortPeriodResultId).HasName("PK_dbo.PortPeriodResult");

                entity.ToTable("PortPeriodResult");

                entity.HasIndex(e => e.PortLayerId, "IX_PortLayerId");

                entity.HasOne(d => d.PortLayer).WithMany(p => p.PortPeriodResults)
                    .HasForeignKey(d => d.PortLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortPeriodResult_dbo.PortLayer_PortLayerId");
            });

            modelBuilder.Entity<PortProjectedRetro>(entity =>
            {
                entity.HasKey(e => e.PortProjectedRetroId).HasName("PK_dbo.PortProjectedRetro");

                entity.ToTable("PortProjectedRetro");

                entity.HasIndex(e => e.PortfolioId, "IX_PortfolioId");

                entity.HasIndex(e => e.RetroProgramId, "IX_RetroProgramId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Portfolio).WithMany(p => p.PortProjectedRetros)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortProjectedRetro_dbo.Portfolio_PortfolioId");

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.PortProjectedRetros)
                    .HasForeignKey(d => d.RetroProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortProjectedRetro_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<PortRoeResult>(entity =>
            {
                entity.HasKey(e => e.PortRoeResultId).HasName("PK_dbo.PortRoeResult");

                entity.ToTable("PortRoeResult");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.HasIndex(e => e.PortfolioId, "IX_PortfolioId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.GrossCapitalTvar).HasColumnName("GrossCapitalTVar");
                entity.Property(e => e.GrossCatPmlTvarArl).HasColumnName("GrossCatPmlTVarArl");
                entity.Property(e => e.GrossRoetvar).HasColumnName("GrossROETVar");
                entity.Property(e => e.GrossRoevar).HasColumnName("GrossROEVar");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NetRoevar).HasColumnName("NetROEVar");
                entity.Property(e => e.NetRoevarWithFees).HasColumnName("NetROEVarWithFees");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.PortRoeResults)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortRoeResult_dbo.Layer_LayerId");

                entity.HasOne(d => d.Portfolio).WithMany(p => p.PortRoeResults)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortRoeResult_dbo.Portfolio_PortfolioId");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.HasKey(e => e.PortfolioId).HasName("PK_dbo.Portfolio");

                entity.ToTable("Portfolio");

                entity.Property(e => e.AsOfDate).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .HasDefaultValue("");
                entity.Property(e => e.Expiration).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.GrossRoe).HasColumnName("GrossROE");
                entity.Property(e => e.Inception).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
                entity.Property(e => e.JobId).HasMaxLength(10);
                entity.Property(e => e.LastPricedUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Uwyear).HasColumnName("UWYear");
            });

            modelBuilder.Entity<PortfolioFx>(entity =>
            {
                entity.HasKey(e => e.PortfolioFxid).HasName("PK_dbo.PortfolioFX");

                entity.ToTable("PortfolioFX");

                entity.HasIndex(e => e.PortfolioId, "IX_PortfolioId");

                entity.Property(e => e.PortfolioFxid).HasColumnName("PortfolioFXId");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.Fxrate)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FXRate");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioFxes)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PortfolioFX_dbo.Portfolio_PortfolioId");
            });

            modelBuilder.Entity<PremiumBase>(entity =>
            {
                entity.HasKey(e => e.PremiumBaseId).HasName("PK_dbo.PremiumBase");

                entity.ToTable("PremiumBase");

                entity.HasIndex(e => e.PremiumBaseId, "IX_PremiumBaseId");

                entity.Property(e => e.PremiumBaseId).ValueGeneratedNever();
                entity.Property(e => e.Adjustment).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CommAcctPrem).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DepositAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DepositPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.EqAct).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EqActExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EqEst).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EqEstExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EstUltPremium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Flat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdAct).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdActExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdEst).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdEstExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MinAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MinPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NcbPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Notes).HasMaxLength(250);
                entity.Property(e => e.QuoteCommAcctPrem).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Siact)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIAct");
                entity.Property(e => e.SiactExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIActExp");
                entity.Property(e => e.Siest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIEst");
                entity.Property(e => e.SiestExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIEstExp");
                entity.Property(e => e.Spiact)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIAct");
                entity.Property(e => e.SpiactExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIActExp");
                entity.Property(e => e.Spiest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIEst");
                entity.Property(e => e.SpiestExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIEstExp");
                entity.Property(e => e.SwingRateLossMultiplier).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.SwingRateMaxPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.SwingRateMinPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.WdAct).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.WdActExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.WdEst).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.WdEstExp).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.PremiumBaseNavigation).WithOne(p => p.PremiumBase)
                    .HasForeignKey<PremiumBase>(d => d.PremiumBaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PremiumBase_dbo.Layer_PremiumBaseId");
            });

            modelBuilder.Entity<PremiumBaseContract>(entity =>
            {
                entity.HasKey(e => e.PremiumBaseContractId).HasName("PK_dbo.PremiumBaseContract");

                entity.ToTable("PremiumBaseContract");

                entity.HasIndex(e => e.PremiumBaseContractId, "IX_PremiumBaseContractId");

                entity.Property(e => e.PremiumBaseContractId).ValueGeneratedNever();
                entity.Property(e => e.Adjustment).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DepositAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DepositPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.EqAct).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EqActExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EqEst).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EqEstExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EstUltPremium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Flat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdAct).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdActExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdEst).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MdEstExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MinAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MinPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NcbPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Notes).HasMaxLength(250);
                entity.Property(e => e.PremiumMethod).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Siact)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIAct");
                entity.Property(e => e.SiactExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIActExp");
                entity.Property(e => e.Siest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIEst");
                entity.Property(e => e.SiestExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SIEstExp");
                entity.Property(e => e.Spiact)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIAct");
                entity.Property(e => e.SpiactExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIActExp");
                entity.Property(e => e.Spiest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIEst");
                entity.Property(e => e.SpiestExp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SPIEstExp");
                entity.Property(e => e.WdAct).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.WdActExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.WdEst).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.WdEstExp).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.PremiumBaseContractNavigation).WithOne(p => p.PremiumBaseContract)
                    .HasForeignKey<PremiumBaseContract>(d => d.PremiumBaseContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PremiumBaseContract_dbo.Contract_PremiumBaseContractId");
            });

            modelBuilder.Entity<PremiumInstallment>(entity =>
            {
                entity.HasKey(e => e.PremiumInstallmentId).HasName("PK_dbo.PremiumInstallment");

                entity.ToTable("PremiumInstallment");

                entity.HasIndex(e => e.PremiumBaseId, "IX_PremiumBaseId");

                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Commission).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.InstallmentAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InstallmentPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Ncb).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Override).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.PremiumBase).WithMany(p => p.PremiumInstallments)
                    .HasForeignKey(d => d.PremiumBaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PremiumInstallment_dbo.PremiumBase_PremiumBaseId");
            });

            modelBuilder.Entity<PremiumInstallmentContract>(entity =>
            {
                entity.HasKey(e => e.PremiumInstallmentContractId).HasName("PK_dbo.PremiumInstallmentContract");

                entity.ToTable("PremiumInstallmentContract");

                entity.HasIndex(e => e.PremiumBaseContractId, "IX_PremiumBaseContractId");

                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Commission).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.InstallmentAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InstallmentPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Ncb).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Override).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.PremiumBaseContract).WithMany(p => p.PremiumInstallmentContracts)
                    .HasForeignKey(d => d.PremiumBaseContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PremiumInstallmentContract_dbo.PremiumBaseContract_PremiumBaseContractId");
            });

            modelBuilder.Entity<PremiumSurplusRatio>(entity =>
            {
                entity.HasKey(e => e.PremiumSurplusId).HasName("PK_dbo.PremiumSurplusRatio");

                entity.ToTable("PremiumSurplusRatio");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Rol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SurplusRatio).HasColumnType("decimal(18, 10)");
            });

            modelBuilder.Entity<PresetLdp>(entity =>
            {
                entity.HasKey(e => e.PresetLdpid).HasName("PK_dbo.PresetLDP");

                entity.ToTable("PresetLDP");

                entity.Property(e => e.PresetLdpid).HasColumnName("PresetLDPId");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<PresetLdpdist>(entity =>
            {
                entity.HasKey(e => e.PresetLdpdistId).HasName("PK_dbo.PresetLDPDist");

                entity.ToTable("PresetLDPDist");

                entity.HasIndex(e => e.PresetLdpid, "IX_PresetLDPId");

                entity.Property(e => e.PresetLdpdistId).HasColumnName("PresetLDPDistId");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.PaidLossPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.PresetLdpid).HasColumnName("PresetLDPId");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PresetLdp).WithMany(p => p.PresetLdpdists)
                    .HasForeignKey(d => d.PresetLdpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PresetLDPDist_dbo.PresetLDP_PresetLDPId");
            });

            modelBuilder.Entity<Programme>(entity =>
            {
                entity.HasKey(e => e.ProgramId).HasName("PK_dbo.Program");

                entity.ToTable("Program");

                entity.HasIndex(e => e.CedentId, "IX_CedentId");

                entity.HasIndex(e => e.CompanyId, "IX_CompanyId");

                entity.HasIndex(e => e.DeptId, "IX_DeptId");

                entity.HasIndex(e => e.OfficeId, "IX_OfficeId");

                entity.HasIndex(e => e.ReinsurerId, "IX_ReinsurerId");

                entity.HasIndex(e => e.RegisId, "UQ_RegisIdProgram")
                    .IsUnique()
                    .HasFilter("([RegisId] IS NOT NULL AND [RegisId]<>'' AND [IsDeleted]=(0) AND [IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ExtName).HasMaxLength(50);
                entity.Property(e => e.FacilityDefault).HasMaxLength(50);
                entity.Property(e => e.Lobdefault)
                    .HasMaxLength(50)
                    .HasColumnName("LOBDefault");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.QsofXs).HasColumnName("QSofXS");
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RegisNbr).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SegmentDefault).HasMaxLength(50);

                entity.HasOne(d => d.Cedent).WithMany(p => p.ProgramCedents)
                    .HasForeignKey(d => d.CedentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Program_dbo.Cedent_CedentId");

                entity.HasOne(d => d.Company).WithMany(p => p.Programs)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Program_dbo.Company_CompanyId");

                entity.HasOne(d => d.Dept).WithMany(p => p.Programs)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Program_dbo.Dept_DeptId");

                entity.HasOne(d => d.Office).WithMany(p => p.Programs)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Program_dbo.Office_OfficeId");

                entity.HasOne(d => d.Reinsurer).WithMany(p => p.ProgramReinsurers)
                    .HasForeignKey(d => d.ReinsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Program_dbo.Cedent_ReinsurerId");
            });

            modelBuilder.Entity<ProgramRoeResult>(entity =>
            {
                entity.HasKey(e => e.ProgramRoeResultId).HasName("PK_dbo.ProgramRoeResult");

                entity.ToTable("ProgramRoeResult");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.StandaloneRoe).HasColumnName("StandaloneROE");
                entity.Property(e => e.StandaloneRoeauth).HasColumnName("StandaloneROEAuth");
                entity.Property(e => e.StandaloneRoequote).HasColumnName("StandaloneROEQuote");

                entity.HasOne(d => d.Submission).WithMany(p => p.ProgramRoeResults)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ProgramRoeResult_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<PxSection>(entity =>
            {
                entity.HasKey(e => e.PxSectionId).HasName("PK_dbo.PxSection");

                entity.ToTable("PxSection");

                entity.HasIndex(e => new { e.LayerId, e.PxLayerId }, "UQ_PxSection").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Yltrollup).HasColumnName("YLTRollup");

                entity.HasOne(d => d.Layer).WithMany(p => p.PxSectionLayers)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PxSection_dbo.Layer_LayerId");

                entity.HasOne(d => d.PxLayer).WithMany(p => p.PxSectionPxLayers)
                    .HasForeignKey(d => d.PxLayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PxSection_dbo.Layer_PxLayerId");
            });

            modelBuilder.Entity<PxSectionContract>(entity =>
            {
                entity.HasKey(e => e.PxSectionContractId).HasName("PK_dbo.PxSectionContract");

                entity.ToTable("PxSectionContract");

                entity.HasIndex(e => e.ContractId, "IX_ContractId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Yltrollup)
                    .HasMaxLength(20)
                    .HasColumnName("YLTRollup");

                entity.HasOne(d => d.Contract).WithMany(p => p.PxSectionContracts)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PxSectionContract_dbo.Contract_ContractId");
            });

            modelBuilder.Entity<Rcsspoint>(entity =>
            {
                entity.HasKey(e => e.RcsspointId).HasName("PK_dbo.RCSSPoint");

                entity.ToTable("RCSSPoint");

                entity.HasIndex(e => e.RetroCommissionId, "IX_RetroCommissionId");

                entity.Property(e => e.RcsspointId).HasColumnName("RCSSPointId");
                entity.Property(e => e.Commission).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.LossRatioFrom).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossRatioTo).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RetroCommission).WithMany(p => p.Rcsspoints)
                    .HasForeignKey(d => d.RetroCommissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RCSSPoint_dbo.RetroCommission_RetroCommissionId");
            });

            modelBuilder.Entity<Reinstatement>(entity =>
            {
                entity.HasKey(e => e.ReinstatementId).HasName("PK_dbo.Reinstatement");

                entity.ToTable("Reinstatement");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Premium).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.Reinstatements)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Reinstatement_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<ReinstatementContract>(entity =>
            {
                entity.HasKey(e => e.ReinstatementContractId).HasName("PK_dbo.ReinstatementContract");

                entity.ToTable("ReinstatementContract");

                entity.HasIndex(e => e.ContractId, "IX_ContractId");

                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Premium).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Contract).WithMany(p => p.ReinstatementContracts)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ReinstatementContract_dbo.Contract_ContractId");
            });

            modelBuilder.Entity<RetroAllocation>(entity =>
            {
                entity.HasKey(e => e.RetroAllocationId).HasName("PK_dbo.RetroAllocation");

                entity.ToTable("RetroAllocation");

                entity.HasIndex(e => new { e.RetroInvestorId, e.LayerId }, "UQ_RetroInvestorId_LayerId").IsUnique();

                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.BrokerageSent).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionCapFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionCapFactorSent).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionDemand).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionGross).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionGrossFinalSent).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionNet).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionNetFinalSent).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionPlaced).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.El)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("EL");
                entity.Property(e => e.ManagementFee).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Message).HasMaxLength(500);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Override).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.OverrideSent).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RegisMessage).HasMaxLength(500);
                entity.Property(e => e.Rol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.TailFee).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Taxes).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.TaxesSent).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Zone).HasMaxLength(500);

                entity.HasOne(d => d.Layer).WithMany(p => p.RetroAllocations)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroAllocation_dbo.Layer_LayerId");

                entity.HasOne(d => d.RetroInvestor).WithMany(p => p.RetroAllocations)
                    .HasForeignKey(d => d.RetroInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroAllocation_dbo.RetroInvestor_RetroInvestorId");
            });

            modelBuilder.Entity<RetroBufferByEvent>(entity =>
            {
                entity.HasKey(e => e.RetroBufferByEventId).HasName("PK_dbo.RetroBufferByEvent");

                entity.ToTable("RetroBufferByEvent");

                entity.HasIndex(e => e.RetroInvestorId, "IX_RetroInvestorId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RetroInvestor).WithMany(p => p.RetroBufferByEvents)
                    .HasForeignKey(d => d.RetroInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroBufferByEvent_dbo.RetroInvestor_RetroInvestorId");
            });

            modelBuilder.Entity<RetroBufferByTime>(entity =>
            {
                entity.HasKey(e => e.RetroBufferByTimeId).HasName("PK_dbo.RetroBufferByTime");

                entity.ToTable("RetroBufferByTime");

                entity.HasIndex(e => e.RetroInvestorId, "IX_RetroInvestorId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RetroInvestor).WithMany(p => p.RetroBufferByTimes)
                    .HasForeignKey(d => d.RetroInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroBufferByTime_dbo.RetroInvestor_RetroInvestorId");
            });

            modelBuilder.Entity<RetroCommission>(entity =>
            {
                entity.HasKey(e => e.RetroCommissionId).HasName("PK_dbo.RetroCommission");

                entity.ToTable("RetroCommission");

                entity.HasIndex(e => e.BrokerContactId, "IX_BrokerContactId");

                entity.HasIndex(e => e.BrokerId, "IX_BrokerId");

                entity.HasIndex(e => new { e.RetroProgramId, e.Name }, "UQ_RetroCommissionName")
                    .IsUnique()
                    .HasFilter("([RetroProgramId] IS NOT NULL AND [IsActive]=(1) AND [IsDeleted]=(0))");

                entity.Property(e => e.Brokerage).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Ccfyears).HasColumnName("CCFYears");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Dcfamount).HasColumnName("DCFAmount");
                entity.Property(e => e.Dcfyears).HasColumnName("DCFYears");
                entity.Property(e => e.HighWaterMark).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Other).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Pcshare)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PCShare");
                entity.Property(e => e.Pcshare2)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("PCShare2");
                entity.Property(e => e.PcstartDate).HasColumnName("PCStartDate");
                entity.Property(e => e.ProfitComm2).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Rhoe2)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("RHOE2");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SscommMax)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommMax");
                entity.Property(e => e.SscommMin)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommMin");
                entity.Property(e => e.SscommProv)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSCommProv");
                entity.Property(e => e.SslossRatioMax)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioMax");
                entity.Property(e => e.SslossRatioMin)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("SSLossRatioMin");
                entity.Property(e => e.TailFee).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Taxes).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.BrokerContact).WithMany(p => p.RetroCommissions)
                    .HasForeignKey(d => d.BrokerContactId)
                    .HasConstraintName("FK_dbo.RetroCommission_dbo.BrokerContact_BrokerContactId");

                entity.HasOne(d => d.Broker).WithMany(p => p.RetroCommissions)
                    .HasForeignKey(d => d.BrokerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroCommission_dbo.Broker_BrokerId");

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.RetroCommissions)
                    .HasForeignKey(d => d.RetroProgramId)
                    .HasConstraintName("FK_dbo.RetroCommission_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<RetroDoc>(entity =>
            {
                entity.HasKey(e => e.RetroDocId).HasName("PK_dbo.RetroDoc");

                entity.ToTable("RetroDoc");

                entity.HasIndex(e => e.DbfileId, "IX_DBFileId");

                entity.HasIndex(e => e.RetroProgramId, "IX_RetroProgramId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.DbfileId).HasColumnName("DBFileId");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.DocType).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Dbfile).WithMany(p => p.RetroDocs)
                    .HasForeignKey(d => d.DbfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroDoc_dbo.DBFile_DBFileId");

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.RetroDocs)
                    .HasForeignKey(d => d.RetroProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroDoc_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<RetroFacilityOverride>(entity =>
            {
                entity.HasKey(e => e.RetroFacilityOverrideId).HasName("PK_dbo.RetroFacilityOverride");

                entity.ToTable("RetroFacilityOverride");

                entity.HasIndex(e => e.RetroInvestorId, "IX_RetroInvestorId");

                entity.Property(e => e.Cession).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Facility).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RetroInvestor).WithMany(p => p.RetroFacilityOverrides)
                    .HasForeignKey(d => d.RetroInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroFacilityOverride_dbo.RetroInvestor_RetroInvestorId");
            });

            modelBuilder.Entity<RetroInvestor>(entity =>
            {
                entity.HasKey(e => e.RetroInvestorId).HasName("PK_dbo.RetroInvestor");

                entity.ToTable("RetroInvestor");

                entity.HasIndex(e => e.RetroCommissionId, "IX_RetroCommissionId");

                entity.HasIndex(e => e.SpinsurerId, "IX_SPInsurerId");

                entity.Property(e => e.CessionCapBufferPct).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ExcludedDomiciles).HasMaxLength(500);
                entity.Property(e => e.ExcludedFacilities).HasMaxLength(500);
                entity.Property(e => e.HurdleRate).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.InvestmentAuth).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.InvestmentAuthAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InvestmentEstimated).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.InvestmentEstimatedAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.InvestmentSigned).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.InvestmentSignedAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ManagementFee).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.NotionalCollateral).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Override).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.PerformanceFee).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ProfitComm).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Rhoe)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("RHOE");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SpinsurerId).HasColumnName("SPInsurerId");
                entity.Property(e => e.TargetCollateral).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TargetPremium).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.RetroCommission).WithMany(p => p.RetroInvestors)
                    .HasForeignKey(d => d.RetroCommissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroInvestor_dbo.RetroCommission_RetroCommissionId");

                entity.HasOne(d => d.Spinsurer).WithMany(p => p.RetroInvestors)
                    .HasForeignKey(d => d.SpinsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroInvestor_dbo.SPInsurer_SPInsurerId");
            });

            modelBuilder.Entity<RetroInvestorReset>(entity =>
            {
                entity.HasKey(e => e.RetroInvestorResetId).HasName("PK_dbo.RetroInvestorReset");

                entity.ToTable("RetroInvestorReset");

                entity.HasIndex(e => e.RetroInvestorId, "IX_RetroInvestorId");

                entity.HasIndex(e => e.RetroProgramResetId, "IX_RetroProgramResetId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.InvestmentSigned).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.InvestmentSignedAmt).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.TargetCollateral).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TargetPremium).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.RetroInvestor).WithMany(p => p.RetroInvestorResets)
                    .HasForeignKey(d => d.RetroInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroInvestorReset_dbo.RetroInvestor_RetroInvestorId");

                entity.HasOne(d => d.RetroProgramReset).WithMany(p => p.RetroInvestorResets)
                    .HasForeignKey(d => d.RetroProgramResetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroInvestorReset_dbo.RetroProgramReset_RetroProgramResetId");
            });

            modelBuilder.Entity<RetroInvestorZone>(entity =>
            {
                entity.HasKey(e => e.RetroInvestorZoneId).HasName("PK_dbo.RetroInvestorZone");

                entity.ToTable("RetroInvestorZone");

                entity.HasIndex(e => new { e.RetroInvestorId, e.StartDate, e.TopUpZoneId }, "UQ_RetroInvestorZone").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RetroInvestor).WithMany(p => p.RetroInvestorZones)
                    .HasForeignKey(d => d.RetroInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroInvestorZone_dbo.RetroInvestor_RetroInvestorId");
            });

            modelBuilder.Entity<RetroProfile>(entity =>
            {
                entity.HasKey(e => e.RetroProfileId).HasName("PK_dbo.RetroProfile");

                entity.ToTable("RetroProfile");

                entity.HasIndex(e => e.CompanyId, "IX_CompanyId");

                entity.HasIndex(e => e.DeptId, "IX_DeptId");

                entity.HasIndex(e => e.ManagerId, "IX_ManagerId");

                entity.HasIndex(e => e.OfficeId, "IX_OfficeId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Company).WithMany(p => p.RetroProfiles)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroProfile_dbo.Company_CompanyId");

                entity.HasOne(d => d.Dept).WithMany(p => p.RetroProfiles)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroProfile_dbo.Dept_DeptId");

                entity.HasOne(d => d.Manager).WithMany(p => p.RetroProfiles)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroProfile_dbo.User_ManagerId");

                entity.HasOne(d => d.Office).WithMany(p => p.RetroProfiles)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroProfile_dbo.Office_OfficeId");
            });

            modelBuilder.Entity<RetroProgram>(entity =>
            {
                entity.HasKey(e => e.RetroProgramId).HasName("PK_dbo.RetroProgram");

                entity.ToTable("RetroProgram");

                entity.HasIndex(e => e.DefaultRetroCommissionId, "IX_DefaultRetroCommissionId");

                entity.HasIndex(e => e.RetroProfileId, "IX_RetroProfileId");

                entity.Property(e => e.CanApplyZonalRol).HasColumnName("CanApplyZonalROL");
                entity.Property(e => e.CessionCapBuffer).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CmtdInvestorColl).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CmtdPayCapacity).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CmtdPremExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.EstInvestorColl).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EstPayCapacity).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EstPremExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HurdleRate).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LastFinalizeDate).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
                entity.Property(e => e.ManagementFee).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(450);
                entity.Property(e => e.Notes).HasMaxLength(4000);
                entity.Property(e => e.OriginalDeductions).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Override).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.PerformanceFee).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ProfitComm).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Rhoe)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("RHOE");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SignedInvestorColl).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SignedPayCapacity).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SignedPremExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SubjectFacilities).HasMaxLength(500);
                entity.Property(e => e.SubjectLobs)
                    .HasMaxLength(200)
                    .HasColumnName("SubjectLOBs");
                entity.Property(e => e.SubjectOfficeIds).HasMaxLength(100);
                entity.Property(e => e.TgtInvestorColl).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TgtPayCapacity).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TgtPremExp).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Uwyear).HasColumnName("UWYear");

                entity.HasOne(d => d.DefaultRetroCommission).WithMany(p => p.RetroPrograms)
                    .HasForeignKey(d => d.DefaultRetroCommissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroProgram_dbo.RetroCommission_DefaultRetroCommissionId");

                entity.HasOne(d => d.RetroProfile).WithMany(p => p.RetroPrograms)
                    .HasForeignKey(d => d.RetroProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroProgram_dbo.RetroProfile_RetroProfileId");
            });

            modelBuilder.Entity<RetroProgramReset>(entity =>
            {
                entity.HasKey(e => e.RetroProgramResetId).HasName("PK_dbo.RetroProgramReset");

                entity.ToTable("RetroProgramReset");

                entity.HasIndex(e => e.RetroProgramId, "IX_RetroProgramId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.TargetCollateral).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TargetPremium).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.RetroProgramResets)
                    .HasForeignKey(d => d.RetroProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroProgramReset_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<RetroZone>(entity =>
            {
                entity.HasKey(e => e.RetroZoneId).HasName("PK_dbo.RetroZone");

                entity.ToTable("RetroZone");

                entity.HasIndex(e => new { e.RetroProgramId, e.StartDate, e.TopUpZoneId }, "UQ_RetroZoneWithStartDate").IsUnique();

                entity.Property(e => e.Cession).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.EllowerBound)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELLowerBound");
                entity.Property(e => e.ElupperBound)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELUpperBound");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(75);
                entity.Property(e => e.RollowerBound)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROLLowerBound");
                entity.Property(e => e.RolupperBound)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROLUpperBound");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.StartDate).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.RetroZones)
                    .HasForeignKey(d => d.RetroProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroZone_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<RetroZoneOverride>(entity =>
            {
                entity.HasKey(e => e.RetroZoneOverrideId).HasName("PK_dbo.RetroZoneOverride");

                entity.ToTable("RetroZoneOverride");

                entity.HasIndex(e => new { e.RetroInvestorId, e.RetroZoneId }, "UQ_RetroInvestorId_RetroZoneId")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.Cession).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RetroInvestor).WithMany(p => p.RetroZoneOverrides)
                    .HasForeignKey(d => d.RetroInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroZoneOverride_dbo.RetroInvestor_RetroInvestorId");

                entity.HasOne(d => d.RetroZone).WithMany(p => p.RetroZoneOverrides)
                    .HasForeignKey(d => d.RetroZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RetroZoneOverride_dbo.RetroZone_RetroZoneId");
            });

            modelBuilder.Entity<RiskTransferAnalysis>(entity =>
            {
                entity.HasKey(e => e.RiskTransferAnalysisId).HasName("PK_dbo.RiskTransferAnalysis");

                entity.ToTable("RiskTransferAnalysis");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Layers).HasMaxLength(500);
                entity.Property(e => e.LossPercentage).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossProbability).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.OtherDesc).HasMaxLength(500);
                entity.Property(e => e.RiskTransferAnalysisNotes).HasColumnType("ntext");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.TreatyNbr).HasMaxLength(20);
                entity.Property(e => e.Uwyear).HasColumnName("UWYear");

                entity.HasOne(d => d.Submission).WithMany(p => p.RiskTransferAnalyses)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RiskTransferAnalysis_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<RiskTransferAnalysisReviewer>(entity =>
            {
                entity.HasKey(e => e.RiskTransferAnalysisReviewerId).HasName("PK_dbo.RiskTransferAnalysisReviewer");

                entity.ToTable("RiskTransferAnalysisReviewer");

                entity.HasIndex(e => e.RiskTransferAnalysisId, "IX_RiskTransferAnalysisId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RiskTransferAnalysis).WithMany(p => p.RiskTransferAnalysisReviewers)
                    .HasForeignKey(d => d.RiskTransferAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RiskTransferAnalysisReviewer_dbo.RiskTransferAnalysis_RiskTransferAnalysisId");

                entity.HasOne(d => d.User).WithMany(p => p.RiskTransferAnalysisReviewers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RiskTransferAnalysisReviewer_dbo.User_UserId");
            });

            modelBuilder.Entity<RiskZone>(entity =>
            {
                entity.HasKey(e => e.RiskZoneId).HasName("PK_dbo.RiskZone");

                entity.ToTable("RiskZone");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.IristerritoryCode)
                    .HasMaxLength(20)
                    .HasColumnName("IRISTerritoryCode");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasDefaultValue("");
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RegisName)
                    .HasMaxLength(50)
                    .HasDefaultValue("");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<RoeAssumption>(entity =>
            {
                entity.HasKey(e => e.RoeAssumptionId).HasName("PK_dbo.RoeAssumption");

                entity.ToTable("RoeAssumption");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.HasIndex(e => e.PresetLdpid, "IX_PresetLDPId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.PresetLdpid).HasColumnName("PresetLDPId");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.RoeAssumptions)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RoeAssumption_dbo.Layer_LayerId");

                entity.HasOne(d => d.PresetLdp).WithMany(p => p.RoeAssumptions)
                    .HasForeignKey(d => d.PresetLdpid)
                    .HasConstraintName("FK_dbo.RoeAssumption_dbo.PresetLDP_PresetLDPId");
            });

            modelBuilder.Entity<RoeCapitalResult>(entity =>
            {
                entity.HasKey(e => e.RoeCapitalResultId).HasName("PK_dbo.RoeCapitalResult");

                entity.ToTable("RoeCapitalResult");

                entity.HasIndex(e => new { e.LayerId, e.FieldStatus, e.LossView, e.RoeResultBasis }, "UQ_RoeCapitalResult").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.RoeCapitalResults)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RoeCapitalResult_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<RoeLeverageFactor>(entity =>
            {
                entity.HasKey(e => e.RoeLeverageFactorId).HasName("PK_dbo.RoeLeverageFactor");

                entity.ToTable("RoeLeverageFactor");

                entity.HasIndex(e => e.RoeAssumptionId, "IX_RoeAssumptionId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Weight).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.RoeAssumption).WithMany(p => p.RoeLeverageFactors)
                    .HasForeignKey(d => d.RoeAssumptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RoeLeverageFactor_dbo.RoeAssumption_RoeAssumptionId");
            });

            modelBuilder.Entity<RoeLossDevPattern>(entity =>
            {
                entity.HasKey(e => e.RoeLossDevPatternId).HasName("PK_dbo.RoeLossDevPattern");

                entity.ToTable("RoeLossDevPattern");

                entity.HasIndex(e => e.RoeAssumptionId, "IX_RoeAssumptionId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.PaidLoss).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.RoeAssumption).WithMany(p => p.RoeLossDevPatterns)
                    .HasForeignKey(d => d.RoeAssumptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RoeLossDevPattern_dbo.RoeAssumption_RoeAssumptionId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK_dbo.Role");

                entity.ToTable("Role");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => e.RolePermissionId).HasName("PK_dbo.RolePermission");

                entity.ToTable("RolePermission");

                entity.HasIndex(e => e.PermissionId, "IX_PermissionId");

                entity.HasIndex(e => e.RoleId, "IX_RoleId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RolePermission_dbo.Permission_PermissionId");

                entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RolePermission_dbo.Role_RoleId");
            });

            modelBuilder.Entity<SnpLob>(entity =>
            {
                entity.HasKey(e => e.SnpLobId).HasName("PK_dbo.SnpLob");

                entity.ToTable("SnpLob");

                entity.HasIndex(e => e.Name, "UQ_SnpLob_Name").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.PremiumFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ReserveFactor).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Spinsurer>(entity =>
            {
                entity.HasKey(e => e.SpinsurerId).HasName("PK_dbo.SPInsurer");

                entity.ToTable("SPInsurer");

                entity.HasIndex(e => e.InsurerId, "IX_InsurerId");

                entity.HasIndex(e => e.RetroProgramId, "IX_RetroProgramId");

                entity.Property(e => e.SpinsurerId).HasColumnName("SPInsurerId");
                entity.Property(e => e.ContractId).HasMaxLength(20);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.FundsWithheldAccountNumber).HasMaxLength(500);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SegregatedAccount).HasMaxLength(500);
                entity.Property(e => e.TrustAccountNumber).HasMaxLength(500);
                entity.Property(e => e.TrustBank).HasMaxLength(50);

                entity.HasOne(d => d.Insurer).WithMany(p => p.Spinsurers)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SPInsurer_dbo.Cedent_InsurerId");

                entity.HasOne(d => d.RetroProgram).WithMany(p => p.Spinsurers)
                    .HasForeignKey(d => d.RetroProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SPInsurer_dbo.RetroProgram_RetroProgramId");
            });

            modelBuilder.Entity<Sspoint>(entity =>
            {
                entity.HasKey(e => e.SspointId).HasName("PK_dbo.SSPoint");

                entity.ToTable("SSPoint");

                entity.HasIndex(e => e.LayerId, "IX_LayerId");

                entity.Property(e => e.SspointId).HasColumnName("SSPointId");
                entity.Property(e => e.Commission).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.LossRatioFrom).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossRatioTo).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Layer).WithMany(p => p.Sspoints)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SSPoint_dbo.Layer_LayerId");
            });

            modelBuilder.Entity<SspointContract>(entity =>
            {
                entity.HasKey(e => e.SspointContractId).HasName("PK_dbo.SSPointContract");

                entity.ToTable("SSPointContract");

                entity.HasIndex(e => e.ContractId, "IX_ContractId");

                entity.Property(e => e.SspointContractId).HasColumnName("SSPointContractId");
                entity.Property(e => e.Commission).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.LossRatioFrom).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.LossRatioTo).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Contract).WithMany(p => p.SspointContracts)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SSPointContract_dbo.Contract_ContractId");
            });

            modelBuilder.Entity<SubDeltaPxResult>(entity =>
            {
                entity.HasKey(e => e.SubDeltaPxResultId).HasName("PK_dbo.SubDeltaPxResult");

                entity.ToTable("SubDeltaPxResult");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.HasIndex(e => e.SubmissionPxPortfolioId, "IX_SubmissionPxPortfolioId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.GrossCapitalTvarAuth).HasColumnName("GrossCapitalTVarAuth");
                entity.Property(e => e.GrossCapitalTvarQuote).HasColumnName("GrossCapitalTVarQuote");
                entity.Property(e => e.GrossCapitalTvarSigned).HasColumnName("GrossCapitalTVarSigned");
                entity.Property(e => e.GrossCatPmlTvarArlAuth).HasColumnName("GrossCatPmlTVarArlAuth");
                entity.Property(e => e.GrossCatPmlTvarArlQuote).HasColumnName("GrossCatPmlTVarArlQuote");
                entity.Property(e => e.GrossCatPmlTvarArlSigned).HasColumnName("GrossCatPmlTVarArlSigned");
                entity.Property(e => e.GrossRoetvarAuth).HasColumnName("GrossROETVarAuth");
                entity.Property(e => e.GrossRoetvarQuote).HasColumnName("GrossROETVarQuote");
                entity.Property(e => e.GrossRoetvarSigned).HasColumnName("GrossROETVarSigned");
                entity.Property(e => e.GrossRoevarAuth).HasColumnName("GrossROEVarAuth");
                entity.Property(e => e.GrossRoevarCorreAuth).HasColumnName("GrossROEVarCorreAuth");
                entity.Property(e => e.GrossRoevarCorreQuote).HasColumnName("GrossROEVarCorreQuote");
                entity.Property(e => e.GrossRoevarQuote).HasColumnName("GrossROEVarQuote");
                entity.Property(e => e.GrossRoevarSigned).HasColumnName("GrossROEVarSigned");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NetCapitalTvarAuth).HasColumnName("NetCapitalTVarAuth");
                entity.Property(e => e.NetCapitalTvarQuote).HasColumnName("NetCapitalTVarQuote");
                entity.Property(e => e.NetCapitalTvarSigned).HasColumnName("NetCapitalTVarSigned");
                entity.Property(e => e.NetCatPmlTvarArlAuth).HasColumnName("NetCatPmlTVarArlAuth");
                entity.Property(e => e.NetCatPmlTvarArlQuote).HasColumnName("NetCatPmlTVarArlQuote");
                entity.Property(e => e.NetCatPmlTvarArlSigned).HasColumnName("NetCatPmlTVarArlSigned");
                entity.Property(e => e.NetMinRoevarAuth).HasColumnName("NetMinROEVarAuth");
                entity.Property(e => e.NetMinRoevarQuote).HasColumnName("NetMinROEVarQuote");
                entity.Property(e => e.NetMinRoevarSigned).HasColumnName("NetMinROEVarSigned");
                entity.Property(e => e.NetRoetvarAuth).HasColumnName("NetROETVarAuth");
                entity.Property(e => e.NetRoetvarQuote).HasColumnName("NetROETVarQuote");
                entity.Property(e => e.NetRoetvarSigned).HasColumnName("NetROETVarSigned");
                entity.Property(e => e.NetRoevarAuth).HasColumnName("NetROEVarAuth");
                entity.Property(e => e.NetRoevarQuote).HasColumnName("NetROEVarQuote");
                entity.Property(e => e.NetRoevarSigned).HasColumnName("NetROEVarSigned");
                entity.Property(e => e.NetRoevarWithFeesAuth).HasColumnName("NetROEVarWithFeesAuth");
                entity.Property(e => e.NetRoevarWithFeesQuote).HasColumnName("NetROEVarWithFeesQuote");
                entity.Property(e => e.NetRoevarWithFeesSigned).HasColumnName("NetROEVarWithFeesSigned");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Submission).WithMany(p => p.SubDeltaPxResults)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubDeltaPxResult_dbo.Submission_SubmissionId");

                entity.HasOne(d => d.SubmissionPxPortfolio).WithMany(p => p.SubDeltaPxResults)
                    .HasForeignKey(d => d.SubmissionPxPortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubDeltaPxResult_dbo.SubmissionPxPortfolio_SubmissionPxPortfolioId");
            });

            modelBuilder.Entity<SubDeltaPxResultContract>(entity =>
            {
                entity.HasKey(e => e.SubDeltaPxResultContractId).HasName("PK_dbo.SubDeltaPxResultContract");

                entity.ToTable("SubDeltaPxResultContract");

                entity.HasIndex(e => e.ContractBinderId, "IX_ContractBinderId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.GrossCapitalTvar).HasColumnName("GrossCapitalTVar");
                entity.Property(e => e.GrossRoetvar).HasColumnName("GrossROETVar");
                entity.Property(e => e.GrossRoevar).HasColumnName("GrossROEVar");
                entity.Property(e => e.LossView).HasMaxLength(25);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NetRoevar).HasColumnName("NetROEVar");
                entity.Property(e => e.NetRoevarWithFees).HasColumnName("NetROEVarWithFees");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ContractBinder).WithMany(p => p.SubDeltaPxResultContracts)
                    .HasForeignKey(d => d.ContractBinderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubDeltaPxResultContract_dbo.ContractBinder_ContractBinderId");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => e.SubmissionId).HasName("PK_dbo.Submission");

                entity.ToTable("Submission");

                entity.HasIndex(e => e.ActuaryId, "IX_ActuaryId");

                entity.HasIndex(e => e.ActuaryPeerReviewerId, "IX_ActuaryPeerReviewerId");

                entity.HasIndex(e => e.AnalystId, "IX_AnalystId");

                entity.HasIndex(e => e.BrokerContactId, "IX_BrokerContactId");

                entity.HasIndex(e => e.BrokerId, "IX_BrokerId");

                entity.HasIndex(e => e.ExpiringSubmissionId, "IX_ExpiringSubmissionId");

                entity.HasIndex(e => e.GroupBuyerId, "IX_GroupBuyerId");

                entity.HasIndex(e => e.LastRegisSyncByUserId, "IX_LastRegisSyncByUserId");

                entity.HasIndex(e => e.LegalTermsId, "IX_LegalTermsId");

                entity.HasIndex(e => e.LocalBuyerId, "IX_LocalBuyerId");

                entity.HasIndex(e => e.ModelerId, "IX_ModelerId");

                entity.HasIndex(e => e.ProgramId, "IX_ProgramId");

                entity.HasIndex(e => e.RelshipUnderwriterId, "IX_RelshipUnderwriterId");

                entity.HasIndex(e => e.RiskZoneId, "IX_RiskZoneId");

                entity.HasIndex(e => e.SubmissionWriteupId, "IX_SubmissionWriteupId");

                entity.HasIndex(e => e.UnderwriterId, "IX_UnderwriterId");

                entity.Property(e => e.ActuarialDataCheck).HasColumnType("ntext");
                entity.Property(e => e.ActuarialDataLinkNotes).HasColumnType("ntext");
                entity.Property(e => e.ActuarialNotes).HasColumnType("ntext");
                entity.Property(e => e.ActuarialPriority).HasMaxLength(50);
                entity.Property(e => e.ActuarialRanking).HasMaxLength(50);
                entity.Property(e => e.BaseCurrency).HasMaxLength(3);
                entity.Property(e => e.CedentAltName).HasMaxLength(200);
                entity.Property(e => e.ClientAdvocacyLink).HasMaxLength(1000);
                entity.Property(e => e.Correspondence).HasColumnType("ntext");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.DataLinkNotes).HasColumnType("ntext");
                entity.Property(e => e.ErclossViewAir).HasColumnName("ERCLossViewAir");
                entity.Property(e => e.ErclossViewArch).HasColumnName("ERCLossViewArch");
                entity.Property(e => e.ErclossViewRms).HasColumnName("ERCLossViewRMS");
                entity.Property(e => e.FxDateSbf).HasColumnName("FxDateSBF");
                entity.Property(e => e.FxRateSbfgbp)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FxRateSBFGBP");
                entity.Property(e => e.FxRateSbfusd)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FxRateSBFUSD");
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.Fxrate)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FXRate");
                entity.Property(e => e.IrisSla).HasColumnName("IrisSLA");
                entity.Property(e => e.Lmxindicator)
                    .HasMaxLength(50)
                    .HasColumnName("LMXIndicator");
                entity.Property(e => e.MarketShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.ModelingNotes).HasColumnType("ntext");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Notes).HasColumnType("ntext");
                entity.Property(e => e.Pnocdays).HasColumnName("PNOCDays");
                entity.Property(e => e.Priority).HasMaxLength(50);
                entity.Property(e => e.RefId).HasMaxLength(20);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Source).HasMaxLength(50);
                entity.Property(e => e.StrategicNotes).HasColumnType("ntext");
                entity.Property(e => e.SubmissionDataLinkNotes).HasColumnType("ntext");
                entity.Property(e => e.Surplus).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Uwnotes)
                    .HasColumnType("ntext")
                    .HasColumnName("UWNotes");
                entity.Property(e => e.UwyearDefault).HasColumnName("UWYearDefault");

                entity.HasOne(d => d.Actuary).WithMany(p => p.SubmissionActuaries)
                    .HasForeignKey(d => d.ActuaryId)
                    .HasConstraintName("FK_dbo.Submission_dbo.User_ActuaryId");

                entity.HasOne(d => d.ActuaryPeerReviewer).WithMany(p => p.SubmissionActuaryPeerReviewers)
                    .HasForeignKey(d => d.ActuaryPeerReviewerId)
                    .HasConstraintName("FK_dbo.Submission_dbo.User_ActuaryPeerReviewerId");

                entity.HasOne(d => d.Analyst).WithMany(p => p.SubmissionAnalysts)
                    .HasForeignKey(d => d.AnalystId)
                    .HasConstraintName("FK_dbo.Submission_dbo.User_AnalystId");

                entity.HasOne(d => d.BrokerContact).WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.BrokerContactId)
                    .HasConstraintName("FK_dbo.Submission_dbo.BrokerContact_BrokerContactId");

                entity.HasOne(d => d.Broker).WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.BrokerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Submission_dbo.Broker_BrokerId");

                entity.HasOne(d => d.ExpiringSubmission).WithMany(p => p.InverseExpiringSubmission)
                    .HasForeignKey(d => d.ExpiringSubmissionId)
                    .HasConstraintName("FK_dbo.Submission_dbo.Submission_ExpiringSubmissionId");

                entity.HasOne(d => d.GroupBuyer).WithMany(p => p.SubmissionGroupBuyers)
                    .HasForeignKey(d => d.GroupBuyerId)
                    .HasConstraintName("FK_dbo.Submission_dbo.CedentContact_GroupBuyerId");

                entity.HasOne(d => d.LastRegisSyncByUser).WithMany(p => p.SubmissionLastRegisSyncByUsers)
                    .HasForeignKey(d => d.LastRegisSyncByUserId)
                    .HasConstraintName("FK_dbo.Submission_dbo.User_LastRegisSyncByUserId");

                entity.HasOne(d => d.LegalTerms).WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.LegalTermsId)
                    .HasConstraintName("FK_dbo.Submission_dbo.LegalTerms_LegalTermsId");

                entity.HasOne(d => d.LocalBuyer).WithMany(p => p.SubmissionLocalBuyers)
                    .HasForeignKey(d => d.LocalBuyerId)
                    .HasConstraintName("FK_dbo.Submission_dbo.CedentContact_LocalBuyerId");

                entity.HasOne(d => d.Modeler).WithMany(p => p.SubmissionModelers)
                    .HasForeignKey(d => d.ModelerId)
                    .HasConstraintName("FK_dbo.Submission_dbo.User_ModelerId");

                entity.HasOne(d => d.Program).WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Submission_dbo.Program_ProgramId");

                entity.HasOne(d => d.RelshipUnderwriter).WithMany(p => p.SubmissionRelshipUnderwriters)
                    .HasForeignKey(d => d.RelshipUnderwriterId)
                    .HasConstraintName("FK_dbo.Submission_dbo.User_RelshipUnderwriterId");

                entity.HasOne(d => d.RiskZone).WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.RiskZoneId)
                    .HasConstraintName("FK_dbo.Submission_dbo.RiskZone_RiskZoneId");

                entity.HasOne(d => d.SubmissionWriteup).WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.SubmissionWriteupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Submission_dbo.SubmissionWriteup_SubmissionWriteupId");

                entity.HasOne(d => d.Underwriter).WithMany(p => p.SubmissionUnderwriters)
                    .HasForeignKey(d => d.UnderwriterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Submission_dbo.User_UnderwriterId");
            });

            modelBuilder.Entity<SubmissionGuAnalysis>(entity =>
            {
                entity.HasKey(e => e.SubmissionGuAnalysisId).HasName("PK_dbo.SubmissionGuAnalysis");

                entity.ToTable("SubmissionGuAnalysis");

                entity.HasIndex(e => e.GuAnalysisId, "IX_GuAnalysisId");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.HasIndex(e => new { e.GuAnalysisId, e.SubmissionId }, "IX_Submission_GuAnalysis")
                    .IsUnique()
                    .HasFilter("([IsDeleted]=(0) AND [IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Fxdate).HasColumnName("FXDate");
                entity.Property(e => e.Fxrate)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FXRate");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.GuAnalysis).WithMany(p => p.SubmissionGuAnalyses)
                    .HasForeignKey(d => d.GuAnalysisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubmissionGuAnalysis_dbo.GuAnalysis_GuAnalysisId");

                entity.HasOne(d => d.Submission).WithMany(p => p.SubmissionGuAnalyses)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubmissionGuAnalysis_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<SubmissionPxPortfolio>(entity =>
            {
                entity.HasKey(e => e.SubmissionPxPortfolioId).HasName("PK_dbo.SubmissionPxPortfolio");

                entity.ToTable("SubmissionPxPortfolio");

                entity.HasIndex(e => e.PortfolioId, "IX_PortfolioId");

                entity.HasIndex(e => e.SubmissionId, "IX_SubmissionId");

                entity.HasIndex(e => new { e.SubmissionId, e.PortfolioId }, "UQ_SubmissionId_PortfolioId")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.JobId).HasMaxLength(10);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Portfolio).WithMany(p => p.SubmissionPxPortfolios)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubmissionPxPortfolio_dbo.Portfolio_PortfolioId");

                entity.HasOne(d => d.Submission).WithMany(p => p.SubmissionPxPortfolios)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubmissionPxPortfolio_dbo.Submission_SubmissionId");
            });

            modelBuilder.Entity<SubmissionWriteup>(entity =>
            {
                entity.HasKey(e => e.SubmissionWriteupId).HasName("PK_dbo.SubmissionWriteup");

                entity.ToTable("SubmissionWriteup");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RiskFlowNotes).HasColumnType("ntext");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.SpreadsheetData).HasColumnType("image");
                entity.Property(e => e.UwspreadsheetData)
                    .HasColumnType("image")
                    .HasColumnName("UWSpreadsheetData");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.SubscriptionId).HasName("PK_dbo.Subscription");

                entity.ToTable("Subscription");

                entity.HasIndex(e => e.NotificationEventId, "IX_NotificationEventId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.NotificationEvent).WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.NotificationEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Subscription_dbo.NotificationEvent_NotificationEventId");
            });

            modelBuilder.Entity<TargetPmldef>(entity =>
            {
                entity.HasKey(e => e.TargetPmldefId).HasName("PK_dbo.TargetPMLDef");

                entity.ToTable("TargetPMLDef");

                entity.HasIndex(e => e.LossZoneId, "IX_LossZoneId");

                entity.HasIndex(e => e.PmlmatchingDefId, "IX_PMLMatchingDefId");

                entity.Property(e => e.TargetPmldefId).HasColumnName("TargetPMLDefId");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.PmlmatchingDefId).HasColumnName("PMLMatchingDefId");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Rp).HasColumnName("RP");

                entity.HasOne(d => d.LossZone).WithMany(p => p.TargetPmldefs)
                    .HasForeignKey(d => d.LossZoneId)
                    .HasConstraintName("FK_dbo.TargetPMLDef_dbo.LossZone_LossZoneId");

                entity.HasOne(d => d.PmlmatchingDef).WithMany(p => p.TargetPmldefs)
                    .HasForeignKey(d => d.PmlmatchingDefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TargetPMLDef_dbo.PmlMatchingDef_PMLMatchingDefId");
            });

            modelBuilder.Entity<Tmpla>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tmpla");

                entity.Property(e => e.MajorZone).HasMaxLength(255);
                entity.Property(e => e.Peril)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Tmpra>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tmpra");

                entity.Property(e => e.MajorZone).HasMaxLength(255);
                entity.Property(e => e.Peril)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TopUpZone>(entity =>
            {
                entity.HasKey(e => e.TopUpZoneId).HasName("PK_dbo.TopUpZone");

                entity.ToTable("TopUpZone");

                entity.HasIndex(e => e.Name, "UQ_TopZoneName").IsUnique();

                entity.Property(e => e.Cession).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.CessionCapQs2).HasColumnName("CessionCapQS2");
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Elthreshold)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ELThreshold");
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.ZoneEnd).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
                entity.Property(e => e.ZoneStart).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            });

            modelBuilder.Entity<TopUpZoneGeoMap>(entity =>
            {
                entity.HasKey(e => e.TopUpZoneGeoMapId).HasName("PK_dbo.TopUpZoneGeoMap");

                entity.ToTable("TopUpZoneGeoMap");

                entity.HasIndex(e => e.TopUpZoneId, "IX_TopUpZoneId");

                entity.HasIndex(e => new { e.GeoLevelCode, e.CountryCode, e.AreaCode }, "UQ_TopUpZoneGeoMap").IsUnique();

                entity.Property(e => e.AreaCode).HasMaxLength(15);
                entity.Property(e => e.CountryCode).HasMaxLength(15);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.GeoLevelCode).HasMaxLength(10);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.TopUpZone).WithMany(p => p.TopUpZoneGeoMaps)
                    .HasForeignKey(d => d.TopUpZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TopUpZoneGeoMap_dbo.TopUpZone_TopUpZoneId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK_dbo.User");

                entity.ToTable("User");

                entity.HasIndex(e => e.DeptId, "IX_DeptId");

                entity.HasIndex(e => e.RoleId, "IX_RoleId");

                entity.HasIndex(e => new { e.Username, e.Domain }, "UQ_DomainUsername").IsUnique();

                entity.Property(e => e.AdminComments).HasMaxLength(500);
                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Domain).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.ExcludedOffices).HasMaxLength(100);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.Irisuwcode).HasColumnName("IRISUWCode");
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.NickName).HasMaxLength(50);
                entity.Property(e => e.ProvisionedCompanies).HasMaxLength(100);
                entity.Property(e => e.RegisId).HasMaxLength(20);
                entity.Property(e => e.RegisStaffCode).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Upn).HasMaxLength(250);
                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Dept).WithMany(p => p.Users)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.User_dbo.Dept_DeptId");

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.User_dbo.Role_RoleId");
            });

            modelBuilder.Entity<UserLayout>(entity =>
            {
                entity.HasKey(e => e.UserLayoutId).HasName("PK_dbo.UserLayout");

                entity.ToTable("UserLayout");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.Layout).HasColumnType("ntext");
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.User).WithMany(p => p.UserLayouts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.UserLayout_dbo.User_UserId");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.HasKey(e => e.UserPermissionId).HasName("PK_dbo.UserPermission");

                entity.ToTable("UserPermission");

                entity.HasIndex(e => e.PermissionId, "IX_PermissionId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.HasIndex(e => new { e.UserId, e.PermissionId }, "UQ_UserIdPermissionId")
                    .IsUnique()
                    .HasFilter("([IsActive]=(1) AND [IsDeleted]=(0))");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.UserPermission_dbo.Permission_PermissionId");

                entity.HasOne(d => d.User).WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.UserPermission_dbo.User_UserId");
            });

            modelBuilder.Entity<UserSubscription>(entity =>
            {
                entity.HasKey(e => e.UserSubscriptionId).HasName("PK_dbo.UserSubscription");

                entity.ToTable("UserSubscription");

                entity.HasIndex(e => e.SubscriptionId, "IX_SubscriptionId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Subscription).WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.UserSubscription_dbo.Subscription_SubscriptionId");

                entity.HasOne(d => d.User).WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserSubscription_dbo.User_UserId");
            });

            modelBuilder.Entity<VwAuditDetail>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwAuditDetail", "ProdSupport");

                entity.Property(e => e.ObjectType).HasMaxLength(512);
                entity.Property(e => e.Property).HasMaxLength(256);
                entity.Property(e => e.ServerName).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VwAuditDetailLayer>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwAuditDetailLayer", "ProdSupport");

                entity.Property(e => e.Property).HasMaxLength(256);
                entity.Property(e => e.ServerName).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VwAuditDetailProgram>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwAuditDetailProgram", "ProdSupport");

                entity.Property(e => e.Property).HasMaxLength(256);
                entity.Property(e => e.ServerName).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VwAuditDetailSubmission>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwAuditDetailSubmission", "ProdSupport");

                entity.Property(e => e.Property).HasMaxLength(256);
                entity.Property(e => e.ServerName).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VwContractReviewerPending>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwContractReviewerPending", "ProdSupport");

                entity.Property(e => e.ContractBinderStatus)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ContractBinder Status");
                entity.Property(e => e.ReviewerFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Reviewer FirstName");
                entity.Property(e => e.ReviewerLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Reviewer LastName");
                entity.Property(e => e.UwyearDefault).HasColumnName("UWYearDefault");
            });

            modelBuilder.Entity<VwLayer>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwLayer");

                entity.Property(e => e.ContractLimitUsd)
                    .HasColumnType("decimal(38, 6)")
                    .HasColumnName("ContractLimitUSD");
            });

            modelBuilder.Entity<VwLayerLossSummary>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwLayerLossSummary");

                entity.Property(e => e.AirEl).HasColumnName("AirEL");
                entity.Property(e => e.ArlEl).HasColumnName("ArlEL");
                entity.Property(e => e.Cr).HasColumnName("CR");
                entity.Property(e => e.Er).HasColumnName("ER");
                entity.Property(e => e.ExpectedRp).HasColumnName("ExpectedRP");
                entity.Property(e => e.ExpectedRpamt).HasColumnName("ExpectedRPAmt");
                entity.Property(e => e.GrossRoevarSigned).HasColumnName("GrossROEVarSigned");
                entity.Property(e => e.Lr).HasColumnName("LR");
                entity.Property(e => e.NetRoevarSigned).HasColumnName("NetROEVarSigned");
                entity.Property(e => e.Rb).HasColumnName("RB");
                entity.Property(e => e.RmsEl).HasColumnName("RmsEL");
                entity.Property(e => e.StandaloneRoe).HasColumnName("StandaloneROE");
            });

            modelBuilder.Entity<VwLayerLossZoneSummary>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwLayerLossZoneSummary");

                entity.Property(e => e.El).HasColumnName("EL");
            });

            modelBuilder.Entity<VwLayerMajorZoneLossSummary>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwLayerMajorZoneLossSummary");

                entity.Property(e => e.El).HasColumnName("EL");
            });

            modelBuilder.Entity<VwLayerTerm>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwLayerTerms");

                entity.Property(e => e.AggLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AggRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.BaseCurrency).HasMaxLength(3);
                entity.Property(e => e.ContractLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Fxrate)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("FXRate");
                entity.Property(e => e.NotionalLimit).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.NotionalRol)
                    .HasColumnType("numeric(38, 20)")
                    .HasColumnName("NotionalROL");
                entity.Property(e => e.OccLimit).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OccRetention).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Placement).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Premium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.QuotePremium).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.QuoteRol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("QuoteROL");
                entity.Property(e => e.QuotedShare).HasColumnType("decimal(18, 10)");
                entity.Property(e => e.Rol)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("ROL");
                entity.Property(e => e.SignedShare).HasColumnType("decimal(18, 10)");
            });

            modelBuilder.Entity<VwLossEventSummary>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwLossEventSummary");

                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.EventCode).HasMaxLength(20);
                entity.Property(e => e.GeographyIds).HasMaxLength(4000);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.PcscatNum).HasColumnName("PCSCatNum");
                entity.Property(e => e.Peril).HasMaxLength(10);
                entity.Property(e => e.Region).HasMaxLength(50);
            });

            modelBuilder.Entity<VwRolePermission>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwRolePermission");

                entity.Property(e => e.Permission).HasMaxLength(50);
                entity.Property(e => e.PermissionDesc).HasMaxLength(100);
                entity.Property(e => e.PermissionState)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.UserRole).HasMaxLength(50);
            });

            modelBuilder.Entity<VwUser>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwUser");

                entity.Property(e => e.Company).HasMaxLength(50);
                entity.Property(e => e.Dept).HasMaxLength(100);
                entity.Property(e => e.Domain).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.LegalEntCode).HasMaxLength(8);
                entity.Property(e => e.NickName).HasMaxLength(50);
                entity.Property(e => e.Office).HasMaxLength(50);
                entity.Property(e => e.OfficeCode).HasMaxLength(20);
                entity.Property(e => e.RegisStaffCode).HasMaxLength(50);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VwUserImplicitPermission>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwUserImplicitPermission");

                entity.Property(e => e.Company).HasMaxLength(50);
                entity.Property(e => e.Dept).HasMaxLength(100);
                entity.Property(e => e.Domain).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.LegalEntCode).HasMaxLength(8);
                entity.Property(e => e.Office).HasMaxLength(50);
                entity.Property(e => e.Permission).HasMaxLength(50);
                entity.Property(e => e.PermissionDesc).HasMaxLength(100);
                entity.Property(e => e.PermissionState)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VwUserPermission>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vwUserPermission");

                entity.Property(e => e.Company).HasMaxLength(50);
                entity.Property(e => e.Dept).HasMaxLength(100);
                entity.Property(e => e.Domain).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.LegalEntCode).HasMaxLength(8);
                entity.Property(e => e.Office).HasMaxLength(50);
                entity.Property(e => e.Permission).HasMaxLength(50);
                entity.Property(e => e.PermissionDesc).HasMaxLength(100);
                entity.Property(e => e.PermissionState)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<ZoneDefinition>(entity =>
            {
                entity.HasKey(e => e.ZoneDefinitionId).HasName("PK_dbo.ZoneDefinition");

                entity.ToTable("ZoneDefinition");

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ZoneGeography>(entity =>
            {
                entity.HasKey(e => e.ZoneGeographyId).HasName("PK_dbo.ZoneGeography");

                entity.ToTable("ZoneGeography");

                entity.HasIndex(e => e.LossZoneId, "IX_LossZoneId");

                entity.HasIndex(e => e.MajorZoneId, "IX_MajorZoneId");

                entity.HasIndex(e => new { e.ZoneDefinitionId, e.GeographyId, e.Peril }, "UQ_ZoneDefGeography").IsUnique();

                entity.Property(e => e.CreateUser).HasMaxLength(50);
                entity.Property(e => e.ModifyUser).HasMaxLength(50);
                entity.Property(e => e.Peril).HasMaxLength(2);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Geography).WithMany(p => p.ZoneGeographies)
                    .HasForeignKey(d => d.GeographyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ZoneGeography_dbo.Geography_GeographyId");

                entity.HasOne(d => d.LossZone).WithMany(p => p.ZoneGeographies)
                    .HasForeignKey(d => d.LossZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ZoneGeography_dbo.LossZone_LossZoneId");

                entity.HasOne(d => d.MajorZone).WithMany(p => p.ZoneGeographies)
                    .HasForeignKey(d => d.MajorZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ZoneGeography_dbo.MajorZone_MajorZoneId");

                entity.HasOne(d => d.ZoneDefinition).WithMany(p => p.ZoneGeographies)
                    .HasForeignKey(d => d.ZoneDefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ZoneGeography_dbo.ZoneDefinition_ZoneDefinitionId");
            });

            modelBuilder.Entity<ZzzIndustryLossDupRecsImport220920>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("zzzIndustryLoss_DupRecs_Import_220920");

                entity.Property(e => e.Country).HasMaxLength(2);
                entity.Property(e => e.EstType).HasMaxLength(3);
                entity.Property(e => e.State).HasMaxLength(20);
            });
            modelBuilder.HasSequence<int>("LossEvent_EventCode_Seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}