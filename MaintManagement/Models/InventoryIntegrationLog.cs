using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryIntegrationLog", Schema = "inventory")]
public partial class InventoryIntegrationLog
{
    [Key]
    public Guid InventoryIntegrationLogId { get; set; }

    public Guid TenantId { get; set; }

    public Guid? TransactionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IntegrationSystem { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ExternalReferenceNo { get; set; }

    public string? RequestPayload { get; set; }

    public string? ResponsePayload { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public int RetryCount { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("InventoryIntegrationLogs")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("TransactionId")]
    [InverseProperty("InventoryIntegrationLogs")]
    public virtual InventoryTransaction? Transaction { get; set; }
}
