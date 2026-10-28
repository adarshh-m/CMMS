using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Users", Schema = "security")]
[Index("TenantId", "UserName", Name = "UX_Users_Tenant_UserName", IsUnique = true)]
public partial class User
{
    [Key]
    public Guid UserId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? EmployeeNo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? MobileNo { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastLoginOn { get; set; }

    public DateTime CreatedOn { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PreferredLanguageCode { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Abcclassification> AbcclassificationCreatedByNavigations { get; set; } = new List<Abcclassification>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Abcclassification> AbcclassificationLastModifiedByNavigations { get; set; } = new List<Abcclassification>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Area> AreaCreatedByNavigations { get; set; } = new List<Area>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Area> AreaLastModifiedByNavigations { get; set; } = new List<Area>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetCategory> AssetCategoryCreatedByNavigations { get; set; } = new List<AssetCategory>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetCategory> AssetCategoryLastModifiedByNavigations { get; set; } = new List<AssetCategory>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Asset> AssetCreatedByNavigations { get; set; } = new List<Asset>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetCriticality> AssetCriticalityCreatedByNavigations { get; set; } = new List<AssetCriticality>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetCriticality> AssetCriticalityLastModifiedByNavigations { get; set; } = new List<AssetCriticality>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetGroup> AssetGroupCreatedByNavigations { get; set; } = new List<AssetGroup>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetGroupEntry> AssetGroupEntryCreatedByNavigations { get; set; } = new List<AssetGroupEntry>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetGroupEntry> AssetGroupEntryLastModifiedByNavigations { get; set; } = new List<AssetGroupEntry>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetGroup> AssetGroupLastModifiedByNavigations { get; set; } = new List<AssetGroup>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetHierarchy> AssetHierarchyCreatedByNavigations { get; set; } = new List<AssetHierarchy>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetHierarchy> AssetHierarchyLastModifiedByNavigations { get; set; } = new List<AssetHierarchy>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Asset> AssetLastModifiedByNavigations { get; set; } = new List<Asset>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetLocation> AssetLocationCreatedByNavigations { get; set; } = new List<AssetLocation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetLocation> AssetLocationLastModifiedByNavigations { get; set; } = new List<AssetLocation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetStatus> AssetStatusCreatedByNavigations { get; set; } = new List<AssetStatus>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetStatus> AssetStatusLastModifiedByNavigations { get; set; } = new List<AssetStatus>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AssetType> AssetTypeCreatedByNavigations { get; set; } = new List<AssetType>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AssetType> AssetTypeLastModifiedByNavigations { get; set; } = new List<AssetType>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Attachment> AttachmentCreatedByNavigations { get; set; } = new List<Attachment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Attachment> AttachmentLastModifiedByNavigations { get; set; } = new List<Attachment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<AuditEvent> AuditEventCreatedByNavigations { get; set; } = new List<AuditEvent>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<AuditEvent> AuditEventLastModifiedByNavigations { get; set; } = new List<AuditEvent>();

    [InverseProperty("ApproverUser")]
    public virtual ICollection<BreakdownApproval> BreakdownApprovalApproverUsers { get; set; } = new List<BreakdownApproval>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownApproval> BreakdownApprovalCreatedByNavigations { get; set; } = new List<BreakdownApproval>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownApproval> BreakdownApprovalLastModifiedByNavigations { get; set; } = new List<BreakdownApproval>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownCause> BreakdownCauseCreatedByNavigations { get; set; } = new List<BreakdownCause>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownCause> BreakdownCauseLastModifiedByNavigations { get; set; } = new List<BreakdownCause>();

    [InverseProperty("AssignedToUser")]
    public virtual ICollection<BreakdownCorrectiveAction> BreakdownCorrectiveActionAssignedToUsers { get; set; } = new List<BreakdownCorrectiveAction>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownCorrectiveAction> BreakdownCorrectiveActionCreatedByNavigations { get; set; } = new List<BreakdownCorrectiveAction>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownCorrectiveAction> BreakdownCorrectiveActionLastModifiedByNavigations { get; set; } = new List<BreakdownCorrectiveAction>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownEvidence> BreakdownEvidenceCreatedByNavigations { get; set; } = new List<BreakdownEvidence>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownEvidence> BreakdownEvidenceLastModifiedByNavigations { get; set; } = new List<BreakdownEvidence>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownFailure> BreakdownFailureCreatedByNavigations { get; set; } = new List<BreakdownFailure>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownFailure> BreakdownFailureLastModifiedByNavigations { get; set; } = new List<BreakdownFailure>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownInvestigation> BreakdownInvestigationCreatedByNavigations { get; set; } = new List<BreakdownInvestigation>();

    [InverseProperty("InvestigatorUser")]
    public virtual ICollection<BreakdownInvestigation> BreakdownInvestigationInvestigatorUsers { get; set; } = new List<BreakdownInvestigation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownInvestigation> BreakdownInvestigationLastModifiedByNavigations { get; set; } = new List<BreakdownInvestigation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownPreventiveAction> BreakdownPreventiveActionCreatedByNavigations { get; set; } = new List<BreakdownPreventiveAction>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownPreventiveAction> BreakdownPreventiveActionLastModifiedByNavigations { get; set; } = new List<BreakdownPreventiveAction>();

    [InverseProperty("ResponsibleUser")]
    public virtual ICollection<BreakdownPreventiveAction> BreakdownPreventiveActionResponsibleUsers { get; set; } = new List<BreakdownPreventiveAction>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownVerification> BreakdownVerificationCreatedByNavigations { get; set; } = new List<BreakdownVerification>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownVerification> BreakdownVerificationLastModifiedByNavigations { get; set; } = new List<BreakdownVerification>();

    [InverseProperty("VerifiedByUser")]
    public virtual ICollection<BreakdownVerification> BreakdownVerificationVerifiedByUsers { get; set; } = new List<BreakdownVerification>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<BreakdownWhyAnalysis> BreakdownWhyAnalysisCreatedByNavigations { get; set; } = new List<BreakdownWhyAnalysis>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<BreakdownWhyAnalysis> BreakdownWhyAnalysisLastModifiedByNavigations { get; set; } = new List<BreakdownWhyAnalysis>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationAsset> CalibrationAssetCreatedByNavigations { get; set; } = new List<CalibrationAsset>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationAsset> CalibrationAssetLastModifiedByNavigations { get; set; } = new List<CalibrationAsset>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationCertificate> CalibrationCertificateCreatedByNavigations { get; set; } = new List<CalibrationCertificate>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationCertificate> CalibrationCertificateLastModifiedByNavigations { get; set; } = new List<CalibrationCertificate>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationComplianceSnapshot> CalibrationComplianceSnapshotCreatedByNavigations { get; set; } = new List<CalibrationComplianceSnapshot>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationComplianceSnapshot> CalibrationComplianceSnapshotLastModifiedByNavigations { get; set; } = new List<CalibrationComplianceSnapshot>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationEvidence> CalibrationEvidenceCreatedByNavigations { get; set; } = new List<CalibrationEvidence>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationEvidence> CalibrationEvidenceLastModifiedByNavigations { get; set; } = new List<CalibrationEvidence>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationExecution> CalibrationExecutionCreatedByNavigations { get; set; } = new List<CalibrationExecution>();

    [InverseProperty("ExecutedByUser")]
    public virtual ICollection<CalibrationExecution> CalibrationExecutionExecutedByUsers { get; set; } = new List<CalibrationExecution>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationExecution> CalibrationExecutionLastModifiedByNavigations { get; set; } = new List<CalibrationExecution>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationMethod> CalibrationMethodCreatedByNavigations { get; set; } = new List<CalibrationMethod>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationMethod> CalibrationMethodLastModifiedByNavigations { get; set; } = new List<CalibrationMethod>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationOotassessment> CalibrationOotassessmentCreatedByNavigations { get; set; } = new List<CalibrationOotassessment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationOotassessment> CalibrationOotassessmentLastModifiedByNavigations { get; set; } = new List<CalibrationOotassessment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationReading> CalibrationReadingCreatedByNavigations { get; set; } = new List<CalibrationReading>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationReading> CalibrationReadingLastModifiedByNavigations { get; set; } = new List<CalibrationReading>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationResult> CalibrationResultCreatedByNavigations { get; set; } = new List<CalibrationResult>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationResult> CalibrationResultLastModifiedByNavigations { get; set; } = new List<CalibrationResult>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationSchedule> CalibrationScheduleCreatedByNavigations { get; set; } = new List<CalibrationSchedule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationSchedule> CalibrationScheduleLastModifiedByNavigations { get; set; } = new List<CalibrationSchedule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationSignature> CalibrationSignatureCreatedByNavigations { get; set; } = new List<CalibrationSignature>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationSignature> CalibrationSignatureLastModifiedByNavigations { get; set; } = new List<CalibrationSignature>();

    [InverseProperty("User")]
    public virtual ICollection<CalibrationSignature> CalibrationSignatureUsers { get; set; } = new List<CalibrationSignature>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationStandard> CalibrationStandardCreatedByNavigations { get; set; } = new List<CalibrationStandard>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationStandard> CalibrationStandardLastModifiedByNavigations { get; set; } = new List<CalibrationStandard>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationVersion> CalibrationVersionCreatedByNavigations { get; set; } = new List<CalibrationVersion>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationVersion> CalibrationVersionLastModifiedByNavigations { get; set; } = new List<CalibrationVersion>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CalibrationWorkOrder> CalibrationWorkOrderCreatedByNavigations { get; set; } = new List<CalibrationWorkOrder>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CalibrationWorkOrder> CalibrationWorkOrderLastModifiedByNavigations { get; set; } = new List<CalibrationWorkOrder>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CauseCode> CauseCodeCreatedByNavigations { get; set; } = new List<CauseCode>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<CauseCode> CauseCodeModifiedByNavigations { get; set; } = new List<CauseCode>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistExecution> ChecklistExecutionCreatedByNavigations { get; set; } = new List<ChecklistExecution>();

    [InverseProperty("ExecutedByUser")]
    public virtual ICollection<ChecklistExecution> ChecklistExecutionExecutedByUsers { get; set; } = new List<ChecklistExecution>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistExecution> ChecklistExecutionLastModifiedByNavigations { get; set; } = new List<ChecklistExecution>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistExecutionSection> ChecklistExecutionSectionCreatedByNavigations { get; set; } = new List<ChecklistExecutionSection>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistExecutionSection> ChecklistExecutionSectionLastModifiedByNavigations { get; set; } = new List<ChecklistExecutionSection>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistQuestion> ChecklistQuestionCreatedByNavigations { get; set; } = new List<ChecklistQuestion>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistQuestion> ChecklistQuestionLastModifiedByNavigations { get; set; } = new List<ChecklistQuestion>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistQuestionOption> ChecklistQuestionOptionCreatedByNavigations { get; set; } = new List<ChecklistQuestionOption>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistQuestionOption> ChecklistQuestionOptionLastModifiedByNavigations { get; set; } = new List<ChecklistQuestionOption>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistResponseAttachment> ChecklistResponseAttachmentCreatedByNavigations { get; set; } = new List<ChecklistResponseAttachment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistResponseAttachment> ChecklistResponseAttachmentLastModifiedByNavigations { get; set; } = new List<ChecklistResponseAttachment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistResponse> ChecklistResponseCreatedByNavigations { get; set; } = new List<ChecklistResponse>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistResponse> ChecklistResponseLastModifiedByNavigations { get; set; } = new List<ChecklistResponse>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistRule> ChecklistRuleCreatedByNavigations { get; set; } = new List<ChecklistRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistRule> ChecklistRuleLastModifiedByNavigations { get; set; } = new List<ChecklistRule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistScore> ChecklistScoreCreatedByNavigations { get; set; } = new List<ChecklistScore>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistScore> ChecklistScoreLastModifiedByNavigations { get; set; } = new List<ChecklistScore>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistSection> ChecklistSectionCreatedByNavigations { get; set; } = new List<ChecklistSection>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistSection> ChecklistSectionLastModifiedByNavigations { get; set; } = new List<ChecklistSection>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistSignature> ChecklistSignatureCreatedByNavigations { get; set; } = new List<ChecklistSignature>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistSignature> ChecklistSignatureLastModifiedByNavigations { get; set; } = new List<ChecklistSignature>();

    [InverseProperty("SignedByUser")]
    public virtual ICollection<ChecklistSignature> ChecklistSignatureSignedByUsers { get; set; } = new List<ChecklistSignature>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ChecklistVersion> ChecklistVersionCreatedByNavigations { get; set; } = new List<ChecklistVersion>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ChecklistVersion> ChecklistVersionLastModifiedByNavigations { get; set; } = new List<ChecklistVersion>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ControlMeasure> ControlMeasureCreatedByNavigations { get; set; } = new List<ControlMeasure>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<ControlMeasure> ControlMeasureModifiedByNavigations { get; set; } = new List<ControlMeasure>();

    [InverseProperty("ConductedByUser")]
    public virtual ICollection<CycleCount> CycleCountConductedByUsers { get; set; } = new List<CycleCount>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<CycleCount> CycleCountCreatedByNavigations { get; set; } = new List<CycleCount>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<CycleCount> CycleCountLastModifiedByNavigations { get; set; } = new List<CycleCount>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<DeadStockAnalysis> DeadStockAnalysisCreatedByNavigations { get; set; } = new List<DeadStockAnalysis>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<DeadStockAnalysis> DeadStockAnalysisLastModifiedByNavigations { get; set; } = new List<DeadStockAnalysis>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Department> DepartmentCreatedByNavigations { get; set; } = new List<Department>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Department> DepartmentLastModifiedByNavigations { get; set; } = new List<Department>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignature1> ElectronicSignature1CreatedByNavigations { get; set; } = new List<ElectronicSignature1>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignature1> ElectronicSignature1LastModifiedByNavigations { get; set; } = new List<ElectronicSignature1>();

    [InverseProperty("User")]
    public virtual ICollection<ElectronicSignature1> ElectronicSignature1Users { get; set; } = new List<ElectronicSignature1>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureAttachment> ElectronicSignatureAttachmentCreatedByNavigations { get; set; } = new List<ElectronicSignatureAttachment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureAttachment> ElectronicSignatureAttachmentLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureAttachment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureAudit> ElectronicSignatureAuditCreatedByNavigations { get; set; } = new List<ElectronicSignatureAudit>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureAudit> ElectronicSignatureAuditLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureAudit>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureChallenge> ElectronicSignatureChallengeCreatedByNavigations { get; set; } = new List<ElectronicSignatureChallenge>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureChallenge> ElectronicSignatureChallengeLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureChallenge>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignature> ElectronicSignatureCreatedByNavigations { get; set; } = new List<ElectronicSignature>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignature> ElectronicSignatureLastModifiedByNavigations { get; set; } = new List<ElectronicSignature>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureMeaning> ElectronicSignatureMeaningCreatedByNavigations { get; set; } = new List<ElectronicSignatureMeaning>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureMeaning> ElectronicSignatureMeaningLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureMeaning>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignaturePurpose> ElectronicSignaturePurposeCreatedByNavigations { get; set; } = new List<ElectronicSignaturePurpose>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignaturePurpose> ElectronicSignaturePurposeLastModifiedByNavigations { get; set; } = new List<ElectronicSignaturePurpose>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureRequest> ElectronicSignatureRequestCreatedByNavigations { get; set; } = new List<ElectronicSignatureRequest>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureRequest> ElectronicSignatureRequestLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureRequest>();

    [InverseProperty("RequestedByUser")]
    public virtual ICollection<ElectronicSignatureRequest> ElectronicSignatureRequestRequestedByUsers { get; set; } = new List<ElectronicSignatureRequest>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureRoleAssignment> ElectronicSignatureRoleAssignmentCreatedByNavigations { get; set; } = new List<ElectronicSignatureRoleAssignment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureRoleAssignment> ElectronicSignatureRoleAssignmentLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureRoleAssignment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureRole> ElectronicSignatureRoleCreatedByNavigations { get; set; } = new List<ElectronicSignatureRole>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureRole> ElectronicSignatureRoleLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureRole>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureSequence> ElectronicSignatureSequenceCreatedByNavigations { get; set; } = new List<ElectronicSignatureSequence>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureSequence> ElectronicSignatureSequenceLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureSequence>();

    [InverseProperty("User")]
    public virtual ICollection<ElectronicSignature> ElectronicSignatureUsers { get; set; } = new List<ElectronicSignature>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ElectronicSignatureVerification> ElectronicSignatureVerificationCreatedByNavigations { get; set; } = new List<ElectronicSignatureVerification>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ElectronicSignatureVerification> ElectronicSignatureVerificationLastModifiedByNavigations { get; set; } = new List<ElectronicSignatureVerification>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventBatch> EventBatchCreatedByNavigations { get; set; } = new List<EventBatch>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventBatch> EventBatchLastModifiedByNavigations { get; set; } = new List<EventBatch>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventConsumerOffset> EventConsumerOffsetCreatedByNavigations { get; set; } = new List<EventConsumerOffset>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventConsumerOffset> EventConsumerOffsetLastModifiedByNavigations { get; set; } = new List<EventConsumerOffset>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventDeadLetter> EventDeadLetterCreatedByNavigations { get; set; } = new List<EventDeadLetter>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventDeadLetter> EventDeadLetterLastModifiedByNavigations { get; set; } = new List<EventDeadLetter>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventInbox> EventInboxCreatedByNavigations { get; set; } = new List<EventInbox>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventInbox> EventInboxLastModifiedByNavigations { get; set; } = new List<EventInbox>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventPublicationLog> EventPublicationLogCreatedByNavigations { get; set; } = new List<EventPublicationLog>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventPublicationLog> EventPublicationLogLastModifiedByNavigations { get; set; } = new List<EventPublicationLog>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventReplayRequest> EventReplayRequestCreatedByNavigations { get; set; } = new List<EventReplayRequest>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventReplayRequest> EventReplayRequestLastModifiedByNavigations { get; set; } = new List<EventReplayRequest>();

    [InverseProperty("RequestedByUser")]
    public virtual ICollection<EventReplayRequest> EventReplayRequestRequestedByUsers { get; set; } = new List<EventReplayRequest>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventSchema> EventSchemaCreatedByNavigations { get; set; } = new List<EventSchema>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventSchema> EventSchemaLastModifiedByNavigations { get; set; } = new List<EventSchema>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventSubscription> EventSubscriptionCreatedByNavigations { get; set; } = new List<EventSubscription>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventSubscription> EventSubscriptionLastModifiedByNavigations { get; set; } = new List<EventSubscription>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventType> EventTypeCreatedByNavigations { get; set; } = new List<EventType>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<EventType> EventTypeLastModifiedByNavigations { get; set; } = new List<EventType>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<FailureCode> FailureCodeCreatedByNavigations { get; set; } = new List<FailureCode>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<FailureCode> FailureCodeModifiedByNavigations { get; set; } = new List<FailureCode>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Feature> FeatureCreatedByNavigations { get; set; } = new List<Feature>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Feature> FeatureLastModifiedByNavigations { get; set; } = new List<Feature>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<GoodsReceiptNote> GoodsReceiptNoteCreatedByNavigations { get; set; } = new List<GoodsReceiptNote>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<GoodsReceiptNote> GoodsReceiptNoteLastModifiedByNavigations { get; set; } = new List<GoodsReceiptNote>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationBatch> IntegrationBatchCreatedByNavigations { get; set; } = new List<IntegrationBatch>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationBatch> IntegrationBatchLastModifiedByNavigations { get; set; } = new List<IntegrationBatch>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationConfiguration> IntegrationConfigurationCreatedByNavigations { get; set; } = new List<IntegrationConfiguration>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationConfiguration> IntegrationConfigurationLastModifiedByNavigations { get; set; } = new List<IntegrationConfiguration>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationCredential> IntegrationCredentialCreatedByNavigations { get; set; } = new List<IntegrationCredential>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationCredential> IntegrationCredentialLastModifiedByNavigations { get; set; } = new List<IntegrationCredential>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationDeadLetter> IntegrationDeadLetterCreatedByNavigations { get; set; } = new List<IntegrationDeadLetter>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationDeadLetter> IntegrationDeadLetterLastModifiedByNavigations { get; set; } = new List<IntegrationDeadLetter>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationEndpoint> IntegrationEndpointCreatedByNavigations { get; set; } = new List<IntegrationEndpoint>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationEndpoint> IntegrationEndpointLastModifiedByNavigations { get; set; } = new List<IntegrationEndpoint>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationEvent> IntegrationEventCreatedByNavigations { get; set; } = new List<IntegrationEvent>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationEvent> IntegrationEventLastModifiedByNavigations { get; set; } = new List<IntegrationEvent>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationInbox> IntegrationInboxCreatedByNavigations { get; set; } = new List<IntegrationInbox>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationInbox> IntegrationInboxLastModifiedByNavigations { get; set; } = new List<IntegrationInbox>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationMapping> IntegrationMappingCreatedByNavigations { get; set; } = new List<IntegrationMapping>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationMapping> IntegrationMappingLastModifiedByNavigations { get; set; } = new List<IntegrationMapping>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationRetry> IntegrationRetryCreatedByNavigations { get; set; } = new List<IntegrationRetry>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationRetry> IntegrationRetryLastModifiedByNavigations { get; set; } = new List<IntegrationRetry>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationSchedule> IntegrationScheduleCreatedByNavigations { get; set; } = new List<IntegrationSchedule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationSchedule> IntegrationScheduleLastModifiedByNavigations { get; set; } = new List<IntegrationSchedule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationSubscription> IntegrationSubscriptionCreatedByNavigations { get; set; } = new List<IntegrationSubscription>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationSubscription> IntegrationSubscriptionLastModifiedByNavigations { get; set; } = new List<IntegrationSubscription>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<IntegrationSystem> IntegrationSystemCreatedByNavigations { get; set; } = new List<IntegrationSystem>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<IntegrationSystem> IntegrationSystemLastModifiedByNavigations { get; set; } = new List<IntegrationSystem>();

    [InverseProperty("ApprovedByUser")]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustmentApprovedByUsers { get; set; } = new List<InventoryAdjustment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustmentCreatedByNavigations { get; set; } = new List<InventoryAdjustment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustmentLastModifiedByNavigations { get; set; } = new List<InventoryAdjustment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryBalance> InventoryBalanceCreatedByNavigations { get; set; } = new List<InventoryBalance>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryBalance> InventoryBalanceLastModifiedByNavigations { get; set; } = new List<InventoryBalance>();

    [InverseProperty("ConsumedByUser")]
    public virtual ICollection<InventoryConsumption> InventoryConsumptionConsumedByUsers { get; set; } = new List<InventoryConsumption>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryConsumption> InventoryConsumptionCreatedByNavigations { get; set; } = new List<InventoryConsumption>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryConsumption> InventoryConsumptionLastModifiedByNavigations { get; set; } = new List<InventoryConsumption>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryCycleCountLine> InventoryCycleCountLineCreatedByNavigations { get; set; } = new List<InventoryCycleCountLine>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryCycleCountLine> InventoryCycleCountLineLastModifiedByNavigations { get; set; } = new List<InventoryCycleCountLine>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryForecast> InventoryForecastCreatedByNavigations { get; set; } = new List<InventoryForecast>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryForecast> InventoryForecastLastModifiedByNavigations { get; set; } = new List<InventoryForecast>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryIssue> InventoryIssueCreatedByNavigations { get; set; } = new List<InventoryIssue>();

    [InverseProperty("IssuedToUser")]
    public virtual ICollection<InventoryIssue> InventoryIssueIssuedToUsers { get; set; } = new List<InventoryIssue>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryIssue> InventoryIssueLastModifiedByNavigations { get; set; } = new List<InventoryIssue>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryLot> InventoryLotCreatedByNavigations { get; set; } = new List<InventoryLot>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryLot> InventoryLotLastModifiedByNavigations { get; set; } = new List<InventoryLot>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryReceipt> InventoryReceiptCreatedByNavigations { get; set; } = new List<InventoryReceipt>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryReceiptItem> InventoryReceiptItemCreatedByNavigations { get; set; } = new List<InventoryReceiptItem>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryReceiptItem> InventoryReceiptItemLastModifiedByNavigations { get; set; } = new List<InventoryReceiptItem>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryReceipt> InventoryReceiptLastModifiedByNavigations { get; set; } = new List<InventoryReceipt>();

    [InverseProperty("ReceivedByUser")]
    public virtual ICollection<InventoryReceipt> InventoryReceiptReceivedByUsers { get; set; } = new List<InventoryReceipt>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryReservation> InventoryReservationCreatedByNavigations { get; set; } = new List<InventoryReservation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryReservation> InventoryReservationLastModifiedByNavigations { get; set; } = new List<InventoryReservation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryReturn> InventoryReturnCreatedByNavigations { get; set; } = new List<InventoryReturn>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryReturn> InventoryReturnLastModifiedByNavigations { get; set; } = new List<InventoryReturn>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventorySerial> InventorySerialCreatedByNavigations { get; set; } = new List<InventorySerial>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventorySerial> InventorySerialLastModifiedByNavigations { get; set; } = new List<InventorySerial>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryStockAgeing> InventoryStockAgeingCreatedByNavigations { get; set; } = new List<InventoryStockAgeing>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryStockAgeing> InventoryStockAgeingLastModifiedByNavigations { get; set; } = new List<InventoryStockAgeing>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryTransaction> InventoryTransactionCreatedByNavigations { get; set; } = new List<InventoryTransaction>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryTransaction> InventoryTransactionLastModifiedByNavigations { get; set; } = new List<InventoryTransaction>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryTransfer> InventoryTransferCreatedByNavigations { get; set; } = new List<InventoryTransfer>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryTransfer> InventoryTransferLastModifiedByNavigations { get; set; } = new List<InventoryTransfer>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<InventoryValuationSnapshot> InventoryValuationSnapshotCreatedByNavigations { get; set; } = new List<InventoryValuationSnapshot>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<InventoryValuationSnapshot> InventoryValuationSnapshotLastModifiedByNavigations { get; set; } = new List<InventoryValuationSnapshot>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Language> LanguageCreatedByNavigations { get; set; } = new List<Language>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Language> LanguageLastModifiedByNavigations { get; set; } = new List<Language>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Localization> LocalizationCreatedByNavigations { get; set; } = new List<Localization>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Localization> LocalizationLastModifiedByNavigations { get; set; } = new List<Localization>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<LoginHistory> LoginHistoryCreatedByNavigations { get; set; } = new List<LoginHistory>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<LoginHistory> LoginHistoryLastModifiedByNavigations { get; set; } = new List<LoginHistory>();

    [InverseProperty("User")]
    public virtual ICollection<LoginHistory> LoginHistoryUsers { get; set; } = new List<LoginHistory>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<LookupBase> LookupBaseCreatedByNavigations { get; set; } = new List<LookupBase>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<LookupBase> LookupBaseLastModifiedByNavigations { get; set; } = new List<LookupBase>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MaintenanceGroup> MaintenanceGroupCreatedByNavigations { get; set; } = new List<MaintenanceGroup>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<MaintenanceGroup> MaintenanceGroupLastModifiedByNavigations { get; set; } = new List<MaintenanceGroup>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestCreatedByNavigations { get; set; } = new List<MaintenanceRequest>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestLastModifiedByNavigations { get; set; } = new List<MaintenanceRequest>();

    [InverseProperty("RequestedByNavigation")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestRequestedByNavigations { get; set; } = new List<MaintenanceRequest>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MaterialAlternate> MaterialAlternateCreatedByNavigations { get; set; } = new List<MaterialAlternate>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<MaterialAlternate> MaterialAlternateLastModifiedByNavigations { get; set; } = new List<MaterialAlternate>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MaterialCostLedger> MaterialCostLedgerCreatedByNavigations { get; set; } = new List<MaterialCostLedger>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<MaterialCostLedger> MaterialCostLedgerLastModifiedByNavigations { get; set; } = new List<MaterialCostLedger>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Material> MaterialCreatedByNavigations { get; set; } = new List<Material>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Material> MaterialLastModifiedByNavigations { get; set; } = new List<Material>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MaterialVendor> MaterialVendorCreatedByNavigations { get; set; } = new List<MaterialVendor>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<MaterialVendor> MaterialVendorLastModifiedByNavigations { get; set; } = new List<MaterialVendor>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MaterialWarehouse> MaterialWarehouseCreatedByNavigations { get; set; } = new List<MaterialWarehouse>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<MaterialWarehouse> MaterialWarehouseLastModifiedByNavigations { get; set; } = new List<MaterialWarehouse>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Menu> MenuCreatedByNavigations { get; set; } = new List<Menu>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Menu> MenuLastModifiedByNavigations { get; set; } = new List<Menu>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MenuPermission> MenuPermissionCreatedByNavigations { get; set; } = new List<MenuPermission>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<MenuPermission> MenuPermissionLastModifiedByNavigations { get; set; } = new List<MenuPermission>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationAttachment> NotificationAttachmentCreatedByNavigations { get; set; } = new List<NotificationAttachment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationAttachment> NotificationAttachmentLastModifiedByNavigations { get; set; } = new List<NotificationAttachment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationDelivery> NotificationDeliveryCreatedByNavigations { get; set; } = new List<NotificationDelivery>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationDelivery> NotificationDeliveryLastModifiedByNavigations { get; set; } = new List<NotificationDelivery>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationEscalationRule> NotificationEscalationRuleCreatedByNavigations { get; set; } = new List<NotificationEscalationRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationEscalationRule> NotificationEscalationRuleLastModifiedByNavigations { get; set; } = new List<NotificationEscalationRule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationEvent> NotificationEventCreatedByNavigations { get; set; } = new List<NotificationEvent>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationEvent> NotificationEventLastModifiedByNavigations { get; set; } = new List<NotificationEvent>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationPreference> NotificationPreferenceCreatedByNavigations { get; set; } = new List<NotificationPreference>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationPreference> NotificationPreferenceLastModifiedByNavigations { get; set; } = new List<NotificationPreference>();

    [InverseProperty("User")]
    public virtual ICollection<NotificationPreference> NotificationPreferenceUsers { get; set; } = new List<NotificationPreference>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationRecipient> NotificationRecipientCreatedByNavigations { get; set; } = new List<NotificationRecipient>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationRecipient> NotificationRecipientLastModifiedByNavigations { get; set; } = new List<NotificationRecipient>();

    [InverseProperty("User")]
    public virtual ICollection<NotificationRecipient> NotificationRecipientUsers { get; set; } = new List<NotificationRecipient>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationRetry> NotificationRetryCreatedByNavigations { get; set; } = new List<NotificationRetry>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationRetry> NotificationRetryLastModifiedByNavigations { get; set; } = new List<NotificationRetry>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationSubscription> NotificationSubscriptionCreatedByNavigations { get; set; } = new List<NotificationSubscription>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationSubscription> NotificationSubscriptionLastModifiedByNavigations { get; set; } = new List<NotificationSubscription>();

    [InverseProperty("User")]
    public virtual ICollection<NotificationSubscription> NotificationSubscriptionUsers { get; set; } = new List<NotificationSubscription>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationTemplate> NotificationTemplateCreatedByNavigations { get; set; } = new List<NotificationTemplate>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationTemplate> NotificationTemplateLastModifiedByNavigations { get; set; } = new List<NotificationTemplate>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NotificationTemplateTranslation> NotificationTemplateTranslationCreatedByNavigations { get; set; } = new List<NotificationTemplateTranslation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<NotificationTemplateTranslation> NotificationTemplateTranslationLastModifiedByNavigations { get; set; } = new List<NotificationTemplateTranslation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PasswordHistory> PasswordHistoryCreatedByNavigations { get; set; } = new List<PasswordHistory>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PasswordHistory> PasswordHistoryLastModifiedByNavigations { get; set; } = new List<PasswordHistory>();

    [InverseProperty("User")]
    public virtual ICollection<PasswordHistory> PasswordHistoryUsers { get; set; } = new List<PasswordHistory>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Permission> PermissionCreatedByNavigations { get; set; } = new List<Permission>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Permission> PermissionLastModifiedByNavigations { get; set; } = new List<Permission>();

    [InverseProperty("ApproverUser")]
    public virtual ICollection<PermitApproval> PermitApprovalApproverUsers { get; set; } = new List<PermitApproval>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitApproval> PermitApprovalCreatedByNavigations { get; set; } = new List<PermitApproval>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitApproval> PermitApprovalLastModifiedByNavigations { get; set; } = new List<PermitApproval>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitAsset> PermitAssetCreatedByNavigations { get; set; } = new List<PermitAsset>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitAsset> PermitAssetLastModifiedByNavigations { get; set; } = new List<PermitAsset>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitAttachment> PermitAttachmentCreatedByNavigations { get; set; } = new List<PermitAttachment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitAttachment> PermitAttachmentLastModifiedByNavigations { get; set; } = new List<PermitAttachment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitBlockingRule> PermitBlockingRuleCreatedByNavigations { get; set; } = new List<PermitBlockingRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitBlockingRule> PermitBlockingRuleLastModifiedByNavigations { get; set; } = new List<PermitBlockingRule>();

    [InverseProperty("ClosedByUser")]
    public virtual ICollection<PermitClosure> PermitClosureClosedByUsers { get; set; } = new List<PermitClosure>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitClosure> PermitClosureCreatedByNavigations { get; set; } = new List<PermitClosure>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitClosure> PermitClosureLastModifiedByNavigations { get; set; } = new List<PermitClosure>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitControlMeasure> PermitControlMeasureCreatedByNavigations { get; set; } = new List<PermitControlMeasure>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitControlMeasure> PermitControlMeasureLastModifiedByNavigations { get; set; } = new List<PermitControlMeasure>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Permit> PermitCreatedByNavigations { get; set; } = new List<Permit>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitEmployee> PermitEmployeeCreatedByNavigations { get; set; } = new List<PermitEmployee>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitEmployee> PermitEmployeeLastModifiedByNavigations { get; set; } = new List<PermitEmployee>();

    [InverseProperty("User")]
    public virtual ICollection<PermitEmployee> PermitEmployeeUsers { get; set; } = new List<PermitEmployee>();

    [InverseProperty("ApprovedByUser")]
    public virtual ICollection<PermitExtension> PermitExtensionApprovedByUsers { get; set; } = new List<PermitExtension>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitExtension> PermitExtensionCreatedByNavigations { get; set; } = new List<PermitExtension>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitExtension> PermitExtensionLastModifiedByNavigations { get; set; } = new List<PermitExtension>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitHazard> PermitHazardCreatedByNavigations { get; set; } = new List<PermitHazard>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitHazard> PermitHazardLastModifiedByNavigations { get; set; } = new List<PermitHazard>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitIssue> PermitIssueCreatedByNavigations { get; set; } = new List<PermitIssue>();

    [InverseProperty("IssuedByUser")]
    public virtual ICollection<PermitIssue> PermitIssueIssuedByUsers { get; set; } = new List<PermitIssue>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitIssue> PermitIssueLastModifiedByNavigations { get; set; } = new List<PermitIssue>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Permit> PermitLastModifiedByNavigations { get; set; } = new List<Permit>();

    [InverseProperty("RequestedByUser")]
    public virtual ICollection<Permit> PermitRequestedByUsers { get; set; } = new List<Permit>();

    [InverseProperty("AssessedByUser")]
    public virtual ICollection<PermitRiskAssessment> PermitRiskAssessmentAssessedByUsers { get; set; } = new List<PermitRiskAssessment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitRiskAssessment> PermitRiskAssessmentCreatedByNavigations { get; set; } = new List<PermitRiskAssessment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitRiskAssessment> PermitRiskAssessmentLastModifiedByNavigations { get; set; } = new List<PermitRiskAssessment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitSignature> PermitSignatureCreatedByNavigations { get; set; } = new List<PermitSignature>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitSignature> PermitSignatureLastModifiedByNavigations { get; set; } = new List<PermitSignature>();

    [InverseProperty("User")]
    public virtual ICollection<PermitSignature> PermitSignatureUsers { get; set; } = new List<PermitSignature>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitSuspend> PermitSuspendCreatedByNavigations { get; set; } = new List<PermitSuspend>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitSuspend> PermitSuspendLastModifiedByNavigations { get; set; } = new List<PermitSuspend>();

    [InverseProperty("SuspendedByUser")]
    public virtual ICollection<PermitSuspend> PermitSuspendSuspendedByUsers { get; set; } = new List<PermitSuspend>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PermitWorkIsolation> PermitWorkIsolationCreatedByNavigations { get; set; } = new List<PermitWorkIsolation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PermitWorkIsolation> PermitWorkIsolationLastModifiedByNavigations { get; set; } = new List<PermitWorkIsolation>();

    [InverseProperty("VerifiedByUser")]
    public virtual ICollection<PermitWorkIsolation> PermitWorkIsolationVerifiedByUsers { get; set; } = new List<PermitWorkIsolation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Plant> PlantCreatedByNavigations { get; set; } = new List<Plant>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Plant> PlantLastModifiedByNavigations { get; set; } = new List<Plant>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmcalendarRule> PmcalendarRuleCreatedByNavigations { get; set; } = new List<PmcalendarRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmcalendarRule> PmcalendarRuleLastModifiedByNavigations { get; set; } = new List<PmcalendarRule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmcomplianceSnapshot> PmcomplianceSnapshotCreatedByNavigations { get; set; } = new List<PmcomplianceSnapshot>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmcomplianceSnapshot> PmcomplianceSnapshotLastModifiedByNavigations { get; set; } = new List<PmcomplianceSnapshot>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmcycleRule> PmcycleRuleCreatedByNavigations { get; set; } = new List<PmcycleRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmcycleRule> PmcycleRuleLastModifiedByNavigations { get; set; } = new List<PmcycleRule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmexecutionChecklist> PmexecutionChecklistCreatedByNavigations { get; set; } = new List<PmexecutionChecklist>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmexecutionChecklist> PmexecutionChecklistLastModifiedByNavigations { get; set; } = new List<PmexecutionChecklist>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Pmexecution> PmexecutionCreatedByNavigations { get; set; } = new List<Pmexecution>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Pmexecution> PmexecutionLastModifiedByNavigations { get; set; } = new List<Pmexecution>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmexecutionReading> PmexecutionReadingCreatedByNavigations { get; set; } = new List<PmexecutionReading>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmexecutionReading> PmexecutionReadingLastModifiedByNavigations { get; set; } = new List<PmexecutionReading>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Pmforecast> PmforecastCreatedByNavigations { get; set; } = new List<Pmforecast>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Pmforecast> PmforecastLastModifiedByNavigations { get; set; } = new List<Pmforecast>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmgenerationLog> PmgenerationLogCreatedByNavigations { get; set; } = new List<PmgenerationLog>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmgenerationLog> PmgenerationLogLastModifiedByNavigations { get; set; } = new List<PmgenerationLog>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmquantityRule> PmquantityRuleCreatedByNavigations { get; set; } = new List<PmquantityRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmquantityRule> PmquantityRuleLastModifiedByNavigations { get; set; } = new List<PmquantityRule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmruntimeRule> PmruntimeRuleCreatedByNavigations { get; set; } = new List<PmruntimeRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmruntimeRule> PmruntimeRuleLastModifiedByNavigations { get; set; } = new List<PmruntimeRule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmscheduleAsset> PmscheduleAssetCreatedByNavigations { get; set; } = new List<PmscheduleAsset>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmscheduleAsset> PmscheduleAssetLastModifiedByNavigations { get; set; } = new List<PmscheduleAsset>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmscheduleChecklist> PmscheduleChecklistCreatedByNavigations { get; set; } = new List<PmscheduleChecklist>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmscheduleChecklist> PmscheduleChecklistLastModifiedByNavigations { get; set; } = new List<PmscheduleChecklist>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Pmschedule> PmscheduleCreatedByNavigations { get; set; } = new List<Pmschedule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Pmschedule> PmscheduleLastModifiedByNavigations { get; set; } = new List<Pmschedule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmtriggerHistory> PmtriggerHistoryCreatedByNavigations { get; set; } = new List<PmtriggerHistory>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmtriggerHistory> PmtriggerHistoryLastModifiedByNavigations { get; set; } = new List<PmtriggerHistory>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PmworkOrder> PmworkOrderCreatedByNavigations { get; set; } = new List<PmworkOrder>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PmworkOrder> PmworkOrderLastModifiedByNavigations { get; set; } = new List<PmworkOrder>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ProductionLine> ProductionLineCreatedByNavigations { get; set; } = new List<ProductionLine>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ProductionLine> ProductionLineLastModifiedByNavigations { get; set; } = new List<ProductionLine>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PurchaseReceipt> PurchaseReceiptCreatedByNavigations { get; set; } = new List<PurchaseReceipt>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<PurchaseReceiptItem> PurchaseReceiptItemCreatedByNavigations { get; set; } = new List<PurchaseReceiptItem>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PurchaseReceiptItem> PurchaseReceiptItemLastModifiedByNavigations { get; set; } = new List<PurchaseReceiptItem>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<PurchaseReceipt> PurchaseReceiptLastModifiedByNavigations { get; set; } = new List<PurchaseReceipt>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<RefreshToken> RefreshTokenCreatedByNavigations { get; set; } = new List<RefreshToken>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<RefreshToken> RefreshTokenLastModifiedByNavigations { get; set; } = new List<RefreshToken>();

    [InverseProperty("User")]
    public virtual ICollection<RefreshToken> RefreshTokenUsers { get; set; } = new List<RefreshToken>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ReorderSuggestion> ReorderSuggestionCreatedByNavigations { get; set; } = new List<ReorderSuggestion>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<ReorderSuggestion> ReorderSuggestionLastModifiedByNavigations { get; set; } = new List<ReorderSuggestion>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Role> RoleCreatedByNavigations { get; set; } = new List<Role>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Role> RoleLastModifiedByNavigations { get; set; } = new List<Role>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<RolePermission> RolePermissionCreatedByNavigations { get; set; } = new List<RolePermission>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<RolePermission> RolePermissionLastModifiedByNavigations { get; set; } = new List<RolePermission>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<SecurityAudit> SecurityAuditCreatedByNavigations { get; set; } = new List<SecurityAudit>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<SecurityAudit> SecurityAuditLastModifiedByNavigations { get; set; } = new List<SecurityAudit>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Session> SessionCreatedByNavigations { get; set; } = new List<Session>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Session> SessionLastModifiedByNavigations { get; set; } = new List<Session>();

    [InverseProperty("User")]
    public virtual ICollection<Session> SessionUsers { get; set; } = new List<Session>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<SlaInstance> SlaInstanceCreatedByNavigations { get; set; } = new List<SlaInstance>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<SlaInstance> SlaInstanceLastModifiedByNavigations { get; set; } = new List<SlaInstance>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<SpareRequest> SpareRequestCreatedByNavigations { get; set; } = new List<SpareRequest>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<SpareRequestItem> SpareRequestItemCreatedByNavigations { get; set; } = new List<SpareRequestItem>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<SpareRequestItem> SpareRequestItemLastModifiedByNavigations { get; set; } = new List<SpareRequestItem>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<SpareRequest> SpareRequestLastModifiedByNavigations { get; set; } = new List<SpareRequest>();

    [InverseProperty("RequestedByUser")]
    public virtual ICollection<SpareRequest> SpareRequestRequestedByUsers { get; set; } = new List<SpareRequest>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<StockSnapshot> StockSnapshotCreatedByNavigations { get; set; } = new List<StockSnapshot>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<StockSnapshot> StockSnapshotLastModifiedByNavigations { get; set; } = new List<StockSnapshot>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<StorageLocation> StorageLocationCreatedByNavigations { get; set; } = new List<StorageLocation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<StorageLocation> StorageLocationLastModifiedByNavigations { get; set; } = new List<StorageLocation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<SystemMessage> SystemMessageCreatedByNavigations { get; set; } = new List<SystemMessage>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<SystemMessage> SystemMessageLastModifiedByNavigations { get; set; } = new List<SystemMessage>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<SystemMessageTranslation> SystemMessageTranslationCreatedByNavigations { get; set; } = new List<SystemMessageTranslation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<SystemMessageTranslation> SystemMessageTranslationLastModifiedByNavigations { get; set; } = new List<SystemMessageTranslation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Team> TeamCreatedByNavigations { get; set; } = new List<Team>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Team> TeamLastModifiedByNavigations { get; set; } = new List<Team>();

    [ForeignKey("TenantId")]
    [InverseProperty("Users")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Tenant> TenantCreatedByNavigations { get; set; } = new List<Tenant>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<TenantFeature> TenantFeatureCreatedByNavigations { get; set; } = new List<TenantFeature>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<TenantFeature> TenantFeatureLastModifiedByNavigations { get; set; } = new List<TenantFeature>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<TenantLanguage> TenantLanguageCreatedByNavigations { get; set; } = new List<TenantLanguage>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<TenantLanguage> TenantLanguageLastModifiedByNavigations { get; set; } = new List<TenantLanguage>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Tenant> TenantLastModifiedByNavigations { get; set; } = new List<Tenant>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Uom> UomCreatedByNavigations { get; set; } = new List<Uom>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<Uom> UomModifiedByNavigations { get; set; } = new List<Uom>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<UserClaim> UserClaimCreatedByNavigations { get; set; } = new List<UserClaim>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<UserClaim> UserClaimLastModifiedByNavigations { get; set; } = new List<UserClaim>();

    [InverseProperty("User")]
    public virtual ICollection<UserClaim> UserClaimUsers { get; set; } = new List<UserClaim>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<UserDepartment> UserDepartmentCreatedByNavigations { get; set; } = new List<UserDepartment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<UserDepartment> UserDepartmentLastModifiedByNavigations { get; set; } = new List<UserDepartment>();

    [InverseProperty("User")]
    public virtual ICollection<UserDepartment> UserDepartmentUsers { get; set; } = new List<UserDepartment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<UserPlant> UserPlantCreatedByNavigations { get; set; } = new List<UserPlant>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<UserPlant> UserPlantLastModifiedByNavigations { get; set; } = new List<UserPlant>();

    [InverseProperty("User")]
    public virtual ICollection<UserPlant> UserPlantUsers { get; set; } = new List<UserPlant>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<UserRole> UserRoleCreatedByNavigations { get; set; } = new List<UserRole>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<UserRole> UserRoleLastModifiedByNavigations { get; set; } = new List<UserRole>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoleUsers { get; set; } = new List<UserRole>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<UserTeam> UserTeamCreatedByNavigations { get; set; } = new List<UserTeam>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<UserTeam> UserTeamLastModifiedByNavigations { get; set; } = new List<UserTeam>();

    [InverseProperty("User")]
    public virtual ICollection<UserTeam> UserTeamUsers { get; set; } = new List<UserTeam>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Vendor> VendorCreatedByNavigations { get; set; } = new List<Vendor>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<Vendor> VendorModifiedByNavigations { get; set; } = new List<Vendor>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Warehouse> WarehouseCreatedByNavigations { get; set; } = new List<Warehouse>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<Warehouse> WarehouseLastModifiedByNavigations { get; set; } = new List<Warehouse>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WebhookRequestLog> WebhookRequestLogCreatedByNavigations { get; set; } = new List<WebhookRequestLog>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WebhookRequestLog> WebhookRequestLogLastModifiedByNavigations { get; set; } = new List<WebhookRequestLog>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WebhookSubscription> WebhookSubscriptionCreatedByNavigations { get; set; } = new List<WebhookSubscription>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WebhookSubscription> WebhookSubscriptionLastModifiedByNavigations { get; set; } = new List<WebhookSubscription>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkCenter> WorkCenterCreatedByNavigations { get; set; } = new List<WorkCenter>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkCenter> WorkCenterLastModifiedByNavigations { get; set; } = new List<WorkCenter>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkOrderAssignment> WorkOrderAssignmentCreatedByNavigations { get; set; } = new List<WorkOrderAssignment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkOrderAssignment> WorkOrderAssignmentLastModifiedByNavigations { get; set; } = new List<WorkOrderAssignment>();

    [InverseProperty("User")]
    public virtual ICollection<WorkOrderAssignment> WorkOrderAssignmentUsers { get; set; } = new List<WorkOrderAssignment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkOrder> WorkOrderCreatedByNavigations { get; set; } = new List<WorkOrder>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkOrder> WorkOrderLastModifiedByNavigations { get; set; } = new List<WorkOrder>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowAction> WorkflowActionCreatedByNavigations { get; set; } = new List<WorkflowAction>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowAction> WorkflowActionLastModifiedByNavigations { get; set; } = new List<WorkflowAction>();

    [InverseProperty("ApproverUser")]
    public virtual ICollection<WorkflowApproval> WorkflowApprovalApproverUsers { get; set; } = new List<WorkflowApproval>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowApproval> WorkflowApprovalCreatedByNavigations { get; set; } = new List<WorkflowApproval>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowApproval> WorkflowApprovalLastModifiedByNavigations { get; set; } = new List<WorkflowApproval>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<WorkflowComment> WorkflowComments { get; set; } = new List<WorkflowComment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowEscalation> WorkflowEscalationCreatedByNavigations { get; set; } = new List<WorkflowEscalation>();

    [InverseProperty("EscalatedToUser")]
    public virtual ICollection<WorkflowEscalation> WorkflowEscalationEscalatedToUsers { get; set; } = new List<WorkflowEscalation>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowEscalation> WorkflowEscalationLastModifiedByNavigations { get; set; } = new List<WorkflowEscalation>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowHistory> WorkflowHistoryCreatedByNavigations { get; set; } = new List<WorkflowHistory>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowHistory> WorkflowHistoryLastModifiedByNavigations { get; set; } = new List<WorkflowHistory>();

    [InverseProperty("PerformedByUser")]
    public virtual ICollection<WorkflowHistory> WorkflowHistoryPerformedByUsers { get; set; } = new List<WorkflowHistory>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowInstance> WorkflowInstanceCreatedByNavigations { get; set; } = new List<WorkflowInstance>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowInstance> WorkflowInstanceLastModifiedByNavigations { get; set; } = new List<WorkflowInstance>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowInstanceState> WorkflowInstanceStateCreatedByNavigations { get; set; } = new List<WorkflowInstanceState>();

    [InverseProperty("EnteredByUser")]
    public virtual ICollection<WorkflowInstanceState> WorkflowInstanceStateEnteredByUsers { get; set; } = new List<WorkflowInstanceState>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowInstanceState> WorkflowInstanceStateLastModifiedByNavigations { get; set; } = new List<WorkflowInstanceState>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowNotification> WorkflowNotificationCreatedByNavigations { get; set; } = new List<WorkflowNotification>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowNotification> WorkflowNotificationLastModifiedByNavigations { get; set; } = new List<WorkflowNotification>();

    [InverseProperty("RecipientUser")]
    public virtual ICollection<WorkflowNotification> WorkflowNotificationRecipientUsers { get; set; } = new List<WorkflowNotification>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowRoleAssignment> WorkflowRoleAssignmentCreatedByNavigations { get; set; } = new List<WorkflowRoleAssignment>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowRoleAssignment> WorkflowRoleAssignmentLastModifiedByNavigations { get; set; } = new List<WorkflowRoleAssignment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowRule> WorkflowRuleCreatedByNavigations { get; set; } = new List<WorkflowRule>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowRule> WorkflowRuleLastModifiedByNavigations { get; set; } = new List<WorkflowRule>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowState> WorkflowStateCreatedByNavigations { get; set; } = new List<WorkflowState>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowState> WorkflowStateLastModifiedByNavigations { get; set; } = new List<WorkflowState>();

    [InverseProperty("AssignedUser")]
    public virtual ICollection<WorkflowTask> WorkflowTaskAssignedUsers { get; set; } = new List<WorkflowTask>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowTask> WorkflowTaskCreatedByNavigations { get; set; } = new List<WorkflowTask>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowTask> WorkflowTaskLastModifiedByNavigations { get; set; } = new List<WorkflowTask>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowTransition> WorkflowTransitionCreatedByNavigations { get; set; } = new List<WorkflowTransition>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowTransition> WorkflowTransitionLastModifiedByNavigations { get; set; } = new List<WorkflowTransition>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<WorkflowVariable> WorkflowVariableCreatedByNavigations { get; set; } = new List<WorkflowVariable>();

    [InverseProperty("LastModifiedByNavigation")]
    public virtual ICollection<WorkflowVariable> WorkflowVariableLastModifiedByNavigations { get; set; } = new List<WorkflowVariable>();
}
