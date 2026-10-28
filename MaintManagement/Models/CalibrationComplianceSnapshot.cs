using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationComplianceSnapshot", Schema = "calibration")]
[Index("SnapshotYear", "SnapshotMonth", Name = "IX_ComplianceSnapshot_Period")]
public partial class CalibrationComplianceSnapshot
{
    [Key]
    public Guid CalibrationComplianceSnapshotId { get; set; }

    public Guid TenantId { get; set; }

    public Guid PlantId { get; set; }

    public int SnapshotMonth { get; set; }

    public int SnapshotYear { get; set; }

    public int TotalDue { get; set; }

    public int TotalCompleted { get; set; }

    public int OverdueCount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CompliancePercent { get; set; }

    public DateTime CalculatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationComplianceSnapshotCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationComplianceSnapshotLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PlantId")]
    [InverseProperty("CalibrationComplianceSnapshots")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("CalibrationComplianceSnapshots")]
    public virtual Tenant Tenant { get; set; } = null!;
}
