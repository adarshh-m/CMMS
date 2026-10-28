using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationConfiguration", Schema = "integration")]
public partial class IntegrationConfiguration
{
    [Key]
    public Guid IntegrationConfigurationId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? ConfigurationKey { get; set; }

    public string? ConfigurationValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationConfigurationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationConfigurations")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationConfigurationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
