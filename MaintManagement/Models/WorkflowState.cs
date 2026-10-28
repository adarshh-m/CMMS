using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowState", Schema = "workflow")]
public partial class WorkflowState
{
    [Key]
    public Guid WorkflowStateId { get; set; }

    public Guid WorkflowDefinitionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string StateCode { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string StateName { get; set; } = null!;

    public bool IsInitialState { get; set; }

    public bool IsFinalState { get; set; }

    public int? DisplayOrder { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowStateCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowStateLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkflowDefinitionId")]
    [InverseProperty("WorkflowStates")]
    public virtual WorkflowDefinition WorkflowDefinition { get; set; } = null!;

    [InverseProperty("FromState")]
    public virtual ICollection<WorkflowHistory> WorkflowHistoryFromStates { get; set; } = new List<WorkflowHistory>();

    [InverseProperty("ToState")]
    public virtual ICollection<WorkflowHistory> WorkflowHistoryToStates { get; set; } = new List<WorkflowHistory>();

    [InverseProperty("WorkflowState")]
    public virtual ICollection<WorkflowInstanceState> WorkflowInstanceStates { get; set; } = new List<WorkflowInstanceState>();

    [InverseProperty("CurrentState")]
    public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; } = new List<WorkflowInstance>();

    [InverseProperty("WorkflowState")]
    public virtual ICollection<WorkflowRoleAssignment> WorkflowRoleAssignments { get; set; } = new List<WorkflowRoleAssignment>();

    [InverseProperty("FromState")]
    public virtual ICollection<WorkflowTransition> WorkflowTransitionFromStates { get; set; } = new List<WorkflowTransition>();

    [InverseProperty("ToState")]
    public virtual ICollection<WorkflowTransition> WorkflowTransitionToStates { get; set; } = new List<WorkflowTransition>();
}
