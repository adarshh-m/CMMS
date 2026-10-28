using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryAdjustment", Schema = "inventory")]
public partial class InventoryAdjustment
{
    [Key]
    public Guid InventoryAdjustmentId { get; set; }

    public Guid InventoryTransactionId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? AdjustmentReason { get; set; }

    public Guid? ApprovedByUserId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ApprovedByUserId")]
    [InverseProperty("InventoryAdjustmentApprovedByUsers")]
    public virtual User? ApprovedByUser { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryAdjustmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("InventoryTransactionId")]
    [InverseProperty("InventoryAdjustments")]
    public virtual InventoryTransaction InventoryTransaction { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryAdjustmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
