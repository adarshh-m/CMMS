////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.

////builder.Services.AddControllers();
////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();

////app.UseAuthorization();

////app.MapControllers();

////app.Run();

//using Microsoft.AspNetCore.OData;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OData.ModelBuilder;
//using MaintManagement.Models;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<CmmsContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var modelBuilder = new ODataConventionModelBuilder();

//modelBuilder.EntitySet<Asset>("Asset");
//modelBuilder.EntitySet<AssetType>("AssetType");
//modelBuilder.EntitySet<Abcclassification>("Abcclassification");
//modelBuilder.EntitySet<Area>("Area");
//modelBuilder.EntitySet<AssetCategory>("AssetCategory");
//modelBuilder.EntitySet<Asset>("Asset");
//modelBuilder.EntitySet<AssetCriticality>("AssetCriticality");
//modelBuilder.EntitySet<AssetHierarchy>("AssetHierarchy");
//modelBuilder.EntitySet<AssetLocation>("AssetLocation");
//modelBuilder.EntitySet<AssetStatus>("AssetStatus");
//modelBuilder.EntitySet<AssetType>("AssetType");
//modelBuilder.EntitySet<AuditEvent>("AuditEvent");
//modelBuilder.EntitySet<BreakdownApproval>("BreakdownApproval");
//modelBuilder.EntitySet<BreakdownFailure>("BreakdownFailure");
//modelBuilder.EntitySet<BreakdownWhyAnalysis>("BreakdownWhyAnalysis");
//modelBuilder.EntitySet<CalibrationAsset>("CalibrationAsset");
//modelBuilder.EntitySet<CalibrationCertificate>("CalibrationCertificate");
//modelBuilder.EntitySet<CalibrationComplianceSnapshot>("CalibrationComplianceSnapshot");
//modelBuilder.EntitySet<CalibrationEvidence>("CalibrationEvidence");
//modelBuilder.EntitySet<CalibrationExecution>("CalibrationExecution");
//modelBuilder.EntitySet<CalibrationOotassessment>("CalibrationOOTAssessment");
//modelBuilder.EntitySet<CalibrationReading>("CalibrationReading");
//modelBuilder.EntitySet<CalibrationSchedule>("CalibrationSchedule");
//modelBuilder.EntitySet<CalibrationStandard>("CalibrationStandard");
//modelBuilder.EntitySet<CalibrationVersion>("CalibrationVersion");
//modelBuilder.EntitySet<ChecklistExecutionSection>("ChecklistExecutionSection");
//modelBuilder.EntitySet<ChecklistQuestionOption>("ChecklistQuestionOption");
//modelBuilder.EntitySet<ChecklistResponseAttachment>("ChecklistResponseAttachment");
//modelBuilder.EntitySet<ChecklistResponse>("ChecklistResponse");
//modelBuilder.EntitySet<ChecklistRule>("ChecklistRule");
//modelBuilder.EntitySet<ChecklistScore>("ChecklistScore");
//modelBuilder.EntitySet<ChecklistSection>("ChecklistSection");
//modelBuilder.EntitySet<ChecklistVersion>("ChecklistVersion");
//modelBuilder.EntitySet<CycleCount>("CycleCount");
//modelBuilder.EntitySet<DeadStockAnalysis>("DeadStockAnalysis");
//modelBuilder.EntitySet<Department>("Department");
//modelBuilder.EntitySet<ElectronicSignatureAttachment>("ElectronicSignatureAttachment");
//modelBuilder.EntitySet<ElectronicSignatureAudit>("ElectronicSignatureAudit");
//modelBuilder.EntitySet<ElectronicSignatureChallenge>("ElectronicSignatureChallenge");
//modelBuilder.EntitySet<ElectronicSignatureMeaning>("ElectronicSignatureMeaning");
//modelBuilder.EntitySet<ElectronicSignaturePurpose>("ElectronicSignaturePurpose");
//modelBuilder.EntitySet<ElectronicSignatureRoleAssignment>("ElectronicSignatureRoleAssignment");
//modelBuilder.EntitySet<ElectronicSignatureRole>("ElectronicSignatureRole");
//modelBuilder.EntitySet<ElectronicSignatureSequence>("ElectronicSignatureSequence");
//modelBuilder.EntitySet<ElectronicSignatureVerification>("ElectronicSignatureVerification");
//modelBuilder.EntitySet<ElectronicSignature>("ElectronicSignature");
//modelBuilder.EntitySet<EventBatch>("EventBatch");
//modelBuilder.EntitySet<EventConsumerOffset>("EventConsumerOffset");
//modelBuilder.EntitySet<EventDeadLetter>("EventDeadLetter");
//modelBuilder.EntitySet<EventInbox>("EventInbox");
//modelBuilder.EntitySet<EventPublicationLog>("EventPublicationLog");
//modelBuilder.EntitySet<EventReplayRequest>("EventReplayRequest");
//modelBuilder.EntitySet<EventSchema>("EventSchema");
//modelBuilder.EntitySet<EventSubscription>("EventSubscription");
//modelBuilder.EntitySet<EventType>("EventType");
//modelBuilder.EntitySet<Feature>("Feature");
//modelBuilder.EntitySet<GoodsReceiptNote>("GoodsReceiptNote");
//modelBuilder.EntitySet<IntegrationBatch>("IntegrationBatch");
//modelBuilder.EntitySet<IntegrationConfiguration>("IntegrationConfiguration");
//modelBuilder.EntitySet<IntegrationCredential>("IntegrationCredential");
//modelBuilder.EntitySet<IntegrationDeadLetter>("IntegrationDeadLetter");
//modelBuilder.EntitySet<IntegrationEndpoint>("IntegrationEndpoint");
//modelBuilder.EntitySet<IntegrationEvent>("IntegrationEvent");
//modelBuilder.EntitySet<IntegrationInbox>("IntegrationInbox");
//modelBuilder.EntitySet<IntegrationMapping>("IntegrationMapping");
//modelBuilder.EntitySet<IntegrationOutbox>("IntegrationOutbox");
//modelBuilder.EntitySet<IntegrationRetry>("IntegrationRetry");
//modelBuilder.EntitySet<IntegrationSchedule>("IntegrationSchedule");
//modelBuilder.EntitySet<IntegrationSubscription>("IntegrationSubscription");
//modelBuilder.EntitySet<IntegrationSystem>("IntegrationSystem");
//modelBuilder.EntitySet<InventoryAdjustment>("InventoryAdjustment");
//modelBuilder.EntitySet<InventoryConsumption>("InventoryConsumption");
//modelBuilder.EntitySet<InventoryCycleCountLine>("InventoryCycleCountLine");
//modelBuilder.EntitySet<InventoryForecast>("InventoryForecast");
//modelBuilder.EntitySet<InventoryIntegrationLog>("InventoryIntegrationLog");
//modelBuilder.EntitySet<InventoryIssue>("InventoryIssue");
//modelBuilder.EntitySet<InventoryReceipt>("InventoryReceipt");
//modelBuilder.EntitySet<InventoryReceiptItem>("InventoryReceiptItem");
//modelBuilder.EntitySet<InventoryTransfer>("InventoryTransfer");
//modelBuilder.EntitySet<InventoryValuationSnapshot>("InventoryValuationSnapshot");
//modelBuilder.EntitySet<Language>("Language");
//modelBuilder.EntitySet<MaintenanceRequest>("MaintenanceRequest");
//modelBuilder.EntitySet<MaterialAlternate>("MaterialAlternate");
//modelBuilder.EntitySet<Material>("Material");
//modelBuilder.EntitySet<MaterialVendor>("MaterialVendor");
//modelBuilder.EntitySet<MaterialWarehouse>("MaterialWarehouse");
//modelBuilder.EntitySet<MenuPermission>("MenuPermission");
//modelBuilder.EntitySet<NotificationAttachment>("NotificationAttachment");
//modelBuilder.EntitySet<NotificationDelivery>("NotificationDelivery");
//modelBuilder.EntitySet<NotificationMessage>("NotificationMessage");
//modelBuilder.EntitySet<NotificationPreference>("NotificationPreference");
//modelBuilder.EntitySet<NotificationRecipient>("NotificationRecipient");
//modelBuilder.EntitySet<NotificationRetry>("NotificationRetry");
//modelBuilder.EntitySet<NotificationSubscription>("NotificationSubscription");
//modelBuilder.EntitySet<NotificationTemplate>("NotificationTemplate");
//modelBuilder.EntitySet<NotificationTemplateTranslation>("NotificationTemplateTranslation");
//modelBuilder.EntitySet<Permission>("Permission");
//modelBuilder.EntitySet<PermitAsset>("PermitAsset");
//modelBuilder.EntitySet<PermitClosure>("PermitClosure");
//modelBuilder.EntitySet<PermitControlMeasure>("PermitControlMeasure");
//modelBuilder.EntitySet<PermitExtension>("PermitExtension");
//modelBuilder.EntitySet<PermitSignature>("PermitSignature");
//modelBuilder.EntitySet<PermitWorkIsolation>("PermitWorkIsolation");
//modelBuilder.EntitySet<PmcycleRule>("PMCycleRule");
//modelBuilder.EntitySet<PmexecutionReading>("PMExecutionReading");
//modelBuilder.EntitySet<Pmforecast>("PMForecast");
//modelBuilder.EntitySet<PmgenerationLog>("PMGenerationLog");
//modelBuilder.EntitySet<PmquantityRule>("PMQuantityRule");
//modelBuilder.EntitySet<PmscheduleAsset>("PMScheduleAsset");
//modelBuilder.EntitySet<PmscheduleChecklist>("PMScheduleChecklist");
//modelBuilder.EntitySet<Pmschedule>("PMSchedule");
//modelBuilder.EntitySet<PmtriggerHistory>("PMTriggerHistory");
//modelBuilder.EntitySet<RolePermission>("RolePermission");
//modelBuilder.EntitySet<StockSnapshot>("StockSnapshot");
//modelBuilder.EntitySet<SystemMessage>("SystemMessage");
//modelBuilder.EntitySet<SystemMessageTranslation>("SystemMessageTranslation");
//modelBuilder.EntitySet<Tenant>("Tenant");
//modelBuilder.EntitySet<TenantFeature>("TenantFeature");
//modelBuilder.EntitySet<TenantLanguage>("TenantLanguage");
//modelBuilder.EntitySet<UserDepartment>("UserDepartment");
//modelBuilder.EntitySet<UserPlant>("UserPlant");
//modelBuilder.EntitySet<WebhookRequestLog>("WebhookRequestLog");
//modelBuilder.EntitySet<WebhookSubscription>("WebhookSubscription");
//modelBuilder.EntitySet<WorkCenter>("WorkCenter");
//modelBuilder.EntitySet<WorkflowAction>("WorkflowAction");
//modelBuilder.EntitySet<WorkflowApproval>("WorkflowApproval");
//modelBuilder.EntitySet<WorkflowDefinition>("WorkflowDefinition");
//modelBuilder.EntitySet<WorkflowEscalation>("WorkflowEscalation");
//modelBuilder.EntitySet<WorkflowHistory>("WorkflowHistory");
//modelBuilder.EntitySet<WorkflowInstance>("WorkflowInstance");
//modelBuilder.EntitySet<WorkflowInstanceState>("WorkflowInstanceState");
//modelBuilder.EntitySet<WorkflowRoleAssignment>("WorkflowRoleAssignment");
//modelBuilder.EntitySet<WorkflowRule>("WorkflowRule");
//modelBuilder.EntitySet<WorkflowState>("WorkflowState");
//modelBuilder.EntitySet<WorkflowTransition>("WorkflowTransition");
//modelBuilder.EntitySet<WorkflowVariable>("WorkflowVariable");

