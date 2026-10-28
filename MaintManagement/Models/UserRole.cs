using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("UserRoles", Schema = "security")]
public partial class UserRole
{
    [Key]
    public Guid UserRoleId { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UserRoleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("UserRoleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserRoleUsers")]
    public virtual User User { get; set; } = null!;
}
