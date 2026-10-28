using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationResult", Schema = "calibration")]
public partial class CalibrationResult
{
    [Key]
    public Guid CalibrationResultId { get; set; }

    public Guid CalibrationExecutionId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string ResultCode { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? ResultDescription { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationExecutionId")]
    [InverseProperty("CalibrationResults")]
    public virtual CalibrationExecution CalibrationExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationResultCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationResultLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