//modelBuilder.EntitySet<ApiClient>("ApiClient");
//modelBuilder.EntitySet<Attachment>("Attachment");
//modelBuilder.EntitySet<Breakdown>("Breakdown");
//modelBuilder.EntitySet<BreakdownCause>("BreakdownCause");
//modelBuilder.EntitySet<BreakdownCorrectiveAction>("BreakdownCorrectiveAction");
//modelBuilder.EntitySet<BreakdownEvidence>("BreakdownEvidence");
//modelBuilder.EntitySet<BreakdownInvestigation>("BreakdownInvestigation");
//modelBuilder.EntitySet<BreakdownPreventiveAction>("BreakdownPreventiveAction");
//modelBuilder.EntitySet<BreakdownVerification>("BreakdownVerification");
//modelBuilder.EntitySet<CalibrationMethod>("CalibrationMethod");
//modelBuilder.EntitySet<CalibrationResult>("CalibrationResult");
//modelBuilder.EntitySet<CalibrationSignature>("CalibrationSignature");
//modelBuilder.EntitySet<CalibrationWorkOrder>("CalibrationWorkOrder");
//modelBuilder.EntitySet<ChecklistExecution>("ChecklistExecution");
//modelBuilder.EntitySet<ChecklistQuestion>("ChecklistQuestion");
//modelBuilder.EntitySet<ChecklistSignature>("ChecklistSignature");
//modelBuilder.EntitySet<ChecklistTemplate>("ChecklistTemplate");
////modelBuilder.EntitySet<ElectronicSignature1>("ElectronicSignature");
//modelBuilder.EntitySet<ElectronicSignaturePolicy>("ElectronicSignaturePolicy");
//modelBuilder.EntitySet<ElectronicSignatureRequest>("ElectronicSignatureRequest");
//modelBuilder.EntitySet<EventOutbox>("EventOutbox");
//modelBuilder.EntitySet<IntegrationMessage>("IntegrationMessage");
//modelBuilder.EntitySet<InventoryBalance>("InventoryBalance");
//modelBuilder.EntitySet<InventoryLot>("InventoryLot");
//modelBuilder.EntitySet<InventoryReservation>("InventoryReservation");
//modelBuilder.EntitySet<InventoryReturn>("InventoryReturn");
//modelBuilder.EntitySet<InventorySerial>("InventorySerial");
//modelBuilder.EntitySet<InventoryStockAgeing>("InventoryStockAgeing");
//modelBuilder.EntitySet<InventoryTransaction>("InventoryTransaction");
//modelBuilder.EntitySet<InventoryTransactionOutbox>("InventoryTransactionOutbox");
//modelBuilder.EntitySet<Localization>("Localization");
//modelBuilder.EntitySet<LoginHistory>("LoginHistory");
//modelBuilder.EntitySet<LookupBase>("LookupBase");
//modelBuilder.EntitySet<MaterialCostLedger>("MaterialCostLedger");
//modelBuilder.EntitySet<Menu>("Menu");
//modelBuilder.EntitySet<NotificationEscalationRule>("NotificationEscalationRule");
//modelBuilder.EntitySet<NotificationEvent>("NotificationEvent");
//modelBuilder.EntitySet<PasswordHistory>("PasswordHistory");
//modelBuilder.EntitySet<Permit>("Permit");
//modelBuilder.EntitySet<PermitApproval>("PermitApproval");
//modelBuilder.EntitySet<PermitAttachment>("PermitAttachment");
//modelBuilder.EntitySet<PermitBlockingRule>("PermitBlockingRule");
//modelBuilder.EntitySet<PermitEmployee>("PermitEmployee");
//modelBuilder.EntitySet<PermitHazard>("PermitHazard");
//modelBuilder.EntitySet<HazardMaster>("HazardMaster");

