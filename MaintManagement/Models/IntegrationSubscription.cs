using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationSubscription", Schema = "integration")]
public partial class IntegrationSubscription
{
    [Key]
    public Guid IntegrationSubscriptionId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    public Guid IntegrationEventId { get; set; }

    public bool IsEnabled { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationSubscriptionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationEventId")]
    [InverseProperty("IntegrationSubscriptions")]
    public virtual IntegrationEvent IntegrationEvent { get; set; } = null!;

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationSubscriptions")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationSubscriptionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
