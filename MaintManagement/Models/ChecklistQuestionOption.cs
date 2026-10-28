using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistQuestionOption", Schema = "checklist")]
public partial class ChecklistQuestionOption
{
    [Key]
    public Guid ChecklistQuestionOptionId { get; set; }

    public Guid ChecklistQuestionId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? OptionValue { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OptionText { get; set; }

    public int? SequenceNo { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistQuestionId")]
    [InverseProperty("ChecklistQuestionOptions")]
    public virtual ChecklistQuestion ChecklistQuestion { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistQuestionOptionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistQuestionOptionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
