using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Permission", Schema = "security")]
public partial class Permission
{
    [Key]
    public Guid PermissionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string PermissionCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string PermissionName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? ResourceName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ActionName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermissionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermissionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Permission")]
    public virtual ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>();

    [InverseProperty("Permission")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
