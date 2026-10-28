using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMExecutionChecklist", Schema = "pm")]
public partial class PmexecutionChecklist
{
    [Key]
    [Column("PMExecutionChecklistId")]
    public Guid PmexecutionChecklistId { get; set; }

    [Column("PMExecutionId")]
    public Guid PmexecutionId { get; set; }

    public Guid ChecklistQuestionId { get; set; }

    public string? ResponseValue { get; set; }

    public bool? PassFlag { get; set; }

    [StringLength(1000)]
    public string? Remarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistQuestionId")]
    [InverseProperty("PmexecutionChecklists")]
    public virtual ChecklistQuestion ChecklistQuestion { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmexecutionChecklistCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmexecutionChecklistLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmexecutionId")]
    [InverseProperty("PmexecutionChecklists")]
    public virtual Pmexecution Pmexecution { get; set; } = null!;
}
