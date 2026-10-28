using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMExecutionReading", Schema = "pm")]
public partial class PmexecutionReading
{
    [Key]
    [Column("PMExecutionReadingId")]
    public Guid PmexecutionReadingId { get; set; }

    [Column("PMExecutionId")]
    public Guid PmexecutionId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? ReadingName { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ReadingValue { get; set; }

    [Column("UOM")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Uom { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? MinValue { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? MaxValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmexecutionReadingCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmexecutionReadingLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmexecutionId")]
    [InverseProperty("PmexecutionReadings")]
    public virtual Pmexecution Pmexecution { get; set; } = null!;
}
