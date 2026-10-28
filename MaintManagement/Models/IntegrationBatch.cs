using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationBatch", Schema = "integration")]
[Index("BatchStatus", Name = "IX_Batch_Status")]
public partial class IntegrationBatch
{
    [Key]
    public Guid IntegrationBatchId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BatchNumber { get; set; }

    public DateTime? BatchStartDate { get; set; }

    public DateTime? BatchEndDate { get; set; }

    public int? RecordCount { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? BatchStatus { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationBatchCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationBatches")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationBatchLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
