using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationReading", Schema = "calibration")]
public partial class CalibrationReading
{
    [Key]
    public Guid CalibrationReadingId { get; set; }

    public Guid CalibrationExecutionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TestPoint { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal? NominalValue { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal? AsFoundValue { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal? AsLeftValue { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal? ToleranceValue { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UnitOfMeasure { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationExecutionId")]
    [InverseProperty("CalibrationReadings")]
    public virtual CalibrationExecution CalibrationExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationReadingCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationReadingLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
