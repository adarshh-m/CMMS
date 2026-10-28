using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownVerification", Schema = "breakdown")]
public partial class BreakdownVerification
{
    [Key]
    public Guid VerificationId { get; set; }

    public Guid BreakdownId { get; set; }

    public Guid VerifiedByUserId { get; set; }

    public DateTime VerificationDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerificationResult { get; set; }

    [StringLength(2000)]
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownVerifications")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownVerificationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownVerificationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("VerifiedByUserId")]
    [InverseProperty("BreakdownVerificationVerifiedByUsers")]
    public virtual User VerifiedByUser { get; set; } = null!;
}
