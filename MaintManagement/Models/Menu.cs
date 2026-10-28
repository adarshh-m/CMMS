using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Menu", Schema = "security")]
public partial class Menu
{
    [Key]
    public Guid MenuId { get; set; }

    public Guid? ParentMenuId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MenuCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? MenuName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? RouteUrl { get; set; }

    public int? DisplayOrder { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("MenuCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("ParentMenu")]
    public virtual ICollection<Menu> InverseParentMenu { get; set; } = new List<Menu>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MenuLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Menu")]
    public virtual ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>();

    [ForeignKey("ParentMenuId")]
    [InverseProperty("InverseParentMenu")]
    public virtual Menu? ParentMenu { get; set; }
}
