using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CauseCode", Schema = "masterdata")]
[Index("CauseCode1", Name = "UQ__CauseCod__712D2A40AF7A421C", IsUnique = true)]
public partial class CauseCode
{
    [Key]
    public Guid CauseCodeId { get; set; }

    [Column("CauseCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string CauseCode1 { get; set; } = null!;

    [StringLength(200)]
    public string CauseName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CauseCategory { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? SeverityLevel { get; set; }

    [Column("CAPARequired")]
    public bool Caparequired { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [InverseProperty("CauseCode")]
    public virtual ICollection<BreakdownCause> BreakdownCauses { get; set; } = new List<BreakdownCause>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("CauseCodeCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ModifiedBy")]
    [InverseProperty("CauseCodeModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
