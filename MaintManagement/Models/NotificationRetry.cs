using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationRetry", Schema = "notification")]
[Index("RetryDate", Name = "IX_Retry_Date")]
public partial class NotificationRetry
{
    [Key]
    public Guid NotificationRetryId { get; set; }

    public Guid NotificationDeliveryId { get; set; }

    public int RetryAttemptNo { get; set; }

    public DateTime RetryDate { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? RetryStatus { get; set; }

    public string? ErrorMessage { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationRetryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationRetryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("NotificationDeliveryId")]
    [InverseProperty("NotificationRetries")]
    public virtual NotificationDelivery NotificationDelivery { get; set; } = null!;
}
