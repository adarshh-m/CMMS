using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetCategory", Schema = "asset")]
public partial class AssetCategory
{
    [Key]
    public Guid AssetCategoryId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("AssetCategory")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetCategoryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetCategoryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AssetCategories")]
    public virtual Tenant Tenant { get; set; } = null!;
}
