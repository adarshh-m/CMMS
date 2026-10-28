using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventConsumerOffset", Schema = "eventbus")]
public partial class EventConsumerOffset
{
    [Key]
    public Guid EventConsumerOffsetId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SubscriberCode { get; set; }

    public Guid? LastProcessedEventId { get; set; }

    public DateTime? LastProcessedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventConsumerOffsetCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventConsumerOffsetLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
