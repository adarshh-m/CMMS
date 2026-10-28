using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("TenantFeature", Schema = "security")]
public partial class TenantFeature
{
    [Key]
    public Guid TenantFeatureId { get; set; }

    public Guid TenantId { get; set; }

    public Guid FeatureId { get; set; }

    public bool IsEnabled { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TenantFeatureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("FeatureId")]
    [InverseProperty("TenantFeatures")]
    public virtual Feature Feature { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("TenantFeatureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("TenantFeatures")]
    public virtual Tenant Tenant { get; set; } = null!;
}
