using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MaterialCategory", Schema = "inventory")]
[Index("CategoryCode", Name = "UQ__Material__371BA95513428CD4", IsUnique = true)]
public partial class MaterialCategory
{
    [Key]
    public Guid MaterialCategoryId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CategoryCode { get; set; } = null!;

    [StringLength(200)]
    public string CategoryName { get; set; } = null!;

    public Guid? ParentCategoryId { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsInventory { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    [InverseProperty("ParentCategory")]
    public virtual ICollection<MaterialCategory> InverseParentCategory { get; set; } = new List<MaterialCategory>();

    [InverseProperty("MaterialCategory")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    [ForeignKey("ParentCategoryId")]
    [InverseProperty("InverseParentCategory")]
    public virtual MaterialCategory? ParentCategory { get; set; }
}
