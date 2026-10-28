using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistRule", Schema = "checklist")]
public partial class ChecklistRule
{
    [Key]
    public Guid ChecklistRuleId { get; set; }

    public Guid ChecklistQuestionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string RuleType { get; set; } = null!;

    public string? RuleExpression { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistQuestionId")]
    [InverseProperty("ChecklistRules")]
    public virtual ChecklistQuestion ChecklistQuestion { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
