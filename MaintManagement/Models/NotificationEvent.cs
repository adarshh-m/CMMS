using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationEvent", Schema = "notification")]
public partial class NotificationEvent
{
    [Key]
    public Guid NotificationEventId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EventCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string EventName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationEventCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationEventLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("NotificationEvent")]
    public virtual ICollection<NotificationMessage> NotificationMessages { get; set; } = new List<NotificationMessage>();

    [InverseProperty("NotificationEvent")]
    public virtual ICollection<NotificationSubscription> NotificationSubscriptions { get; set; } = new List<NotificationSubscription>();

    [InverseProperty("NotificationEvent")]
    public virtual ICollection<NotificationTemplate> NotificationTemplates { get; set; } = new List<NotificationTemplate>();

    [ForeignKey("TenantId")]
    [InverseProperty("NotificationEvents")]
    public virtual Tenant Tenant { get; set; } = null!;
}
