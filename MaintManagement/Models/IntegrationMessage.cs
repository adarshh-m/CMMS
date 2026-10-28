using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationMessage", Schema = "integration")]
[Index("Status", Name = "IX_Message_Status")]
public partial class IntegrationMessage
{
    [Key]
    public Guid IntegrationMessageId { get; set; }

    public Guid TenantId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Direction { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MessageType { get; set; }

    public string? Payload { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public DateTime CreatedOn { get; set; }

    [InverseProperty("IntegrationMessage")]
    public virtual ICollection<IntegrationDeadLetter> IntegrationDeadLetters { get; set; } = new List<IntegrationDeadLetter>();

    [InverseProperty("IntegrationMessage")]
    public virtual ICollection<IntegrationRetry> IntegrationRetries { get; set; } = new List<IntegrationRetry>();

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationMessages")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("IntegrationMessages")]
    public virtual Tenant Tenant { get; set; } = null!;
}
