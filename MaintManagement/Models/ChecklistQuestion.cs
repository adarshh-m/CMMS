using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistQuestion", Schema = "checklist")]
[Index("ChecklistSectionId", Name = "IX_ChecklistQuestion_Section")]
public partial class ChecklistQuestion
{
    [Key]
    public Guid ChecklistQuestionId { get; set; }

    public Guid ChecklistSectionId { get; set; }

    [StringLength(2000)]
    public string QuestionText { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string QuestionType { get; set; } = null!;

    public int SequenceNo { get; set; }

    public bool IsMandatory { get; set; }

    public bool AllowsAttachment { get; set; }

    public bool AllowsComment { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("ChecklistQuestion")]
    public virtual ICollection<ChecklistQuestionOption> ChecklistQuestionOptions { get; set; } = new List<ChecklistQuestionOption>();

    [InverseProperty("ChecklistQuestion")]
    public virtual ICollection<ChecklistResponse> ChecklistResponses { get; set; } = new List<ChecklistResponse>();

    [InverseProperty("ChecklistQuestion")]
    public virtual ICollection<ChecklistRule> ChecklistRules { get; set; } = new List<ChecklistRule>();

    [ForeignKey("ChecklistSectionId")]
    [InverseProperty("ChecklistQuestions")]
    public virtual ChecklistSection ChecklistSection { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistQuestionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistQuestionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("ChecklistQuestion")]
    public virtual ICollection<PmexecutionChecklist> PmexecutionChecklists { get; set; } = new List<PmexecutionChecklist>();
}