//modelBuilder.EntitySet<PermitIssue>("PermitIssue");
//modelBuilder.EntitySet<PermitRiskAssessment>("PermitRiskAssessment");
//modelBuilder.EntitySet<PermitSuspend>("PermitSuspend");
//modelBuilder.EntitySet<Plant>("Plant");
//modelBuilder.EntitySet<PmcalendarRule>("PMCalendarRule");
//modelBuilder.EntitySet<PmcomplianceSnapshot>("PMComplianceSnapshot");
//modelBuilder.EntitySet<Pmexecution>("PMExecution");
//modelBuilder.EntitySet<PmexecutionChecklist>("PMExecutionChecklist");
//modelBuilder.EntitySet<PmruntimeRule>("PMRuntimeRule");
//modelBuilder.EntitySet<PmworkOrder>("PMWorkOrder");
//modelBuilder.EntitySet<ProductionLine>("ProductionLine");
//modelBuilder.EntitySet<PurchaseReceipt>("PurchaseReceipt");
//modelBuilder.EntitySet<PurchaseReceiptItem>("PurchaseReceiptItem");
//modelBuilder.EntitySet<RefreshToken>("RefreshToken");
//modelBuilder.EntitySet<ReorderSuggestion>("ReorderSuggestion");
//modelBuilder.EntitySet<Role>("Roles");
//modelBuilder.EntitySet<SecurityAudit>("SecurityAudit");
//modelBuilder.EntitySet<Session>("Session");
//modelBuilder.EntitySet<SlaInstance>("SlaInstance");
//modelBuilder.EntitySet<SpareRequest>("SpareRequest");
//modelBuilder.EntitySet<SpareRequestItem>("SpareRequestItem");
//modelBuilder.EntitySet<StorageLocation>("StorageLocation");
//modelBuilder.EntitySet<Team>("Team");
//modelBuilder.EntitySet<User>("Users");
//modelBuilder.EntitySet<UserClaim>("UserClaim");
//modelBuilder.EntitySet<UserRole>("UserRoles");
//modelBuilder.EntitySet<UserTeam>("UserTeam");
//modelBuilder.EntitySet<Warehouse>("Warehouse");
//modelBuilder.EntitySet<WorkOrder>("WorkOrder");
//modelBuilder.EntitySet<WorkOrderAssignment>("WorkOrderAssignment");
//modelBuilder.EntitySet<WorkflowComment>("WorkflowComment");
//modelBuilder.EntitySet<WorkflowNotification>("WorkflowNotification");
//modelBuilder.EntitySet<WorkflowTask>("WorkflowTask");


//builder.Services.AddControllers()
//    .AddOData(options =>
//    {
//        options.AddRouteComponents("odata", modelBuilder.GetEdmModel())
//            .Select()
//            .Filter()
//            .OrderBy()
//            .Expand()
//            .Count();
//    });

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())

//{

//    app.UseSwagger();

//    app.UseSwaggerUI();

//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

//using Microsoft.AspNetCore.OData;

//using Microsoft.EntityFrameworkCore;

//using Microsoft.OData.ModelBuilder;

//using MaintManagement.Models;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<CmmsContext>(options =>

//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddCors(options =>

//{

//    options.AddPolicy("AllowAll", policy =>

//    {

//        policy.AllowAnyOrigin()

//              .AllowAnyHeader()

//              .AllowAnyMethod();

//    });

//});

//var modelBuilder = new ODataConventionModelBuilder();

//modelBuilder.EntitySet<Asset>("Asset");

//modelBuilder.EntitySet<AssetType>("AssetType");

//modelBuilder.EntitySet<Abcclassification>("Abcclassification");

//modelBuilder.EntitySet<Area>("Area");

//modelBuilder.EntitySet<AssetCategory>("AssetCategory");

//modelBuilder.EntitySet<Asset>("Asset");

//modelBuilder.EntitySet<AssetCriticality>("AssetCriticality");

//modelBuilder.EntitySet<AssetHierarchy>("AssetHierarchy");

//modelBuilder.EntitySet<AssetLocation>("AssetLocation");

//modelBuilder.EntitySet<AssetStatus>("AssetStatus");

//modelBuilder.EntitySet<AssetType>("AssetType");

//modelBuilder.EntitySet<AuditEvent>("AuditEvent");

//modelBuilder.EntitySet<BreakdownApproval>("BreakdownApproval");

//modelBuilder.EntitySet<BreakdownFailure>("BreakdownFailure");

//modelBuilder.EntitySet<BreakdownWhyAnalysis>("BreakdownWhyAnalysis");

//modelBuilder.EntitySet<CalibrationAsset>("CalibrationAsset");

//modelBuilder.EntitySet<CalibrationCertificate>("CalibrationCertificate");

//modelBuilder.EntitySet<CalibrationComplianceSnapshot>("CalibrationComplianceSnapshot");

//modelBuilder.EntitySet<CalibrationEvidence>("CalibrationEvidence");

//modelBuilder.EntitySet<CalibrationExecution>("CalibrationExecution");

//modelBuilder.EntitySet<CalibrationOotassessment>("CalibrationOOTAssessment");

//modelBuilder.EntitySet<CalibrationReading>("CalibrationReading");

