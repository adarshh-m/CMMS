using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryReceipt", Schema = "inventory")]
public partial class InventoryReceipt
{
    [Key]
    public Guid InventoryReceiptId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ReceiptNumber { get; set; } = null!;

    public Guid WarehouseId { get; set; }

    public DateTime ReceiptDate { get; set; }

    public Guid? VendorId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReferenceDocumentNo { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public Guid ReceivedByUserId { get; set; }

    [StringLength(1000)]
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryReceiptCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("Receipt")]
    public virtual ICollection<GoodsReceiptNote> GoodsReceiptNotes { get; set; } = new List<GoodsReceiptNote>();

    [InverseProperty("InventoryReceipt")]
    public virtual ICollection<InventoryReceiptItem> InventoryReceiptItems { get; set; } = new List<InventoryReceiptItem>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryReceiptLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("ReceivedByUserId")]
    [InverseProperty("InventoryReceiptReceivedByUsers")]
    public virtual User ReceivedByUser { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("InventoryReceipts")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("VendorId")]
    [InverseProperty("InventoryReceipts")]
    public virtual Vendor? Vendor { get; set; }

    [ForeignKey("WarehouseId")]
    [InverseProperty("InventoryReceipts")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
