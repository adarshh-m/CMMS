using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("EventBatch", Schema = "eventbus")]
public partial class EventBatch
{
    [Key]
    public Guid EventBatchId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BatchNo { get; set; }

    public DateTime? BatchStart { get; set; }

    public DateTime? BatchEnd { get; set; }

    public int? EventCount { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventBatchCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("EventBatchLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
