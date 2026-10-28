using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MaterialWarehouse", Schema = "inventory")]
public partial class MaterialWarehouse
{
    [Key]
    public Guid MaterialWarehouseId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid WarehouseId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ReorderPoint { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? MinLevel { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? MaxLevel { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaterialWarehouseCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MaterialWarehouseLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("MaterialWarehouses")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    [InverseProperty("MaterialWarehouses")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
