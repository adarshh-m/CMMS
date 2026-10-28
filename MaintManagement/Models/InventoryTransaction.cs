using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryTransaction", Schema = "inventory")]
[Index("TransactionDate", Name = "IX_InventoryTransaction_Date")]
[Index("TransactionType", Name = "IX_InventoryTransaction_Type")]
public partial class InventoryTransaction
{
    [Key]
    public Guid InventoryTransactionId { get; set; }

    public Guid TenantId { get; set; }

    public Guid MaterialId { get; set; }

    public DateTime TransactionDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TransactionType { get; set; } = null!;

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? UnitCost { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReferenceNumber { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ExternalTransactionId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryTransactionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("InventoryTransaction")]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustments { get; set; } = new List<InventoryAdjustment>();

    [InverseProperty("InventoryTransaction")]
    public virtual ICollection<InventoryConsumption> InventoryConsumptions { get; set; } = new List<InventoryConsumption>();

    [InverseProperty("Transaction")]
    public virtual ICollection<InventoryIntegrationLog> InventoryIntegrationLogs { get; set; } = new List<InventoryIntegrationLog>();

    [InverseProperty("InventoryTransaction")]
    public virtual ICollection<InventoryIssue> InventoryIssues { get; set; } = new List<InventoryIssue>();

    [InverseProperty("InventoryTransaction")]
    public virtual ICollection<InventoryReturn> InventoryReturns { get; set; } = new List<InventoryReturn>();

    [InverseProperty("Transaction")]
    public virtual ICollection<InventoryTransactionOutbox> InventoryTransactionOutboxes { get; set; } = new List<InventoryTransactionOutbox>();

    [InverseProperty("InventoryTransaction")]
    public virtual ICollection<InventoryTransfer> InventoryTransfers { get; set; } = new List<InventoryTransfer>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryTransactionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryTransactions")]
    public virtual Material Material { get; set; } = null!;

    [InverseProperty("Transaction")]
    public virtual ICollection<MaterialCostLedger> MaterialCostLedgers { get; set; } = new List<MaterialCostLedger>();

    [ForeignKey("TenantId")]
    [InverseProperty("InventoryTransactions")]
    public virtual Tenant Tenant { get; set; } = null!;
}
