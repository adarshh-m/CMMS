using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationRetry", Schema = "integration")]
public partial class IntegrationRetry
{
    [Key]
    public Guid IntegrationRetryId { get; set; }

    public Guid IntegrationMessageId { get; set; }

    public int RetryNumber { get; set; }

    public DateTime RetryDate { get; set; }

    public string? ErrorMessage { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationRetryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationMessageId")]
    [InverseProperty("IntegrationRetries")]
    public virtual IntegrationMessage IntegrationMessage { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationRetryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
