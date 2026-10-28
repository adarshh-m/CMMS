using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowNotification", Schema = "workflow")]
public partial class WorkflowNotification
{
    [Key]
    public Guid WorkflowNotificationId { get; set; }

    public Guid WorkflowInstanceId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NotificationType { get; set; }

    public Guid? RecipientUserId { get; set; }

    public DateTime? SentOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowNotificationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowNotificationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("RecipientUserId")]
    [InverseProperty("WorkflowNotificationRecipientUsers")]
    public virtual User? RecipientUser { get; set; }

    [ForeignKey("WorkflowInstanceId")]
    [InverseProperty("WorkflowNotifications")]
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;
}
