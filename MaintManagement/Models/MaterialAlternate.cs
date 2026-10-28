using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MaterialAlternate", Schema = "inventory")]
public partial class MaterialAlternate
{
    [Key]
    public Guid MaterialAlternateId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid AlternateMaterialId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AlternateMaterialId")]
    [InverseProperty("MaterialAlternateAlternateMaterials")]
    public virtual Material AlternateMaterial { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaterialAlternateCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MaterialAlternateLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("MaterialAlternateMaterials")]
    public virtual Material Material { get; set; } = null!;
}
