using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AssetLocation", Schema = "asset")]
public partial class AssetLocation
{
    [Key]
    public Guid LocationId { get; set; }

    public Guid TenantId { get; set; }

    public Guid WorkCenterId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LocationCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? LocationName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("Location")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("AssetLocationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AssetLocationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("AssetLocations")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WorkCenterId")]
    [InverseProperty("AssetLocations")]
    public virtual WorkCenter WorkCenter { get; set; } = null!;
}
