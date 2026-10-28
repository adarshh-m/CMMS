using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationVersion", Schema = "calibration")]
public partial class CalibrationVersion
{
    [Key]
    public Guid CalibrationVersionId { get; set; }

    public Guid CalibrationMethodId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string VersionNo { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? SupersededVersion { get; set; }

    public DateOnly EffectiveDate { get; set; }

    [StringLength(1000)]
    public string? ChangeReason { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationMethodId")]
    [InverseProperty("CalibrationVersions")]
    public virtual CalibrationMethod CalibrationMethod { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationVersionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationVersionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
