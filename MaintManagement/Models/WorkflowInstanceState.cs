using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowInstanceState", Schema = "workflow")]
public partial class WorkflowInstanceState
{
    [Key]
    public Guid WorkflowInstanceStateId { get; set; }

    public Guid WorkflowInstanceId { get; set; }

    public Guid WorkflowStateId { get; set; }

    public DateTime EnteredOn { get; set; }

    public DateTime? ExitedOn { get; set; }

    public Guid? EnteredByUserId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowInstanceStateCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("EnteredByUserId")]
    [InverseProperty("WorkflowInstanceStateEnteredByUsers")]
    public virtual User? EnteredByUser { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowInstanceStateLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkflowInstanceId")]
    [InverseProperty("WorkflowInstanceStates")]
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;

    [ForeignKey("WorkflowStateId")]
    [InverseProperty("WorkflowInstanceStates")]
    public virtual WorkflowState WorkflowState { get; set; } = null!;
}
