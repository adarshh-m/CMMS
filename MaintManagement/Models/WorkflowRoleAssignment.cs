using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowRoleAssignment", Schema = "workflow")]
public partial class WorkflowRoleAssignment
{
    [Key]
    public Guid WorkflowRoleAssignmentId { get; set; }

    public Guid WorkflowDefinitionId { get; set; }

    public Guid WorkflowStateId { get; set; }

    public Guid RoleId { get; set; }

    public bool IsMandatory { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowRoleAssignmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowRoleAssignmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("WorkflowRoleAssignments")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("WorkflowDefinitionId")]
    [InverseProperty("WorkflowRoleAssignments")]
    public virtual WorkflowDefinition WorkflowDefinition { get; set; } = null!;

    [ForeignKey("WorkflowStateId")]
    [InverseProperty("WorkflowRoleAssignments")]
    public virtual WorkflowState WorkflowState { get; set; } = null!;
}
