using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetHierarchy", Schema = "asset")]
public partial class AssetHierarchy
{
    [Key]
    public Guid AssetHierarchyId { get; set; }

    public Guid TenantId { get; set; }

    public Guid ParentAssetId { get; set; }

    public Guid ChildAssetId { get; set; }

    public int LevelNo { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChildAssetId")]
    [InverseProperty("AssetHierarchyChildAssets")]
    public virtual Asset ChildAsset { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetHierarchyCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetHierarchyLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("ParentAssetId")]
    [InverseProperty("AssetHierarchyParentAssets")]
    public virtual Asset ParentAsset { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("AssetHierarchies")]
    public virtual Tenant Tenant { get; set; } = null!;
}
