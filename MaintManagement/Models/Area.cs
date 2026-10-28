using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Area", Schema = "masterdata")]
public partial class Area
{
    [Key]
    public Guid AreaId { get; set; }

    public Guid TenantId { get; set; }

    public Guid DepartmentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AreaCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? AreaName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("AreaCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Areas")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AreaLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Area")]
    public virtual ICollection<ProductionLine> ProductionLines { get; set; } = new List<ProductionLine>();

    [ForeignKey("TenantId")]
    [InverseProperty("Areas")]
    public virtual Tenant Tenant { get; set; } = null!;
}