//modelBuilder.EntitySet<CalibrationSchedule>("CalibrationSchedule");

//modelBuilder.EntitySet<CalibrationStandard>("CalibrationStandard");

//modelBuilder.EntitySet<CalibrationVersion>("CalibrationVersion");

//modelBuilder.EntitySet<ChecklistExecutionSection>("ChecklistExecutionSection");

//modelBuilder.EntitySet<ChecklistQuestionOption>("ChecklistQuestionOption");

//modelBuilder.EntitySet<ChecklistResponseAttachment>("ChecklistResponseAttachment");

//modelBuilder.EntitySet<ChecklistResponse>("ChecklistResponse");

//modelBuilder.EntitySet<ChecklistRule>("ChecklistRule");

//modelBuilder.EntitySet<ChecklistScore>("ChecklistScore");

//modelBuilder.EntitySet<ChecklistSection>("ChecklistSection");

//modelBuilder.EntitySet<ChecklistVersion>("ChecklistVersion");

//modelBuilder.EntitySet<CycleCount>("CycleCount");

//modelBuilder.EntitySet<DeadStockAnalysis>("DeadStockAnalysis");

//modelBuilder.EntitySet<Department>("Department");

//modelBuilder.EntitySet<ElectronicSignatureAttachment>("ElectronicSignatureAttachment");

//modelBuilder.EntitySet<ElectronicSignatureAudit>("ElectronicSignatureAudit");

//modelBuilder.EntitySet<ElectronicSignatureChallenge>("ElectronicSignatureChallenge");

//modelBuilder.EntitySet<ElectronicSignatureMeaning>("ElectronicSignatureMeaning");

//modelBuilder.EntitySet<ElectronicSignaturePurpose>("ElectronicSignaturePurpose");

//modelBuilder.EntitySet<ElectronicSignatureRoleAssignment>("ElectronicSignatureRoleAssignment");

//modelBuilder.EntitySet<ElectronicSignatureRole>("ElectronicSignatureRole");

//modelBuilder.EntitySet<ElectronicSignatureSequence>("ElectronicSignatureSequence");

//modelBuilder.EntitySet<ElectronicSignatureVerification>("ElectronicSignatureVerification");

//modelBuilder.EntitySet<ElectronicSignature>("ElectronicSignature");

//modelBuilder.EntitySet<EventBatch>("EventBatch");

//modelBuilder.EntitySet<EventConsumerOffset>("EventConsumerOffset");

//modelBuilder.EntitySet<EventDeadLetter>("EventDeadLetter");

//modelBuilder.EntitySet<EventInbox>("EventInbox");

//modelBuilder.EntitySet<EventPublicationLog>("EventPublicationLog");

//modelBuilder.EntitySet<EventReplayRequest>("EventReplayRequest");

//modelBuilder.EntitySet<EventSchema>("EventSchema");

//modelBuilder.EntitySet<EventSubscription>("EventSubscription");

//modelBuilder.EntitySet<EventType>("EventType");

//modelBuilder.EntitySet<Feature>("Feature");

//modelBuilder.EntitySet<GoodsReceiptNote>("GoodsReceiptNote");

//modelBuilder.EntitySet<IntegrationBatch>("IntegrationBatch");

//modelBuilder.EntitySet<IntegrationConfiguration>("IntegrationConfiguration");

//modelBuilder.EntitySet<IntegrationCredential>("IntegrationCredential");

//modelBuilder.EntitySet<IntegrationDeadLetter>("IntegrationDeadLetter");

//modelBuilder.EntitySet<IntegrationEndpoint>("IntegrationEndpoint");

//modelBuilder.EntitySet<IntegrationEvent>("IntegrationEvent");

//modelBuilder.EntitySet<IntegrationInbox>("IntegrationInbox");

//modelBuilder.EntitySet<IntegrationMapping>("IntegrationMapping");

//modelBuilder.EntitySet<IntegrationOutbox>("IntegrationOutbox");

//modelBuilder.EntitySet<IntegrationRetry>("IntegrationRetry");

//modelBuilder.EntitySet<IntegrationSchedule>("IntegrationSchedule");

//modelBuilder.EntitySet<IntegrationSubscription>("IntegrationSubscription");

//modelBuilder.EntitySet<IntegrationSystem>("IntegrationSystem");

//modelBuilder.EntitySet<InventoryAdjustment>("InventoryAdjustment");

//modelBuilder.EntitySet<InventoryConsumption>("InventoryConsumption");

//modelBuilder.EntitySet<InventoryCycleCountLine>("InventoryCycleCountLine");

//modelBuilder.EntitySet<InventoryForecast>("InventoryForecast");

//modelBuilder.EntitySet<InventoryIntegrationLog>("InventoryIntegrationLog");

//modelBuilder.EntitySet<InventoryIssue>("InventoryIssue");

//modelBuilder.EntitySet<InventoryReceipt>("InventoryReceipt");

//modelBuilder.EntitySet<InventoryReceiptItem>("InventoryReceiptItem");

//modelBuilder.EntitySet<InventoryTransfer>("InventoryTransfer");

//modelBuilder.EntitySet<InventoryValuationSnapshot>("InventoryValuationSnapshot");

//modelBuilder.EntitySet<Language>("Language");

//modelBuilder.EntitySet<MaintenanceRequest>("MaintenanceRequest");

//modelBuilder.EntitySet<MaterialAlternate>("MaterialAlternate");

//modelBuilder.EntitySet<Material>("Material");

//modelBuilder.EntitySet<MaterialVendor>("MaterialVendor");

//modelBuilder.EntitySet<MaterialWarehouse>("MaterialWarehouse");

//modelBuilder.EntitySet<MenuPermission>("MenuPermission");

//modelBuilder.EntitySet<NotificationAttachment>("NotificationAttachment");

//modelBuilder.EntitySet<NotificationDelivery>("NotificationDelivery");

//modelBuilder.EntitySet<NotificationMessage>("NotificationMessage");

//modelBuilder.EntitySet<NotificationPreference>("NotificationPreference");

//modelBuilder.EntitySet<NotificationRecipient>("NotificationRecipient");

//modelBuilder.EntitySet<NotificationRetry>("NotificationRetry");

//modelBuilder.EntitySet<NotificationSubscription>("NotificationSubscription");

//modelBuilder.EntitySet<NotificationTemplate>("NotificationTemplate");

//modelBuilder.EntitySet<NotificationTemplateTranslation>("NotificationTemplateTranslation");

//modelBuilder.EntitySet<Permission>("Permission");

//modelBuilder.EntitySet<PermitAsset>("PermitAsset");

//modelBuilder.EntitySet<PermitClosure>("PermitClosure");

//modelBuilder.EntitySet<PermitControlMeasure>("PermitControlMeasure");

//modelBuilder.EntitySet<PermitExtension>("PermitExtension");

//modelBuilder.EntitySet<PermitSignature>("PermitSignature");

//modelBuilder.EntitySet<PermitWorkIsolation>("PermitWorkIsolation");

