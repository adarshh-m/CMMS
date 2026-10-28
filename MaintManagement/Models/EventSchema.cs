using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventSchema", Schema = "eventbus")]
public partial class EventSchema
{
    [Key]
    public Guid EventSchemaId { get; set; }

    public Guid EventTypeId { get; set; }

    public int VersionNo { get; set; }

    public string? JsonSchema { get; set; }

    public DateTime EffectiveDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventSchemaCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("EventTypeId")]
    [InverseProperty("EventSchemas")]
    public virtual EventType EventType { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventSchemaLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
