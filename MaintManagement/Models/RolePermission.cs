using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("RolePermission", Schema = "security")]
public partial class RolePermission
{
    [Key]
    public Guid RolePermissionId { get; set; }

    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("RolePermissionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("RolePermissionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermissionId")]
    [InverseProperty("RolePermissions")]
    public virtual Permission Permission { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("RolePermissions")]
    public virtual Role Role { get; set; } = null!;
}