//modelBuilder.EntitySet<PmcycleRule>("PMCycleRule");

//modelBuilder.EntitySet<PmexecutionReading>("PMExecutionReading");

//modelBuilder.EntitySet<Pmforecast>("PMForecast");

//modelBuilder.EntitySet<PmgenerationLog>("PMGenerationLog");

//modelBuilder.EntitySet<PmquantityRule>("PMQuantityRule");

//modelBuilder.EntitySet<PmscheduleAsset>("PMScheduleAsset");

//modelBuilder.EntitySet<PmscheduleChecklist>("PMScheduleChecklist");

//modelBuilder.EntitySet<Pmschedule>("PMSchedule");

//modelBuilder.EntitySet<PmtriggerHistory>("PMTriggerHistory");

//modelBuilder.EntitySet<RolePermission>("RolePermission");

//modelBuilder.EntitySet<StockSnapshot>("StockSnapshot");

//modelBuilder.EntitySet<SystemMessage>("SystemMessage");

//modelBuilder.EntitySet<SystemMessageTranslation>("SystemMessageTranslation");

//modelBuilder.EntitySet<Tenant>("Tenant");

//modelBuilder.EntitySet<TenantFeature>("TenantFeature");

//modelBuilder.EntitySet<TenantLanguage>("TenantLanguage");

//modelBuilder.EntitySet<UserDepartment>("UserDepartment");

//modelBuilder.EntitySet<UserPlant>("UserPlant");

//modelBuilder.EntitySet<WebhookRequestLog>("WebhookRequestLog");

//modelBuilder.EntitySet<WebhookSubscription>("WebhookSubscription");

//modelBuilder.EntitySet<WorkCenter>("WorkCenter");

//modelBuilder.EntitySet<WorkflowAction>("WorkflowAction");

//modelBuilder.EntitySet<WorkflowApproval>("WorkflowApproval");

//modelBuilder.EntitySet<WorkflowDefinition>("WorkflowDefinition");

//modelBuilder.EntitySet<WorkflowEscalation>("WorkflowEscalation");

//modelBuilder.EntitySet<WorkflowHistory>("WorkflowHistory");

//modelBuilder.EntitySet<WorkflowInstance>("WorkflowInstance");

//modelBuilder.EntitySet<WorkflowInstanceState>("WorkflowInstanceState");

//modelBuilder.EntitySet<WorkflowRoleAssignment>("WorkflowRoleAssignment");

//modelBuilder.EntitySet<WorkflowRule>("WorkflowRule");

//modelBuilder.EntitySet<WorkflowState>("WorkflowState");

//modelBuilder.EntitySet<WorkflowTransition>("WorkflowTransition");

//modelBuilder.EntitySet<WorkflowVariable>("WorkflowVariable");

//modelBuilder.EntitySet<ApiClient>("ApiClient");

//modelBuilder.EntitySet<Attachment>("Attachment");

//modelBuilder.EntitySet<Breakdown>("Breakdown");

//modelBuilder.EntitySet<BreakdownCause>("BreakdownCause");

//modelBuilder.EntitySet<BreakdownCorrectiveAction>("BreakdownCorrectiveAction");

//modelBuilder.EntitySet<BreakdownEvidence>("BreakdownEvidence");

//modelBuilder.EntitySet<BreakdownInvestigation>("BreakdownInvestigation");

//modelBuilder.EntitySet<BreakdownPreventiveAction>("BreakdownPreventiveAction");

//modelBuilder.EntitySet<BreakdownVerification>("BreakdownVerification");

//modelBuilder.EntitySet<CalibrationMethod>("CalibrationMethod");

//modelBuilder.EntitySet<CalibrationResult>("CalibrationResult");

//modelBuilder.EntitySet<CalibrationSignature>("CalibrationSignature");

//modelBuilder.EntitySet<CalibrationWorkOrder>("CalibrationWorkOrder");

//modelBuilder.EntitySet<ChecklistExecution>("ChecklistExecution");

//modelBuilder.EntitySet<ChecklistQuestion>("ChecklistQuestion");

//modelBuilder.EntitySet<ChecklistSignature>("ChecklistSignature");

//modelBuilder.EntitySet<ChecklistTemplate>("ChecklistTemplate");

////modelBuilder.EntitySet<ElectronicSignature1>("ElectronicSignature");

//modelBuilder.EntitySet<ElectronicSignaturePolicy>("ElectronicSignaturePolicy");

//modelBuilder.EntitySet<ElectronicSignatureRequest>("ElectronicSignatureRequest");

//modelBuilder.EntitySet<EventOutbox>("EventOutbox");

//modelBuilder.EntitySet<IntegrationMessage>("IntegrationMessage");

//modelBuilder.EntitySet<InventoryBalance>("InventoryBalance");

//modelBuilder.EntitySet<InventoryLot>("InventoryLot");

//modelBuilder.EntitySet<InventoryReservation>("InventoryReservation");

//modelBuilder.EntitySet<InventoryReturn>("InventoryReturn");

//modelBuilder.EntitySet<InventorySerial>("InventorySerial");

//modelBuilder.EntitySet<InventoryStockAgeing>("InventoryStockAgeing");

//modelBuilder.EntitySet<InventoryTransaction>("InventoryTransaction");

//modelBuilder.EntitySet<InventoryTransactionOutbox>("InventoryTransactionOutbox");

//modelBuilder.EntitySet<Localization>("Localization");

//modelBuilder.EntitySet<LoginHistory>("LoginHistory");

//modelBuilder.EntitySet<LookupBase>("LookupBase");

//modelBuilder.EntitySet<MaterialCostLedger>("MaterialCostLedger");

//modelBuilder.EntitySet<Menu>("Menu");

//modelBuilder.EntitySet<NotificationEscalationRule>("NotificationEscalationRule");

//modelBuilder.EntitySet<NotificationEvent>("NotificationEvent");

//modelBuilder.EntitySet<PasswordHistory>("PasswordHistory");

//modelBuilder.EntitySet<Permit>("Permit");

//modelBuilder.EntitySet<PermitApproval>("PermitApproval");

//modelBuilder.EntitySet<PermitAttachment>("PermitAttachment");

//modelBuilder.EntitySet<PermitBlockingRule>("PermitBlockingRule");

//modelBuilder.EntitySet<PermitEmployee>("PermitEmployee");

//modelBuilder.EntitySet<PermitHazard>("PermitHazard");

//modelBuilder.EntitySet<HazardMaster>("HazardMaster");

//modelBuilder.EntitySet<PermitIssue>("PermitIssue");

//modelBuilder.EntitySet<PermitRiskAssessment>("PermitRiskAssessment");

//modelBuilder.EntitySet<PermitSuspend>("PermitSuspend");

//modelBuilder.EntitySet<Plant>("Plant");

//modelBuilder.EntitySet<PmcalendarRule>("PMCalendarRule");

