using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("GoodsReceiptNote", Schema = "inventory")]
public partial class GoodsReceiptNote
{
    [Key]
    [Column("GRNId")]
    public Guid Grnid { get; set; }

    public Guid TenantId { get; set; }

    [Column("GRNNumber")]
    [StringLength(100)]
    [Unicode(false)]
    public string Grnnumber { get; set; } = null!;

    public Guid ReceiptId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? VendorDeliveryNote { get; set; }

    [Column("GRNDate")]
    public DateTime Grndate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("GoodsReceiptNoteCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("GoodsReceiptNoteLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("ReceiptId")]
    [InverseProperty("GoodsReceiptNotes")]
    public virtual InventoryReceipt Receipt { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("GoodsReceiptNotes")]
    public virtual Tenant Tenant { get; set; } = null!;
}
