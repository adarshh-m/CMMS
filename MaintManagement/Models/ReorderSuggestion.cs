using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ReorderSuggestion", Schema = "inventory")]
public partial class ReorderSuggestion
{
    [Key]
    public Guid ReorderSuggestionId { get; set; }

    public Guid TenantId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid WarehouseId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? CurrentStock { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ReorderPoint { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? SuggestedOrderQty { get; set; }

    public DateTime SuggestedOn { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ReorderSuggestionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ReorderSuggestionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("ReorderSuggestions")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("ReorderSuggestions")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    [InverseProperty("ReorderSuggestions")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
