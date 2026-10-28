using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationMapping", Schema = "integration")]
public partial class IntegrationMapping
{
    [Key]
    public Guid IntegrationMappingId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SourceEntity { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SourceField { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TargetEntity { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TargetField { get; set; }

    public string? TransformationRule { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationMappingCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationMappings")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationMappingLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
