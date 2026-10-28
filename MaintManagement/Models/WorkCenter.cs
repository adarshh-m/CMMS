using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkCenter", Schema = "masterdata")]
public partial class WorkCenter
{
    [Key]
    public Guid WorkCenterId { get; set; }

    public Guid TenantId { get; set; }

    public Guid ProductionLineId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? WorkCenterCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? WorkCenterName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("WorkCenter")]
    public virtual ICollection<AssetLocation> AssetLocations { get; set; } = new List<AssetLocation>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkCenterCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkCenterLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("ProductionLineId")]
    [InverseProperty("WorkCenters")]
    public virtual ProductionLine ProductionLine { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("WorkCenters")]
    public virtual Tenant Tenant { get; set; } = null!;
}
