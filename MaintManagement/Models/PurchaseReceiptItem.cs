using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PurchaseReceiptItem", Schema = "inventory")]
public partial class PurchaseReceiptItem
{
    [Key]
    public Guid PurchaseReceiptItemId { get; set; }

    public Guid PurchaseReceiptId { get; set; }

    public Guid MaterialId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? LineAmount { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PurchaseReceiptItemCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PurchaseReceiptItemLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("PurchaseReceiptItems")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("PurchaseReceiptId")]
    [InverseProperty("PurchaseReceiptItems")]
    public virtual PurchaseReceipt PurchaseReceipt { get; set; } = null!;
}
