using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventInbox", Schema = "eventbus")]
[Index("SubscriberCode", "EventId", Name = "IX_EventInbox_Event")]
[Index("SubscriberCode", "EventId", Name = "UX_EventInbox", IsUnique = true)]
public partial class EventInbox
{
    [Key]
    public Guid EventInboxId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string SubscriberCode { get; set; } = null!;

    public Guid EventId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EventTypeCode { get; set; }

    public DateTime? ProcessedOn { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public string? ErrorMessage { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventInboxCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventInboxLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
