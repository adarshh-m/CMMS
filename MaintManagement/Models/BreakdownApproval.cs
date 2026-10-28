using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownApproval", Schema = "breakdown")]
public partial class BreakdownApproval
{
    [Key]
    public Guid ApprovalId { get; set; }

    public Guid BreakdownId { get; set; }

    public int ApprovalLevel { get; set; }

    public Guid ApproverUserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ApprovalStatus { get; set; }

    public DateTime? ApprovalDate { get; set; }

    [StringLength(2000)]
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ApproverUserId")]
    [InverseProperty("BreakdownApprovalApproverUsers")]
    public virtual User ApproverUser { get; set; } = null!;

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownApprovals")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownApprovalCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownApprovalLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
