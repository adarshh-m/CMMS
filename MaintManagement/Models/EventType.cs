using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventType", Schema = "eventbus")]
[Index("EventCode", Name = "UQ__EventTyp__640F6716D6038C59", IsUnique = true)]
public partial class EventType
{
    [Key]
    public Guid EventTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EventCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string EventName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Category { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventTypeCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("EventType")]
    public virtual ICollection<EventOutbox> EventOutboxes { get; set; } = new List<EventOutbox>();

    [InverseProperty("EventType")]
    public virtual ICollection<EventSchema> EventSchemas { get; set; } = new List<EventSchema>();

    [InverseProperty("EventType")]
    public virtual ICollection<EventSubscription> EventSubscriptions { get; set; } = new List<EventSubscription>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventTypeLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
