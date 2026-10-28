using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationDeadLetter", Schema = "integration")]
[Index("ResolutionStatus", Name = "IX_DeadLetter_Status")]
public partial class IntegrationDeadLetter
{
    [Key]
    public Guid DeadLetterId { get; set; }

    public Guid IntegrationMessageId { get; set; }

    public string? FailureReason { get; set; }

    public DateTime FailedOn { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? ResolutionStatus { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationDeadLetterCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationMessageId")]
    [InverseProperty("IntegrationDeadLetters")]
    public virtual IntegrationMessage IntegrationMessage { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationDeadLetterLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
