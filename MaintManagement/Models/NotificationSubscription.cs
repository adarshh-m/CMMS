using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationSubscription", Schema = "notification")]
[Index("UserId", Name = "IX_Subscription_User")]
public partial class NotificationSubscription
{
    [Key]
    public Guid NotificationSubscriptionId { get; set; }

    public Guid TenantId { get; set; }

    public Guid NotificationEventId { get; set; }

    public Guid UserId { get; set; }

    public bool IsEnabled { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationSubscriptionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationSubscriptionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("NotificationEventId")]
    [InverseProperty("NotificationSubscriptions")]
    public virtual NotificationEvent NotificationEvent { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("NotificationSubscriptions")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("NotificationSubscriptionUsers")]
    public virtual User User { get; set; } = null!;
}
