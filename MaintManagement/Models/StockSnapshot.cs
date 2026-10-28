using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("StockSnapshot", Schema = "inventory")]
public partial class StockSnapshot
{
    [Key]
    public Guid StockSnapshotId { get; set; }

    public Guid TenantId { get; set; }

    public DateOnly SnapshotDate { get; set; }

    public Guid MaterialId { get; set; }

    public Guid WarehouseId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? QuantityOnHand { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? InventoryValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("StockSnapshotCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("StockSnapshotLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("StockSnapshots")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("StockSnapshots")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    [InverseProperty("StockSnapshots")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
