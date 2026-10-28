using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryTransactionOutbox", Schema = "inventory")]
public partial class InventoryTransactionOutbox
{
    [Key]
    public Guid OutboxId { get; set; }

    public Guid TenantId { get; set; }

    public Guid TransactionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EventType { get; set; }

    public string? Payload { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ProcessedOn { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("InventoryTransactionOutboxes")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("TransactionId")]
    [InverseProperty("InventoryTransactionOutboxes")]
    public virtual InventoryTransaction Transaction { get; set; } = null!;
}
