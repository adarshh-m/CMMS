using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowAction", Schema = "workflow")]
public partial class WorkflowAction
{
    [Key]
    public Guid WorkflowActionId { get; set; }

    public Guid WorkflowTransitionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ActionType { get; set; }

    public string? ActionConfiguration { get; set; }

    public int? SequenceNo { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowActionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowActionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkflowTransitionId")]
    [InverseProperty("WorkflowActions")]
    public virtual WorkflowTransition WorkflowTransition { get; set; } = null!;
}
