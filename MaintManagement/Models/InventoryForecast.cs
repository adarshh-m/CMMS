using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryForecast", Schema = "inventory")]
public partial class InventoryForecast
{
    [Key]
    public Guid InventoryForecastId { get; set; }

    public Guid TenantId { get; set; }

    public Guid MaterialId { get; set; }

    public DateOnly ForecastDate { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal ForecastQuantity { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ForecastSource { get; set; }

    public DateTime GeneratedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryForecastCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryForecastLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("InventoryForecasts")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("InventoryForecasts")]
    public virtual Tenant Tenant { get; set; } = null!;
}
