using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationDelivery", Schema = "notification")]
[Index("ChannelCode", Name = "IX_Delivery_Channel")]
[Index("DeliveryStatus", Name = "IX_Delivery_Status")]
public partial class NotificationDelivery
{
    [Key]
    public Guid NotificationDeliveryId { get; set; }

    public Guid NotificationRecipientId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ChannelCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? ProviderMessageId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DeliveryStatus { get; set; }

    public DateTime? SentOn { get; set; }

    public DateTime? DeliveredOn { get; set; }

    public string? ErrorMessage { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationDeliveryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationDeliveryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("NotificationRecipientId")]
    [InverseProperty("NotificationDeliveries")]
    public virtual NotificationRecipient NotificationRecipient { get; set; } = null!;

    [InverseProperty("NotificationDelivery")]
    public virtual ICollection<NotificationRetry> NotificationRetries { get; set; } = new List<NotificationRetry>();
}
