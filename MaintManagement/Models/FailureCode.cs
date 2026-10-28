using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("FailureCode", Schema = "masterdata")]
[Index("FailureCode1", Name = "UQ__FailureC__93167EFF8028FD9C", IsUnique = true)]
public partial class FailureCode
{
    [Key]
    public Guid FailureCodeId { get; set; }

    [Column("FailureCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string FailureCode1 { get; set; } = null!;

    [StringLength(200)]
    public string FailureName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FailureCategory { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FailureClass { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [InverseProperty("FailureCode")]
    public virtual ICollection<BreakdownFailure> BreakdownFailures { get; set; } = new List<BreakdownFailure>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("FailureCodeCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ModifiedBy")]
    [InverseProperty("FailureCodeModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
