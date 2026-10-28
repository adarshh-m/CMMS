using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryTransfer", Schema = "inventory")]
public partial class InventoryTransfer
{
    [Key]
    public Guid InventoryTransferId { get; set; }

    public Guid InventoryTransactionId { get; set; }

    public Guid SourceWarehouseId { get; set; }

    public Guid DestinationWarehouseId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryTransferCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("DestinationWarehouseId")]
    [InverseProperty("InventoryTransferDestinationWarehouses")]
    public virtual Warehouse DestinationWarehouse { get; set; } = null!;

    [ForeignKey("InventoryTransactionId")]
    [InverseProperty("InventoryTransfers")]
    public virtual InventoryTransaction InventoryTransaction { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryTransferLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("SourceWarehouseId")]
    [InverseProperty("InventoryTransferSourceWarehouses")]
    public virtual Warehouse SourceWarehouse { get; set; } = null!;
}
