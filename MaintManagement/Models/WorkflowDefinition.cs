using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowDefinition", Schema = "workflow")]
public partial class WorkflowDefinition
{
    [Key]
    public Guid WorkflowDefinitionId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string WorkflowCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string WorkflowName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string EntityType { get; set; } = null!;

    public int VersionNo { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("WorkflowDefinitions")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("WorkflowDefinition")]
    public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; } = new List<WorkflowInstance>();

    [InverseProperty("WorkflowDefinition")]
    public virtual ICollection<WorkflowRoleAssignment> WorkflowRoleAssignments { get; set; } = new List<WorkflowRoleAssignment>();

    [InverseProperty("WorkflowDefinition")]
    public virtual ICollection<WorkflowState> WorkflowStates { get; set; } = new List<WorkflowState>();

    [InverseProperty("WorkflowDefinition")]
    public virtual ICollection<WorkflowTransition> WorkflowTransitions { get; set; } = new List<WorkflowTransition>();
}
