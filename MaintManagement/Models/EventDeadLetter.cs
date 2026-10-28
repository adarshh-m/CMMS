using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventDeadLetter", Schema = "eventbus")]
[Index("ResolutionStatus", Name = "IX_EventDeadLetter_Status")]
public partial class EventDeadLetter
{
    [Key]
    public Guid EventDeadLetterId { get; set; }

    public Guid TenantId { get; set; }

    public Guid EventOutboxId { get; set; }

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
    [InverseProperty("EventDeadLetterCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("EventOutboxId")]
    [InverseProperty("EventDeadLetters")]
    public virtual EventOutbox EventOutbox { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventDeadLetterLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("EventDeadLetters")]
    public virtual Tenant Tenant { get; set; } = null!;
}
