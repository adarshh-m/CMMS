using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryReservation", Schema = "inventory")]
public partial class InventoryReservation
{
    [Key]
    public Guid InventoryReservationId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid? WorkOrderId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ReservedQuantity { get; set; }

    public DateTime ReservedDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryReservationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryReservationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryReservations")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("InventoryReservations")]
    public virtual WorkOrder? WorkOrder { get; set; }
}
