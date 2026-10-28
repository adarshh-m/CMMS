using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationRecipient", Schema = "notification")]
public partial class NotificationRecipient
{
    [Key]
    public Guid NotificationRecipientId { get; set; }

    public Guid NotificationMessageId { get; set; }

    public Guid? UserId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? RecipientAddress { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RecipientType { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationRecipientCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationRecipientLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("NotificationRecipient")]
    public virtual ICollection<NotificationDelivery> NotificationDeliveries { get; set; } = new List<NotificationDelivery>();

    [ForeignKey("NotificationMessageId")]
    [InverseProperty("NotificationRecipients")]
    public virtual NotificationMessage NotificationMessage { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("NotificationRecipientUsers")]
    public virtual User? User { get; set; }
}
