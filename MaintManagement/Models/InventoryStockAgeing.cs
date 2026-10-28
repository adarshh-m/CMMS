using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryStockAgeing", Schema = "inventory")]
public partial class InventoryStockAgeing
{
    [Key]
    public Guid InventoryStockAgeingId { get; set; }

    public Guid TenantId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid WarehouseId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AgeBucket { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? InventoryValue { get; set; }

    public DateOnly SnapshotDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryStockAgeingCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryStockAgeingLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryStockAgeings")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("InventoryStockAgeings")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    [InverseProperty("InventoryStockAgeings")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
