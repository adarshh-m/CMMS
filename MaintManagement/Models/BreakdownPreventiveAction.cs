using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownPreventiveAction", Schema = "breakdown")]
[Index("Status", Name = "IX_PreventiveAction_Status")]
public partial class BreakdownPreventiveAction
{
    [Key]
    public Guid PreventiveActionId { get; set; }

    public Guid BreakdownId { get; set; }

    public string? ActionDescription { get; set; }

    public Guid? ResponsibleUserId { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? CompletionDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownPreventiveActions")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownPreventiveActionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownPreventiveActionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("ResponsibleUserId")]
    [InverseProperty("BreakdownPreventiveActionResponsibleUsers")]
    public virtual User? ResponsibleUser { get; set; }
}
