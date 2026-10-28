using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryReturn", Schema = "inventory")]
public partial class InventoryReturn
{
    [Key]
    public Guid InventoryReturnId { get; set; }

    public Guid InventoryTransactionId { get; set; }

    public DateTime ReturnDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ReturnReason { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryReturnCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("InventoryTransactionId")]
    [InverseProperty("InventoryReturns")]
    public virtual InventoryTransaction InventoryTransaction { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryReturnLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
