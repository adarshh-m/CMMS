using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowTransition", Schema = "workflow")]
public partial class WorkflowTransition
{
    [Key]
    public Guid WorkflowTransitionId { get; set; }

    public Guid WorkflowDefinitionId { get; set; }

    public Guid FromStateId { get; set; }

    public Guid ToStateId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TransitionCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? TransitionName { get; set; }

    public bool IsSystemTransition { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowTransitionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("FromStateId")]
    [InverseProperty("WorkflowTransitionFromStates")]
    public virtual WorkflowState FromState { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowTransitionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("ToStateId")]
    [InverseProperty("WorkflowTransitionToStates")]
    public virtual WorkflowState ToState { get; set; } = null!;

    [InverseProperty("WorkflowTransition")]
    public virtual ICollection<WorkflowAction> WorkflowActions { get; set; } = new List<WorkflowAction>();

    [ForeignKey("WorkflowDefinitionId")]
    [InverseProperty("WorkflowTransitions")]
    public virtual WorkflowDefinition WorkflowDefinition { get; set; } = null!;

    [InverseProperty("WorkflowTransition")]
    public virtual ICollection<WorkflowRule> WorkflowRules { get; set; } = new List<WorkflowRule>();
}
