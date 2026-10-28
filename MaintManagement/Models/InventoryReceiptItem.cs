using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryReceiptItem", Schema = "inventory")]
public partial class InventoryReceiptItem
{
    [Key]
    public Guid InventoryReceiptItemId { get; set; }

    public Guid InventoryReceiptId { get; set; }

    public Guid MaterialId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LotNo { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? UnitCost { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryReceiptItemCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("InventoryReceiptId")]
    [InverseProperty("InventoryReceiptItems")]
    public virtual InventoryReceipt InventoryReceipt { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryReceiptItemLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryReceiptItems")]
    public virtual Material Material { get; set; } = null!;
}
