using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventorySerial", Schema = "inventory")]
public partial class InventorySerial
{
    [Key]
    public Guid InventorySerialId { get; set; }

    public Guid MaterialId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string SerialNumber { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventorySerialCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventorySerialLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventorySerials")]
    public virtual Material Material { get; set; } = null!;
}
