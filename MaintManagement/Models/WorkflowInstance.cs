using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowInstance", Schema = "workflow")]
[Index("EntityType", "EntityId", Name = "IX_WorkflowInstance_Entity")]
public partial class WorkflowInstance
{
    [Key]
    public Guid WorkflowInstanceId { get; set; }

    public Guid TenantId { get; set; }

    public Guid WorkflowDefinitionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EntityType { get; set; } = null!;

    public Guid EntityId { get; set; }

    public Guid CurrentStateId { get; set; }

    public DateTime StartedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowInstanceCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("CurrentStateId")]
    [InverseProperty("WorkflowInstances")]
    public virtual WorkflowState CurrentState { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowInstanceLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("WorkflowInstances")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("WorkflowInstance")]
    public virtual ICollection<WorkflowComment> WorkflowComments { get; set; } = new List<WorkflowComment>();

    [ForeignKey("WorkflowDefinitionId")]
    [InverseProperty("WorkflowInstances")]
    public virtual WorkflowDefinition WorkflowDefinition { get; set; } = null!;

    [InverseProperty("WorkflowInstance")]
    public virtual ICollection<WorkflowHistory> WorkflowHistories { get; set; } = new List<WorkflowHistory>();

    [InverseProperty("WorkflowInstance")]
    public virtual ICollection<WorkflowInstanceState> WorkflowInstanceStates { get; set; } = new List<WorkflowInstanceState>();

    [InverseProperty("WorkflowInstance")]
    public virtual ICollection<WorkflowNotification> WorkflowNotifications { get; set; } = new List<WorkflowNotification>();

    [InverseProperty("WorkflowInstance")]
    public virtual ICollection<WorkflowTask> WorkflowTasks { get; set; } = new List<WorkflowTask>();

    [InverseProperty("WorkflowInstance")]
    public virtual ICollection<WorkflowVariable> WorkflowVariables { get; set; } = new List<WorkflowVariable>();
}
