using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationExecution", Schema = "calibration")]
[Index("ExecutionDate", Name = "IX_CalibrationExecution_Date")]
public partial class CalibrationExecution
{
    [Key]
    public Guid CalibrationExecutionId { get; set; }

    public Guid TenantId { get; set; }

    public Guid CalibrationWorkOrderId { get; set; }

    public Guid ExecutedByUserId { get; set; }

    public DateTime ExecutionDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AmbientTemperature { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AmbientHumidity { get; set; }

    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("CalibrationExecution")]
    public virtual ICollection<CalibrationCertificate> CalibrationCertificates { get; set; } = new List<CalibrationCertificate>();

    [InverseProperty("CalibrationExecution")]
    public virtual ICollection<CalibrationEvidence> CalibrationEvidences { get; set; } = new List<CalibrationEvidence>();

    [InverseProperty("CalibrationExecution")]
    public virtual ICollection<CalibrationOotassessment> CalibrationOotassessments { get; set; } = new List<CalibrationOotassessment>();

    [InverseProperty("CalibrationExecution")]
    public virtual ICollection<CalibrationReading> CalibrationReadings { get; set; } = new List<CalibrationReading>();

    [InverseProperty("CalibrationExecution")]
    public virtual ICollection<CalibrationResult> CalibrationResults { get; set; } = new List<CalibrationResult>();

    [InverseProperty("CalibrationExecution")]
    public virtual ICollection<CalibrationSignature> CalibrationSignatures { get; set; } = new List<CalibrationSignature>();

    [ForeignKey("CalibrationWorkOrderId")]
    [InverseProperty("CalibrationExecutions")]
    public virtual CalibrationWorkOrder CalibrationWorkOrder { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationExecutionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ExecutedByUserId")]
    [InverseProperty("CalibrationExecutionExecutedByUsers")]
    public virtual User ExecutedByUser { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationExecutionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("CalibrationExecutions")]
    public virtual Tenant Tenant { get; set; } = null!;
}
