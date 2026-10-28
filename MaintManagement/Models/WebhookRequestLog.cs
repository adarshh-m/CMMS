using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WebhookRequestLog", Schema = "integration")]
[Index("RequestDate", Name = "IX_Webhook_Date")]
public partial class WebhookRequestLog
{
    [Key]
    public Guid WebhookRequestLogId { get; set; }

    public Guid WebhookSubscriptionId { get; set; }

    public DateTime RequestDate { get; set; }

    public string? RequestPayload { get; set; }

    public int? ResponseCode { get; set; }

    public string? ResponsePayload { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WebhookRequestLogCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WebhookRequestLogLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WebhookSubscriptionId")]
    [InverseProperty("WebhookRequestLogs")]
    public virtual WebhookSubscription WebhookSubscription { get; set; } = null!;
}
