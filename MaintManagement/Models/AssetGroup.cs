using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetGroup", Schema = "asset")]
public partial class AssetGroup
{
    [Key]
    public Guid AssetGroupId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string AssetGroupName { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("AssetGroup")]
    public virtual ICollection<AssetGroupEntry> AssetGroupEntries { get; set; } = new List<AssetGroupEntry>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetGroupCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetGroupLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AssetGroups")]
    public virtual Tenant Tenant { get; set; } = null!;
}
