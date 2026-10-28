using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationAsset", Schema = "calibration")]
public partial class CalibrationAsset
{
    [Key]
    public Guid CalibrationAssetId { get; set; }

    public Guid TenantId { get; set; }

    public Guid AssetId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string InstrumentNo { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? InstrumentType { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? MeasurementRange { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AccuracyClass { get; set; }

    public bool CalibrationRequired { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("CalibrationAssets")]
    public virtual Asset Asset { get; set; } = null!;

    [InverseProperty("CalibrationAsset")]
    public virtual ICollection<CalibrationSchedule> CalibrationSchedules { get; set; } = new List<CalibrationSchedule>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationAssetCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationAssetLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("CalibrationAssets")]
    public virtual Tenant Tenant { get; set; } = null!;
}