//modelBuilder.EntitySet<PmcomplianceSnapshot>("PMComplianceSnapshot");

//modelBuilder.EntitySet<Pmexecution>("PMExecution");

//modelBuilder.EntitySet<PmexecutionChecklist>("PMExecutionChecklist");

//modelBuilder.EntitySet<PmruntimeRule>("PMRuntimeRule");

//modelBuilder.EntitySet<PmworkOrder>("PMWorkOrder");

//modelBuilder.EntitySet<ProductionLine>("ProductionLine");

//modelBuilder.EntitySet<PurchaseReceipt>("PurchaseReceipt");

//modelBuilder.EntitySet<PurchaseReceiptItem>("PurchaseReceiptItem");

//modelBuilder.EntitySet<RefreshToken>("RefreshToken");

//modelBuilder.EntitySet<ReorderSuggestion>("ReorderSuggestion");

//modelBuilder.EntitySet<Role>("Roles");

//modelBuilder.EntitySet<SecurityAudit>("SecurityAudit");

//modelBuilder.EntitySet<Session>("Session");

//modelBuilder.EntitySet<SlaInstance>("SlaInstance");

//modelBuilder.EntitySet<SpareRequest>("SpareRequest");

//modelBuilder.EntitySet<SpareRequestItem>("SpareRequestItem");

//modelBuilder.EntitySet<StorageLocation>("StorageLocation");

//modelBuilder.EntitySet<Team>("Team");

//modelBuilder.EntitySet<User>("Users");

//modelBuilder.EntitySet<UserClaim>("UserClaim");

//modelBuilder.EntitySet<UserRole>("UserRoles");

//modelBuilder.EntitySet<UserTeam>("UserTeam");

//modelBuilder.EntitySet<Warehouse>("Warehouse");

//modelBuilder.EntitySet<WorkOrder>("WorkOrder");

//modelBuilder.EntitySet<WorkOrderAssignment>("WorkOrderAssignment");

//modelBuilder.EntitySet<WorkflowComment>("WorkflowComment");

//modelBuilder.EntitySet<WorkflowNotification>("WorkflowNotification");

//modelBuilder.EntitySet<WorkflowTask>("WorkflowTask");


//builder.Services.AddControllers()

//    .AddOData(options =>

//    {

//        options.AddRouteComponents("odata", modelBuilder.GetEdmModel())

//            .Select()

//            .Filter()

//            .OrderBy()

//            .Expand()

//            .Count();

//    });

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())

//{

//    app.UseSwagger();

//    app.UseSwaggerUI();

//}

//app.UseCors("AllowAll");

//app.UseHttpsRedirection();


//app.UseAuthorization();

//app.MapControllers();

//app.Run();



using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using MaintManagement.Models;
using YourNamespace.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CmmsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var modelBuilder = new ODataConventionModelBuilder();

modelBuilder.EntitySet<Asset>("Asset");
modelBuilder.EntitySet<AssetType>("AssetType");
modelBuilder.EntitySet<Abcclassification>("Abcclassification");
modelBuilder.EntitySet<Area>("Area");
modelBuilder.EntitySet<AssetCategory>("AssetCategory");
modelBuilder.EntitySet<Asset>("Asset");
modelBuilder.EntitySet<AssetCriticality>("AssetCriticality");
modelBuilder.EntitySet<AssetHierarchy>("AssetHierarchy");
modelBuilder.EntitySet<AssetLocation>("AssetLocation");
modelBuilder.EntitySet<AssetStatus>("AssetStatus");
modelBuilder.EntitySet<AssetType>("AssetType");
modelBuilder.EntitySet<AuditEvent>("AuditEvent");
modelBuilder.EntitySet<BreakdownApproval>("BreakdownApproval");
modelBuilder.EntitySet<BreakdownFailure>("BreakdownFailure");
modelBuilder.EntitySet<BreakdownWhyAnalysis>("BreakdownWhyAnalysis");
modelBuilder.EntitySet<CalibrationAsset>("CalibrationAsset");
modelBuilder.EntitySet<CalibrationCertificate>("CalibrationCertificate");
modelBuilder.EntitySet<CalibrationComplianceSnapshot>("CalibrationComplianceSnapshot");
modelBuilder.EntitySet<CalibrationEvidence>("CalibrationEvidence");
modelBuilder.EntitySet<CalibrationExecution>("CalibrationExecution");
modelBuilder.EntitySet<CalibrationOotassessment>("CalibrationOOTAssessment");
modelBuilder.EntitySet<CalibrationReading>("CalibrationReading");
modelBuilder.EntitySet<CalibrationSchedule>("CalibrationSchedule");
modelBuilder.EntitySet<CalibrationStandard>("CalibrationStandard");
modelBuilder.EntitySet<CalibrationVersion>("CalibrationVersion");
modelBuilder.EntitySet<ChecklistExecutionSection>("ChecklistExecutionSection");
modelBuilder.EntitySet<ChecklistQuestionOption>("ChecklistQuestionOption");
modelBuilder.EntitySet<ChecklistResponseAttachment>("ChecklistResponseAttachment");
modelBuilder.EntitySet<ChecklistResponse>("ChecklistResponse");
modelBuilder.EntitySet<ChecklistRule>("ChecklistRule");
modelBuilder.EntitySet<ChecklistScore>("ChecklistScore");
modelBuilder.EntitySet<ChecklistSection>("ChecklistSection");
modelBuilder.EntitySet<ChecklistVersion>("ChecklistVersion");
modelBuilder.EntitySet<CycleCount>("CycleCount");
modelBuilder.EntitySet<DeadStockAnalysis>("DeadStockAnalysis");
modelBuilder.EntitySet<Department>("Department");
modelBuilder.EntitySet<ElectronicSignatureAttachment>("ElectronicSignatureAttachment");
modelBuilder.EntitySet<ElectronicSignatureAudit>("ElectronicSignatureAudit");
modelBuilder.EntitySet<ElectronicSignatureChallenge>("ElectronicSignatureChallenge");
modelBuilder.EntitySet<ElectronicSignatureMeaning>("ElectronicSignatureMeaning");
modelBuilder.EntitySet<ElectronicSignaturePurpose>("ElectronicSignaturePurpose");
modelBuilder.EntitySet<ElectronicSignatureRoleAssignment>("ElectronicSignatureRoleAssignment");
modelBuilder.EntitySet<ElectronicSignatureRole>("ElectronicSignatureRole");
modelBuilder.EntitySet<ElectronicSignatureSequence>("ElectronicSignatureSequence");
modelBuilder.EntitySet<ElectronicSignatureVerification>("ElectronicSignatureVerification");
modelBuilder.EntitySet<ElectronicSignature>("ElectronicSignature");
modelBuilder.EntitySet<EventBatch>("EventBatch");
modelBuilder.EntitySet<EventConsumerOffset>("EventConsumerOffset");
modelBuilder.EntitySet<EventDeadLetter>("EventDeadLetter");
modelBuilder.EntitySet<EventInbox>("EventInbox");
modelBuilder.EntitySet<EventPublicationLog>("EventPublicationLog");
modelBuilder.EntitySet<EventReplayRequest>("EventReplayRequest");
modelBuilder.EntitySet<EventSchema>("EventSchema");
modelBuilder.EntitySet<EventSubscription>("EventSubscription");
modelBuilder.EntitySet<EventType>("EventType");
modelBuilder.EntitySet<Feature>("Feature");
modelBuilder.EntitySet<FailureCode>("FailureCode");
modelBuilder.EntitySet<AssetGroup>("AssetGroup");

