using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownCause", Schema = "breakdown")]
public partial class BreakdownCause
{
    [Key]
    public Guid BreakdownCauseId { get; set; }

    public Guid BreakdownId { get; set; }

    public Guid CauseCodeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CauseType { get; set; } = null!;

    [StringLength(1000)]
    public string? CauseDescription { get; set; }

    public bool IsRootCause { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownCauses")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CauseCodeId")]
    [InverseProperty("BreakdownCauses")]
    public virtual CauseCode CauseCode { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownCauseCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownCauseLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
