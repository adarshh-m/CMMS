using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Plant", Schema = "masterdata")]
public partial class Plant
{
    [Key]
    public Guid PlantId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string PlantCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string PlantName { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("Plant")]
    public virtual ICollection<CalibrationComplianceSnapshot> CalibrationComplianceSnapshots { get; set; } = new List<CalibrationComplianceSnapshot>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("PlantCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("Plant")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PlantLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Plant")]
    public virtual ICollection<PmcomplianceSnapshot> PmcomplianceSnapshots { get; set; } = new List<PmcomplianceSnapshot>();

    [ForeignKey("TenantId")]
    [InverseProperty("Plants")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("Plant")]
    public virtual ICollection<UserPlant> UserPlants { get; set; } = new List<UserPlant>();

    [InverseProperty("Plant")]
    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
