using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Roles", Schema = "security")]
public partial class Role
{
    [Key]
    public Guid RoleId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string RoleCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string RoleName { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("RoleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("RoleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    [ForeignKey("TenantId")]
    [InverseProperty("Roles")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    [InverseProperty("Role")]
    public virtual ICollection<WorkflowRoleAssignment> WorkflowRoleAssignments { get; set; } = new List<WorkflowRoleAssignment>();

    [InverseProperty("AssignedRole")]
    public virtual ICollection<WorkflowTask> WorkflowTasks { get; set; } = new List<WorkflowTask>();
}
