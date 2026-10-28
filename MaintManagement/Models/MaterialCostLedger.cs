using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MaterialCostLedger", Schema = "inventory")]
public partial class MaterialCostLedger
{
    [Key]
    public Guid MaterialCostLedgerId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid TransactionId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? CostMethod { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? UnitCost { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? TotalCost { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaterialCostLedgerCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MaterialCostLedgerLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("MaterialCostLedgers")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TransactionId")]
    [InverseProperty("MaterialCostLedgers")]
    public virtual InventoryTransaction Transaction { get; set; } = null!;
}
