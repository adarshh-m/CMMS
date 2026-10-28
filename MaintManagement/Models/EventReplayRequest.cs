using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventReplayRequest", Schema = "eventbus")]
public partial class EventReplayRequest
{
    [Key]
    public Guid EventReplayRequestId { get; set; }

    public Guid EventOutboxId { get; set; }

    public Guid RequestedByUserId { get; set; }

    public DateTime RequestedOn { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? ReplayStatus { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventReplayRequestCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("EventOutboxId")]
    [InverseProperty("EventReplayRequests")]
    public virtual EventOutbox EventOutbox { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventReplayRequestLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("RequestedByUserId")]
    [InverseProperty("EventReplayRequestRequestedByUsers")]
    public virtual User RequestedByUser { get; set; } = null!;
}
