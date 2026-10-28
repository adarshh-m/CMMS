using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowTask", Schema = "workflow")]
[Index("DueDate", Name = "IX_WorkflowTask_DueDate")]
[Index("Status", Name = "IX_WorkflowTask_Status")]
public partial class WorkflowTask
{
    [Key]
    public Guid WorkflowTaskId { get; set; }

    public Guid WorkflowInstanceId { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? TaskName { get; set; }

    public Guid? AssignedUserId { get; set; }

    public Guid? AssignedRoleId { get; set; }

    public DateTime? DueDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssignedRoleId")]
    [InverseProperty("WorkflowTasks")]
    public virtual Role? AssignedRole { get; set; }

    [ForeignKey("AssignedUserId")]
    [InverseProperty("WorkflowTaskAssignedUsers")]
    public virtual User? AssignedUser { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowTaskCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowTaskLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("WorkflowTask")]
    public virtual ICollection<WorkflowApproval> WorkflowApprovals { get; set; } = new List<WorkflowApproval>();

    [InverseProperty("WorkflowTask")]
    public virtual ICollection<WorkflowEscalation> WorkflowEscalations { get; set; } = new List<WorkflowEscalation>();

    [ForeignKey("WorkflowInstanceId")]
    [InverseProperty("WorkflowTasks")]
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;
}
