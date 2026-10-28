using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitType", Schema = "masterdata")]
[Index("PermitCode", Name = "UQ__PermitTy__C75B049569ADFBCC", IsUnique = true)]
public partial class PermitType
{
    [Key]
    public Guid PermitTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string PermitCode { get; set; } = null!;

    [StringLength(200)]
    public string PermitName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    public int? ValidityHours { get; set; }

    public bool RequiresGasTest { get; set; }

    public bool RequiresIsolation { get; set; }

    public bool RequiresApproval { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ColorCode { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [InverseProperty("PermitType")]
    public virtual ICollection<PermitBlockingRule> PermitBlockingRules { get; set; } = new List<PermitBlockingRule>();

    [InverseProperty("PermitType")]
    public virtual ICollection<Permit> Permits { get; set; } = new List<Permit>();
}
