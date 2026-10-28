using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventPublicationLog", Schema = "eventbus")]
public partial class EventPublicationLog
{
    [Key]
    public Guid EventPublicationLogId { get; set; }

    public Guid EventOutboxId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PublishedTo { get; set; }

    public int AttemptNumber { get; set; }

    public DateTime PublishDate { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public string? ErrorMessage { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventPublicationLogCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("EventOutboxId")]
    [InverseProperty("EventPublicationLogs")]
    public virtual EventOutbox EventOutbox { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventPublicationLogLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
