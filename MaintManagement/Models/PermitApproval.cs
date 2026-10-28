using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitApproval", Schema = "permit")]
[Index("ApprovalStatus", Name = "IX_PermitApproval_Status")]
public partial class PermitApproval
{
    [Key]
    public Guid PermitApprovalId { get; set; }

    public Guid PermitId { get; set; }

    public int ApprovalLevel { get; set; }

    public Guid ApproverUserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ApprovalStatus { get; set; } = null!;

    public DateTime? ApprovalDate { get; set; }

    [StringLength(1000)]
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ApproverUserId")]
    [InverseProperty("PermitApprovalApproverUsers")]
    public virtual User ApproverUser { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitApprovalCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitApprovalLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitApprovals")]
    public virtual Permit Permit { get; set; } = null!;
}
