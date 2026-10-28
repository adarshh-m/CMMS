using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryLot", Schema = "inventory")]
public partial class InventoryLot
{
    [Key]
    public Guid InventoryLotId { get; set; }

    public Guid MaterialId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LotNumber { get; set; } = null!;

    public DateOnly? ManufacturingDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Quantity { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryLotCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryLotLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryLots")]
    public virtual Material Material { get; set; } = null!;
}
