using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Warehouse", Schema = "inventory")]
public partial class Warehouse
{
    [Key]
    public Guid WarehouseId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string WarehouseCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string WarehouseName { get; set; } = null!;

    public Guid PlantId { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WarehouseCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("Warehouse")]
    public virtual ICollection<CycleCount> CycleCounts { get; set; } = new List<CycleCount>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<InventoryBalance> InventoryBalances { get; set; } = new List<InventoryBalance>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<InventoryReceipt> InventoryReceipts { get; set; } = new List<InventoryReceipt>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<InventoryStockAgeing> InventoryStockAgeings { get; set; } = new List<InventoryStockAgeing>();

    [InverseProperty("DestinationWarehouse")]
    public virtual ICollection<InventoryTransfer> InventoryTransferDestinationWarehouses { get; set; } = new List<InventoryTransfer>();

    [InverseProperty("SourceWarehouse")]
    public virtual ICollection<InventoryTransfer> InventoryTransferSourceWarehouses { get; set; } = new List<InventoryTransfer>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<InventoryValuationSnapshot> InventoryValuationSnapshots { get; set; } = new List<InventoryValuationSnapshot>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WarehouseLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Warehouse")]
    public virtual ICollection<MaterialWarehouse> MaterialWarehouses { get; set; } = new List<MaterialWarehouse>();

    [ForeignKey("PlantId")]
    [InverseProperty("Warehouses")]
    public virtual Plant Plant { get; set; } = null!;

    [InverseProperty("Warehouse")]
    public virtual ICollection<ReorderSuggestion> ReorderSuggestions { get; set; } = new List<ReorderSuggestion>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<StockSnapshot> StockSnapshots { get; set; } = new List<StockSnapshot>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<StorageLocation> StorageLocations { get; set; } = new List<StorageLocation>();

    [ForeignKey("TenantId")]
    [InverseProperty("Warehouses")]
    public virtual Tenant Tenant { get; set; } = null!;
}
