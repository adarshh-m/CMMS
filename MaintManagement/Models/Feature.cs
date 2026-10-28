using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Feature", Schema = "security")]
[Index("FeatureCode", Name = "UQ__Feature__75CE31547B413CDF", IsUnique = true)]
public partial class Feature
{
    [Key]
    public Guid FeatureId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FeatureCode { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? FeatureName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("FeatureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("FeatureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Feature")]
    public virtual ICollection<TenantFeature> TenantFeatures { get; set; } = new List<TenantFeature>();
}
