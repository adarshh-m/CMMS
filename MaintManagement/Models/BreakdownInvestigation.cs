using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownInvestigation", Schema = "breakdown")]
public partial class BreakdownInvestigation
{
    [Key]
    public Guid InvestigationId { get; set; }

    public Guid BreakdownId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InvestigationMethod { get; set; }

    public Guid InvestigatorUserId { get; set; }

    public DateTime StartedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    public string? Findings { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownInvestigations")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownInvestigationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("InvestigatorUserId")]
    [InverseProperty("BreakdownInvestigationInvestigatorUsers")]
    public virtual User InvestigatorUser { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownInvestigationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
