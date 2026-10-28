using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownEvidence", Schema = "breakdown")]
public partial class BreakdownEvidence
{
    [Key]
    public Guid EvidenceId { get; set; }

    public Guid BreakdownId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EvidenceType { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? FileUrl { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public Guid? UploadedBy { get; set; }

    public DateTime UploadedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownEvidences")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownEvidenceCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownEvidenceLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
