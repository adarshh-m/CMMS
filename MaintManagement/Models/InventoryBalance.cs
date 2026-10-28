using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryBalance", Schema = "inventory")]
[Index("MaterialId", Name = "IX_InventoryBalance_Material")]
[Index("WarehouseId", Name = "IX_InventoryBalance_Warehouse")]
public partial class InventoryBalance
{
    [Key]
    public Guid InventoryBalanceId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid WarehouseId { get; set; }

    public Guid? StorageLocationId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal OnHandQty { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal ReservedQty { get; set; }

    [Column(TypeName = "decimal(19, 4)")]
    public decimal? AvailableQty { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryBalanceCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryBalanceLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryBalances")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("StorageLocationId")]
    [InverseProperty("InventoryBalances")]
    public virtual StorageLocation? StorageLocation { get; set; }

    [ForeignKey("WarehouseId")]
    [InverseProperty("InventoryBalances")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
