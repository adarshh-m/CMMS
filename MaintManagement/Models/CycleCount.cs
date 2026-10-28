using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CycleCount", Schema = "inventory")]
[Index("CountDate", Name = "IX_CycleCount_Date")]
public partial class CycleCount
{
    [Key]
    public Guid CycleCountId { get; set; }

    public Guid TenantId { get; set; }

    public Guid WarehouseId { get; set; }

    public DateTime CountDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? ConductedByUserId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ConductedByUserId")]
    [InverseProperty("CycleCountConductedByUsers")]
    public virtual User? ConductedByUser { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("CycleCountCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("CycleCount")]
    public virtual ICollection<InventoryCycleCountLine> InventoryCycleCountLines { get; set; } = new List<InventoryCycleCountLine>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CycleCountLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("CycleCounts")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    [InverseProperty("CycleCounts")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
