using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("BreakdownWhyAnalysis", Schema = "breakdown")]
public partial class BreakdownWhyAnalysis
{
    [Key]
    public Guid WhyAnalysisId { get; set; }

    public Guid BreakdownId { get; set; }

    public int WhyLevel { get; set; }

    [StringLength(1000)]
    public string? WhyQuestion { get; set; }

    public string? WhyAnswer { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("BreakdownId")]
    [InverseProperty("BreakdownWhyAnalyses")]
    public virtual Breakdown Breakdown { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BreakdownWhyAnalysisCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("BreakdownWhyAnalysisLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
