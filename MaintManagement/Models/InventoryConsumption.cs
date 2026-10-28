using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryConsumption", Schema = "inventory")]
public partial class InventoryConsumption
{
    [Key]
    public Guid InventoryConsumptionId { get; set; }

    public Guid InventoryTransactionId { get; set; }

    public Guid WorkOrderId { get; set; }

    public Guid? ConsumedByUserId { get; set; }

    public DateTime ConsumptionDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ConsumedByUserId")]
    [InverseProperty("InventoryConsumptionConsumedByUsers")]
    public virtual User? ConsumedByUser { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryConsumptionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("InventoryTransactionId")]
    [InverseProperty("InventoryConsumptions")]
    public virtual InventoryTransaction InventoryTransaction { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryConsumptionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkOrderId")]
    [InverseProperty("InventoryConsumptions")]
    public virtual WorkOrder WorkOrder { get; set; } = null!;
}
