using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMComplianceSnapshot", Schema = "pm")]
[Index("SnapshotYear", "SnapshotMonth", Name = "IX_PMCompliance_MonthYear")]
public partial class PmcomplianceSnapshot
{
    [Key]
    public Guid SnapshotId { get; set; }

    public Guid TenantId { get; set; }

    public Guid PlantId { get; set; }

    public int SnapshotMonth { get; set; }

    public int SnapshotYear { get; set; }

    public int? TotalDue { get; set; }

    public int? TotalCompleted { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CompliancePercent { get; set; }

    public DateTime CalculatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmcomplianceSnapshotCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmcomplianceSnapshotLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PlantId")]
    [InverseProperty("PmcomplianceSnapshots")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("PmcomplianceSnapshots")]
    public virtual Tenant Tenant { get; set; } = null!;
}
