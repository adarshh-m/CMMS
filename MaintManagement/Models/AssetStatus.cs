using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetStatus", Schema = "asset")]
public partial class AssetStatus
{
    [Key]
    public Guid AssetStatusId { get; set; }

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

    [InverseProperty("AssetStatus")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetStatusCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetStatusLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AssetStatuses")]
    public virtual Tenant Tenant { get; set; } = null!;
}
