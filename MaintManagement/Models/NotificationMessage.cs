using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationMessage", Schema = "notification")]
[Index("NotificationEventId", Name = "IX_Message_Event")]
[Index("Status", Name = "IX_Message_Status")]
public partial class NotificationMessage
{
    [Key]
    public Guid NotificationMessageId { get; set; }

    public Guid TenantId { get; set; }

    public Guid NotificationEventId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EntityType { get; set; }

    public Guid? EntityId { get; set; }

    public string? Payload { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Priority { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? SentOn { get; set; }

    [InverseProperty("NotificationMessage")]
    public virtual ICollection<NotificationAttachment> NotificationAttachments { get; set; } = new List<NotificationAttachment>();

    [ForeignKey("NotificationEventId")]
    [InverseProperty("NotificationMessages")]
    public virtual NotificationEvent NotificationEvent { get; set; } = null!;

    [InverseProperty("NotificationMessage")]
    public virtual ICollection<NotificationRecipient> NotificationRecipients { get; set; } = new List<NotificationRecipient>();

    [ForeignKey("TenantId")]
    [InverseProperty("NotificationMessages")]
    public virtual Tenant Tenant { get; set; } = null!;
}
