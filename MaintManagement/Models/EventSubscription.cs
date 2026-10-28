using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventSubscription", Schema = "eventbus")]
public partial class EventSubscription
{
    [Key]
    public Guid EventSubscriptionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string SubscriberCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string? SubscriberName { get; set; }

    public Guid EventTypeId { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventSubscriptionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("EventTypeId")]
    [InverseProperty("EventSubscriptions")]
    public virtual EventType EventType { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventSubscriptionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
