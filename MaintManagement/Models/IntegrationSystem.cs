using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationSystem", Schema = "integration")]
public partial class IntegrationSystem
{
    [Key]
    public Guid IntegrationSystemId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string SystemCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string SystemName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string SystemType { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationSystemCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationBatch> IntegrationBatches { get; set; } = new List<IntegrationBatch>();

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationConfiguration> IntegrationConfigurations { get; set; } = new List<IntegrationConfiguration>();

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationCredential> IntegrationCredentials { get; set; } = new List<IntegrationCredential>();

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationEndpoint> IntegrationEndpoints { get; set; } = new List<IntegrationEndpoint>();

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationMapping> IntegrationMappings { get; set; } = new List<IntegrationMapping>();

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationMessage> IntegrationMessages { get; set; } = new List<IntegrationMessage>();

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationSchedule> IntegrationSchedules { get; set; } = new List<IntegrationSchedule>();

    [InverseProperty("IntegrationSystem")]
    public virtual ICollection<IntegrationSubscription> IntegrationSubscriptions { get; set; } = new List<IntegrationSubscription>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationSystemLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("IntegrationSystems")]
    public virtual Tenant Tenant { get; set; } = null!;
}
