using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetType", Schema = "asset")]
public partial class AssetType
{
    [Key]
    public Guid AssetTypeId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("AssetType")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetTypeCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetTypeLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AssetTypes")]
    public virtual Tenant Tenant { get; set; } = null!;
}
