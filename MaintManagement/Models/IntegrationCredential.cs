using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationCredential", Schema = "integration")]
public partial class IntegrationCredential
{
    [Key]
    public Guid IntegrationCredentialId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AuthenticationType { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ClientId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? SecretReference { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? TokenEndpoint { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CertificateReference { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationCredentialCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationCredentials")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationCredentialLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
