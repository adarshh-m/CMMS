using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistResponse", Schema = "checklist")]
[Index("ChecklistExecutionId", Name = "IX_ChecklistResponse_Execution")]
public partial class ChecklistResponse
{
    [Key]
    public Guid ChecklistResponseId { get; set; }

    public Guid ChecklistExecutionId { get; set; }

    public Guid ChecklistQuestionId { get; set; }

    public string? ResponseValue { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal? NumericValue { get; set; }

    public DateOnly? DateValue { get; set; }

    public bool? IsPassed { get; set; }

    [StringLength(2000)]
    public string? CommentText { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistExecutionId")]
    [InverseProperty("ChecklistResponses")]
    public virtual ChecklistExecution ChecklistExecution { get; set; } = null!;

    [ForeignKey("ChecklistQuestionId")]
    [InverseProperty("ChecklistResponses")]
    public virtual ChecklistQuestion ChecklistQuestion { get; set; } = null!;

    [InverseProperty("ChecklistResponse")]
    public virtual ICollection<ChecklistResponseAttachment> ChecklistResponseAttachments { get; set; } = new List<ChecklistResponseAttachment>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistResponseCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistResponseLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