modelBuilder.EntitySet<AssetGroupEntry>("AssetGroupEntry");


modelBuilder.EntitySet<GoodsReceiptNote>("GoodsReceiptNote");
modelBuilder.EntitySet<IntegrationBatch>("IntegrationBatch");
modelBuilder.EntitySet<IntegrationConfiguration>("IntegrationConfiguration");
modelBuilder.EntitySet<IntegrationCredential>("IntegrationCredential");
modelBuilder.EntitySet<IntegrationDeadLetter>("IntegrationDeadLetter");
modelBuilder.EntitySet<IntegrationEndpoint>("IntegrationEndpoint");
modelBuilder.EntitySet<IntegrationEvent>("IntegrationEvent");
modelBuilder.EntitySet<IntegrationInbox>("IntegrationInbox");
modelBuilder.EntitySet<IntegrationMapping>("IntegrationMapping");
modelBuilder.EntitySet<IntegrationOutbox>("IntegrationOutbox");
modelBuilder.EntitySet<IntegrationRetry>("IntegrationRetry");
modelBuilder.EntitySet<IntegrationSchedule>("IntegrationSchedule");
modelBuilder.EntitySet<IntegrationSubscription>("IntegrationSubscription");
modelBuilder.EntitySet<IntegrationSystem>("IntegrationSystem");
modelBuilder.EntitySet<InventoryAdjustment>("InventoryAdjustment");
modelBuilder.EntitySet<InventoryConsumption>("InventoryConsumption");
modelBuilder.EntitySet<InventoryCycleCountLine>("InventoryCycleCountLine");
modelBuilder.EntitySet<InventoryForecast>("InventoryForecast");
modelBuilder.EntitySet<InventoryIntegrationLog>("InventoryIntegrationLog");
modelBuilder.EntitySet<InventoryIssue>("InventoryIssue");
modelBuilder.EntitySet<InventoryReceipt>("InventoryReceipt");
modelBuilder.EntitySet<InventoryReceiptItem>("InventoryReceiptItem");
modelBuilder.EntitySet<InventoryTransfer>("InventoryTransfer");
modelBuilder.EntitySet<InventoryValuationSnapshot>("InventoryValuationSnapshot");
modelBuilder.EntitySet<Language>("Language");
modelBuilder.EntitySet<MaintenanceRequest>("MaintenanceRequest");
modelBuilder.EntitySet<MaterialAlternate>("MaterialAlternate");
modelBuilder.EntitySet<Material>("Material");
modelBuilder.EntitySet<MaterialVendor>("MaterialVendor");
modelBuilder.EntitySet<MaterialWarehouse>("MaterialWarehouse");
modelBuilder.EntitySet<MenuPermission>("MenuPermission");
modelBuilder.EntitySet<NotificationAttachment>("NotificationAttachment");
modelBuilder.EntitySet<NotificationDelivery>("NotificationDelivery");
modelBuilder.EntitySet<NotificationMessage>("NotificationMessage");
modelBuilder.EntitySet<NotificationPreference>("NotificationPreference");
modelBuilder.EntitySet<NotificationRecipient>("NotificationRecipient");
modelBuilder.EntitySet<NotificationRetry>("NotificationRetry");
modelBuilder.EntitySet<NotificationSubscription>("NotificationSubscription");
modelBuilder.EntitySet<NotificationTemplate>("NotificationTemplate");
modelBuilder.EntitySet<NotificationTemplateTranslation>("NotificationTemplateTranslation");
modelBuilder.EntitySet<Permission>("Permission");
modelBuilder.EntitySet<PermitAsset>("PermitAsset");
modelBuilder.EntitySet<PermitClosure>("PermitClosure");
modelBuilder.EntitySet<PermitControlMeasure>("PermitControlMeasure");
modelBuilder.EntitySet<ControlMeasure>("ControlMeasure");

modelBuilder.EntitySet<PermitExtension>("PermitExtension");
modelBuilder.EntitySet<PermitSignature>("PermitSignature");
modelBuilder.EntitySet<PermitWorkIsolation>("PermitWorkIsolation");
modelBuilder.EntitySet<PmcycleRule>("PMCycleRule");
modelBuilder.EntitySet<PmexecutionReading>("PMExecutionReading");
modelBuilder.EntitySet<Pmforecast>("PMForecast");
modelBuilder.EntitySet<PmgenerationLog>("PMGenerationLog");
modelBuilder.EntitySet<PmquantityRule>("PMQuantityRule");
modelBuilder.EntitySet<PmscheduleAsset>("PMScheduleAsset");
modelBuilder.EntitySet<PmscheduleChecklist>("PMScheduleChecklist");
modelBuilder.EntitySet<Pmschedule>("PMSchedule");
modelBuilder.EntitySet<PmtriggerHistory>("PMTriggerHistory");
modelBuilder.EntitySet<RolePermission>("RolePermission");
modelBuilder.EntitySet<StockSnapshot>("StockSnapshot");
modelBuilder.EntitySet<SystemMessage>("SystemMessage");
modelBuilder.EntitySet<SystemMessageTranslation>("SystemMessageTranslation");
modelBuilder.EntitySet<Tenant>("Tenant");
modelBuilder.EntitySet<TenantFeature>("TenantFeature");
modelBuilder.EntitySet<TenantLanguage>("TenantLanguage");
modelBuilder.EntitySet<UserDepartment>("UserDepartment");
modelBuilder.EntitySet<UserPlant>("UserPlant");
modelBuilder.EntitySet<WebhookRequestLog>("WebhookRequestLog");
modelBuilder.EntitySet<WebhookSubscription>("WebhookSubscription");
modelBuilder.EntitySet<WorkCenter>("WorkCenter");
modelBuilder.EntitySet<WorkflowAction>("WorkflowAction");
modelBuilder.EntitySet<WorkflowApproval>("WorkflowApproval");
modelBuilder.EntitySet<WorkflowDefinition>("WorkflowDefinition");
modelBuilder.EntitySet<WorkflowEscalation>("WorkflowEscalation");
modelBuilder.EntitySet<WorkflowHistory>("WorkflowHistory");
modelBuilder.EntitySet<WorkflowInstance>("WorkflowInstance");
modelBuilder.EntitySet<WorkflowInstanceState>("WorkflowInstanceState");
modelBuilder.EntitySet<WorkflowRoleAssignment>("WorkflowRoleAssignment");
modelBuilder.EntitySet<WorkflowRule>("WorkflowRule");
modelBuilder.EntitySet<WorkflowState>("WorkflowState");
modelBuilder.EntitySet<WorkflowTransition>("WorkflowTransition");
modelBuilder.EntitySet<WorkflowVariable>("WorkflowVariable");

