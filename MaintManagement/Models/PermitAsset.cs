using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitAsset", Schema = "permit")]
[Index("AssetId", Name = "IX_PermitAsset_Asset")]
public partial class PermitAsset
{
    [Key]
    public Guid PermitAssetId { get; set; }

    public Guid PermitId { get; set; }

    public Guid AssetId { get; set; }

    public bool IsolationRequired { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("PermitAssets")]
    public virtual Asset Asset { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitAssetCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitAssetLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitAssets")]
    public virtual Permit Permit { get; set; } = null!;
}
