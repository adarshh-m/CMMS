using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetCriticality", Schema = "asset")]
public partial class AssetCriticality
{
    [Key]
    public Guid AssetCriticalityId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }

    public int? ResponseSlaMinutes { get; set; }

    public int? ResolutionSlaMinutes { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("AssetCriticality")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetCriticalityCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetCriticalityLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AssetCriticalities")]
    public virtual Tenant Tenant { get; set; } = null!;
}
