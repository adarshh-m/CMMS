using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowHistory", Schema = "workflow")]
[Index("WorkflowInstanceId", Name = "IX_WorkflowHistory_Instance")]
public partial class WorkflowHistory
{
    [Key]
    public Guid WorkflowHistoryId { get; set; }

    public Guid WorkflowInstanceId { get; set; }

    public Guid? FromStateId { get; set; }

    public Guid? ToStateId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ActionPerformed { get; set; }

    public Guid? PerformedByUserId { get; set; }

    public DateTime PerformedOn { get; set; }

    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowHistoryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("FromStateId")]
    [InverseProperty("WorkflowHistoryFromStates")]
    public virtual WorkflowState? FromState { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowHistoryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PerformedByUserId")]
    [InverseProperty("WorkflowHistoryPerformedByUsers")]
    public virtual User? PerformedByUser { get; set; }

    [ForeignKey("ToStateId")]
    [InverseProperty("WorkflowHistoryToStates")]
    public virtual WorkflowState? ToState { get; set; }

    [ForeignKey("WorkflowInstanceId")]
    [InverseProperty("WorkflowHistories")]
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;
}
