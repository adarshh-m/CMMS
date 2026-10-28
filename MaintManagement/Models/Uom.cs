using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("UOM", Schema = "masterdata")]
[Index("Uomcode", Name = "UQ__UOM__DAFF8B999E95A956", IsUnique = true)]
public partial class Uom
{
    [Key]
    [Column("UOMId")]
    public Guid Uomid { get; set; }

    [Column("UOMCode")]
    [StringLength(20)]
    [Unicode(false)]
    public string Uomcode { get; set; } = null!;

    [Column("UOMName")]
    [StringLength(100)]
    public string Uomname { get; set; } = null!;

    [Column("UOMType")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Uomtype { get; set; }

    public int DecimalPlaces { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UomCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("Uom")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("UomModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
