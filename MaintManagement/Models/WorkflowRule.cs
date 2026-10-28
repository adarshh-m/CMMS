using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowRule", Schema = "workflow")]
public partial class WorkflowRule
{
    [Key]
    public Guid WorkflowRuleId { get; set; }

    public Guid WorkflowTransitionId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? RuleName { get; set; }

    public string Expression { get; set; } = null!;

    public int SequenceNo { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkflowTransitionId")]
    [InverseProperty("WorkflowRules")]
    public virtual WorkflowTransition WorkflowTransition { get; set; } = null!;
}
