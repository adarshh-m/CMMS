using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationEvidence", Schema = "calibration")]
public partial class CalibrationEvidence
{
    [Key]
    public Guid CalibrationEvidenceId { get; set; }

    public Guid CalibrationExecutionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EvidenceType { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? FileUrl { get; set; }

    public DateTime UploadedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationExecutionId")]
    [InverseProperty("CalibrationEvidences")]
    public virtual CalibrationExecution CalibrationExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationEvidenceCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationEvidenceLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
