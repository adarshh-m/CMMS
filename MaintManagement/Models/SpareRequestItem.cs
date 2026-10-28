using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("SpareRequestItem", Schema = "inventory")]
public partial class SpareRequestItem
{
    [Key]
    public Guid SpareRequestItemId { get; set; }

    public Guid SpareRequestId { get; set; }

    public Guid MaterialId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? RequestedQty { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ApprovedQty { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? IssuedQty { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SpareRequestItemCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("SpareRequestItemLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("SpareRequestItems")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("SpareRequestId")]
    [InverseProperty("SpareRequestItems")]
    public virtual SpareRequest SpareRequest { get; set; } = null!;
}
