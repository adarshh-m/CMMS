using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Tenant", Schema = "security")]
[Index("TenantCode", Name = "UX_Tenant_Code", IsUnique = true)]
public partial class Tenant
{
    [Key]
    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TenantCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string TenantName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? TimeZone { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CurrencyCode { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<Abcclassification> Abcclassifications { get; set; } = new List<Abcclassification>();

    [InverseProperty("Tenant")]
    public virtual ICollection<ApiClient> ApiClients { get; set; } = new List<ApiClient>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetCategory> AssetCategories { get; set; } = new List<AssetCategory>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetCriticality> AssetCriticalities { get; set; } = new List<AssetCriticality>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetGroupEntry> AssetGroupEntries { get; set; } = new List<AssetGroupEntry>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetGroup> AssetGroups { get; set; } = new List<AssetGroup>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetHierarchy> AssetHierarchies { get; set; } = new List<AssetHierarchy>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetLocation> AssetLocations { get; set; } = new List<AssetLocation>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetStatus> AssetStatuses { get; set; } = new List<AssetStatus>();

    [InverseProperty("Tenant")]
    public virtual ICollection<AssetType> AssetTypes { get; set; } = new List<AssetType>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Breakdown> Breakdowns { get; set; } = new List<Breakdown>();

    [InverseProperty("Tenant")]
    public virtual ICollection<CalibrationAsset> CalibrationAssets { get; set; } = new List<CalibrationAsset>();

    [InverseProperty("Tenant")]
    public virtual ICollection<CalibrationComplianceSnapshot> CalibrationComplianceSnapshots { get; set; } = new List<CalibrationComplianceSnapshot>();

    [InverseProperty("Tenant")]
    public virtual ICollection<CalibrationExecution> CalibrationExecutions { get; set; } = new List<CalibrationExecution>();

    [InverseProperty("Tenant")]
    public virtual ICollection<CalibrationMethod> CalibrationMethods { get; set; } = new List<CalibrationMethod>();

    [InverseProperty("Tenant")]
    public virtual ICollection<CalibrationSchedule> CalibrationSchedules { get; set; } = new List<CalibrationSchedule>();

    [InverseProperty("Tenant")]
    public virtual ICollection<CalibrationStandard> CalibrationStandards { get; set; } = new List<CalibrationStandard>();

    [InverseProperty("Tenant")]
    public virtual ICollection<CalibrationWorkOrder> CalibrationWorkOrders { get; set; } = new List<CalibrationWorkOrder>();

    [InverseProperty("Tenant")]
    public virtual ICollection<ChecklistExecution> ChecklistExecutions { get; set; } = new List<ChecklistExecution>();

    [InverseProperty("Tenant")]
    public virtual ICollection<ChecklistTemplate> ChecklistTemplates { get; set; } = new List<ChecklistTemplate>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("TenantCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<CycleCount> CycleCounts { get; set; } = new List<CycleCount>();

    [InverseProperty("Tenant")]
    public virtual ICollection<DeadStockAnalysis> DeadStockAnalyses { get; set; } = new List<DeadStockAnalysis>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [InverseProperty("Tenant")]
    public virtual ICollection<ElectronicSignaturePolicy> ElectronicSignaturePolicies { get; set; } = new List<ElectronicSignaturePolicy>();

    [InverseProperty("Tenant")]
    public virtual ICollection<ElectronicSignatureRequest> ElectronicSignatureRequests { get; set; } = new List<ElectronicSignatureRequest>();

    [InverseProperty("Tenant")]
    public virtual ICollection<EventDeadLetter> EventDeadLetters { get; set; } = new List<EventDeadLetter>();

    [InverseProperty("Tenant")]
    public virtual ICollection<EventOutbox> EventOutboxes { get; set; } = new List<EventOutbox>();

    [InverseProperty("Tenant")]
    public virtual ICollection<GoodsReceiptNote> GoodsReceiptNotes { get; set; } = new List<GoodsReceiptNote>();

    [InverseProperty("Tenant")]
    public virtual ICollection<IntegrationInbox> IntegrationInboxes { get; set; } = new List<IntegrationInbox>();

    [InverseProperty("Tenant")]
    public virtual ICollection<IntegrationMessage> IntegrationMessages { get; set; } = new List<IntegrationMessage>();

    [InverseProperty("Tenant")]
    public virtual ICollection<IntegrationOutbox> IntegrationOutboxes { get; set; } = new List<IntegrationOutbox>();

    [InverseProperty("Tenant")]
    public virtual ICollection<IntegrationSystem> IntegrationSystems { get; set; } = new List<IntegrationSystem>();

    [InverseProperty("Tenant")]
    public virtual ICollection<InventoryForecast> InventoryForecasts { get; set; } = new List<InventoryForecast>();

    [InverseProperty("Tenant")]
    public virtual ICollection<InventoryIntegrationLog> InventoryIntegrationLogs { get; set; } = new List<InventoryIntegrationLog>();

    [InverseProperty("Tenant")]
    public virtual ICollection<InventoryReceipt> InventoryReceipts { get; set; } = new List<InventoryReceipt>();

    [InverseProperty("Tenant")]
    public virtual ICollection<InventoryStockAgeing> InventoryStockAgeings { get; set; } = new List<InventoryStockAgeing>();

    [InverseProperty("Tenant")]
    public virtual ICollection<InventoryTransactionOutbox> InventoryTransactionOutboxes { get; set; } = new List<InventoryTransactionOutbox>();

    [InverseProperty("Tenant")]
    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    [InverseProperty("Tenant")]
    public virtual ICollection<InventoryValuationSnapshot> InventoryValuationSnapshots { get; set; } = new List<InventoryValuationSnapshot>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("TenantLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<Localization> Localizations { get; set; } = new List<Localization>();

    [InverseProperty("Tenant")]
    public virtual ICollection<LookupBase> LookupBases { get; set; } = new List<LookupBase>();

    [InverseProperty("Tenant")]
    public virtual ICollection<MaintenanceGroup> MaintenanceGroups { get; set; } = new List<MaintenanceGroup>();

    [InverseProperty("Tenant")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    [InverseProperty("Tenant")]
    public virtual ICollection<NotificationEscalationRule> NotificationEscalationRules { get; set; } = new List<NotificationEscalationRule>();

    [InverseProperty("Tenant")]
    public virtual ICollection<NotificationEvent> NotificationEvents { get; set; } = new List<NotificationEvent>();

    [InverseProperty("Tenant")]
    public virtual ICollection<NotificationMessage> NotificationMessages { get; set; } = new List<NotificationMessage>();

    [InverseProperty("Tenant")]
    public virtual ICollection<NotificationSubscription> NotificationSubscriptions { get; set; } = new List<NotificationSubscription>();

    [InverseProperty("Tenant")]
    public virtual ICollection<NotificationTemplate> NotificationTemplates { get; set; } = new List<NotificationTemplate>();

    [InverseProperty("Tenant")]
    public virtual ICollection<PermitBlockingRule> PermitBlockingRules { get; set; } = new List<PermitBlockingRule>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Permit> Permits { get; set; } = new List<Permit>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();

    [InverseProperty("Tenant")]
    public virtual ICollection<PmcomplianceSnapshot> PmcomplianceSnapshots { get; set; } = new List<PmcomplianceSnapshot>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Pmschedule> Pmschedules { get; set; } = new List<Pmschedule>();

    [InverseProperty("Tenant")]
    public virtual ICollection<PmworkOrder> PmworkOrders { get; set; } = new List<PmworkOrder>();

    [InverseProperty("Tenant")]
    public virtual ICollection<ProductionLine> ProductionLines { get; set; } = new List<ProductionLine>();

    [InverseProperty("Tenant")]
    public virtual ICollection<PurchaseReceipt> PurchaseReceipts { get; set; } = new List<PurchaseReceipt>();

    [InverseProperty("Tenant")]
    public virtual ICollection<ReorderSuggestion> ReorderSuggestions { get; set; } = new List<ReorderSuggestion>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [InverseProperty("Tenant")]
    public virtual ICollection<SlaInstance> SlaInstances { get; set; } = new List<SlaInstance>();

    [InverseProperty("Tenant")]
    public virtual ICollection<SpareRequest> SpareRequests { get; set; } = new List<SpareRequest>();

    [InverseProperty("Tenant")]
    public virtual ICollection<StockSnapshot> StockSnapshots { get; set; } = new List<StockSnapshot>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    [InverseProperty("Tenant")]
    public virtual ICollection<TenantFeature> TenantFeatures { get; set; } = new List<TenantFeature>();

    [InverseProperty("Tenant")]
    public virtual ICollection<TenantLanguage> TenantLanguages { get; set; } = new List<TenantLanguage>();

    [InverseProperty("Tenant")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    [InverseProperty("Tenant")]
    public virtual ICollection<WebhookSubscription> WebhookSubscriptions { get; set; } = new List<WebhookSubscription>();

    [InverseProperty("Tenant")]
    public virtual ICollection<WorkCenter> WorkCenters { get; set; } = new List<WorkCenter>();

    [InverseProperty("Tenant")]
    public virtual ICollection<WorkOrderAssignment> WorkOrderAssignments { get; set; } = new List<WorkOrderAssignment>();

    [InverseProperty("Tenant")]
    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

    [InverseProperty("Tenant")]
    public virtual ICollection<WorkflowDefinition> WorkflowDefinitions { get; set; } = new List<WorkflowDefinition>();

    [InverseProperty("Tenant")]
    public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; } = new List<WorkflowInstance>();
}
