using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WebhookSubscription", Schema = "integration")]
public partial class WebhookSubscription
{
    [Key]
    public Guid WebhookSubscriptionId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? SubscriptionName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? EndpointUrl { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? SecretKeyReference { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WebhookSubscriptionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WebhookSubscriptionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("WebhookSubscriptions")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("WebhookSubscription")]
    public virtual ICollection<WebhookRequestLog> WebhookRequestLogs { get; set; } = new List<WebhookRequestLog>();
}
