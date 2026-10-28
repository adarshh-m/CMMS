using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowApproval", Schema = "workflow")]
[Index("ApprovalStatus", Name = "IX_WorkflowApproval_Status")]
public partial class WorkflowApproval
{
    [Key]
    public Guid WorkflowApprovalId { get; set; }

    public Guid WorkflowTaskId { get; set; }

    public Guid ApproverUserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ApprovalStatus { get; set; }

    public DateTime? ApprovalDate { get; set; }

    [StringLength(2000)]
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ApproverUserId")]
    [InverseProperty("WorkflowApprovalApproverUsers")]
    public virtual User ApproverUser { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowApprovalCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowApprovalLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkflowTaskId")]
    [InverseProperty("WorkflowApprovals")]
    public virtual WorkflowTask WorkflowTask { get; set; } = null!;
}
