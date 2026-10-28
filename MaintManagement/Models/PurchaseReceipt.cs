using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PurchaseReceipt", Schema = "inventory")]
public partial class PurchaseReceipt
{
    [Key]
    public Guid PurchaseReceiptId { get; set; }

    public Guid TenantId { get; set; }

    [Column("ERPReceiptNumber")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ErpreceiptNumber { get; set; }

    public Guid VendorId { get; set; }

    public DateTime ReceiptDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PurchaseOrderNumber { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalAmount { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PurchaseReceiptCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PurchaseReceiptLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("PurchaseReceipt")]
    public virtual ICollection<PurchaseReceiptItem> PurchaseReceiptItems { get; set; } = new List<PurchaseReceiptItem>();

    [ForeignKey("TenantId")]
    [InverseProperty("PurchaseReceipts")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("VendorId")]
    [InverseProperty("PurchaseReceipts")]
    public virtual Vendor Vendor { get; set; } = null!;
}
