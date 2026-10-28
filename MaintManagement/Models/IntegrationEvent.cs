using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationEvent", Schema = "integration")]
public partial class IntegrationEvent
{
    [Key]
    public Guid IntegrationEventId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EventCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string EventName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? SourceModule { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationEventCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("IntegrationEvent")]
    public virtual ICollection<IntegrationOutbox> IntegrationOutboxes { get; set; } = new List<IntegrationOutbox>();

    [InverseProperty("IntegrationEvent")]
    public virtual ICollection<IntegrationSubscription> IntegrationSubscriptions { get; set; } = new List<IntegrationSubscription>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationEventLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
