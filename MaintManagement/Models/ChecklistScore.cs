using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistScore", Schema = "checklist")]
public partial class ChecklistScore
{
    [Key]
    public Guid ChecklistScoreId { get; set; }

    public Guid ChecklistExecutionId { get; set; }

    public int? TotalQuestions { get; set; }

    public int? AnsweredQuestions { get; set; }

    public int? PassedQuestions { get; set; }

    public int? FailedQuestions { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ScorePercent { get; set; }

    public DateTime CalculatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistExecutionId")]
    [InverseProperty("ChecklistScores")]
    public virtual ChecklistExecution ChecklistExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistScoreCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistScoreLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
