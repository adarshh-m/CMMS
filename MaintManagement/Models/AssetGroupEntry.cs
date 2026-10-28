using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetGroupEntry", Schema = "asset")]
[Index("AssetGroupId", "AssetId", Name = "UQ_AssetGroupEntry_AssetGroup_Asset", IsUnique = true)]
public partial class AssetGroupEntry
{
    [Key]
    public Guid AssetGroupEntryId { get; set; }

    public Guid TenantId { get; set; }

    public Guid AssetGroupId { get; set; }

    public Guid AssetId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("AssetGroupEntries")]
    public virtual Asset Asset { get; set; } = null!;

    [ForeignKey("AssetGroupId")]
    [InverseProperty("AssetGroupEntries")]
    public virtual AssetGroup AssetGroup { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetGroupEntryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetGroupEntryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AssetGroupEntries")]
    public virtual Tenant Tenant { get; set; } = null!;
}
