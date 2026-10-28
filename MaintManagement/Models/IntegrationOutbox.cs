using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationOutbox", Schema = "integration")]
[Index("Status", Name = "IX_Outbox_Status")]
public partial class IntegrationOutbox
{
    [Key]
    public Guid OutboxId { get; set; }

    public Guid TenantId { get; set; }

    public Guid IntegrationEventId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EntityType { get; set; }

    public Guid? EntityId { get; set; }

    public string? Payload { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? PublishedOn { get; set; }

    [ForeignKey("IntegrationEventId")]
    [InverseProperty("IntegrationOutboxes")]
    public virtual IntegrationEvent IntegrationEvent { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("IntegrationOutboxes")]
    public virtual Tenant Tenant { get; set; } = null!;
}
