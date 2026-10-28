using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationEndpoint", Schema = "integration")]
public partial class IntegrationEndpoint
{
    [Key]
    public Guid IntegrationEndpointId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EndpointCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EndpointType { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? BaseUrl { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? HttpMethod { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationEndpointCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationEndpoints")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationEndpointLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
