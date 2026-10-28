using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

public partial class CmmsContext : DbContext
{
    public CmmsContext()
    {
    }

    public CmmsContext(DbContextOptions<CmmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abcclassification> Abcclassifications { get; set; }

    public virtual DbSet<ApiClient> ApiClients { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetCategory> AssetCategories { get; set; }

    public virtual DbSet<AssetCriticality> AssetCriticalities { get; set; }

    public virtual DbSet<AssetGroup> AssetGroups { get; set; }

    public virtual DbSet<AssetGroupEntry> AssetGroupEntries { get; set; }

    public virtual DbSet<AssetHierarchy> AssetHierarchies { get; set; }

    public virtual DbSet<AssetLocation> AssetLocations { get; set; }

    public virtual DbSet<AssetStatus> AssetStatuses { get; set; }

    public virtual DbSet<AssetType> AssetTypes { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<AuditEvent> AuditEvents { get; set; }

    public virtual DbSet<Breakdown> Breakdowns { get; set; }

    public virtual DbSet<BreakdownApproval> BreakdownApprovals { get; set; }

    public virtual DbSet<BreakdownCause> BreakdownCauses { get; set; }

    public virtual DbSet<BreakdownCorrectiveAction> BreakdownCorrectiveActions { get; set; }

    public virtual DbSet<BreakdownEvidence> BreakdownEvidences { get; set; }

    public virtual DbSet<BreakdownFailure> BreakdownFailures { get; set; }

    public virtual DbSet<BreakdownInvestigation> BreakdownInvestigations { get; set; }

    public virtual DbSet<BreakdownPreventiveAction> BreakdownPreventiveActions { get; set; }

    public virtual DbSet<BreakdownVerification> BreakdownVerifications { get; set; }

    public virtual DbSet<BreakdownWhyAnalysis> BreakdownWhyAnalyses { get; set; }

    public virtual DbSet<CalibrationAsset> CalibrationAssets { get; set; }

    public virtual DbSet<CalibrationCertificate> CalibrationCertificates { get; set; }

    public virtual DbSet<CalibrationComplianceSnapshot> CalibrationComplianceSnapshots { get; set; }

    public virtual DbSet<CalibrationEvidence> CalibrationEvidences { get; set; }

    public virtual DbSet<CalibrationExecution> CalibrationExecutions { get; set; }

    public virtual DbSet<CalibrationMethod> CalibrationMethods { get; set; }

    public virtual DbSet<CalibrationOotassessment> CalibrationOotassessments { get; set; }

    public virtual DbSet<CalibrationReading> CalibrationReadings { get; set; }

    public virtual DbSet<CalibrationResult> CalibrationResults { get; set; }

    public virtual DbSet<CalibrationSchedule> CalibrationSchedules { get; set; }

    public virtual DbSet<CalibrationSignature> CalibrationSignatures { get; set; }

    public virtual DbSet<CalibrationStandard> CalibrationStandards { get; set; }

    public virtual DbSet<CalibrationVersion> CalibrationVersions { get; set; }

    public virtual DbSet<CalibrationWorkOrder> CalibrationWorkOrders { get; set; }

    public virtual DbSet<CauseCode> CauseCodes { get; set; }

    public virtual DbSet<ChecklistExecution> ChecklistExecutions { get; set; }

    public virtual DbSet<ChecklistExecutionSection> ChecklistExecutionSections { get; set; }

    public virtual DbSet<ChecklistQuestion> ChecklistQuestions { get; set; }

    public virtual DbSet<ChecklistQuestionOption> ChecklistQuestionOptions { get; set; }

    public virtual DbSet<ChecklistResponse> ChecklistResponses { get; set; }

    public virtual DbSet<ChecklistResponseAttachment> ChecklistResponseAttachments { get; set; }

    public virtual DbSet<ChecklistRule> ChecklistRules { get; set; }

    public virtual DbSet<ChecklistScore> ChecklistScores { get; set; }

    public virtual DbSet<ChecklistSection> ChecklistSections { get; set; }

    public virtual DbSet<ChecklistSignature> ChecklistSignatures { get; set; }

    public virtual DbSet<ChecklistTemplate> ChecklistTemplates { get; set; }

    public virtual DbSet<ChecklistVersion> ChecklistVersions { get; set; }

    public virtual DbSet<ControlMeasure> ControlMeasures { get; set; }

    public virtual DbSet<CycleCount> CycleCounts { get; set; }

    public virtual DbSet<DeadStockAnalysis> DeadStockAnalyses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<ElectronicSignature> ElectronicSignatures { get; set; }

    public virtual DbSet<ElectronicSignature1> ElectronicSignatures1 { get; set; }

    public virtual DbSet<ElectronicSignatureAttachment> ElectronicSignatureAttachments { get; set; }

    public virtual DbSet<ElectronicSignatureAudit> ElectronicSignatureAudits { get; set; }

    public virtual DbSet<ElectronicSignatureChallenge> ElectronicSignatureChallenges { get; set; }

    public virtual DbSet<ElectronicSignatureMeaning> ElectronicSignatureMeanings { get; set; }

    public virtual DbSet<ElectronicSignaturePolicy> ElectronicSignaturePolicies { get; set; }

    public virtual DbSet<ElectronicSignaturePurpose> ElectronicSignaturePurposes { get; set; }

    public virtual DbSet<ElectronicSignatureRequest> ElectronicSignatureRequests { get; set; }

    public virtual DbSet<ElectronicSignatureRole> ElectronicSignatureRoles { get; set; }

    public virtual DbSet<ElectronicSignatureRoleAssignment> ElectronicSignatureRoleAssignments { get; set; }

    public virtual DbSet<ElectronicSignatureSequence> ElectronicSignatureSequences { get; set; }

    public virtual DbSet<ElectronicSignatureVerification> ElectronicSignatureVerifications { get; set; }

    public virtual DbSet<EventBatch> EventBatches { get; set; }

    public virtual DbSet<EventConsumerOffset> EventConsumerOffsets { get; set; }

    public virtual DbSet<EventDeadLetter> EventDeadLetters { get; set; }

    public virtual DbSet<EventInbox> EventInboxes { get; set; }

    public virtual DbSet<EventOutbox> EventOutboxes { get; set; }

    public virtual DbSet<EventPublicationLog> EventPublicationLogs { get; set; }

    public virtual DbSet<EventReplayRequest> EventReplayRequests { get; set; }

    public virtual DbSet<EventSchema> EventSchemas { get; set; }

    public virtual DbSet<EventSubscription> EventSubscriptions { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<FailureCode> FailureCodes { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<GoodsReceiptNote> GoodsReceiptNotes { get; set; }

    public virtual DbSet<HazardMaster> HazardMasters { get; set; }

    public virtual DbSet<IntegrationBatch> IntegrationBatches { get; set; }

    public virtual DbSet<IntegrationConfiguration> IntegrationConfigurations { get; set; }

    public virtual DbSet<IntegrationCredential> IntegrationCredentials { get; set; }

    public virtual DbSet<IntegrationDeadLetter> IntegrationDeadLetters { get; set; }

    public virtual DbSet<IntegrationEndpoint> IntegrationEndpoints { get; set; }

    public virtual DbSet<IntegrationEvent> IntegrationEvents { get; set; }

    public virtual DbSet<IntegrationInbox> IntegrationInboxes { get; set; }

    public virtual DbSet<IntegrationMapping> IntegrationMappings { get; set; }

    public virtual DbSet<IntegrationMessage> IntegrationMessages { get; set; }

    public virtual DbSet<IntegrationOutbox> IntegrationOutboxes { get; set; }

    public virtual DbSet<IntegrationRetry> IntegrationRetries { get; set; }

    public virtual DbSet<IntegrationSchedule> IntegrationSchedules { get; set; }

    public virtual DbSet<IntegrationSubscription> IntegrationSubscriptions { get; set; }

    public virtual DbSet<IntegrationSystem> IntegrationSystems { get; set; }

    public virtual DbSet<InventoryAdjustment> InventoryAdjustments { get; set; }

    public virtual DbSet<InventoryBalance> InventoryBalances { get; set; }

    public virtual DbSet<InventoryConsumption> InventoryConsumptions { get; set; }

    public virtual DbSet<InventoryCycleCountLine> InventoryCycleCountLines { get; set; }

    public virtual DbSet<InventoryForecast> InventoryForecasts { get; set; }

    public virtual DbSet<InventoryIntegrationLog> InventoryIntegrationLogs { get; set; }

    public virtual DbSet<InventoryIssue> InventoryIssues { get; set; }

    public virtual DbSet<InventoryLot> InventoryLots { get; set; }

    public virtual DbSet<InventoryReceipt> InventoryReceipts { get; set; }

    public virtual DbSet<InventoryReceiptItem> InventoryReceiptItems { get; set; }

    public virtual DbSet<InventoryReservation> InventoryReservations { get; set; }

    public virtual DbSet<InventoryReturn> InventoryReturns { get; set; }

    public virtual DbSet<InventorySerial> InventorySerials { get; set; }

    public virtual DbSet<InventoryStockAgeing> InventoryStockAgeings { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<InventoryTransactionOutbox> InventoryTransactionOutboxes { get; set; }

    public virtual DbSet<InventoryTransfer> InventoryTransfers { get; set; }

    public virtual DbSet<InventoryValuationSnapshot> InventoryValuationSnapshots { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Localization> Localizations { get; set; }

    public virtual DbSet<LoginHistory> LoginHistories { get; set; }

    public virtual DbSet<LookupBase> LookupBases { get; set; }

    public virtual DbSet<MaintenanceGroup> MaintenanceGroups { get; set; }

    public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialAlternate> MaterialAlternates { get; set; }

    public virtual DbSet<MaterialCategory> MaterialCategories { get; set; }

    public virtual DbSet<MaterialCostLedger> MaterialCostLedgers { get; set; }

    public virtual DbSet<MaterialVendor> MaterialVendors { get; set; }

    public virtual DbSet<MaterialWarehouse> MaterialWarehouses { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuPermission> MenuPermissions { get; set; }

    public virtual DbSet<NotificationAttachment> NotificationAttachments { get; set; }

    public virtual DbSet<NotificationDelivery> NotificationDeliveries { get; set; }

    public virtual DbSet<NotificationEscalationRule> NotificationEscalationRules { get; set; }

    public virtual DbSet<NotificationEvent> NotificationEvents { get; set; }

    public virtual DbSet<NotificationMessage> NotificationMessages { get; set; }

    public virtual DbSet<NotificationPreference> NotificationPreferences { get; set; }

    public virtual DbSet<NotificationRecipient> NotificationRecipients { get; set; }

    public virtual DbSet<NotificationRetry> NotificationRetries { get; set; }

    public virtual DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }

    public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }

    public virtual DbSet<NotificationTemplateTranslation> NotificationTemplateTranslations { get; set; }

    public virtual DbSet<PasswordHistory> PasswordHistories { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Permit> Permits { get; set; }

    public virtual DbSet<PermitApproval> PermitApprovals { get; set; }

    public virtual DbSet<PermitAsset> PermitAssets { get; set; }

    public virtual DbSet<PermitAttachment> PermitAttachments { get; set; }

    public virtual DbSet<PermitBlockingRule> PermitBlockingRules { get; set; }

    public virtual DbSet<PermitClosure> PermitClosures { get; set; }

    public virtual DbSet<PermitControlMeasure> PermitControlMeasures { get; set; }

    public virtual DbSet<PermitEmployee> PermitEmployees { get; set; }

    public virtual DbSet<PermitExtension> PermitExtensions { get; set; }

    public virtual DbSet<PermitHazard> PermitHazards { get; set; }

    public virtual DbSet<PermitIssue> PermitIssues { get; set; }

    public virtual DbSet<PermitRiskAssessment> PermitRiskAssessments { get; set; }

    public virtual DbSet<PermitSignature> PermitSignatures { get; set; }

    public virtual DbSet<PermitSuspend> PermitSuspends { get; set; }

    public virtual DbSet<PermitType> PermitTypes { get; set; }

    public virtual DbSet<PermitWorkIsolation> PermitWorkIsolations { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PmcalendarRule> PmcalendarRules { get; set; }

    public virtual DbSet<PmcomplianceSnapshot> PmcomplianceSnapshots { get; set; }

    public virtual DbSet<PmcycleRule> PmcycleRules { get; set; }

    public virtual DbSet<Pmexecution> Pmexecutions { get; set; }

    public virtual DbSet<PmexecutionChecklist> PmexecutionChecklists { get; set; }

    public virtual DbSet<PmexecutionReading> PmexecutionReadings { get; set; }

    public virtual DbSet<Pmforecast> Pmforecasts { get; set; }

    public virtual DbSet<PmgenerationLog> PmgenerationLogs { get; set; }

    public virtual DbSet<PmquantityRule> PmquantityRules { get; set; }

    public virtual DbSet<PmruntimeRule> PmruntimeRules { get; set; }

    public virtual DbSet<Pmschedule> Pmschedules { get; set; }

    public virtual DbSet<PmscheduleAsset> PmscheduleAssets { get; set; }

    public virtual DbSet<PmscheduleChecklist> PmscheduleChecklists { get; set; }

    public virtual DbSet<PmtriggerHistory> PmtriggerHistories { get; set; }

    public virtual DbSet<PmworkOrder> PmworkOrders { get; set; }

    public virtual DbSet<ProductionLine> ProductionLines { get; set; }

    public virtual DbSet<PurchaseReceipt> PurchaseReceipts { get; set; }

    public virtual DbSet<PurchaseReceiptItem> PurchaseReceiptItems { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<ReorderSuggestion> ReorderSuggestions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<SecurityAudit> SecurityAudits { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SlaInstance> SlaInstances { get; set; }

    public virtual DbSet<SpareRequest> SpareRequests { get; set; }

    public virtual DbSet<SpareRequestItem> SpareRequestItems { get; set; }

    public virtual DbSet<StockSnapshot> StockSnapshots { get; set; }

    public virtual DbSet<StorageLocation> StorageLocations { get; set; }

    public virtual DbSet<SystemMessage> SystemMessages { get; set; }

    public virtual DbSet<SystemMessageTranslation> SystemMessageTranslations { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<TenantFeature> TenantFeatures { get; set; }

    public virtual DbSet<TenantLanguage> TenantLanguages { get; set; }

    public virtual DbSet<Uom> Uoms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClaim> UserClaims { get; set; }

    public virtual DbSet<UserDepartment> UserDepartments { get; set; }

    public virtual DbSet<UserPlant> UserPlants { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserTeam> UserTeams { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VwAssetTypeLookup> VwAssetTypeLookups { get; set; }

    public virtual DbSet<VwWorkOrder> VwWorkOrders { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WebhookRequestLog> WebhookRequestLogs { get; set; }

    public virtual DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }

    public virtual DbSet<WorkCenter> WorkCenters { get; set; }

    public virtual DbSet<WorkOrder> WorkOrders { get; set; }

    public virtual DbSet<WorkOrderAssignment> WorkOrderAssignments { get; set; }

    public virtual DbSet<WorkflowAction> WorkflowActions { get; set; }

    public virtual DbSet<WorkflowApproval> WorkflowApprovals { get; set; }

    public virtual DbSet<WorkflowComment> WorkflowComments { get; set; }

    public virtual DbSet<WorkflowDefinition> WorkflowDefinitions { get; set; }

    public virtual DbSet<WorkflowEscalation> WorkflowEscalations { get; set; }

    public virtual DbSet<WorkflowHistory> WorkflowHistories { get; set; }

    public virtual DbSet<WorkflowInstance> WorkflowInstances { get; set; }

    public virtual DbSet<WorkflowInstanceState> WorkflowInstanceStates { get; set; }

    public virtual DbSet<WorkflowNotification> WorkflowNotifications { get; set; }

    public virtual DbSet<WorkflowRoleAssignment> WorkflowRoleAssignments { get; set; }

    public virtual DbSet<WorkflowRule> WorkflowRules { get; set; }

    public virtual DbSet<WorkflowState> WorkflowStates { get; set; }

    public virtual DbSet<WorkflowTask> WorkflowTasks { get; set; }

    public virtual DbSet<WorkflowTransition> WorkflowTransitions { get; set; }

    public virtual DbSet<WorkflowVariable> WorkflowVariables { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DCCPL0667\\MSSQLSERVER2025;Database=CMMS;User ID=sa;Password=dts@123;Trust Server Certificate=true;Trust Server Certificate=true;Command Timeout=100000");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abcclassification>(entity =>
        {
            entity.HasKey(e => e.AbcclassificationId).HasName("PK__ABCClass__FF7B4C08452F78E6");

            entity.Property(e => e.AbcclassificationId).ValueGeneratedNever();
            entity.Property(e => e.ClassificationCode).IsFixedLength();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AbcclassificationCreatedByNavigations).HasConstraintName("FK_ABCClassification_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AbcclassificationLastModifiedByNavigations).HasConstraintName("FK_ABCClassification_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.Abcclassifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ABCClassi__Mater__68687968");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Abcclassifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ABCClassification_TenantId");
        });

        modelBuilder.Entity<ApiClient>(entity =>
        {
            entity.HasKey(e => e.ApiClientId).HasName("PK__ApiClien__FDC5B7C8ACC78BB1");

            entity.Property(e => e.ApiClientId).ValueGeneratedNever();

            entity.HasOne(d => d.Tenant).WithMany(p => p.ApiClients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApiClient_TenantId");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B82048D5A24709");

            entity.Property(e => e.AreaId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AreaCreatedByNavigations).HasConstraintName("FK_Area_CreatedBy");

            entity.HasOne(d => d.Department).WithMany(p => p.Areas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Area__Department__1332DBDC");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AreaLastModifiedByNavigations).HasConstraintName("FK_Area_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Areas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Area__TenantId__123EB7A3");
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Asset__4349235256CE5031");

            entity.Property(e => e.AssetId).ValueGeneratedNever();

            entity.HasOne(d => d.AssetCategory).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asset__AssetCate__2EDAF651");

            entity.HasOne(d => d.AssetCriticality).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asset__AssetCrit__2FCF1A8A");

            entity.HasOne(d => d.AssetStatus).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asset__AssetStat__30C33EC3");

            entity.HasOne(d => d.AssetType).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asset__AssetType__2DE6D218");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetCreatedByNavigations).HasConstraintName("FK_Asset_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetLastModifiedByNavigations).HasConstraintName("FK_Asset_LastModifiedBy");

            entity.HasOne(d => d.Location).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asset__LocationI__31B762FC");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asset__TenantId__2CF2ADDF");
        });

        modelBuilder.Entity<AssetCategory>(entity =>
        {
            entity.HasKey(e => e.AssetCategoryId).HasName("PK__AssetCat__C381F47DE5FA2C2A");

            entity.Property(e => e.AssetCategoryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetCategoryCreatedByNavigations).HasConstraintName("FK_AssetCategory_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetCategoryLastModifiedByNavigations).HasConstraintName("FK_AssetCategory_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetCate__Tenan__208CD6FA");
        });

        modelBuilder.Entity<AssetCriticality>(entity =>
        {
            entity.HasKey(e => e.AssetCriticalityId).HasName("PK__AssetCri__5634F2B12BF391E4");

            entity.Property(e => e.AssetCriticalityId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetCriticalityCreatedByNavigations).HasConstraintName("FK_AssetCriticality_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetCriticalityLastModifiedByNavigations).HasConstraintName("FK_AssetCriticality_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetCriticalities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetCrit__Tenan__236943A5");
        });

        modelBuilder.Entity<AssetGroup>(entity =>
        {
            entity.Property(e => e.AssetGroupId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetGroupCreatedByNavigations).HasConstraintName("FK_AssetGroup_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetGroupLastModifiedByNavigations).HasConstraintName("FK_AssetGroup_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetGroup_Tenant");
        });

        modelBuilder.Entity<AssetGroupEntry>(entity =>
        {
            entity.Property(e => e.AssetGroupEntryId).ValueGeneratedNever();

            entity.HasOne(d => d.AssetGroup).WithMany(p => p.AssetGroupEntries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetGroupEntry_AssetGroup");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetGroupEntries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetGroupEntry_Asset");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetGroupEntryCreatedByNavigations).HasConstraintName("FK_AssetGroupEntry_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetGroupEntryLastModifiedByNavigations).HasConstraintName("FK_AssetGroupEntry_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetGroupEntries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetGroupEntry_Tenant");
        });

        modelBuilder.Entity<AssetHierarchy>(entity =>
        {
            entity.HasKey(e => e.AssetHierarchyId).HasName("PK__AssetHie__E434378B9E98E560");

            entity.Property(e => e.AssetHierarchyId).ValueGeneratedNever();

            entity.HasOne(d => d.ChildAsset).WithMany(p => p.AssetHierarchyChildAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetHier__Child__367C1819");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetHierarchyCreatedByNavigations).HasConstraintName("FK_AssetHierarchy_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetHierarchyLastModifiedByNavigations).HasConstraintName("FK_AssetHierarchy_LastModifiedBy");

            entity.HasOne(d => d.ParentAsset).WithMany(p => p.AssetHierarchyParentAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetHier__Paren__3587F3E0");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetHierarchies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetHier__Tenan__3493CFA7");
        });

        modelBuilder.Entity<AssetLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__AssetLoc__E7FEA497A25E7A90");

            entity.Property(e => e.LocationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetLocationCreatedByNavigations).HasConstraintName("FK_AssetLocation_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetLocationLastModifiedByNavigations).HasConstraintName("FK_AssetLocation_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetLoca__Tenan__29221CFB");

            entity.HasOne(d => d.WorkCenter).WithMany(p => p.AssetLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetLoca__WorkC__2A164134");
        });

        modelBuilder.Entity<AssetStatus>(entity =>
        {
            entity.HasKey(e => e.AssetStatusId).HasName("PK__AssetSta__E63EE496B8399B62");

            entity.Property(e => e.AssetStatusId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetStatusCreatedByNavigations).HasConstraintName("FK_AssetStatus_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetStatusLastModifiedByNavigations).HasConstraintName("FK_AssetStatus_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetStatuses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetStat__Tenan__2645B050");
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.HasKey(e => e.AssetTypeId).HasName("PK__AssetTyp__FD33C2C22BAAD239");

            entity.Property(e => e.AssetTypeId).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AssetTypeCreatedByNavigations).HasConstraintName("FK_AssetType_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AssetTypeLastModifiedByNavigations).HasConstraintName("FK_AssetType_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AssetTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssetType__Tenan__1DB06A4F");
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__442C64BEFFC11D34");

            entity.Property(e => e.AttachmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AttachmentCreatedByNavigations).HasConstraintName("FK_Attachment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AttachmentLastModifiedByNavigations).HasConstraintName("FK_Attachment_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Attachments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attachmen__Tenan__6BE40491");
        });

        modelBuilder.Entity<AuditEvent>(entity =>
        {
            entity.HasKey(e => e.AuditEventId).HasName("PK__AuditEve__5C3D0E3E60BA38C3");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AuditEventCreatedByNavigations).HasConstraintName("FK_AuditEvent_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AuditEventLastModifiedByNavigations).HasConstraintName("FK_AuditEvent_LastModifiedBy");
        });

        modelBuilder.Entity<Breakdown>(entity =>
        {
            entity.HasKey(e => e.BreakdownId).HasName("PK__Breakdow__B4C97428F5D96165");

            entity.Property(e => e.BreakdownId).ValueGeneratedNever();

            entity.HasOne(d => d.Asset).WithMany(p => p.Breakdowns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Breakdown_Asset");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Breakdowns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Breakdown_TenantId");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.Breakdowns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Breakdown_WorkOrder");
        });

        modelBuilder.Entity<BreakdownApproval>(entity =>
        {
            entity.HasKey(e => e.ApprovalId).HasName("PK__Breakdow__328477F4E9CECDEE");

            entity.Property(e => e.ApprovalId).ValueGeneratedNever();

            entity.HasOne(d => d.ApproverUser).WithMany(p => p.BreakdownApprovalApproverUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BreakdownApproval_ApproverUserId");

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownApprovals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__0662F0A3");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownApprovalCreatedByNavigations).HasConstraintName("FK_BreakdownApproval_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownApprovalLastModifiedByNavigations).HasConstraintName("FK_BreakdownApproval_LastModifiedBy");
        });

        modelBuilder.Entity<BreakdownCause>(entity =>
        {
            entity.HasKey(e => e.BreakdownCauseId).HasName("PK__Breakdow__6BB44541C7EBFB86");

            entity.Property(e => e.BreakdownCauseId).ValueGeneratedNever();

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownCauses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__725BF7F6");

            entity.HasOne(d => d.CauseCode).WithMany(p => p.BreakdownCauses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BreakdownCause_CauseCode");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownCauseCreatedByNavigations).HasConstraintName("FK_BreakdownCause_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownCauseLastModifiedByNavigations).HasConstraintName("FK_BreakdownCause_LastModifiedBy");
        });

        modelBuilder.Entity<BreakdownCorrectiveAction>(entity =>
        {
            entity.HasKey(e => e.CorrectiveActionId).HasName("PK__Breakdow__568C72260A4F8993");

            entity.Property(e => e.CorrectiveActionId).ValueGeneratedNever();

            entity.HasOne(d => d.AssignedToUser).WithMany(p => p.BreakdownCorrectiveActionAssignedToUsers).HasConstraintName("FK_BreakdownCorrectiveAction_AssignedToUserId");

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownCorrectiveActions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__7DCDAAA2");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownCorrectiveActionCreatedByNavigations).HasConstraintName("FK_BreakdownCorrectiveAction_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownCorrectiveActionLastModifiedByNavigations).HasConstraintName("FK_BreakdownCorrectiveAction_LastModifiedBy");
        });

        modelBuilder.Entity<BreakdownEvidence>(entity =>
        {
            entity.HasKey(e => e.EvidenceId).HasName("PK__Breakdow__FA39D7AD9EC1D799");

            entity.Property(e => e.EvidenceId).ValueGeneratedNever();

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownEvidences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__7814D14C");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownEvidenceCreatedByNavigations).HasConstraintName("FK_BreakdownEvidence_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownEvidenceLastModifiedByNavigations).HasConstraintName("FK_BreakdownEvidence_LastModifiedBy");
        });

        modelBuilder.Entity<BreakdownFailure>(entity =>
        {
            entity.HasKey(e => e.BreakdownFailureId).HasName("PK__Breakdow__ACFEFE079A3C7674");

            entity.Property(e => e.BreakdownFailureId).ValueGeneratedNever();

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownFailures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__6E8B6712");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownFailureCreatedByNavigations).HasConstraintName("FK_BreakdownFailure_CreatedBy");

            entity.HasOne(d => d.FailureCode).WithMany(p => p.BreakdownFailures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BreakdownFailure_FailureCode");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownFailureLastModifiedByNavigations).HasConstraintName("FK_BreakdownFailure_LastModifiedBy");
        });

        modelBuilder.Entity<BreakdownInvestigation>(entity =>
        {
            entity.HasKey(e => e.InvestigationId).HasName("PK__Breakdow__83714CF4CCA221D5");

            entity.Property(e => e.InvestigationId).ValueGeneratedNever();

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownInvestigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__753864A1");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownInvestigationCreatedByNavigations).HasConstraintName("FK_BreakdownInvestigation_CreatedBy");

            entity.HasOne(d => d.InvestigatorUser).WithMany(p => p.BreakdownInvestigationInvestigatorUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BreakdownInvestigation_InvestigatorUserId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownInvestigationLastModifiedByNavigations).HasConstraintName("FK_BreakdownInvestigation_LastModifiedBy");
        });

        modelBuilder.Entity<BreakdownPreventiveAction>(entity =>
        {
            entity.HasKey(e => e.PreventiveActionId).HasName("PK__Breakdow__11C1655D10EA5720");

            entity.Property(e => e.PreventiveActionId).ValueGeneratedNever();

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownPreventiveActions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__00AA174D");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownPreventiveActionCreatedByNavigations).HasConstraintName("FK_BreakdownPreventiveAction_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownPreventiveActionLastModifiedByNavigations).HasConstraintName("FK_BreakdownPreventiveAction_LastModifiedBy");

            entity.HasOne(d => d.ResponsibleUser).WithMany(p => p.BreakdownPreventiveActionResponsibleUsers).HasConstraintName("FK_BreakdownPreventiveAction_ResponsibleUserId");
        });

        modelBuilder.Entity<BreakdownVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__Breakdow__306D4907586D89FB");

            entity.Property(e => e.VerificationId).ValueGeneratedNever();

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownVerifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__038683F8");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownVerificationCreatedByNavigations).HasConstraintName("FK_BreakdownVerification_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownVerificationLastModifiedByNavigations).HasConstraintName("FK_BreakdownVerification_LastModifiedBy");

            entity.HasOne(d => d.VerifiedByUser).WithMany(p => p.BreakdownVerificationVerifiedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BreakdownVerification_VerifiedByUserId");
        });

        modelBuilder.Entity<BreakdownWhyAnalysis>(entity =>
        {
            entity.HasKey(e => e.WhyAnalysisId).HasName("PK__Breakdow__0129E85B67990957");

            entity.Property(e => e.WhyAnalysisId).ValueGeneratedNever();

            entity.HasOne(d => d.Breakdown).WithMany(p => p.BreakdownWhyAnalyses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Breakdown__Break__7AF13DF7");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BreakdownWhyAnalysisCreatedByNavigations).HasConstraintName("FK_BreakdownWhyAnalysis_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.BreakdownWhyAnalysisLastModifiedByNavigations).HasConstraintName("FK_BreakdownWhyAnalysis_LastModifiedBy");
        });

        modelBuilder.Entity<CalibrationAsset>(entity =>
        {
            entity.HasKey(e => e.CalibrationAssetId).HasName("PK__Calibrat__7CEBD6EBE5444D47");

            entity.Property(e => e.CalibrationAssetId).ValueGeneratedNever();
            entity.Property(e => e.CalibrationRequired).HasDefaultValue(true);

            entity.HasOne(d => d.Asset).WithMany(p => p.CalibrationAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Asset__39E294A9");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationAssetCreatedByNavigations).HasConstraintName("FK_CalibrationAsset_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationAssetLastModifiedByNavigations).HasConstraintName("FK_CalibrationAsset_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CalibrationAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationAsset_TenantId");
        });

        modelBuilder.Entity<CalibrationCertificate>(entity =>
        {
            entity.HasKey(e => e.CalibrationCertificateId).HasName("PK__Calibrat__48343F3125EA5CC7");

            entity.Property(e => e.CalibrationCertificateId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationExecution).WithMany(p => p.CalibrationCertificates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__5E1FF51F");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationCertificateCreatedByNavigations).HasConstraintName("FK_CalibrationCertificate_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationCertificateLastModifiedByNavigations).HasConstraintName("FK_CalibrationCertificate_LastModifiedBy");
        });

        modelBuilder.Entity<CalibrationComplianceSnapshot>(entity =>
        {
            entity.HasKey(e => e.CalibrationComplianceSnapshotId).HasName("PK__Calibrat__BDC8F68AA44A47DE");

            entity.Property(e => e.CalibrationComplianceSnapshotId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationComplianceSnapshotCreatedByNavigations).HasConstraintName("FK_CalibrationComplianceSnapshot_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationComplianceSnapshotLastModifiedByNavigations).HasConstraintName("FK_CalibrationComplianceSnapshot_LastModifiedBy");

            entity.HasOne(d => d.Plant).WithMany(p => p.CalibrationComplianceSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationComplianceSnapshot_PlantId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CalibrationComplianceSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationComplianceSnapshot_TenantId");
        });

        modelBuilder.Entity<CalibrationEvidence>(entity =>
        {
            entity.HasKey(e => e.CalibrationEvidenceId).HasName("PK__Calibrat__A1BB74BD27136E2E");

            entity.Property(e => e.CalibrationEvidenceId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationExecution).WithMany(p => p.CalibrationEvidences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__58671BC9");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationEvidenceCreatedByNavigations).HasConstraintName("FK_CalibrationEvidence_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationEvidenceLastModifiedByNavigations).HasConstraintName("FK_CalibrationEvidence_LastModifiedBy");
        });

        modelBuilder.Entity<CalibrationExecution>(entity =>
        {
            entity.HasKey(e => e.CalibrationExecutionId).HasName("PK__Calibrat__C5CC1D9F79455CB1");

            entity.Property(e => e.CalibrationExecutionId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationWorkOrder).WithMany(p => p.CalibrationExecutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__4CF5691D");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationExecutionCreatedByNavigations).HasConstraintName("FK_CalibrationExecution_CreatedBy");

            entity.HasOne(d => d.ExecutedByUser).WithMany(p => p.CalibrationExecutionExecutedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationExecution_ExecutedByUserId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationExecutionLastModifiedByNavigations).HasConstraintName("FK_CalibrationExecution_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CalibrationExecutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationExecution_TenantId");
        });

        modelBuilder.Entity<CalibrationMethod>(entity =>
        {
            entity.HasKey(e => e.CalibrationMethodId).HasName("PK__Calibrat__E390C810C4A12806");

            entity.Property(e => e.CalibrationMethodId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationMethodCreatedByNavigations).HasConstraintName("FK_CalibrationMethod_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationMethodLastModifiedByNavigations).HasConstraintName("FK_CalibrationMethod_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CalibrationMethods)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationMethod_TenantId");
        });

        modelBuilder.Entity<CalibrationOotassessment>(entity =>
        {
            entity.HasKey(e => e.OotassessmentId).HasName("PK__Calibrat__D9601BFF8CBBB856");

            entity.Property(e => e.OotassessmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationExecution).WithMany(p => p.CalibrationOotassessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__558AAF1E");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationOotassessmentCreatedByNavigations).HasConstraintName("FK_CalibrationOOTAssessment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationOotassessmentLastModifiedByNavigations).HasConstraintName("FK_CalibrationOOTAssessment_LastModifiedBy");
        });

        modelBuilder.Entity<CalibrationReading>(entity =>
        {
            entity.HasKey(e => e.CalibrationReadingId).HasName("PK__Calibrat__7E431944F4A75891");

            entity.Property(e => e.CalibrationReadingId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationExecution).WithMany(p => p.CalibrationReadings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__4FD1D5C8");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationReadingCreatedByNavigations).HasConstraintName("FK_CalibrationReading_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationReadingLastModifiedByNavigations).HasConstraintName("FK_CalibrationReading_LastModifiedBy");
        });

        modelBuilder.Entity<CalibrationResult>(entity =>
        {
            entity.HasKey(e => e.CalibrationResultId).HasName("PK__Calibrat__D3D4AD0A82856FD6");

            entity.Property(e => e.CalibrationResultId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationExecution).WithMany(p => p.CalibrationResults)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__52AE4273");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationResultCreatedByNavigations).HasConstraintName("FK_CalibrationResult_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationResultLastModifiedByNavigations).HasConstraintName("FK_CalibrationResult_LastModifiedBy");
        });

        modelBuilder.Entity<CalibrationSchedule>(entity =>
        {
            entity.HasKey(e => e.CalibrationScheduleId).HasName("PK__Calibrat__40BA0B1C0F72368C");

            entity.Property(e => e.CalibrationScheduleId).ValueGeneratedNever();
            entity.Property(e => e.AlertDaysBefore).HasDefaultValue(15);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CalibrationAsset).WithMany(p => p.CalibrationSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__45544755");

            entity.HasOne(d => d.CalibrationMethod).WithMany(p => p.CalibrationSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__46486B8E");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationScheduleCreatedByNavigations).HasConstraintName("FK_CalibrationSchedule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationScheduleLastModifiedByNavigations).HasConstraintName("FK_CalibrationSchedule_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CalibrationSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationSchedule_TenantId");
        });

        modelBuilder.Entity<CalibrationSignature>(entity =>
        {
            entity.HasKey(e => e.CalibrationSignatureId).HasName("PK__Calibrat__C3E79A89594EC1E9");

            entity.Property(e => e.CalibrationSignatureId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationExecution).WithMany(p => p.CalibrationSignatures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__5B438874");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationSignatureCreatedByNavigations).HasConstraintName("FK_CalibrationSignature_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationSignatureLastModifiedByNavigations).HasConstraintName("FK_CalibrationSignature_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.CalibrationSignatureUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationSignature_UserId");
        });

        modelBuilder.Entity<CalibrationStandard>(entity =>
        {
            entity.HasKey(e => e.CalibrationStandardId).HasName("PK__Calibrat__74ABA715EE1F3330");

            entity.Property(e => e.CalibrationStandardId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationStandardCreatedByNavigations).HasConstraintName("FK_CalibrationStandard_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationStandardLastModifiedByNavigations).HasConstraintName("FK_CalibrationStandard_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CalibrationStandards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationStandard_TenantId");
        });

        modelBuilder.Entity<CalibrationVersion>(entity =>
        {
            entity.HasKey(e => e.CalibrationVersionId).HasName("PK__Calibrat__5BB912C1722CE43A");

            entity.Property(e => e.CalibrationVersionId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationMethod).WithMany(p => p.CalibrationVersions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__60FC61CA");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationVersionCreatedByNavigations).HasConstraintName("FK_CalibrationVersion_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationVersionLastModifiedByNavigations).HasConstraintName("FK_CalibrationVersion_LastModifiedBy");
        });

        modelBuilder.Entity<CalibrationWorkOrder>(entity =>
        {
            entity.HasKey(e => e.CalibrationWorkOrderId).HasName("PK__Calibrat__67A2608E703E433C");

            entity.Property(e => e.CalibrationWorkOrderId).ValueGeneratedNever();

            entity.HasOne(d => d.CalibrationSchedule).WithMany(p => p.CalibrationWorkOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calibrati__Calib__4924D839");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CalibrationWorkOrderCreatedByNavigations).HasConstraintName("FK_CalibrationWorkOrder_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CalibrationWorkOrderLastModifiedByNavigations).HasConstraintName("FK_CalibrationWorkOrder_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CalibrationWorkOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalibrationWorkOrder_TenantId");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.CalibrationWorkOrders).HasConstraintName("FK__Calibrati__WorkO__4A18FC72");
        });

        modelBuilder.Entity<CauseCode>(entity =>
        {
            entity.Property(e => e.CauseCodeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CauseCodeCreatedByNavigations).HasConstraintName("FK_CauseCode_CreatedBy");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CauseCodeModifiedByNavigations).HasConstraintName("FK_CauseCode_ModifiedBy");
        });

        modelBuilder.Entity<ChecklistExecution>(entity =>
        {
            entity.HasKey(e => e.ChecklistExecutionId).HasName("PK__Checklis__D55D0FF41E27A81D");

            entity.Property(e => e.ChecklistExecutionId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistVersion).WithMany(p => p.ChecklistExecutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__2354350C");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistExecutionCreatedByNavigations).HasConstraintName("FK_ChecklistExecution_CreatedBy");

            entity.HasOne(d => d.ExecutedByUser).WithMany(p => p.ChecklistExecutionExecutedByUsers).HasConstraintName("FK_ChecklistExecution_ExecutedByUserId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistExecutionLastModifiedByNavigations).HasConstraintName("FK_ChecklistExecution_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ChecklistExecutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistExecution_TenantId");
        });

        modelBuilder.Entity<ChecklistExecutionSection>(entity =>
        {
            entity.HasKey(e => e.ChecklistExecutionSectionId).HasName("PK__Checklis__FE91E623E241B045");

            entity.Property(e => e.ChecklistExecutionSectionId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistExecution).WithMany(p => p.ChecklistExecutionSections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__2630A1B7");

            entity.HasOne(d => d.ChecklistSection).WithMany(p => p.ChecklistExecutionSections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__2724C5F0");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistExecutionSectionCreatedByNavigations).HasConstraintName("FK_ChecklistExecutionSection_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistExecutionSectionLastModifiedByNavigations).HasConstraintName("FK_ChecklistExecutionSection_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistQuestion>(entity =>
        {
            entity.HasKey(e => e.ChecklistQuestionId).HasName("PK__Checklis__6815C840ED796F76");

            entity.Property(e => e.ChecklistQuestionId).ValueGeneratedNever();
            entity.Property(e => e.IsMandatory).HasDefaultValue(true);

            entity.HasOne(d => d.ChecklistSection).WithMany(p => p.ChecklistQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__1ABEEF0B");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistQuestionCreatedByNavigations).HasConstraintName("FK_ChecklistQuestion_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistQuestionLastModifiedByNavigations).HasConstraintName("FK_ChecklistQuestion_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistQuestionOption>(entity =>
        {
            entity.HasKey(e => e.ChecklistQuestionOptionId).HasName("PK__Checklis__CA63E480542FA169");

            entity.Property(e => e.ChecklistQuestionOptionId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistQuestion).WithMany(p => p.ChecklistQuestionOptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__1D9B5BB6");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistQuestionOptionCreatedByNavigations).HasConstraintName("FK_ChecklistQuestionOption_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistQuestionOptionLastModifiedByNavigations).HasConstraintName("FK_ChecklistQuestionOption_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistResponse>(entity =>
        {
            entity.HasKey(e => e.ChecklistResponseId).HasName("PK__Checklis__B1E13AE07793AE7E");

            entity.Property(e => e.ChecklistResponseId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistExecution).WithMany(p => p.ChecklistResponses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__2A01329B");

            entity.HasOne(d => d.ChecklistQuestion).WithMany(p => p.ChecklistResponses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__2AF556D4");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistResponseCreatedByNavigations).HasConstraintName("FK_ChecklistResponse_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistResponseLastModifiedByNavigations).HasConstraintName("FK_ChecklistResponse_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistResponseAttachment>(entity =>
        {
            entity.HasKey(e => e.ChecklistResponseAttachmentId).HasName("PK__Checklis__765CEF8CABBA59B3");

            entity.Property(e => e.ChecklistResponseAttachmentId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistResponse).WithMany(p => p.ChecklistResponseAttachments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__2DD1C37F");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistResponseAttachmentCreatedByNavigations).HasConstraintName("FK_ChecklistResponseAttachment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistResponseAttachmentLastModifiedByNavigations).HasConstraintName("FK_ChecklistResponseAttachment_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistRule>(entity =>
        {
            entity.HasKey(e => e.ChecklistRuleId).HasName("PK__Checklis__A4E549E9E3FF7148");

            entity.Property(e => e.ChecklistRuleId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistQuestion).WithMany(p => p.ChecklistRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__2077C861");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistRuleCreatedByNavigations).HasConstraintName("FK_ChecklistRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistRuleLastModifiedByNavigations).HasConstraintName("FK_ChecklistRule_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistScore>(entity =>
        {
            entity.HasKey(e => e.ChecklistScoreId).HasName("PK__Checklis__FA175F5AC130CCB2");

            entity.Property(e => e.ChecklistScoreId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistExecution).WithMany(p => p.ChecklistScores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__338A9CD5");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistScoreCreatedByNavigations).HasConstraintName("FK_ChecklistScore_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistScoreLastModifiedByNavigations).HasConstraintName("FK_ChecklistScore_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistSection>(entity =>
        {
            entity.HasKey(e => e.ChecklistSectionId).HasName("PK__Checklis__A66A08B733105461");

            entity.Property(e => e.ChecklistSectionId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistVersion).WithMany(p => p.ChecklistSections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__150615B5");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistSectionCreatedByNavigations).HasConstraintName("FK_ChecklistSection_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistSectionLastModifiedByNavigations).HasConstraintName("FK_ChecklistSection_LastModifiedBy");
        });

        modelBuilder.Entity<ChecklistSignature>(entity =>
        {
            entity.HasKey(e => e.ChecklistSignatureId).HasName("PK__Checklis__FB6FCDDB1480B2CD");

            entity.Property(e => e.ChecklistSignatureId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistExecution).WithMany(p => p.ChecklistSignatures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__30AE302A");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistSignatureCreatedByNavigations).HasConstraintName("FK_ChecklistSignature_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistSignatureLastModifiedByNavigations).HasConstraintName("FK_ChecklistSignature_LastModifiedBy");

            entity.HasOne(d => d.SignedByUser).WithMany(p => p.ChecklistSignatureSignedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistSignature_SignedByUserId");
        });

        modelBuilder.Entity<ChecklistTemplate>(entity =>
        {
            entity.HasKey(e => e.ChecklistTemplateId).HasName("PK__Checklis__DF9EF6DED3E068B7");

            entity.Property(e => e.ChecklistTemplateId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Tenant).WithMany(p => p.ChecklistTemplates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistTemplate_TenantId");
        });

        modelBuilder.Entity<ChecklistVersion>(entity =>
        {
            entity.HasKey(e => e.ChecklistVersionId).HasName("PK__Checklis__093211EAAF315AAF");

            entity.Property(e => e.ChecklistVersionId).ValueGeneratedNever();
            entity.Property(e => e.IsCurrent).HasDefaultValue(true);

            entity.HasOne(d => d.ChecklistTemplate).WithMany(p => p.ChecklistVersions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__Check__1229A90A");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChecklistVersionCreatedByNavigations).HasConstraintName("FK_ChecklistVersion_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ChecklistVersionLastModifiedByNavigations).HasConstraintName("FK_ChecklistVersion_LastModifiedBy");
        });

        modelBuilder.Entity<ControlMeasure>(entity =>
        {
            entity.Property(e => e.ControlMeasureId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ControlMeasureCreatedByNavigations).HasConstraintName("FK_ControlMeasure_CreatedBy");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ControlMeasureModifiedByNavigations).HasConstraintName("FK_ControlMeasure_ModifiedBy");
        });

        modelBuilder.Entity<CycleCount>(entity =>
        {
            entity.HasKey(e => e.CycleCountId).HasName("PK__CycleCou__A4189B31839E92B8");

            entity.Property(e => e.CycleCountId).ValueGeneratedNever();

            entity.HasOne(d => d.ConductedByUser).WithMany(p => p.CycleCountConductedByUsers).HasConstraintName("FK_CycleCount_ConductedByUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CycleCountCreatedByNavigations).HasConstraintName("FK_CycleCount_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.CycleCountLastModifiedByNavigations).HasConstraintName("FK_CycleCount_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CycleCounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CycleCount_TenantId");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.CycleCounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CycleCount_WarehouseId");
        });

        modelBuilder.Entity<DeadStockAnalysis>(entity =>
        {
            entity.HasKey(e => e.DeadStockAnalysisId).HasName("PK__DeadStoc__390E4912606D07E0");

            entity.Property(e => e.DeadStockAnalysisId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DeadStockAnalysisCreatedByNavigations).HasConstraintName("FK_DeadStockAnalysis_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.DeadStockAnalysisLastModifiedByNavigations).HasConstraintName("FK_DeadStockAnalysis_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.DeadStockAnalyses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeadStockAnalysis_MaterialId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.DeadStockAnalyses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeadStockAnalysis_TenantId");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED8C25E880");

            entity.Property(e => e.DepartmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DepartmentCreatedByNavigations).HasConstraintName("FK_Department_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.DepartmentLastModifiedByNavigations).HasConstraintName("FK_Department_LastModifiedBy");

            entity.HasOne(d => d.Plant).WithMany(p => p.Departments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departmen__Plant__08B54D69");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Departments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departmen__Tenan__07C12930");
        });

        modelBuilder.Entity<ElectronicSignature>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureId).HasName("PK__Electron__39CDA5F8B45ABCF9");

            entity.Property(e => e.ElectronicSignatureId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureCreatedByNavigations).HasConstraintName("FK_ElectronicSignature_CreatedBy");

            entity.HasOne(d => d.ElectronicSignatureRequest).WithMany(p => p.ElectronicSignatures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__41D8BC2C");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignature_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.ElectronicSignatureUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElectronicSignature_UserId");
        });

        modelBuilder.Entity<ElectronicSignature1>(entity =>
        {
            entity.HasKey(e => e.SignatureId).HasName("PK__Electron__3DCA57A90297DA8D");

            entity.Property(e => e.SignatureId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignature1CreatedByNavigations).HasConstraintName("FK_ElectronicSignature_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignature1LastModifiedByNavigations).HasConstraintName("FK_ElectronicSignature_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.ElectronicSignature1Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__UserI__0C50D423");
        });

        modelBuilder.Entity<ElectronicSignatureAttachment>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureAttachmentId).HasName("PK__Electron__1E57FA80C2097C99");

            entity.Property(e => e.ElectronicSignatureAttachmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureAttachmentCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureAttachment_CreatedBy");

            entity.HasOne(d => d.ElectronicSignature).WithMany(p => p.ElectronicSignatureAttachments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__4B622666");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureAttachmentLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureAttachment_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignatureAudit>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureAuditId).HasName("PK__Electron__36C940B1E4CA7ACD");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureAuditCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureAudit_CreatedBy");

            entity.HasOne(d => d.ElectronicSignature).WithMany(p => p.ElectronicSignatureAudits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__4E3E9311");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureAuditLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureAudit_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignatureChallenge>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureChallengeId).HasName("PK__Electron__01EA8A3553A25767");

            entity.Property(e => e.ElectronicSignatureChallengeId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureChallengeCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureChallenge_CreatedBy");

            entity.HasOne(d => d.ElectronicSignatureRequest).WithMany(p => p.ElectronicSignatureChallenges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__4885B9BB");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureChallengeLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureChallenge_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignatureMeaning>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureMeaningId).HasName("PK__Electron__4C7C85381F38F840");

            entity.Property(e => e.ElectronicSignatureMeaningId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureMeaningCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureMeaning_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureMeaningLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureMeaning_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignaturePolicy>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignaturePolicyId).HasName("PK__Electron__BCB22A82BAE62C5F");

            entity.Property(e => e.ElectronicSignaturePolicyId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RequirePassword).HasDefaultValue(true);
            entity.Property(e => e.RequireReason).HasDefaultValue(true);

            entity.HasOne(d => d.Tenant).WithMany(p => p.ElectronicSignaturePolicies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElectronicSignaturePolicy_TenantId");
        });

        modelBuilder.Entity<ElectronicSignaturePurpose>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignaturePurposeId).HasName("PK__Electron__FE2F6A18CE6FF66F");

            entity.Property(e => e.ElectronicSignaturePurposeId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignaturePurposeCreatedByNavigations).HasConstraintName("FK_ElectronicSignaturePurpose_CreatedBy");

            entity.HasOne(d => d.ElectronicSignaturePolicy).WithMany(p => p.ElectronicSignaturePurposes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__3D14070F");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignaturePurposeLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignaturePurpose_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignatureRequest>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureRequestId).HasName("PK__Electron__DFDB1D8D8B1EA383");

            entity.Property(e => e.ElectronicSignatureRequestId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureRequestCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureRequest_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureRequestLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureRequest_LastModifiedBy");

            entity.HasOne(d => d.RequestedByUser).WithMany(p => p.ElectronicSignatureRequestRequestedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElectronicSignatureRequest_RequestedByUserId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ElectronicSignatureRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElectronicSignatureRequest_TenantId");
        });

        modelBuilder.Entity<ElectronicSignatureRole>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureRoleId).HasName("PK__Electron__7CBFD3FA18803225");

            entity.Property(e => e.ElectronicSignatureRoleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureRoleCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureRole_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureRoleLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureRole_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignatureRoleAssignment>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureRoleAssignmentId).HasName("PK__Electron__51A59CF1ECE5B125");

            entity.Property(e => e.ElectronicSignatureRoleAssignmentId).ValueGeneratedNever();
            entity.Property(e => e.IsMandatory).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureRoleAssignmentCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureRoleAssignment_CreatedBy");

            entity.HasOne(d => d.ElectronicSignaturePurpose).WithMany(p => p.ElectronicSignatureRoleAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__55DFB4D9");

            entity.HasOne(d => d.ElectronicSignatureRole).WithMany(p => p.ElectronicSignatureRoleAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__56D3D912");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureRoleAssignmentLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureRoleAssignment_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignatureSequence>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureSequenceId).HasName("PK__Electron__FBF6707DA2676C2B");

            entity.Property(e => e.ElectronicSignatureSequenceId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureSequenceCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureSequence_CreatedBy");

            entity.HasOne(d => d.ElectronicSignaturePurpose).WithMany(p => p.ElectronicSignatureSequences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__59B045BD");

            entity.HasOne(d => d.ElectronicSignatureRole).WithMany(p => p.ElectronicSignatureSequences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__5AA469F6");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureSequenceLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureSequence_LastModifiedBy");
        });

        modelBuilder.Entity<ElectronicSignatureVerification>(entity =>
        {
            entity.HasKey(e => e.ElectronicSignatureVerificationId).HasName("PK__Electron__9445752B01BE7274");

            entity.Property(e => e.ElectronicSignatureVerificationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectronicSignatureVerificationCreatedByNavigations).HasConstraintName("FK_ElectronicSignatureVerification_CreatedBy");

            entity.HasOne(d => d.ElectronicSignature).WithMany(p => p.ElectronicSignatureVerifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Electroni__Elect__44B528D7");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ElectronicSignatureVerificationLastModifiedByNavigations).HasConstraintName("FK_ElectronicSignatureVerification_LastModifiedBy");
        });

        modelBuilder.Entity<EventBatch>(entity =>
        {
            entity.HasKey(e => e.EventBatchId).HasName("PK__EventBat__FC99D3681D15532D");

            entity.Property(e => e.EventBatchId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventBatchCreatedByNavigations).HasConstraintName("FK_EventBatch_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventBatchLastModifiedByNavigations).HasConstraintName("FK_EventBatch_LastModifiedBy");
        });

        modelBuilder.Entity<EventConsumerOffset>(entity =>
        {
            entity.HasKey(e => e.EventConsumerOffsetId).HasName("PK__EventCon__04DC0E464E5DB6DE");

            entity.Property(e => e.EventConsumerOffsetId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventConsumerOffsetCreatedByNavigations).HasConstraintName("FK_EventConsumerOffset_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventConsumerOffsetLastModifiedByNavigations).HasConstraintName("FK_EventConsumerOffset_LastModifiedBy");
        });

        modelBuilder.Entity<EventDeadLetter>(entity =>
        {
            entity.HasKey(e => e.EventDeadLetterId).HasName("PK__EventDea__373B2A52A3C9B8AA");

            entity.Property(e => e.EventDeadLetterId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventDeadLetterCreatedByNavigations).HasConstraintName("FK_EventDeadLetter_CreatedBy");

            entity.HasOne(d => d.EventOutbox).WithMany(p => p.EventDeadLetters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventDead__Event__6DB73E6A");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventDeadLetterLastModifiedByNavigations).HasConstraintName("FK_EventDeadLetter_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.EventDeadLetters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventDeadLetter_TenantId");
        });

        modelBuilder.Entity<EventInbox>(entity =>
        {
            entity.HasKey(e => e.EventInboxId).HasName("PK__EventInb__5C2BA0098375CBF5");

            entity.Property(e => e.EventInboxId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventInboxCreatedByNavigations).HasConstraintName("FK_EventInbox_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventInboxLastModifiedByNavigations).HasConstraintName("FK_EventInbox_LastModifiedBy");
        });

        modelBuilder.Entity<EventOutbox>(entity =>
        {
            entity.HasKey(e => e.EventOutboxId).HasName("PK__EventOut__CF1CBBA92B76BB7B");

            entity.Property(e => e.EventOutboxId).ValueGeneratedNever();
            entity.Property(e => e.EventVersion).HasDefaultValue(1);

            entity.HasOne(d => d.EventType).WithMany(p => p.EventOutboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventOutb__Event__62458BBE");

            entity.HasOne(d => d.Tenant).WithMany(p => p.EventOutboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventOutbox_TenantId");
        });

        modelBuilder.Entity<EventPublicationLog>(entity =>
        {
            entity.HasKey(e => e.EventPublicationLogId).HasName("PK__EventPub__C98986BDBCAFA628");

            entity.Property(e => e.EventPublicationLogId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventPublicationLogCreatedByNavigations).HasConstraintName("FK_EventPublicationLog_CreatedBy");

            entity.HasOne(d => d.EventOutbox).WithMany(p => p.EventPublicationLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventPubl__Event__6521F869");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventPublicationLogLastModifiedByNavigations).HasConstraintName("FK_EventPublicationLog_LastModifiedBy");
        });

        modelBuilder.Entity<EventReplayRequest>(entity =>
        {
            entity.HasKey(e => e.EventReplayRequestId).HasName("PK__EventRep__5B9791FA9A0472A5");

            entity.Property(e => e.EventReplayRequestId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventReplayRequestCreatedByNavigations).HasConstraintName("FK_EventReplayRequest_CreatedBy");

            entity.HasOne(d => d.EventOutbox).WithMany(p => p.EventReplayRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventRepl__Event__7093AB15");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventReplayRequestLastModifiedByNavigations).HasConstraintName("FK_EventReplayRequest_LastModifiedBy");

            entity.HasOne(d => d.RequestedByUser).WithMany(p => p.EventReplayRequestRequestedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventReplayRequest_RequestedByUserId");
        });

        modelBuilder.Entity<EventSchema>(entity =>
        {
            entity.HasKey(e => e.EventSchemaId).HasName("PK__EventSch__B72325AF79D29222");

            entity.Property(e => e.EventSchemaId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventSchemaCreatedByNavigations).HasConstraintName("FK_EventSchema_CreatedBy");

            entity.HasOne(d => d.EventType).WithMany(p => p.EventSchemas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventSche__Event__75586032");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventSchemaLastModifiedByNavigations).HasConstraintName("FK_EventSchema_LastModifiedBy");
        });

        modelBuilder.Entity<EventSubscription>(entity =>
        {
            entity.HasKey(e => e.EventSubscriptionId).HasName("PK__EventSub__194047879837E481");

            entity.Property(e => e.EventSubscriptionId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventSubscriptionCreatedByNavigations).HasConstraintName("FK_EventSubscription_CreatedBy");

            entity.HasOne(d => d.EventType).WithMany(p => p.EventSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventSubs__Event__68F2894D");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventSubscriptionLastModifiedByNavigations).HasConstraintName("FK_EventSubscription_LastModifiedBy");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__EventTyp__A9216B3FD0641D96");

            entity.Property(e => e.EventTypeId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventTypeCreatedByNavigations).HasConstraintName("FK_EventType_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventTypeLastModifiedByNavigations).HasConstraintName("FK_EventType_LastModifiedBy");
        });

        modelBuilder.Entity<FailureCode>(entity =>
        {
            entity.Property(e => e.FailureCodeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.FailureCodeCreatedByNavigations).HasConstraintName("FK_FailureCode_CreatedBy");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.FailureCodeModifiedByNavigations).HasConstraintName("FK_FailureCode_ModifiedBy");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.FeatureId).HasName("PK__Feature__82230BC95C6247FB");

            entity.Property(e => e.FeatureId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.FeatureCreatedByNavigations).HasConstraintName("FK_Feature_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.FeatureLastModifiedByNavigations).HasConstraintName("FK_Feature_LastModifiedBy");
        });

        modelBuilder.Entity<GoodsReceiptNote>(entity =>
        {
            entity.HasKey(e => e.Grnid).HasName("PK__GoodsRec__BC0E8C4216BD00F8");

            entity.Property(e => e.Grnid).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.GoodsReceiptNoteCreatedByNavigations).HasConstraintName("FK_GoodsReceiptNote_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.GoodsReceiptNoteLastModifiedByNavigations).HasConstraintName("FK_GoodsReceiptNote_LastModifiedBy");

            entity.HasOne(d => d.Receipt).WithMany(p => p.GoodsReceiptNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GoodsRece__Recei__5B0E7E4A");

            entity.HasOne(d => d.Tenant).WithMany(p => p.GoodsReceiptNotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GoodsReceiptNote_TenantId");
        });

        modelBuilder.Entity<HazardMaster>(entity =>
        {
            entity.Property(e => e.HazardId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<IntegrationBatch>(entity =>
        {
            entity.HasKey(e => e.IntegrationBatchId).HasName("PK__Integrat__E7A9B752C51784F0");

            entity.Property(e => e.IntegrationBatchId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationBatchCreatedByNavigations).HasConstraintName("FK_IntegrationBatch_CreatedBy");

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationBatches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__515009E6");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationBatchLastModifiedByNavigations).HasConstraintName("FK_IntegrationBatch_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationConfiguration>(entity =>
        {
            entity.HasKey(e => e.IntegrationConfigurationId).HasName("PK__Integrat__C99234BD43085403");

            entity.Property(e => e.IntegrationConfigurationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationConfigurationCreatedByNavigations).HasConstraintName("FK_IntegrationConfiguration_CreatedBy");

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationConfigurations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__33BFA6FF");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationConfigurationLastModifiedByNavigations).HasConstraintName("FK_IntegrationConfiguration_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationCredential>(entity =>
        {
            entity.HasKey(e => e.IntegrationCredentialId).HasName("PK__Integrat__B033DEC25BA371E1");

            entity.Property(e => e.IntegrationCredentialId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationCredentialCreatedByNavigations).HasConstraintName("FK_IntegrationCredential_CreatedBy");

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationCredentials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__30E33A54");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationCredentialLastModifiedByNavigations).HasConstraintName("FK_IntegrationCredential_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationDeadLetter>(entity =>
        {
            entity.HasKey(e => e.DeadLetterId).HasName("PK__Integrat__91C7CFBFA711798A");

            entity.Property(e => e.DeadLetterId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationDeadLetterCreatedByNavigations).HasConstraintName("FK_IntegrationDeadLetter_CreatedBy");

            entity.HasOne(d => d.IntegrationMessage).WithMany(p => p.IntegrationDeadLetters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__43F60EC8");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationDeadLetterLastModifiedByNavigations).HasConstraintName("FK_IntegrationDeadLetter_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationEndpoint>(entity =>
        {
            entity.HasKey(e => e.IntegrationEndpointId).HasName("PK__Integrat__60840C834A044EE1");

            entity.Property(e => e.IntegrationEndpointId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationEndpointCreatedByNavigations).HasConstraintName("FK_IntegrationEndpoint_CreatedBy");

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationEndpoints)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__2E06CDA9");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationEndpointLastModifiedByNavigations).HasConstraintName("FK_IntegrationEndpoint_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationEvent>(entity =>
        {
            entity.HasKey(e => e.IntegrationEventId).HasName("PK__Integrat__9965005117303B81");

            entity.Property(e => e.IntegrationEventId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationEventCreatedByNavigations).HasConstraintName("FK_IntegrationEvent_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationEventLastModifiedByNavigations).HasConstraintName("FK_IntegrationEvent_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationInbox>(entity =>
        {
            entity.HasKey(e => e.InboxId).HasName("PK__Integrat__61A99C6CE25685B2");

            entity.Property(e => e.InboxId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationInboxCreatedByNavigations).HasConstraintName("FK_IntegrationInbox_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationInboxLastModifiedByNavigations).HasConstraintName("FK_IntegrationInbox_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.IntegrationInboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IntegrationInbox_TenantId");
        });

        modelBuilder.Entity<IntegrationMapping>(entity =>
        {
            entity.HasKey(e => e.IntegrationMappingId).HasName("PK__Integrat__0C56D120EF02618E");

            entity.Property(e => e.IntegrationMappingId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationMappingCreatedByNavigations).HasConstraintName("FK_IntegrationMapping_CreatedBy");

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__542C7691");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationMappingLastModifiedByNavigations).HasConstraintName("FK_IntegrationMapping_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationMessage>(entity =>
        {
            entity.HasKey(e => e.IntegrationMessageId).HasName("PK__Integrat__D8E17C183BB7A5D7");

            entity.Property(e => e.IntegrationMessageId).ValueGeneratedNever();

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__3E3D3572");

            entity.HasOne(d => d.Tenant).WithMany(p => p.IntegrationMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IntegrationMessage_TenantId");
        });

        modelBuilder.Entity<IntegrationOutbox>(entity =>
        {
            entity.HasKey(e => e.OutboxId).HasName("PK__Integrat__0903AF48BA76962D");

            entity.Property(e => e.OutboxId).ValueGeneratedNever();

            entity.HasOne(d => d.IntegrationEvent).WithMany(p => p.IntegrationOutboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__39788055");

            entity.HasOne(d => d.Tenant).WithMany(p => p.IntegrationOutboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IntegrationOutbox_TenantId");
        });

        modelBuilder.Entity<IntegrationRetry>(entity =>
        {
            entity.HasKey(e => e.IntegrationRetryId).HasName("PK__Integrat__EBDD6EAA5A440C86");

            entity.Property(e => e.IntegrationRetryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationRetryCreatedByNavigations).HasConstraintName("FK_IntegrationRetry_CreatedBy");

            entity.HasOne(d => d.IntegrationMessage).WithMany(p => p.IntegrationRetries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__4119A21D");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationRetryLastModifiedByNavigations).HasConstraintName("FK_IntegrationRetry_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationSchedule>(entity =>
        {
            entity.HasKey(e => e.IntegrationScheduleId).HasName("PK__Integrat__28ED9FDBA1ACBC00");

            entity.Property(e => e.IntegrationScheduleId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationScheduleCreatedByNavigations).HasConstraintName("FK_IntegrationSchedule_CreatedBy");

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__57FD0775");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationScheduleLastModifiedByNavigations).HasConstraintName("FK_IntegrationSchedule_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationSubscription>(entity =>
        {
            entity.HasKey(e => e.IntegrationSubscriptionId).HasName("PK__Integrat__1333657820A48933");

            entity.Property(e => e.IntegrationSubscriptionId).ValueGeneratedNever();
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationSubscriptionCreatedByNavigations).HasConstraintName("FK_IntegrationSubscription_CreatedBy");

            entity.HasOne(d => d.IntegrationEvent).WithMany(p => p.IntegrationSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__48BAC3E5");

            entity.HasOne(d => d.IntegrationSystem).WithMany(p => p.IntegrationSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Integrati__Integ__47C69FAC");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationSubscriptionLastModifiedByNavigations).HasConstraintName("FK_IntegrationSubscription_LastModifiedBy");
        });

        modelBuilder.Entity<IntegrationSystem>(entity =>
        {
            entity.HasKey(e => e.IntegrationSystemId).HasName("PK__Integrat__B2F592DC2F9F43DC");

            entity.Property(e => e.IntegrationSystemId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.IntegrationSystemCreatedByNavigations).HasConstraintName("FK_IntegrationSystem_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.IntegrationSystemLastModifiedByNavigations).HasConstraintName("FK_IntegrationSystem_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.IntegrationSystems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IntegrationSystem_TenantId");
        });

        modelBuilder.Entity<InventoryAdjustment>(entity =>
        {
            entity.HasKey(e => e.InventoryAdjustmentId).HasName("PK__Inventor__E7407FFCA98A84DE");

            entity.Property(e => e.InventoryAdjustmentId).ValueGeneratedNever();

            entity.HasOne(d => d.ApprovedByUser).WithMany(p => p.InventoryAdjustmentApprovedByUsers).HasConstraintName("FK_InventoryAdjustment_ApprovedByUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryAdjustmentCreatedByNavigations).HasConstraintName("FK_InventoryAdjustment_CreatedBy");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.InventoryAdjustments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryAdjustment_InventoryTransactionId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryAdjustmentLastModifiedByNavigations).HasConstraintName("FK_InventoryAdjustment_LastModifiedBy");
        });

        modelBuilder.Entity<InventoryBalance>(entity =>
        {
            entity.HasKey(e => e.InventoryBalanceId).HasName("PK__Inventor__FBB792AE42E76FDA");

            entity.Property(e => e.InventoryBalanceId).ValueGeneratedNever();
            entity.Property(e => e.AvailableQty).HasComputedColumnSql("([OnHandQty]-[ReservedQty])", false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryBalanceCreatedByNavigations).HasConstraintName("FK_InventoryBalance_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryBalanceLastModifiedByNavigations).HasConstraintName("FK_InventoryBalance_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryBalances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryBalance_MaterialId");

            entity.HasOne(d => d.StorageLocation).WithMany(p => p.InventoryBalances).HasConstraintName("FK_InventoryBalance_StorageLocationId");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryBalances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryBalance_WarehouseId");
        });

        modelBuilder.Entity<InventoryConsumption>(entity =>
        {
            entity.HasKey(e => e.InventoryConsumptionId).HasName("PK__Inventor__42BBBCDBC0EEE7C0");

            entity.Property(e => e.InventoryConsumptionId).ValueGeneratedNever();

            entity.HasOne(d => d.ConsumedByUser).WithMany(p => p.InventoryConsumptionConsumedByUsers).HasConstraintName("FK_InventoryConsumption_ConsumedByUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryConsumptionCreatedByNavigations).HasConstraintName("FK_InventoryConsumption_CreatedBy");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.InventoryConsumptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryConsumption_InventoryTransactionId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryConsumptionLastModifiedByNavigations).HasConstraintName("FK_InventoryConsumption_LastModifiedBy");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.InventoryConsumptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryConsumption_WorkOrderId");
        });

        modelBuilder.Entity<InventoryCycleCountLine>(entity =>
        {
            entity.HasKey(e => e.InventoryCycleCountLineId).HasName("PK__Inventor__50DA4D29DB0801C8");

            entity.Property(e => e.InventoryCycleCountLineId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryCycleCountLineCreatedByNavigations).HasConstraintName("FK_InventoryCycleCountLine_CreatedBy");

            entity.HasOne(d => d.CycleCount).WithMany(p => p.InventoryCycleCountLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Cycle__73DA2C14");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryCycleCountLineLastModifiedByNavigations).HasConstraintName("FK_InventoryCycleCountLine_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryCycleCountLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Mater__74CE504D");
        });

        modelBuilder.Entity<InventoryForecast>(entity =>
        {
            entity.HasKey(e => e.InventoryForecastId).HasName("PK__Inventor__06202669CF391127");

            entity.Property(e => e.InventoryForecastId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryForecastCreatedByNavigations).HasConstraintName("FK_InventoryForecast_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryForecastLastModifiedByNavigations).HasConstraintName("FK_InventoryForecast_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryForecasts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Mater__61BB7BD9");

            entity.HasOne(d => d.Tenant).WithMany(p => p.InventoryForecasts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryForecast_TenantId");
        });

        modelBuilder.Entity<InventoryIntegrationLog>(entity =>
        {
            entity.HasKey(e => e.InventoryIntegrationLogId).HasName("PK__Inventor__1AD76B17D4518AF5");

            entity.Property(e => e.InventoryIntegrationLogId).ValueGeneratedNever();

            entity.HasOne(d => d.Tenant).WithMany(p => p.InventoryIntegrationLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryIntegrationLog_TenantId");

            entity.HasOne(d => d.Transaction).WithMany(p => p.InventoryIntegrationLogs).HasConstraintName("FK_InventoryIntegrationLog_TransactionId");
        });

        modelBuilder.Entity<InventoryIssue>(entity =>
        {
            entity.HasKey(e => e.InventoryIssueId).HasName("PK__Inventor__E85C9F41BB27F293");

            entity.Property(e => e.InventoryIssueId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryIssueCreatedByNavigations).HasConstraintName("FK_InventoryIssue_CreatedBy");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.InventoryIssues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryIssue_InventoryTransactionId");

            entity.HasOne(d => d.IssuedToUser).WithMany(p => p.InventoryIssueIssuedToUsers).HasConstraintName("FK_InventoryIssue_IssuedToUserId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryIssueLastModifiedByNavigations).HasConstraintName("FK_InventoryIssue_LastModifiedBy");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.InventoryIssues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryIssue_WorkOrderId");
        });

        modelBuilder.Entity<InventoryLot>(entity =>
        {
            entity.HasKey(e => e.InventoryLotId).HasName("PK__Inventor__9B63ED44C00D4724");

            entity.Property(e => e.InventoryLotId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryLotCreatedByNavigations).HasConstraintName("FK_InventoryLot_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryLotLastModifiedByNavigations).HasConstraintName("FK_InventoryLot_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryLots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryLot_MaterialId");
        });

        modelBuilder.Entity<InventoryReceipt>(entity =>
        {
            entity.HasKey(e => e.InventoryReceiptId).HasName("PK__Inventor__4B45C4C362AA0FE8");

            entity.Property(e => e.InventoryReceiptId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryReceiptCreatedByNavigations).HasConstraintName("FK_InventoryReceipt_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryReceiptLastModifiedByNavigations).HasConstraintName("FK_InventoryReceipt_LastModifiedBy");

            entity.HasOne(d => d.ReceivedByUser).WithMany(p => p.InventoryReceiptReceivedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryReceipt_ReceivedByUserId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.InventoryReceipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryReceipt_TenantId");

            entity.HasOne(d => d.Vendor).WithMany(p => p.InventoryReceipts).HasConstraintName("FK_InventoryReceipt_Vendor");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryReceipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Wareh__4EA8A765");
        });

        modelBuilder.Entity<InventoryReceiptItem>(entity =>
        {
            entity.HasKey(e => e.InventoryReceiptItemId).HasName("PK__Inventor__C519223093D70B8D");

            entity.Property(e => e.InventoryReceiptItemId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryReceiptItemCreatedByNavigations).HasConstraintName("FK_InventoryReceiptItem_CreatedBy");

            entity.HasOne(d => d.InventoryReceipt).WithMany(p => p.InventoryReceiptItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Inven__51851410");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryReceiptItemLastModifiedByNavigations).HasConstraintName("FK_InventoryReceiptItem_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryReceiptItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Mater__52793849");
        });

        modelBuilder.Entity<InventoryReservation>(entity =>
        {
            entity.HasKey(e => e.InventoryReservationId).HasName("PK__Inventor__0EF888982FF131DA");

            entity.Property(e => e.InventoryReservationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryReservationCreatedByNavigations).HasConstraintName("FK_InventoryReservation_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryReservationLastModifiedByNavigations).HasConstraintName("FK_InventoryReservation_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryReservations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryReservation_MaterialId");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.InventoryReservations).HasConstraintName("FK_InventoryReservation_WorkOrderId");
        });

        modelBuilder.Entity<InventoryReturn>(entity =>
        {
            entity.HasKey(e => e.InventoryReturnId).HasName("PK__Inventor__A7534F1BB56AB04B");

            entity.Property(e => e.InventoryReturnId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryReturnCreatedByNavigations).HasConstraintName("FK_InventoryReturn_CreatedBy");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.InventoryReturns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryReturn_InventoryTransactionId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryReturnLastModifiedByNavigations).HasConstraintName("FK_InventoryReturn_LastModifiedBy");
        });

        modelBuilder.Entity<InventorySerial>(entity =>
        {
            entity.HasKey(e => e.InventorySerialId).HasName("PK__Inventor__DD64B38C7079FE67");

            entity.Property(e => e.InventorySerialId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventorySerialCreatedByNavigations).HasConstraintName("FK_InventorySerial_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventorySerialLastModifiedByNavigations).HasConstraintName("FK_InventorySerial_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventorySerials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventorySerial_MaterialId");
        });

        modelBuilder.Entity<InventoryStockAgeing>(entity =>
        {
            entity.HasKey(e => e.InventoryStockAgeingId).HasName("PK__Inventor__CF9DF5FF0D9CE6F2");

            entity.Property(e => e.InventoryStockAgeingId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryStockAgeingCreatedByNavigations).HasConstraintName("FK_InventoryStockAgeing_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryStockAgeingLastModifiedByNavigations).HasConstraintName("FK_InventoryStockAgeing_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryStockAgeings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryStockAgeing_MaterialId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.InventoryStockAgeings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryStockAgeing_TenantId");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryStockAgeings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryStockAgeing_WarehouseId");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.InventoryTransactionId).HasName("PK__Inventor__0863F808DF916148");

            entity.Property(e => e.InventoryTransactionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryTransactionCreatedByNavigations).HasConstraintName("FK_InventoryTransaction_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryTransactionLastModifiedByNavigations).HasConstraintName("FK_InventoryTransaction_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTransaction_MaterialId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.InventoryTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTransaction_TenantId");
        });

        modelBuilder.Entity<InventoryTransactionOutbox>(entity =>
        {
            entity.HasKey(e => e.OutboxId).HasName("PK__Inventor__0903AF482AD42C11");

            entity.Property(e => e.OutboxId).ValueGeneratedNever();

            entity.HasOne(d => d.Tenant).WithMany(p => p.InventoryTransactionOutboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTransactionOutbox_TenantId");

            entity.HasOne(d => d.Transaction).WithMany(p => p.InventoryTransactionOutboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTransactionOutbox_TransactionId");
        });

        modelBuilder.Entity<InventoryTransfer>(entity =>
        {
            entity.HasKey(e => e.InventoryTransferId).HasName("PK__Inventor__3E82BD9FF7FC2B73");

            entity.Property(e => e.InventoryTransferId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryTransferCreatedByNavigations).HasConstraintName("FK_InventoryTransfer_CreatedBy");

            entity.HasOne(d => d.DestinationWarehouse).WithMany(p => p.InventoryTransferDestinationWarehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTransfer_DestinationWarehouseId");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.InventoryTransfers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTransfer_InventoryTransactionId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryTransferLastModifiedByNavigations).HasConstraintName("FK_InventoryTransfer_LastModifiedBy");

            entity.HasOne(d => d.SourceWarehouse).WithMany(p => p.InventoryTransferSourceWarehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTransfer_SourceWarehouseId");
        });

        modelBuilder.Entity<InventoryValuationSnapshot>(entity =>
        {
            entity.HasKey(e => e.InventoryValuationSnapshotId).HasName("PK__Inventor__B58C696F70989DA3");

            entity.Property(e => e.InventoryValuationSnapshotId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryValuationSnapshotCreatedByNavigations).HasConstraintName("FK_InventoryValuationSnapshot_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InventoryValuationSnapshotLastModifiedByNavigations).HasConstraintName("FK_InventoryValuationSnapshot_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.InventoryValuationSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryValuationSnapshot_MaterialId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.InventoryValuationSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryValuationSnapshot_TenantId");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryValuationSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryValuationSnapshot_WarehouseId");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855AB752145AB");

            entity.Property(e => e.LanguageId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LanguageCreatedByNavigations).HasConstraintName("FK_Language_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.LanguageLastModifiedByNavigations).HasConstraintName("FK_Language_LastModifiedBy");
        });

        modelBuilder.Entity<Localization>(entity =>
        {
            entity.HasKey(e => e.LocalizationId).HasName("PK__Localiza__F4D37ED8F17C2753");

            entity.Property(e => e.LocalizationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LocalizationCreatedByNavigations).HasConstraintName("FK_Localization_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.LocalizationLastModifiedByNavigations).HasConstraintName("FK_Localization_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Localizations).HasConstraintName("FK_Localization_TenantId");
        });

        modelBuilder.Entity<LoginHistory>(entity =>
        {
            entity.HasKey(e => e.LoginHistoryId).HasName("PK__LoginHis__2773EA9F06F6F954");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LoginHistoryCreatedByNavigations).HasConstraintName("FK_LoginHistory_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.LoginHistoryLastModifiedByNavigations).HasConstraintName("FK_LoginHistory_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.LoginHistoryUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoginHist__UserI__7B264821");
        });

        modelBuilder.Entity<LookupBase>(entity =>
        {
            entity.HasKey(e => e.LookupId).HasName("PK__LookupBa__6D8B9C4B43FC7A4F");

            entity.Property(e => e.LookupId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LookupBaseCreatedByNavigations).HasConstraintName("FK_LookupBase_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.LookupBaseLastModifiedByNavigations).HasConstraintName("FK_LookupBase_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.LookupBases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LookupBase_TenantId");
        });

        modelBuilder.Entity<MaintenanceGroup>(entity =>
        {
            entity.Property(e => e.MaintenanceGroupId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MaintenanceGroupCreatedByNavigations).HasConstraintName("FK_MaintenanceGroup_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MaintenanceGroupLastModifiedByNavigations).HasConstraintName("FK_MaintenanceGroup_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.MaintenanceGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaintenanceGroup_Tenant");
        });

        modelBuilder.Entity<MaintenanceRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Maintena__33A8517A698C2712");

            entity.Property(e => e.RequestId).ValueGeneratedNever();

            entity.HasOne(d => d.Asset).WithMany(p => p.MaintenanceRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Maintenan__Asset__3F115E1A");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MaintenanceRequestCreatedByNavigations).HasConstraintName("FK_MaintenanceRequest_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MaintenanceRequestLastModifiedByNavigations).HasConstraintName("FK_MaintenanceRequest_LastModifiedBy");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.MaintenanceRequestRequestedByNavigations).HasConstraintName("FK__Maintenan__Reque__40058253");

            entity.HasOne(d => d.Tenant).WithMany(p => p.MaintenanceRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Maintenan__Tenan__3E1D39E1");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Material__C50610F7191F5EA9");

            entity.Property(e => e.MaterialId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MaterialCreatedByNavigations).HasConstraintName("FK_Material_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MaterialLastModifiedByNavigations).HasConstraintName("FK_Material_LastModifiedBy");

            entity.HasOne(d => d.MaterialCategory).WithMany(p => p.Materials).HasConstraintName("FK_Material_MaterialCategory");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Materials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Material_TenantId");

            entity.HasOne(d => d.Uom).WithMany(p => p.Materials).HasConstraintName("FK_Material_UOM");
        });

        modelBuilder.Entity<MaterialAlternate>(entity =>
        {
            entity.HasKey(e => e.MaterialAlternateId).HasName("PK__Material__9F08B2AB05C872DA");

            entity.Property(e => e.MaterialAlternateId).ValueGeneratedNever();

            entity.HasOne(d => d.AlternateMaterial).WithMany(p => p.MaterialAlternateAlternateMaterials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialAlternate_AlternateMaterialId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MaterialAlternateCreatedByNavigations).HasConstraintName("FK_MaterialAlternate_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MaterialAlternateLastModifiedByNavigations).HasConstraintName("FK_MaterialAlternate_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialAlternateMaterials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialAlternate_MaterialId");
        });

        modelBuilder.Entity<MaterialCategory>(entity =>
        {
            entity.Property(e => e.MaterialCategoryId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsInventory).HasDefaultValue(true);

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory).HasConstraintName("FK_MaterialCategory_Parent");
        });

        modelBuilder.Entity<MaterialCostLedger>(entity =>
        {
            entity.HasKey(e => e.MaterialCostLedgerId).HasName("PK__Material__ACDAE753CE0BD81A");

            entity.Property(e => e.MaterialCostLedgerId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MaterialCostLedgerCreatedByNavigations).HasConstraintName("FK_MaterialCostLedger_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MaterialCostLedgerLastModifiedByNavigations).HasConstraintName("FK_MaterialCostLedger_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialCostLedgers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialCostLedger_MaterialId");

            entity.HasOne(d => d.Transaction).WithMany(p => p.MaterialCostLedgers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialCostLedger_TransactionId");
        });

        modelBuilder.Entity<MaterialVendor>(entity =>
        {
            entity.HasKey(e => e.MaterialVendorId).HasName("PK__Material__80EDBCE24B705468");

            entity.Property(e => e.MaterialVendorId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MaterialVendorCreatedByNavigations).HasConstraintName("FK_MaterialVendor_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MaterialVendorLastModifiedByNavigations).HasConstraintName("FK_MaterialVendor_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialVendors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialVendor_MaterialId");

            entity.HasOne(d => d.Vendor).WithMany(p => p.MaterialVendors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialVendor_Vendor");
        });

        modelBuilder.Entity<MaterialWarehouse>(entity =>
        {
            entity.HasKey(e => e.MaterialWarehouseId).HasName("PK__Material__2F3C18A3192DF5FE");

            entity.Property(e => e.MaterialWarehouseId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MaterialWarehouseCreatedByNavigations).HasConstraintName("FK_MaterialWarehouse_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MaterialWarehouseLastModifiedByNavigations).HasConstraintName("FK_MaterialWarehouse_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialWarehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialWarehouse_MaterialId");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.MaterialWarehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialWarehouse_WarehouseId");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED230B906203A");

            entity.Property(e => e.MenuId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MenuCreatedByNavigations).HasConstraintName("FK_Menu_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MenuLastModifiedByNavigations).HasConstraintName("FK_Menu_LastModifiedBy");

            entity.HasOne(d => d.ParentMenu).WithMany(p => p.InverseParentMenu).HasConstraintName("FK__Menu__ParentMenu__05A3D694");
        });

        modelBuilder.Entity<MenuPermission>(entity =>
        {
            entity.HasKey(e => e.MenuPermissionId).HasName("PK__MenuPerm__830F63C521E50D4E");

            entity.Property(e => e.MenuPermissionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MenuPermissionCreatedByNavigations).HasConstraintName("FK_MenuPermission_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.MenuPermissionLastModifiedByNavigations).HasConstraintName("FK_MenuPermission_LastModifiedBy");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MenuPermi__MenuI__0880433F");

            entity.HasOne(d => d.Permission).WithMany(p => p.MenuPermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MenuPermi__Permi__09746778");
        });

        modelBuilder.Entity<NotificationAttachment>(entity =>
        {
            entity.HasKey(e => e.NotificationAttachmentId).HasName("PK__Notifica__DB093C979BC85CD4");

            entity.Property(e => e.NotificationAttachmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationAttachmentCreatedByNavigations).HasConstraintName("FK_NotificationAttachment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationAttachmentLastModifiedByNavigations).HasConstraintName("FK_NotificationAttachment_LastModifiedBy");

            entity.HasOne(d => d.NotificationMessage).WithMany(p => p.NotificationAttachments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__17236851");
        });

        modelBuilder.Entity<NotificationDelivery>(entity =>
        {
            entity.HasKey(e => e.NotificationDeliveryId).HasName("PK__Notifica__2E709C65071F78D9");

            entity.Property(e => e.NotificationDeliveryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationDeliveryCreatedByNavigations).HasConstraintName("FK_NotificationDelivery_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationDeliveryLastModifiedByNavigations).HasConstraintName("FK_NotificationDelivery_LastModifiedBy");

            entity.HasOne(d => d.NotificationRecipient).WithMany(p => p.NotificationDeliveries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__116A8EFB");
        });

        modelBuilder.Entity<NotificationEscalationRule>(entity =>
        {
            entity.HasKey(e => e.NotificationEscalationRuleId).HasName("PK__Notifica__669F01BF2FFDEC3A");

            entity.Property(e => e.NotificationEscalationRuleId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationEscalationRuleCreatedByNavigations).HasConstraintName("FK_NotificationEscalationRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationEscalationRuleLastModifiedByNavigations).HasConstraintName("FK_NotificationEscalationRule_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.NotificationEscalationRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationEscalationRule_TenantId");
        });

        modelBuilder.Entity<NotificationEvent>(entity =>
        {
            entity.HasKey(e => e.NotificationEventId).HasName("PK__Notifica__2BA9DF9C0CCA5734");

            entity.Property(e => e.NotificationEventId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationEventCreatedByNavigations).HasConstraintName("FK_NotificationEvent_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationEventLastModifiedByNavigations).HasConstraintName("FK_NotificationEvent_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.NotificationEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationEvent_TenantId");
        });

        modelBuilder.Entity<NotificationMessage>(entity =>
        {
            entity.HasKey(e => e.NotificationMessageId).HasName("PK__Notifica__FFFA59DA5456D182");

            entity.Property(e => e.NotificationMessageId).ValueGeneratedNever();

            entity.HasOne(d => d.NotificationEvent).WithMany(p => p.NotificationMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__0504B816");

            entity.HasOne(d => d.Tenant).WithMany(p => p.NotificationMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationMessage_TenantId");
        });

        modelBuilder.Entity<NotificationPreference>(entity =>
        {
            entity.HasKey(e => e.NotificationPreferenceId).HasName("PK__Notifica__1B80A6627672EFCA");

            entity.Property(e => e.NotificationPreferenceId).ValueGeneratedNever();
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationPreferenceCreatedByNavigations).HasConstraintName("FK_NotificationPreference_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationPreferenceLastModifiedByNavigations).HasConstraintName("FK_NotificationPreference_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationPreferenceUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__UserI__1DD065E0");
        });

        modelBuilder.Entity<NotificationRecipient>(entity =>
        {
            entity.HasKey(e => e.NotificationRecipientId).HasName("PK__Notifica__F6659EE4D437E390");

            entity.Property(e => e.NotificationRecipientId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationRecipientCreatedByNavigations).HasConstraintName("FK_NotificationRecipient_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationRecipientLastModifiedByNavigations).HasConstraintName("FK_NotificationRecipient_LastModifiedBy");

            entity.HasOne(d => d.NotificationMessage).WithMany(p => p.NotificationRecipients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__0E8E2250");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationRecipientUsers).HasConstraintName("FK_NotificationRecipient_UserId");
        });

        modelBuilder.Entity<NotificationRetry>(entity =>
        {
            entity.HasKey(e => e.NotificationRetryId).HasName("PK__Notifica__987B18D32BF20218");

            entity.Property(e => e.NotificationRetryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationRetryCreatedByNavigations).HasConstraintName("FK_NotificationRetry_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationRetryLastModifiedByNavigations).HasConstraintName("FK_NotificationRetry_LastModifiedBy");

            entity.HasOne(d => d.NotificationDelivery).WithMany(p => p.NotificationRetries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__1446FBA6");
        });

        modelBuilder.Entity<NotificationSubscription>(entity =>
        {
            entity.HasKey(e => e.NotificationSubscriptionId).HasName("PK__Notifica__DE983C619CB3774C");

            entity.Property(e => e.NotificationSubscriptionId).ValueGeneratedNever();
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationSubscriptionCreatedByNavigations).HasConstraintName("FK_NotificationSubscription_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationSubscriptionLastModifiedByNavigations).HasConstraintName("FK_NotificationSubscription_LastModifiedBy");

            entity.HasOne(d => d.NotificationEvent).WithMany(p => p.NotificationSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__09C96D33");

            entity.HasOne(d => d.Tenant).WithMany(p => p.NotificationSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationSubscription_TenantId");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationSubscriptionUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__UserI__0ABD916C");
        });

        modelBuilder.Entity<NotificationTemplate>(entity =>
        {
            entity.HasKey(e => e.NotificationTemplateId).HasName("PK__Notifica__9C914FCB6BA48E67");

            entity.Property(e => e.NotificationTemplateId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationTemplateCreatedByNavigations).HasConstraintName("FK_NotificationTemplate_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationTemplateLastModifiedByNavigations).HasConstraintName("FK_NotificationTemplate_LastModifiedBy");

            entity.HasOne(d => d.NotificationEvent).WithMany(p => p.NotificationTemplates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__7D63964E");

            entity.HasOne(d => d.Tenant).WithMany(p => p.NotificationTemplates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationTemplate_TenantId");
        });

        modelBuilder.Entity<NotificationTemplateTranslation>(entity =>
        {
            entity.HasKey(e => e.NotificationTemplateTranslationId).HasName("PK__Notifica__C9086815AA59BC5D");

            entity.Property(e => e.NotificationTemplateTranslationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationTemplateTranslationCreatedByNavigations).HasConstraintName("FK_NotificationTemplateTranslation_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.NotificationTemplateTranslationLastModifiedByNavigations).HasConstraintName("FK_NotificationTemplateTranslation_LastModifiedBy");

            entity.HasOne(d => d.NotificationTemplate).WithMany(p => p.NotificationTemplateTranslations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationTemplateTranslation_NotificationTemplateId");
        });

        modelBuilder.Entity<PasswordHistory>(entity =>
        {
            entity.HasKey(e => e.PasswordHistoryId).HasName("PK__Password__0A9DD31DD6BC7B21");

            entity.Property(e => e.PasswordHistoryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PasswordHistoryCreatedByNavigations).HasConstraintName("FK_PasswordHistory_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PasswordHistoryLastModifiedByNavigations).HasConstraintName("FK_PasswordHistory_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.PasswordHistoryUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PasswordH__UserI__7E02B4CC");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2F031F37EF");

            entity.Property(e => e.PermissionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermissionCreatedByNavigations).HasConstraintName("FK_Permission_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermissionLastModifiedByNavigations).HasConstraintName("FK_Permission_LastModifiedBy");
        });

        modelBuilder.Entity<Permit>(entity =>
        {
            entity.HasKey(e => e.PermitId).HasName("PK__Permit__0B0E6DD02A2C32BA");

            entity.Property(e => e.PermitId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitCreatedByNavigations).HasConstraintName("FK_Permit_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitLastModifiedByNavigations).HasConstraintName("FK_Permit_LastModifiedBy");

            entity.HasOne(d => d.PermitType).WithMany(p => p.Permits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permit_PermitType");

            entity.HasOne(d => d.RequestedByUser).WithMany(p => p.PermitRequestedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permit_RequestedByUserId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Permits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permit_TenantId");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.Permits).HasConstraintName("FK__Permit__WorkOrde__66B53B20");
        });

        modelBuilder.Entity<PermitApproval>(entity =>
        {
            entity.HasKey(e => e.PermitApprovalId).HasName("PK__PermitAp__9CED81D44794E124");

            entity.Property(e => e.PermitApprovalId).ValueGeneratedNever();

            entity.HasOne(d => d.ApproverUser).WithMany(p => p.PermitApprovalApproverUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitApproval_ApproverUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitApprovalCreatedByNavigations).HasConstraintName("FK_PermitApproval_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitApprovalLastModifiedByNavigations).HasConstraintName("FK_PermitApproval_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitApprovals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitApp__Permi__7BB05806");
        });

        modelBuilder.Entity<PermitAsset>(entity =>
        {
            entity.HasKey(e => e.PermitAssetId).HasName("PK__PermitAs__435F94237C3596F9");

            entity.Property(e => e.PermitAssetId).ValueGeneratedNever();

            entity.HasOne(d => d.Asset).WithMany(p => p.PermitAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitAss__Asset__6B79F03D");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitAssetCreatedByNavigations).HasConstraintName("FK_PermitAsset_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitAssetLastModifiedByNavigations).HasConstraintName("FK_PermitAsset_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitAss__Permi__6A85CC04");
        });

        modelBuilder.Entity<PermitAttachment>(entity =>
        {
            entity.HasKey(e => e.PermitAttachmentId).HasName("PK__PermitAt__58B11513A398FEC2");

            entity.Property(e => e.PermitAttachmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitAttachmentCreatedByNavigations).HasConstraintName("FK_PermitAttachment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitAttachmentLastModifiedByNavigations).HasConstraintName("FK_PermitAttachment_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitAttachments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitAtt__Permi__09FE775D");
        });

        modelBuilder.Entity<PermitBlockingRule>(entity =>
        {
            entity.HasKey(e => e.PermitBlockingRuleId).HasName("PK__PermitBl__27562372CA82C9A6");

            entity.Property(e => e.PermitBlockingRuleId).ValueGeneratedNever();
            entity.Property(e => e.BlockExecution).HasDefaultValue(true);
            entity.Property(e => e.BlockMachineRelease).HasDefaultValue(true);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitBlockingRuleCreatedByNavigations).HasConstraintName("FK_PermitBlockingRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitBlockingRuleLastModifiedByNavigations).HasConstraintName("FK_PermitBlockingRule_LastModifiedBy");

            entity.HasOne(d => d.PermitType).WithMany(p => p.PermitBlockingRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitBlockingRule_PermitType");

            entity.HasOne(d => d.Tenant).WithMany(p => p.PermitBlockingRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitBlockingRule_TenantId");
        });

        modelBuilder.Entity<PermitClosure>(entity =>
        {
            entity.HasKey(e => e.PermitClosureId).HasName("PK__PermitCl__F386750D0FCD713B");

            entity.Property(e => e.PermitClosureId).ValueGeneratedNever();

            entity.HasOne(d => d.ClosedByUser).WithMany(p => p.PermitClosureClosedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitClosure_ClosedByUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitClosureCreatedByNavigations).HasConstraintName("FK_PermitClosure_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitClosureLastModifiedByNavigations).HasConstraintName("FK_PermitClosure_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitClosures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitClo__Permi__0FB750B3");
        });

        modelBuilder.Entity<PermitControlMeasure>(entity =>
        {
            entity.HasKey(e => e.PermitControlMeasureId).HasName("PK__PermitCo__6E30AA1B615C5E4C");

            entity.Property(e => e.PermitControlMeasureId).ValueGeneratedNever();
            entity.Property(e => e.IsMandatory).HasDefaultValue(true);

            entity.HasOne(d => d.ControlMeasure).WithMany(p => p.PermitControlMeasures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitControlMeasure_ControlMeasure");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitControlMeasureCreatedByNavigations).HasConstraintName("FK_PermitControlMeasure_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitControlMeasureLastModifiedByNavigations).HasConstraintName("FK_PermitControlMeasure_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitControlMeasures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitCon__Permi__75F77EB0");
        });

        modelBuilder.Entity<PermitEmployee>(entity =>
        {
            entity.HasKey(e => e.PermitEmployeeId).HasName("PK__PermitEm__9E1D6768DCA90517");

            entity.Property(e => e.PermitEmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitEmployeeCreatedByNavigations).HasConstraintName("FK_PermitEmployee_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitEmployeeLastModifiedByNavigations).HasConstraintName("FK_PermitEmployee_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitEmp__Permi__6E565CE8");

            entity.HasOne(d => d.User).WithMany(p => p.PermitEmployeeUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitEmployee_UserId");
        });

        modelBuilder.Entity<PermitExtension>(entity =>
        {
            entity.HasKey(e => e.PermitExtensionId).HasName("PK__PermitEx__AF48DA1B931EE7A3");

            entity.Property(e => e.PermitExtensionId).ValueGeneratedNever();

            entity.HasOne(d => d.ApprovedByUser).WithMany(p => p.PermitExtensionApprovedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitExtension_ApprovedByUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitExtensionCreatedByNavigations).HasConstraintName("FK_PermitExtension_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitExtensionLastModifiedByNavigations).HasConstraintName("FK_PermitExtension_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitExtensions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitExt__Permi__04459E07");
        });

        modelBuilder.Entity<PermitHazard>(entity =>
        {
            entity.HasKey(e => e.PermitHazardId).HasName("PK__PermitHa__E213ED1531B1DE2F");

            entity.Property(e => e.PermitHazardId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitHazardCreatedByNavigations).HasConstraintName("FK_PermitHazard_CreatedBy");

            entity.HasOne(d => d.Hazard).WithMany(p => p.PermitHazards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitHazard_HazardMaster");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitHazardLastModifiedByNavigations).HasConstraintName("FK_PermitHazard_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitHazards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitHaz__Permi__7132C993");
        });

        modelBuilder.Entity<PermitIssue>(entity =>
        {
            entity.HasKey(e => e.PermitIssueId).HasName("PK__PermitIs__338A33C919BB3182");

            entity.Property(e => e.PermitIssueId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitIssueCreatedByNavigations).HasConstraintName("FK_PermitIssue_CreatedBy");

            entity.HasOne(d => d.IssuedByUser).WithMany(p => p.PermitIssueIssuedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitIssue_IssuedByUserId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitIssueLastModifiedByNavigations).HasConstraintName("FK_PermitIssue_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitIssues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitIss__Permi__7E8CC4B1");
        });

        modelBuilder.Entity<PermitRiskAssessment>(entity =>
        {
            entity.HasKey(e => e.PermitRiskAssessmentId).HasName("PK__PermitRi__5AA11E5584FC3F54");

            entity.Property(e => e.PermitRiskAssessmentId).ValueGeneratedNever();

            entity.HasOne(d => d.AssessedByUser).WithMany(p => p.PermitRiskAssessmentAssessedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitRiskAssessment_AssessedByUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitRiskAssessmentCreatedByNavigations).HasConstraintName("FK_PermitRiskAssessment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitRiskAssessmentLastModifiedByNavigations).HasConstraintName("FK_PermitRiskAssessment_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitRiskAssessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitRis__Permi__78D3EB5B");
        });

        modelBuilder.Entity<PermitSignature>(entity =>
        {
            entity.HasKey(e => e.PermitSignatureId).HasName("PK__PermitSi__41B93E0E9D9CC0D0");

            entity.Property(e => e.PermitSignatureId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitSignatureCreatedByNavigations).HasConstraintName("FK_PermitSignature_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitSignatureLastModifiedByNavigations).HasConstraintName("FK_PermitSignature_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitSignatures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitSig__Permi__0CDAE408");

            entity.HasOne(d => d.User).WithMany(p => p.PermitSignatureUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitSignature_UserId");
        });

        modelBuilder.Entity<PermitSuspend>(entity =>
        {
            entity.HasKey(e => e.PermitSuspendId).HasName("PK__PermitSu__2BB40612D3399A82");

            entity.Property(e => e.PermitSuspendId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitSuspendCreatedByNavigations).HasConstraintName("FK_PermitSuspend_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitSuspendLastModifiedByNavigations).HasConstraintName("FK_PermitSuspend_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitSuspends)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitSus__Permi__0169315C");

            entity.HasOne(d => d.SuspendedByUser).WithMany(p => p.PermitSuspendSuspendedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermitSuspend_SuspendedByUserId");
        });

        modelBuilder.Entity<PermitType>(entity =>
        {
            entity.Property(e => e.PermitTypeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RequiresApproval).HasDefaultValue(true);
        });

        modelBuilder.Entity<PermitWorkIsolation>(entity =>
        {
            entity.HasKey(e => e.PermitWorkIsolationId).HasName("PK__PermitWo__2492C1FB49E7864D");

            entity.Property(e => e.PermitWorkIsolationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermitWorkIsolationCreatedByNavigations).HasConstraintName("FK_PermitWorkIsolation_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PermitWorkIsolationLastModifiedByNavigations).HasConstraintName("FK_PermitWorkIsolation_LastModifiedBy");

            entity.HasOne(d => d.Permit).WithMany(p => p.PermitWorkIsolations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PermitWor__Permi__07220AB2");

            entity.HasOne(d => d.VerifiedByUser).WithMany(p => p.PermitWorkIsolationVerifiedByUsers).HasConstraintName("FK_PermitWorkIsolation_VerifiedByUserId");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.PlantId).HasName("PK__Plant__98FE395CAF56A33A");

            entity.Property(e => e.PlantId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PlantCreatedByNavigations).HasConstraintName("FK_Plant_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PlantLastModifiedByNavigations).HasConstraintName("FK_Plant_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Plants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Plant__TenantId__01142BA1");
        });

        modelBuilder.Entity<PmcalendarRule>(entity =>
        {
            entity.HasKey(e => e.PmcalendarRuleId).HasName("PK__PMCalend__AE2DF769FAA36AC0");

            entity.Property(e => e.PmcalendarRuleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmcalendarRuleCreatedByNavigations).HasConstraintName("FK_PMCalendarRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmcalendarRuleLastModifiedByNavigations).HasConstraintName("FK_PMCalendarRule_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmcalendarRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMCalenda__PMSch__13BCEBC1");
        });

        modelBuilder.Entity<PmcomplianceSnapshot>(entity =>
        {
            entity.HasKey(e => e.SnapshotId).HasName("PK__PMCompli__664F572B8764A129");

            entity.Property(e => e.SnapshotId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmcomplianceSnapshotCreatedByNavigations).HasConstraintName("FK_PMComplianceSnapshot_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmcomplianceSnapshotLastModifiedByNavigations).HasConstraintName("FK_PMComplianceSnapshot_LastModifiedBy");

            entity.HasOne(d => d.Plant).WithMany(p => p.PmcomplianceSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PMComplianceSnapshot_PlantId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.PmcomplianceSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PMComplianceSnapshot_TenantId");
        });

        modelBuilder.Entity<PmcycleRule>(entity =>
        {
            entity.HasKey(e => e.PmcycleRuleId).HasName("PK__PMCycleR__6BAE48B9EA02836D");

            entity.Property(e => e.PmcycleRuleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmcycleRuleCreatedByNavigations).HasConstraintName("FK_PMCycleRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmcycleRuleLastModifiedByNavigations).HasConstraintName("FK_PMCycleRule_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmcycleRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMCycleRu__PMSch__1975C517");
        });

        modelBuilder.Entity<Pmexecution>(entity =>
        {
            entity.HasKey(e => e.PmexecutionId).HasName("PK__PMExecut__37D33D8D377C69DC");

            entity.Property(e => e.PmexecutionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmexecutionCreatedByNavigations).HasConstraintName("FK_PMExecution_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmexecutionLastModifiedByNavigations).HasConstraintName("FK_PMExecution_LastModifiedBy");

            entity.HasOne(d => d.PmworkOrder).WithMany(p => p.Pmexecutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMExecuti__PMWor__2B947552");
        });

        modelBuilder.Entity<PmexecutionChecklist>(entity =>
        {
            entity.HasKey(e => e.PmexecutionChecklistId).HasName("PK__PMExecut__E6B107F2F58447CB");

            entity.Property(e => e.PmexecutionChecklistId).ValueGeneratedNever();

            entity.HasOne(d => d.ChecklistQuestion).WithMany(p => p.PmexecutionChecklists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PMExecutionChecklist_ChecklistQuestionId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmexecutionChecklistCreatedByNavigations).HasConstraintName("FK_PMExecutionChecklist_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmexecutionChecklistLastModifiedByNavigations).HasConstraintName("FK_PMExecutionChecklist_LastModifiedBy");

            entity.HasOne(d => d.Pmexecution).WithMany(p => p.PmexecutionChecklists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMExecuti__PMExe__314D4EA8");
        });

        modelBuilder.Entity<PmexecutionReading>(entity =>
        {
            entity.HasKey(e => e.PmexecutionReadingId).HasName("PK__PMExecut__6096FE5C31D9B837");

            entity.Property(e => e.PmexecutionReadingId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmexecutionReadingCreatedByNavigations).HasConstraintName("FK_PMExecutionReading_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmexecutionReadingLastModifiedByNavigations).HasConstraintName("FK_PMExecutionReading_LastModifiedBy");

            entity.HasOne(d => d.Pmexecution).WithMany(p => p.PmexecutionReadings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMExecuti__PMExe__2E70E1FD");
        });

        modelBuilder.Entity<Pmforecast>(entity =>
        {
            entity.HasKey(e => e.PmforecastId).HasName("PK__PMForeca__160533CA2E575033");

            entity.Property(e => e.PmforecastId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmforecastCreatedByNavigations).HasConstraintName("FK_PMForecast_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmforecastLastModifiedByNavigations).HasConstraintName("FK_PMForecast_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.Pmforecasts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMForecas__PMSch__361203C5");
        });

        modelBuilder.Entity<PmgenerationLog>(entity =>
        {
            entity.HasKey(e => e.PmgenerationLogId).HasName("PK__PMGenera__EB2AD664546FA0DC");

            entity.Property(e => e.PmgenerationLogId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmgenerationLogCreatedByNavigations).HasConstraintName("FK_PMGenerationLog_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmgenerationLogLastModifiedByNavigations).HasConstraintName("FK_PMGenerationLog_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmgenerationLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMGenerat__PMSch__220B0B18");

            entity.HasOne(d => d.PmworkOrder).WithMany(p => p.PmgenerationLogs).HasConstraintName("FK_PMGenerationLog_PMWorkOrderId");
        });

        modelBuilder.Entity<PmquantityRule>(entity =>
        {
            entity.HasKey(e => e.PmquantityRuleId).HasName("PK__PMQuanti__4E45682D92F4B64B");

            entity.Property(e => e.PmquantityRuleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmquantityRuleCreatedByNavigations).HasConstraintName("FK_PMQuantityRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmquantityRuleLastModifiedByNavigations).HasConstraintName("FK_PMQuantityRule_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmquantityRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMQuantit__PMSch__1C5231C2");
        });

        modelBuilder.Entity<PmruntimeRule>(entity =>
        {
            entity.HasKey(e => e.PmruntimeRuleId).HasName("PK__PMRuntim__430E5A4F6A3CEBC7");

            entity.Property(e => e.PmruntimeRuleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmruntimeRuleCreatedByNavigations).HasConstraintName("FK_PMRuntimeRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmruntimeRuleLastModifiedByNavigations).HasConstraintName("FK_PMRuntimeRule_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmruntimeRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMRuntime__PMSch__1699586C");
        });

        modelBuilder.Entity<Pmschedule>(entity =>
        {
            entity.HasKey(e => e.PmscheduleId).HasName("PK__PMSchedu__38C94E1D953E9BA6");

            entity.Property(e => e.PmscheduleId).ValueGeneratedNever();
            entity.Property(e => e.AutoGenerate).HasDefaultValue(true);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Asset).WithMany(p => p.Pmschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSchedul__Asset__55009F39");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmscheduleCreatedByNavigations).HasConstraintName("FK_PMSchedule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmscheduleLastModifiedByNavigations).HasConstraintName("FK_PMSchedule_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Pmschedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSchedul__Tenan__540C7B00");
        });

        modelBuilder.Entity<PmscheduleAsset>(entity =>
        {
            entity.HasKey(e => e.PmscheduleAssetId).HasName("PK__PMSchedu__D4FCEBE7C251F45B");

            entity.Property(e => e.PmscheduleAssetId).ValueGeneratedNever();

            entity.HasOne(d => d.Asset).WithMany(p => p.PmscheduleAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSchedul__Asset__0D0FEE32");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmscheduleAssetCreatedByNavigations).HasConstraintName("FK_PMScheduleAsset_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmscheduleAssetLastModifiedByNavigations).HasConstraintName("FK_PMScheduleAsset_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmscheduleAssets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSchedul__PMSch__0C1BC9F9");
        });

        modelBuilder.Entity<PmscheduleChecklist>(entity =>
        {
            entity.HasKey(e => e.PmscheduleChecklistId).HasName("PK__PMSchedu__EE877958F5DF8C2C");

            entity.Property(e => e.PmscheduleChecklistId).ValueGeneratedNever();
            entity.Property(e => e.IsMandatory).HasDefaultValue(true);

            entity.HasOne(d => d.Checklist).WithMany(p => p.PmscheduleChecklists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PMScheduleChecklist_ChecklistId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmscheduleChecklistCreatedByNavigations).HasConstraintName("FK_PMScheduleChecklist_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmscheduleChecklistLastModifiedByNavigations).HasConstraintName("FK_PMScheduleChecklist_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmscheduleChecklists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMSchedul__PMSch__10E07F16");
        });

        modelBuilder.Entity<PmtriggerHistory>(entity =>
        {
            entity.HasKey(e => e.PmtriggerHistoryId).HasName("PK__PMTrigge__FEBC33523E6C49A1");

            entity.Property(e => e.PmtriggerHistoryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmtriggerHistoryCreatedByNavigations).HasConstraintName("FK_PMTriggerHistory_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmtriggerHistoryLastModifiedByNavigations).HasConstraintName("FK_PMTriggerHistory_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmtriggerHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMTrigger__PMSch__1F2E9E6D");
        });

        modelBuilder.Entity<PmworkOrder>(entity =>
        {
            entity.HasKey(e => e.PmworkOrderId).HasName("PK__PMWorkOr__D54BA1C5C5EF023A");

            entity.Property(e => e.PmworkOrderId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PmworkOrderCreatedByNavigations).HasConstraintName("FK_PMWorkOrder_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PmworkOrderLastModifiedByNavigations).HasConstraintName("FK_PMWorkOrder_LastModifiedBy");

            entity.HasOne(d => d.Pmschedule).WithMany(p => p.PmworkOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMWorkOrd__PMSch__27C3E46E");

            entity.HasOne(d => d.Tenant).WithMany(p => p.PmworkOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PMWorkOrder_TenantId");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.PmworkOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PMWorkOrd__WorkO__28B808A7");
        });

        modelBuilder.Entity<ProductionLine>(entity =>
        {
            entity.HasKey(e => e.ProductionLineId).HasName("PK__Producti__E1546AFF92FEF0FE");

            entity.Property(e => e.ProductionLineId).ValueGeneratedNever();

            entity.HasOne(d => d.Area).WithMany(p => p.ProductionLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__AreaI__17036CC0");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductionLineCreatedByNavigations).HasConstraintName("FK_ProductionLine_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ProductionLineLastModifiedByNavigations).HasConstraintName("FK_ProductionLine_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ProductionLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Tenan__160F4887");
        });

        modelBuilder.Entity<PurchaseReceipt>(entity =>
        {
            entity.HasKey(e => e.PurchaseReceiptId).HasName("PK__Purchase__BF967F2F6C1BD0B6");

            entity.Property(e => e.PurchaseReceiptId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PurchaseReceiptCreatedByNavigations).HasConstraintName("FK_PurchaseReceipt_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PurchaseReceiptLastModifiedByNavigations).HasConstraintName("FK_PurchaseReceipt_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.PurchaseReceipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseReceipt_TenantId");

            entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseReceipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseReceipt_Vendor");
        });

        modelBuilder.Entity<PurchaseReceiptItem>(entity =>
        {
            entity.HasKey(e => e.PurchaseReceiptItemId).HasName("PK__Purchase__73F60B14FB074D80");

            entity.Property(e => e.PurchaseReceiptItemId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PurchaseReceiptItemCreatedByNavigations).HasConstraintName("FK_PurchaseReceiptItem_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.PurchaseReceiptItemLastModifiedByNavigations).HasConstraintName("FK_PurchaseReceiptItem_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.PurchaseReceiptItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Mater__5832119F");

            entity.HasOne(d => d.PurchaseReceipt).WithMany(p => p.PurchaseReceiptItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Purch__573DED66");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId).HasName("PK__RefreshT__F5845E398FE6F37C");

            entity.Property(e => e.RefreshTokenId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RefreshTokenCreatedByNavigations).HasConstraintName("FK_RefreshToken_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RefreshTokenLastModifiedByNavigations).HasConstraintName("FK_RefreshToken_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokenUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RefreshTo__UserI__02C769E9");
        });

        modelBuilder.Entity<ReorderSuggestion>(entity =>
        {
            entity.HasKey(e => e.ReorderSuggestionId).HasName("PK__ReorderS__7A9CF3F948558915");

            entity.Property(e => e.ReorderSuggestionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ReorderSuggestionCreatedByNavigations).HasConstraintName("FK_ReorderSuggestion_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.ReorderSuggestionLastModifiedByNavigations).HasConstraintName("FK_ReorderSuggestion_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.ReorderSuggestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReorderSu__Mater__6497E884");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ReorderSuggestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReorderSuggestion_TenantId");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.ReorderSuggestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReorderSu__Wareh__658C0CBD");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A50B967E6");

            entity.Property(e => e.RoleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleCreatedByNavigations).HasConstraintName("FK_Roles_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RoleLastModifiedByNavigations).HasConstraintName("FK_Roles_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Roles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_Tenant");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.RolePermissionId).HasName("PK__RolePerm__120F46BA7584EAED");

            entity.Property(e => e.RolePermissionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RolePermissionCreatedByNavigations).HasConstraintName("FK_RolePermission_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RolePermissionLastModifiedByNavigations).HasConstraintName("FK_RolePermission_LastModifiedBy");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Permission");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Role");
        });

        modelBuilder.Entity<SecurityAudit>(entity =>
        {
            entity.HasKey(e => e.SecurityAuditId).HasName("PK__Security__BBA9EDDD0835C2C0");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SecurityAuditCreatedByNavigations).HasConstraintName("FK_SecurityAudit_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SecurityAuditLastModifiedByNavigations).HasConstraintName("FK_SecurityAudit_LastModifiedBy");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Session__C9F49290670C64DB");

            entity.Property(e => e.SessionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SessionCreatedByNavigations).HasConstraintName("FK_Session_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SessionLastModifiedByNavigations).HasConstraintName("FK_Session_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.SessionUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Session__UserId__7849DB76");
        });

        modelBuilder.Entity<SlaInstance>(entity =>
        {
            entity.HasKey(e => e.SlaInstanceId).HasName("PK__SlaInsta__94FF9F43AEEC95E1");

            entity.Property(e => e.SlaInstanceId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SlaInstanceCreatedByNavigations).HasConstraintName("FK_SlaInstance_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SlaInstanceLastModifiedByNavigations).HasConstraintName("FK_SlaInstance_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.SlaInstances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SlaInstan__Tenan__4C6B5938");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.SlaInstances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SlaInstan__WorkO__4D5F7D71");
        });

        modelBuilder.Entity<SpareRequest>(entity =>
        {
            entity.HasKey(e => e.SpareRequestId).HasName("PK__SpareReq__1B6DD60DCDBE3BF0");

            entity.Property(e => e.SpareRequestId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SpareRequestCreatedByNavigations).HasConstraintName("FK_SpareRequest_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SpareRequestLastModifiedByNavigations).HasConstraintName("FK_SpareRequest_LastModifiedBy");

            entity.HasOne(d => d.RequestedByUser).WithMany(p => p.SpareRequestRequestedByUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpareRequest_RequestedByUserId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.SpareRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpareRequest_TenantId");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.SpareRequests).HasConstraintName("FK_SpareRequest_WorkOrderId");
        });

        modelBuilder.Entity<SpareRequestItem>(entity =>
        {
            entity.HasKey(e => e.SpareRequestItemId).HasName("PK__SpareReq__10313174B31DC9EA");

            entity.Property(e => e.SpareRequestItemId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SpareRequestItemCreatedByNavigations).HasConstraintName("FK_SpareRequestItem_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SpareRequestItemLastModifiedByNavigations).HasConstraintName("FK_SpareRequestItem_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.SpareRequestItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpareRequestItem_MaterialId");

            entity.HasOne(d => d.SpareRequest).WithMany(p => p.SpareRequestItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpareRequestItem_SpareRequestId");
        });

        modelBuilder.Entity<StockSnapshot>(entity =>
        {
            entity.HasKey(e => e.StockSnapshotId).HasName("PK__StockSna__7F504638EE97B29A");

            entity.Property(e => e.StockSnapshotId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.StockSnapshotCreatedByNavigations).HasConstraintName("FK_StockSnapshot_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.StockSnapshotLastModifiedByNavigations).HasConstraintName("FK_StockSnapshot_LastModifiedBy");

            entity.HasOne(d => d.Material).WithMany(p => p.StockSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockSnap__Mater__5DEAEAF5");

            entity.HasOne(d => d.Tenant).WithMany(p => p.StockSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockSnapshot_TenantId");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.StockSnapshots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockSnap__Wareh__5EDF0F2E");
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.HasKey(e => e.StorageLocationId).HasName("PK__StorageL__59BA7AF9E0562D91");

            entity.Property(e => e.StorageLocationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.StorageLocationCreatedByNavigations).HasConstraintName("FK_StorageLocation_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.StorageLocationLastModifiedByNavigations).HasConstraintName("FK_StorageLocation_LastModifiedBy");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.StorageLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StorageLocation_WarehouseId");
        });

        modelBuilder.Entity<SystemMessage>(entity =>
        {
            entity.HasKey(e => e.MessageCode).HasName("PK__SystemMe__54E8229E5C9A590E");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SystemMessageCreatedByNavigations).HasConstraintName("FK_SystemMessage_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SystemMessageLastModifiedByNavigations).HasConstraintName("FK_SystemMessage_LastModifiedBy");
        });

        modelBuilder.Entity<SystemMessageTranslation>(entity =>
        {
            entity.HasKey(e => e.MessageTranslationId).HasName("PK__SystemMe__61CB6638A4CD2CDA");

            entity.Property(e => e.MessageTranslationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SystemMessageTranslationCreatedByNavigations).HasConstraintName("FK_SystemMessageTranslation_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.SystemMessageTranslationLastModifiedByNavigations).HasConstraintName("FK_SystemMessageTranslation_LastModifiedBy");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Team__123AE79902EFB18C");

            entity.Property(e => e.TeamId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TeamCreatedByNavigations).HasConstraintName("FK_Team_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.TeamLastModifiedByNavigations).HasConstraintName("FK_Team_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Teams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Team__TenantId__395884C4");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.Property(e => e.TenantId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TenantCreatedByNavigations).HasConstraintName("FK_Tenant_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.TenantLastModifiedByNavigations).HasConstraintName("FK_Tenant_LastModifiedBy");
        });

        modelBuilder.Entity<TenantFeature>(entity =>
        {
            entity.HasKey(e => e.TenantFeatureId).HasName("PK__TenantFe__A045505693E0F918");

            entity.Property(e => e.TenantFeatureId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TenantFeatureCreatedByNavigations).HasConstraintName("FK_TenantFeature_CreatedBy");

            entity.HasOne(d => d.Feature).WithMany(p => p.TenantFeatures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TenantFea__Featu__12FDD1B2");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.TenantFeatureLastModifiedByNavigations).HasConstraintName("FK_TenantFeature_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.TenantFeatures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TenantFea__Tenan__1209AD79");
        });

        modelBuilder.Entity<TenantLanguage>(entity =>
        {
            entity.HasKey(e => e.TenantLanguageId).HasName("PK__TenantLa__C6204D9ED295B965");

            entity.Property(e => e.TenantLanguageId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TenantLanguageCreatedByNavigations).HasConstraintName("FK_TenantLanguage_CreatedBy");

            entity.HasOne(d => d.Language).WithMany(p => p.TenantLanguages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TenantLanguage_LanguageId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.TenantLanguageLastModifiedByNavigations).HasConstraintName("FK_TenantLanguage_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.TenantLanguages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TenantLanguage_TenantId");
        });

        modelBuilder.Entity<Uom>(entity =>
        {
            entity.Property(e => e.Uomid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DecimalPlaces).HasDefaultValue(2);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UomCreatedByNavigations).HasConstraintName("FK_UOM_CreatedBy");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.UomModifiedByNavigations).HasConstraintName("FK_UOM_ModifiedBy");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Tenant).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Tenant");
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.HasKey(e => e.UserClaimId).HasName("PK__UserClai__E22E29E4E9124A1D");

            entity.Property(e => e.UserClaimId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserClaimCreatedByNavigations).HasConstraintName("FK_UserClaim_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.UserClaimLastModifiedByNavigations).HasConstraintName("FK_UserClaim_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.UserClaimUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserClaim_Users");
        });

        modelBuilder.Entity<UserDepartment>(entity =>
        {
            entity.HasKey(e => e.UserDepartmentId).HasName("PK__UserDepa__2395A747183F5630");

            entity.Property(e => e.UserDepartmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserDepartmentCreatedByNavigations).HasConstraintName("FK_UserDepartment_CreatedBy");

            entity.HasOne(d => d.Department).WithMany(p => p.UserDepartments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDepartment_Department");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.UserDepartmentLastModifiedByNavigations).HasConstraintName("FK_UserDepartment_LastModifiedBy");

            entity.HasOne(d => d.User).WithMany(p => p.UserDepartmentUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDepartment_Users");
        });

        modelBuilder.Entity<UserPlant>(entity =>
        {
            entity.HasKey(e => e.UserPlantId).HasName("PK__UserPlan__53A69E642DB7BC34");

            entity.Property(e => e.UserPlantId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserPlantCreatedByNavigations).HasConstraintName("FK_UserPlant_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.UserPlantLastModifiedByNavigations).HasConstraintName("FK_UserPlant_LastModifiedBy");

            entity.HasOne(d => d.Plant).WithMany(p => p.UserPlants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPlant_Plant");

            entity.HasOne(d => d.User).WithMany(p => p.UserPlantUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPlant_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A350DA6A2C4");

            entity.Property(e => e.UserRoleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserRoleCreatedByNavigations).HasConstraintName("FK_UserRoles_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.UserRoleLastModifiedByNavigations).HasConstraintName("FK_UserRoles_LastModifiedBy");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoleUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");
        });

        modelBuilder.Entity<UserTeam>(entity =>
        {
            entity.HasKey(e => e.UserTeamId).HasName("PK__UserTeam__9ADF80B2ED856E2B");

            entity.Property(e => e.UserTeamId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserTeamCreatedByNavigations).HasConstraintName("FK_UserTeam_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.UserTeamLastModifiedByNavigations).HasConstraintName("FK_UserTeam_LastModifiedBy");

            entity.HasOne(d => d.Team).WithMany(p => p.UserTeams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserTeam__TeamId__72910220");

            entity.HasOne(d => d.User).WithMany(p => p.UserTeamUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserTeam__UserId__719CDDE7");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.Property(e => e.VendorId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.VendorStatus).HasDefaultValue("Active");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VendorCreatedByNavigations).HasConstraintName("FK_Vendor_CreatedBy");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.VendorModifiedByNavigations).HasConstraintName("FK_Vendor_ModifiedBy");
        });

        modelBuilder.Entity<VwAssetTypeLookup>(entity =>
        {
            entity.ToView("vwAssetTypeLookup", "masterdata");
        });

        modelBuilder.Entity<VwWorkOrder>(entity =>
        {
            entity.ToView("vwWorkOrders", "maintenance");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__2608AFF964EE130B");

            entity.Property(e => e.WarehouseId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WarehouseCreatedByNavigations).HasConstraintName("FK_Warehouse_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WarehouseLastModifiedByNavigations).HasConstraintName("FK_Warehouse_LastModifiedBy");

            entity.HasOne(d => d.Plant).WithMany(p => p.Warehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_PlantId");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Warehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_TenantId");
        });

        modelBuilder.Entity<WebhookRequestLog>(entity =>
        {
            entity.HasKey(e => e.WebhookRequestLogId).HasName("PK__WebhookR__6EA7DD391F40ABD6");

            entity.Property(e => e.WebhookRequestLogId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WebhookRequestLogCreatedByNavigations).HasConstraintName("FK_WebhookRequestLog_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WebhookRequestLogLastModifiedByNavigations).HasConstraintName("FK_WebhookRequestLog_LastModifiedBy");

            entity.HasOne(d => d.WebhookSubscription).WithMany(p => p.WebhookRequestLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WebhookRe__Webho__4E739D3B");
        });

        modelBuilder.Entity<WebhookSubscription>(entity =>
        {
            entity.HasKey(e => e.WebhookSubscriptionId).HasName("PK__WebhookS__62A4AB8302909E67");

            entity.Property(e => e.WebhookSubscriptionId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WebhookSubscriptionCreatedByNavigations).HasConstraintName("FK_WebhookSubscription_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WebhookSubscriptionLastModifiedByNavigations).HasConstraintName("FK_WebhookSubscription_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.WebhookSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebhookSubscription_TenantId");
        });

        modelBuilder.Entity<WorkCenter>(entity =>
        {
            entity.HasKey(e => e.WorkCenterId).HasName("PK__WorkCent__F98CA1FA497EFEDB");

            entity.Property(e => e.WorkCenterId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkCenterCreatedByNavigations).HasConstraintName("FK_WorkCenter_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkCenterLastModifiedByNavigations).HasConstraintName("FK_WorkCenter_LastModifiedBy");

            entity.HasOne(d => d.ProductionLine).WithMany(p => p.WorkCenters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkCente__Produ__1AD3FDA4");

            entity.HasOne(d => d.Tenant).WithMany(p => p.WorkCenters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkCente__Tenan__19DFD96B");
        });

        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity.HasKey(e => e.WorkOrderId).HasName("PK__WorkOrde__AE755115F08E7E11");

            entity.Property(e => e.WorkOrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Asset).WithMany(p => p.WorkOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkOrder__Asset__44CA3770");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkOrderCreatedByNavigations).HasConstraintName("FK_WorkOrder_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkOrderLastModifiedByNavigations).HasConstraintName("FK_WorkOrder_LastModifiedBy");

            entity.HasOne(d => d.Request).WithMany(p => p.WorkOrders).HasConstraintName("FK__WorkOrder__Reque__43D61337");

            entity.HasOne(d => d.Tenant).WithMany(p => p.WorkOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkOrder__Tenan__42E1EEFE");
        });

        modelBuilder.Entity<WorkOrderAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__WorkOrde__32499E77EAA9C4A2");

            entity.Property(e => e.AssignmentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkOrderAssignmentCreatedByNavigations).HasConstraintName("FK_WorkOrderAssignment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkOrderAssignmentLastModifiedByNavigations).HasConstraintName("FK_WorkOrderAssignment_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.WorkOrderAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkOrder__Tenan__47A6A41B");

            entity.HasOne(d => d.User).WithMany(p => p.WorkOrderAssignmentUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkOrder__UserI__498EEC8D");

            entity.HasOne(d => d.WorkOrder).WithMany(p => p.WorkOrderAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkOrder__WorkO__489AC854");
        });

        modelBuilder.Entity<WorkflowAction>(entity =>
        {
            entity.HasKey(e => e.WorkflowActionId).HasName("PK__Workflow__5B286E2C460E0E6E");

            entity.Property(e => e.WorkflowActionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowActionCreatedByNavigations).HasConstraintName("FK_WorkflowAction_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowActionLastModifiedByNavigations).HasConstraintName("FK_WorkflowAction_LastModifiedBy");

            entity.HasOne(d => d.WorkflowTransition).WithMany(p => p.WorkflowActions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowA__Workf__6B0FDBE9");
        });

        modelBuilder.Entity<WorkflowApproval>(entity =>
        {
            entity.HasKey(e => e.WorkflowApprovalId).HasName("PK__Workflow__75BC88DC6C884CE8");

            entity.Property(e => e.WorkflowApprovalId).ValueGeneratedNever();

            entity.HasOne(d => d.ApproverUser).WithMany(p => p.WorkflowApprovalApproverUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowApproval_ApproverUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowApprovalCreatedByNavigations).HasConstraintName("FK_WorkflowApproval_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowApprovalLastModifiedByNavigations).HasConstraintName("FK_WorkflowApproval_LastModifiedBy");

            entity.HasOne(d => d.WorkflowTask).WithMany(p => p.WorkflowApprovals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowA__Workf__7869D707");
        });

        modelBuilder.Entity<WorkflowComment>(entity =>
        {
            entity.HasKey(e => e.WorkflowCommentId).HasName("PK__Workflow__393704C1E7B037E8");

            entity.Property(e => e.WorkflowCommentId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.WorkflowComments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowComment_CreatedByUserId");

            entity.HasOne(d => d.WorkflowInstance).WithMany(p => p.WorkflowComments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowC__Workf__7E22B05D");
        });

        modelBuilder.Entity<WorkflowDefinition>(entity =>
        {
            entity.HasKey(e => e.WorkflowDefinitionId).HasName("PK__Workflow__30FF7BF683A58E1A");

            entity.Property(e => e.WorkflowDefinitionId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Tenant).WithMany(p => p.WorkflowDefinitions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowDefinition_TenantId");
        });

        modelBuilder.Entity<WorkflowEscalation>(entity =>
        {
            entity.HasKey(e => e.WorkflowEscalationId).HasName("PK__Workflow__13FFE94CA73E405A");

            entity.Property(e => e.WorkflowEscalationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowEscalationCreatedByNavigations).HasConstraintName("FK_WorkflowEscalation_CreatedBy");

            entity.HasOne(d => d.EscalatedToUser).WithMany(p => p.WorkflowEscalationEscalatedToUsers).HasConstraintName("FK_WorkflowEscalation_EscalatedToUserId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowEscalationLastModifiedByNavigations).HasConstraintName("FK_WorkflowEscalation_LastModifiedBy");

            entity.HasOne(d => d.WorkflowTask).WithMany(p => p.WorkflowEscalations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowE__Workf__03DB89B3");
        });

        modelBuilder.Entity<WorkflowHistory>(entity =>
        {
            entity.HasKey(e => e.WorkflowHistoryId).HasName("PK__Workflow__4469D5550E94A31A");

            entity.Property(e => e.WorkflowHistoryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowHistoryCreatedByNavigations).HasConstraintName("FK_WorkflowHistory_CreatedBy");

            entity.HasOne(d => d.FromState).WithMany(p => p.WorkflowHistoryFromStates).HasConstraintName("FK_WorkflowHistory_FromStateId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowHistoryLastModifiedByNavigations).HasConstraintName("FK_WorkflowHistory_LastModifiedBy");

            entity.HasOne(d => d.PerformedByUser).WithMany(p => p.WorkflowHistoryPerformedByUsers).HasConstraintName("FK_WorkflowHistory_PerformedByUserId");

            entity.HasOne(d => d.ToState).WithMany(p => p.WorkflowHistoryToStates).HasConstraintName("FK_WorkflowHistory_ToStateId");

            entity.HasOne(d => d.WorkflowInstance).WithMany(p => p.WorkflowHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowH__Workf__7B4643B2");
        });

        modelBuilder.Entity<WorkflowInstance>(entity =>
        {
            entity.HasKey(e => e.WorkflowInstanceId).HasName("PK__Workflow__12BEE6B8F1BDF8F5");

            entity.Property(e => e.WorkflowInstanceId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowInstanceCreatedByNavigations).HasConstraintName("FK_WorkflowInstance_CreatedBy");

            entity.HasOne(d => d.CurrentState).WithMany(p => p.WorkflowInstances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowI__Curre__6EE06CCD");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowInstanceLastModifiedByNavigations).HasConstraintName("FK_WorkflowInstance_LastModifiedBy");

            entity.HasOne(d => d.Tenant).WithMany(p => p.WorkflowInstances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowInstance_TenantId");

            entity.HasOne(d => d.WorkflowDefinition).WithMany(p => p.WorkflowInstances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowI__Workf__6DEC4894");
        });

        modelBuilder.Entity<WorkflowInstanceState>(entity =>
        {
            entity.HasKey(e => e.WorkflowInstanceStateId).HasName("PK__Workflow__17D50CC61B2E8CFA");

            entity.Property(e => e.WorkflowInstanceStateId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowInstanceStateCreatedByNavigations).HasConstraintName("FK_WorkflowInstanceState_CreatedBy");

            entity.HasOne(d => d.EnteredByUser).WithMany(p => p.WorkflowInstanceStateEnteredByUsers).HasConstraintName("FK_WorkflowInstanceState_EnteredByUserId");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowInstanceStateLastModifiedByNavigations).HasConstraintName("FK_WorkflowInstanceState_LastModifiedBy");

            entity.HasOne(d => d.WorkflowInstance).WithMany(p => p.WorkflowInstanceStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowI__Workf__71BCD978");

            entity.HasOne(d => d.WorkflowState).WithMany(p => p.WorkflowInstanceStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowI__Workf__72B0FDB1");
        });

        modelBuilder.Entity<WorkflowNotification>(entity =>
        {
            entity.HasKey(e => e.WorkflowNotificationId).HasName("PK__Workflow__87E9B0FDAD96D9BC");

            entity.Property(e => e.WorkflowNotificationId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowNotificationCreatedByNavigations).HasConstraintName("FK_WorkflowNotification_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowNotificationLastModifiedByNavigations).HasConstraintName("FK_WorkflowNotification_LastModifiedBy");

            entity.HasOne(d => d.RecipientUser).WithMany(p => p.WorkflowNotificationRecipientUsers).HasConstraintName("FK_WorkflowNotification_RecipientUserId");

            entity.HasOne(d => d.WorkflowInstance).WithMany(p => p.WorkflowNotifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowN__Workf__00FF1D08");
        });

        modelBuilder.Entity<WorkflowRoleAssignment>(entity =>
        {
            entity.HasKey(e => e.WorkflowRoleAssignmentId).HasName("PK__Workflow__19DAB19B51B86009");

            entity.Property(e => e.WorkflowRoleAssignmentId).ValueGeneratedNever();
            entity.Property(e => e.IsMandatory).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowRoleAssignmentCreatedByNavigations).HasConstraintName("FK_WorkflowRoleAssignment_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowRoleAssignmentLastModifiedByNavigations).HasConstraintName("FK_WorkflowRoleAssignment_LastModifiedBy");

            entity.HasOne(d => d.Role).WithMany(p => p.WorkflowRoleAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRoleAssignment_RoleId");

            entity.HasOne(d => d.WorkflowDefinition).WithMany(p => p.WorkflowRoleAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowR__Workf__07AC1A97");

            entity.HasOne(d => d.WorkflowState).WithMany(p => p.WorkflowRoleAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowR__Workf__08A03ED0");
        });

        modelBuilder.Entity<WorkflowRule>(entity =>
        {
            entity.HasKey(e => e.WorkflowRuleId).HasName("PK__Workflow__18FE286BDDF37BD3");

            entity.Property(e => e.WorkflowRuleId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowRuleCreatedByNavigations).HasConstraintName("FK_WorkflowRule_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowRuleLastModifiedByNavigations).HasConstraintName("FK_WorkflowRule_LastModifiedBy");

            entity.HasOne(d => d.WorkflowTransition).WithMany(p => p.WorkflowRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowR__Workf__68336F3E");
        });

        modelBuilder.Entity<WorkflowState>(entity =>
        {
            entity.HasKey(e => e.WorkflowStateId).HasName("PK__Workflow__AA4551A0B89D68FE");

            entity.Property(e => e.WorkflowStateId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowStateCreatedByNavigations).HasConstraintName("FK_WorkflowState_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowStateLastModifiedByNavigations).HasConstraintName("FK_WorkflowState_LastModifiedBy");

            entity.HasOne(d => d.WorkflowDefinition).WithMany(p => p.WorkflowStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowS__Workf__5F9E293D");
        });

        modelBuilder.Entity<WorkflowTask>(entity =>
        {
            entity.HasKey(e => e.WorkflowTaskId).HasName("PK__Workflow__C47EA5E15CB66307");

            entity.Property(e => e.WorkflowTaskId).ValueGeneratedNever();

            entity.HasOne(d => d.AssignedRole).WithMany(p => p.WorkflowTasks).HasConstraintName("FK_WorkflowTask_AssignedRoleId");

            entity.HasOne(d => d.AssignedUser).WithMany(p => p.WorkflowTaskAssignedUsers).HasConstraintName("FK_WorkflowTask_AssignedUserId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowTaskCreatedByNavigations).HasConstraintName("FK_WorkflowTask_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowTaskLastModifiedByNavigations).HasConstraintName("FK_WorkflowTask_LastModifiedBy");

            entity.HasOne(d => d.WorkflowInstance).WithMany(p => p.WorkflowTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowT__Workf__758D6A5C");
        });

        modelBuilder.Entity<WorkflowTransition>(entity =>
        {
            entity.HasKey(e => e.WorkflowTransitionId).HasName("PK__Workflow__07243D0AAA15BE18");

            entity.Property(e => e.WorkflowTransitionId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowTransitionCreatedByNavigations).HasConstraintName("FK_WorkflowTransition_CreatedBy");

            entity.HasOne(d => d.FromState).WithMany(p => p.WorkflowTransitionFromStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowT__FromS__6462DE5A");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowTransitionLastModifiedByNavigations).HasConstraintName("FK_WorkflowTransition_LastModifiedBy");

            entity.HasOne(d => d.ToState).WithMany(p => p.WorkflowTransitionToStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowT__ToSta__65570293");

            entity.HasOne(d => d.WorkflowDefinition).WithMany(p => p.WorkflowTransitions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowT__Workf__636EBA21");
        });

        modelBuilder.Entity<WorkflowVariable>(entity =>
        {
            entity.HasKey(e => e.WorkflowVariableId).HasName("PK__Workflow__F65698CD8FB387E9");

            entity.Property(e => e.WorkflowVariableId).ValueGeneratedNever();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WorkflowVariableCreatedByNavigations).HasConstraintName("FK_WorkflowVariable_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.WorkflowVariableLastModifiedByNavigations).HasConstraintName("FK_WorkflowVariable_LastModifiedBy");

            entity.HasOne(d => d.WorkflowInstance).WithMany(p => p.WorkflowVariables)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowV__Workf__0B7CAB7B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
