using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Permit", Schema = "permit")]
[Index("PermitNumber", Name = "IX_Permit_Number")]
[Index("PlannedStartDate", Name = "IX_Permit_StartDate")]
[Index("Status", Name = "IX_Permit_Status")]
public partial class Permit
{
    [Key]
    public Guid PermitId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string PermitNumber { get; set; } = null!;

    public Guid PermitTypeId { get; set; }

    public Guid? WorkOrderId { get; set; }

    public Guid RequestedByUserId { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime PlannedStartDate { get; set; }

    public DateTime PlannedEndDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [StringLength(2000)]
    public string? WorkDescription { get; set; }

    public bool EmergencyFlag { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Permit")]
    public virtual ICollection<PermitApproval> PermitApprovals { get; set; } = new List<PermitApproval>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitAsset> PermitAssets { get; set; } = new List<PermitAsset>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitAttachment> PermitAttachments { get; set; } = new List<PermitAttachment>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitClosure> PermitClosures { get; set; } = new List<PermitClosure>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitControlMeasure> PermitControlMeasures { get; set; } = new List<PermitControlMeasure>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitEmployee> PermitEmployees { get; set; } = new List<PermitEmployee>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitExtension> PermitExtensions { get; set; } = new List<PermitExtension>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitHazard> PermitHazards { get; set; } = new List<PermitHazard>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitIssue> PermitIssues { get; set; } = new List<PermitIssue>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitRiskAssessment> PermitRiskAssessments { get; set; } = new List<PermitRiskAssessment>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitSignature> PermitSignatures { get; set; } = new List<PermitSignature>();

    [InverseProperty("Permit")]
    public virtual ICollection<PermitSuspend> PermitSuspends { get; set; } = new List<PermitSuspend>();

    [ForeignKey("PermitTypeId")]
    [InverseProperty("Permits")]
    public virtual PermitType PermitType { get; set; } = null!;

    [InverseProperty("Permit")]
    public virtual ICollection<PermitWorkIsolation> PermitWorkIsolations { get; set; } = new List<PermitWorkIsolation>();

    [ForeignKey("RequestedByUserId")]
    [InverseProperty("PermitRequestedByUsers")]
    public virtual User RequestedByUser { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Permits")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("Permits")]
    public virtual WorkOrder? WorkOrder { get; set; }
}
