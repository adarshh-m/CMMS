using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MenuPermission", Schema = "security")]
public partial class MenuPermission
{
    [Key]
    public Guid MenuPermissionId { get; set; }

    public Guid MenuId { get; set; }

    public Guid PermissionId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("MenuPermissionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MenuPermissionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MenuId")]
    [InverseProperty("MenuPermissions")]
    public virtual Menu Menu { get; set; } = null!;

    [ForeignKey("PermissionId")]
    [InverseProperty("MenuPermissions")]
    public virtual Permission Permission { get; set; } = null!;
}
