using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("HazardMaster", Schema = "masterdata")]
[Index("HazardCode", Name = "UQ__HazardMa__2825E79D57DB45ED", IsUnique = true)]
public partial class HazardMaster
{
    [Key]
    public Guid HazardId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string HazardCode { get; set; } = null!;

    [StringLength(250)]
    public string HazardName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string HazardCategory { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? RiskLevel { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [InverseProperty("Hazard")]
    public virtual ICollection<PermitHazard> PermitHazards { get; set; } = new List<PermitHazard>();
}
