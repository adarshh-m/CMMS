using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationOOTAssessment", Schema = "calibration")]
public partial class CalibrationOotassessment
{
    [Key]
    [Column("OOTAssessmentId")]
    public Guid OotassessmentId { get; set; }

    public Guid CalibrationExecutionId { get; set; }

    public string? ProductImpactAssessment { get; set; }

    public string? BatchImpactAssessment { get; set; }

    public string? MeasurementImpactAssessment { get; set; }

    [Column("CAPARequired")]
    public bool Caparequired { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationExecutionId")]
    [InverseProperty("CalibrationOotassessments")]
    public virtual CalibrationExecution CalibrationExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationOotassessmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationOotassessmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
