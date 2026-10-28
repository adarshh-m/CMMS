using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryCycleCountLine", Schema = "inventory")]
public partial class InventoryCycleCountLine
{
    [Key]
    public Guid InventoryCycleCountLineId { get; set; }

    public Guid CycleCountId { get; set; }

    public Guid MaterialId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? SystemQuantity { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? CountedQuantity { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? VarianceQuantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? VarianceValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryCycleCountLineCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("CycleCountId")]
    [InverseProperty("InventoryCycleCountLines")]
    public virtual CycleCount CycleCount { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryCycleCountLineLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryCycleCountLines")]
    public virtual Material Material { get; set; } = null!;
}
