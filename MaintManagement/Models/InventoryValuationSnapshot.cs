using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryValuationSnapshot", Schema = "inventory")]
public partial class InventoryValuationSnapshot
{
    [Key]
    public Guid InventoryValuationSnapshotId { get; set; }

    public Guid TenantId { get; set; }

    public int SnapshotMonth { get; set; }

    public int SnapshotYear { get; set; }

    public Guid MaterialId { get; set; }

    public Guid WarehouseId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? UnitCost { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalValue { get; set; }

    public DateTime CalculatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryValuationSnapshotCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryValuationSnapshotLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryValuationSnapshots")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("InventoryValuationSnapshots")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    [InverseProperty("InventoryValuationSnapshots")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
