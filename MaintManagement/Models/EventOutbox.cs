using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventOutbox", Schema = "eventbus")]
[Index("CreatedOn", Name = "IX_EventOutbox_CreatedOn")]
[Index("Status", Name = "IX_EventOutbox_Status")]
public partial class EventOutbox
{
    [Key]
    public Guid EventOutboxId { get; set; }

    public Guid TenantId { get; set; }

    public Guid EventTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AggregateType { get; set; } = null!;

    public Guid AggregateId { get; set; }

    public Guid? CorrelationId { get; set; }

    public string Payload { get; set; } = null!;

    public string? Headers { get; set; }

    public int EventVersion { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? PublishedOn { get; set; }

    [InverseProperty("EventOutbox")]
    public virtual ICollection<EventDeadLetter> EventDeadLetters { get; set; } = new List<EventDeadLetter>();

    [InverseProperty("EventOutbox")]
    public virtual ICollection<EventPublicationLog> EventPublicationLogs { get; set; } = new List<EventPublicationLog>();

    [InverseProperty("EventOutbox")]
    public virtual ICollection<EventReplayRequest> EventReplayRequests { get; set; } = new List<EventReplayRequest>();

    [ForeignKey("EventTypeId")]
    [InverseProperty("EventOutboxes")]
    public virtual EventType EventType { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("EventOutboxes")]
    public virtual Tenant Tenant { get; set; } = null!;
}
