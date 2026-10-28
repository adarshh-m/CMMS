using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowEscalation", Schema = "workflow")]
public partial class WorkflowEscalation
{
    [Key]
    public Guid WorkflowEscalationId { get; set; }

    public Guid WorkflowTaskId { get; set; }

    public int? EscalationLevel { get; set; }

    public Guid? EscalatedToUserId { get; set; }

    public DateTime? EscalatedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowEscalationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("EscalatedToUserId")]
    [InverseProperty("WorkflowEscalationEscalatedToUsers")]
    public virtual User? EscalatedToUser { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowEscalationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkflowTaskId")]
    [InverseProperty("WorkflowEscalations")]
    public virtual WorkflowTask WorkflowTask { get; set; } = null!;
}
