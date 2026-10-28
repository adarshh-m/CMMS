using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ProductionLine", Schema = "masterdata")]
public partial class ProductionLine
{
    [Key]
    public Guid ProductionLineId { get; set; }

    public Guid TenantId { get; set; }

    public Guid AreaId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LineCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? LineName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("ProductionLines")]
    public virtual Area Area { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProductionLineCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ProductionLineLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("ProductionLines")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("ProductionLine")]
    public virtual ICollection<WorkCenter> WorkCenters { get; set; } = new List<WorkCenter>();
}
