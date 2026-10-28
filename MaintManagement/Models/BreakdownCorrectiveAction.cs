using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownCorrectiveAction", Schema = "breakdown")]
[Index("Status", Name = "IX_CorrectiveAction_Status")]
public partial class BreakdownCorrectiveAction
{
    [Key]
    public Guid CorrectiveActionId { get; set; }

    public Guid BreakdownId { get; set; }

    public string? ActionDescription { get; set; }

    public Guid? AssignedToUserId { get; set; }

    public DateOnly? TargetDate { get; set; }

    public DateOnly? CompletedDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssignedToUserId")]
    [InverseProperty("BreakdownCorrectiveActionAssignedToUsers")]
    public virtual User? AssignedToUser { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownCorrectiveActions")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownCorrectiveActionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownCorrectiveActionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
