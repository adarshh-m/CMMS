using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Material", Schema = "inventory")]
[Index("TenantId", "MaterialCode", Name = "UX_Material_Code", IsUnique = true)]
public partial class Material
{
    [Key]
    public Guid MaterialId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string MaterialCode { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string MaterialDescription { get; set; } = null!;

    public Guid? MaterialCategoryId { get; set; }

    [Column("UOMId")]
    public Guid? Uomid { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ReorderLevel { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? MinStockLevel { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? MaxStockLevel { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? StandardCost { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("Material")]
    public virtual ICollection<Abcclassification> Abcclassifications { get; set; } = new List<Abcclassification>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaterialCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("Material")]
    public virtual ICollection<DeadStockAnalysis> DeadStockAnalyses { get; set; } = new List<DeadStockAnalysis>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryBalance> InventoryBalances { get; set; } = new List<InventoryBalance>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryCycleCountLine> InventoryCycleCountLines { get; set; } = new List<InventoryCycleCountLine>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryForecast> InventoryForecasts { get; set; } = new List<InventoryForecast>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryLot> InventoryLots { get; set; } = new List<InventoryLot>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryReceiptItem> InventoryReceiptItems { get; set; } = new List<InventoryReceiptItem>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryReservation> InventoryReservations { get; set; } = new List<InventoryReservation>();

    [InverseProperty("Material")]
    public virtual ICollection<InventorySerial> InventorySerials { get; set; } = new List<InventorySerial>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryStockAgeing> InventoryStockAgeings { get; set; } = new List<InventoryStockAgeing>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    [InverseProperty("Material")]
    public virtual ICollection<InventoryValuationSnapshot> InventoryValuationSnapshots { get; set; } = new List<InventoryValuationSnapshot>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MaterialLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("AlternateMaterial")]
    public virtual ICollection<MaterialAlternate> MaterialAlternateAlternateMaterials { get; set; } = new List<MaterialAlternate>();

    [InverseProperty("Material")]
    public virtual ICollection<MaterialAlternate> MaterialAlternateMaterials { get; set; } = new List<MaterialAlternate>();

    [ForeignKey("MaterialCategoryId")]
    [InverseProperty("Materials")]
    public virtual MaterialCategory? MaterialCategory { get; set; }

    [InverseProperty("Material")]
    public virtual ICollection<MaterialCostLedger> MaterialCostLedgers { get; set; } = new List<MaterialCostLedger>();

    [InverseProperty("Material")]
    public virtual ICollection<MaterialVendor> MaterialVendors { get; set; } = new List<MaterialVendor>();

    [InverseProperty("Material")]
    public virtual ICollection<MaterialWarehouse> MaterialWarehouses { get; set; } = new List<MaterialWarehouse>();

    [InverseProperty("Material")]
    public virtual ICollection<PurchaseReceiptItem> PurchaseReceiptItems { get; set; } = new List<PurchaseReceiptItem>();

    [InverseProperty("Material")]
    public virtual ICollection<ReorderSuggestion> ReorderSuggestions { get; set; } = new List<ReorderSuggestion>();

    [InverseProperty("Material")]
    public virtual ICollection<SpareRequestItem> SpareRequestItems { get; set; } = new List<SpareRequestItem>();

    [InverseProperty("Material")]
    public virtual ICollection<StockSnapshot> StockSnapshots { get; set; } = new List<StockSnapshot>();

    [ForeignKey("TenantId")]
    [InverseProperty("Materials")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("Uomid")]
    [InverseProperty("Materials")]
    public virtual Uom? Uom { get; set; }
}
