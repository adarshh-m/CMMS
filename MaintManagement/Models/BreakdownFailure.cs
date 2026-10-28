using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownFailure", Schema = "breakdown")]
public partial class BreakdownFailure
{
    [Key]
    public Guid BreakdownFailureId { get; set; }

    public Guid BreakdownId { get; set; }

    public Guid FailureCodeId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? FailedComponent { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? FailureMode { get; set; }

    public string? FailureNarrative { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownFailures")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownFailureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("FailureCodeId")]
    [InverseProperty("BreakdownFailures")]
    public virtual FailureCode FailureCode { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownFailureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
