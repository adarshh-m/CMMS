using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ApiClient", Schema = "security")]
public partial class ApiClient
{
    [Key]
    public Guid ApiClientId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ClientCode { get; set; } = null!;

    public byte[]? ClientSecretHash { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("ApiClients")]
    public virtual Tenant Tenant { get; set; } = null!;
}
