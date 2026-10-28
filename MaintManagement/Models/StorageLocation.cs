using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("StorageLocation", Schema = "inventory")]
public partial class StorageLocation
{
    [Key]
    public Guid StorageLocationId { get; set; }

    public Guid WarehouseId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LocationCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? LocationName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LocationType { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("StorageLocationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("StorageLocation")]
    public virtual ICollection<InventoryBalance> InventoryBalances { get; set; } = new List<InventoryBalance>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("StorageLocationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WarehouseId")]
    [InverseProperty("StorageLocations")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