modelBuilder.EntitySet<ApiClient>("ApiClient");
modelBuilder.EntitySet<Attachment>("Attachment");
modelBuilder.EntitySet<Breakdown>("Breakdown");
modelBuilder.EntitySet<BreakdownCause>("BreakdownCause");
modelBuilder.EntitySet<CauseCode>("CauseCode");
modelBuilder.EntitySet<MaintenanceGroup>("MaintenanceGroup");

modelBuilder.EntitySet<BreakdownCorrectiveAction>("BreakdownCorrectiveAction");
modelBuilder.EntitySet<BreakdownEvidence>("BreakdownEvidence");
modelBuilder.EntitySet<BreakdownInvestigation>("BreakdownInvestigation");
modelBuilder.EntitySet<BreakdownPreventiveAction>("BreakdownPreventiveAction");
modelBuilder.EntitySet<BreakdownVerification>("BreakdownVerification");
modelBuilder.EntitySet<CalibrationMethod>("CalibrationMethod");
modelBuilder.EntitySet<CalibrationResult>("CalibrationResult");
modelBuilder.EntitySet<CalibrationSignature>("CalibrationSignature");
modelBuilder.EntitySet<CalibrationWorkOrder>("CalibrationWorkOrder");
modelBuilder.EntitySet<ChecklistExecution>("ChecklistExecution");
modelBuilder.EntitySet<ChecklistQuestion>("ChecklistQuestion");
modelBuilder.EntitySet<ChecklistSignature>("ChecklistSignature");
modelBuilder.EntitySet<ChecklistTemplate>("ChecklistTemplate");
modelBuilder.EntitySet<ElectronicSignature>("ElectronicSignature");

//modelBuilder.EntitySet<ElectronicSignature1>("ElectronicSignature");
modelBuilder.EntitySet<ElectronicSignaturePolicy>("ElectronicSignaturePolicy");
modelBuilder.EntitySet<ElectronicSignatureRequest>("ElectronicSignatureRequest");
modelBuilder.EntitySet<EventOutbox>("EventOutbox");
modelBuilder.EntitySet<IntegrationMessage>("IntegrationMessage");
modelBuilder.EntitySet<InventoryBalance>("InventoryBalance");
modelBuilder.EntitySet<InventoryLot>("InventoryLot");
modelBuilder.EntitySet<InventoryReservation>("InventoryReservation");
modelBuilder.EntitySet<InventoryReturn>("InventoryReturn");
modelBuilder.EntitySet<InventorySerial>("InventorySerial");
modelBuilder.EntitySet<InventoryStockAgeing>("InventoryStockAgeing");
modelBuilder.EntitySet<InventoryTransaction>("InventoryTransaction");
modelBuilder.EntitySet<InventoryTransactionOutbox>("InventoryTransactionOutbox");
modelBuilder.EntitySet<Localization>("Localization");
modelBuilder.EntitySet<LoginHistory>("LoginHistory");
modelBuilder.EntitySet<LookupBase>("LookupBase");
modelBuilder.EntitySet<MaterialCostLedger>("MaterialCostLedger");
modelBuilder.EntitySet<MaterialCategory>("MaterialCategory");

modelBuilder.EntitySet<Menu>("Menu");
modelBuilder.EntitySet<NotificationEscalationRule>("NotificationEscalationRule");
modelBuilder.EntitySet<NotificationEvent>("NotificationEvent");
modelBuilder.EntitySet<PasswordHistory>("PasswordHistory");
modelBuilder.EntitySet<Permit>("Permit");
modelBuilder.EntitySet<PermitApproval>("PermitApproval");
modelBuilder.EntitySet<PermitAttachment>("PermitAttachment");
modelBuilder.EntitySet<PermitBlockingRule>("PermitBlockingRule");
modelBuilder.EntitySet<PermitEmployee>("PermitEmployee");
modelBuilder.EntitySet<PermitHazard>("PermitHazard");
modelBuilder.EntitySet<HazardMaster>("HazardMaster");

modelBuilder.EntitySet<PermitIssue>("PermitIssue");
modelBuilder.EntitySet<PermitRiskAssessment>("PermitRiskAssessment");
modelBuilder.EntitySet<PermitSuspend>("PermitSuspend");
modelBuilder.EntitySet<Plant>("Plant");
modelBuilder.EntitySet<PmcalendarRule>("PMCalendarRule");
modelBuilder.EntitySet<PmcomplianceSnapshot>("PMComplianceSnapshot");
modelBuilder.EntitySet<Pmexecution>("PMExecution");
modelBuilder.EntitySet<PmexecutionChecklist>("PMExecutionChecklist");
modelBuilder.EntitySet<PmruntimeRule>("PMRuntimeRule");
modelBuilder.EntitySet<PmworkOrder>("PMWorkOrder");
modelBuilder.EntitySet<ProductionLine>("ProductionLine");
modelBuilder.EntitySet<PurchaseReceipt>("PurchaseReceipt");
modelBuilder.EntitySet<PurchaseReceiptItem>("PurchaseReceiptItem");
modelBuilder.EntitySet<RefreshToken>("RefreshToken");
modelBuilder.EntitySet<ReorderSuggestion>("ReorderSuggestion");
modelBuilder.EntitySet<Role>("Roles");
modelBuilder.EntitySet<SecurityAudit>("SecurityAudit");
modelBuilder.EntitySet<Session>("Session");
modelBuilder.EntitySet<SlaInstance>("SlaInstance");
modelBuilder.EntitySet<SpareRequest>("SpareRequest");
modelBuilder.EntitySet<SpareRequestItem>("SpareRequestItem");
modelBuilder.EntitySet<StorageLocation>("StorageLocation");
modelBuilder.EntitySet<Team>("Team");
modelBuilder.EntitySet<User>("Users");
modelBuilder.EntitySet<UserClaim>("UserClaim");
modelBuilder.EntitySet<UserRole>("UserRoles");
modelBuilder.EntitySet<UserTeam>("UserTeam");
modelBuilder.EntitySet<Warehouse>("Warehouse");
modelBuilder.EntitySet<WorkOrder>("WorkOrder");
modelBuilder.EntitySet<WorkOrderAssignment>("WorkOrderAssignment");
modelBuilder.EntitySet<WorkflowComment>("WorkflowComment");
modelBuilder.EntitySet<WorkflowNotification>("WorkflowNotification");
modelBuilder.EntitySet<WorkflowTask>("WorkflowTask");


builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.AddRouteComponents("odata", modelBuilder.GetEdmModel())
            .Select()
            .Filter()
            .OrderBy()
            .Expand()
            .Count();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();


