using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Department", Schema = "masterdata")]
public partial class Department
{
    [Key]
    public Guid DepartmentId { get; set; }

    public Guid TenantId { get; set; }

    public Guid PlantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DepartmentCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? DepartmentName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("DepartmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("DepartmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PlantId")]
    [InverseProperty("Departments")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Departments")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<UserDepartment> UserDepartments { get; set; } = new List<UserDepartment>();
}
