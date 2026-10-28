using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Asset", Schema = "asset")]
[Index("TenantId", Name = "IX_Asset_Tenant")]
[Index("TenantId", "AssetCode", Name = "UX_Asset_Code", IsUnique = true)]
public partial class Asset
{
    [Key]
    public Guid AssetId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AssetCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string AssetName { get; set; } = null!;

    public Guid AssetTypeId { get; set; }

    public Guid AssetCategoryId { get; set; }

    public Guid AssetCriticalityId { get; set; }

    public Guid AssetStatusId { get; set; }

    public Guid LocationId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Manufacturer { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ModelNo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SerialNo { get; set; }

    public DateOnly? CommissionDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetCategoryId")]
    [InverseProperty("Assets")]
    public virtual AssetCategory AssetCategory { get; set; } = null!;

    [ForeignKey("AssetCriticalityId")]
    [InverseProperty("Assets")]
    public virtual AssetCriticality AssetCriticality { get; set; } = null!;

    [InverseProperty("Asset")]
    public virtual ICollection<AssetGroupEntry> AssetGroupEntries { get; set; } = new List<AssetGroupEntry>();

    [InverseProperty("ChildAsset")]
    public virtual ICollection<AssetHierarchy> AssetHierarchyChildAssets { get; set; } = new List<AssetHierarchy>();

    [InverseProperty("ParentAsset")]
    public virtual ICollection<AssetHierarchy> AssetHierarchyParentAssets { get; set; } = new List<AssetHierarchy>();

    [ForeignKey("AssetStatusId")]
    [InverseProperty("Assets")]
    public virtual AssetStatus AssetStatus { get; set; } = null!;

    [ForeignKey("AssetTypeId")]
    [InverseProperty("Assets")]
    public virtual AssetType AssetType { get; set; } = null!;

    [InverseProperty("Asset")]
    public virtual ICollection<Breakdown> Breakdowns { get; set; } = new List<Breakdown>();

    [InverseProperty("Asset")]
    public virtual ICollection<CalibrationAsset> CalibrationAssets { get; set; } = new List<CalibrationAsset>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Assets")]
    public virtual AssetLocation Location { get; set; } = null!;

    [InverseProperty("Asset")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    [InverseProperty("Asset")]
    public virtual ICollection<PermitAsset> PermitAssets { get; set; } = new List<PermitAsset>();

    [InverseProperty("Asset")]
    public virtual ICollection<PmscheduleAsset> PmscheduleAssets { get; set; } = new List<PmscheduleAsset>();

    [InverseProperty("Asset")]
    public virtual ICollection<Pmschedule> Pmschedules { get; set; } = new List<Pmschedule>();

    [ForeignKey("TenantId")]
    [InverseProperty("Assets")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("Asset")]
    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
