using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistExecutionSection", Schema = "checklist")]
public partial class ChecklistExecutionSection
{
    [Key]
    public Guid ChecklistExecutionSectionId { get; set; }

    public Guid ChecklistExecutionId { get; set; }

    public Guid ChecklistSectionId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistExecutionId")]
    [InverseProperty("ChecklistExecutionSections")]
    public virtual ChecklistExecution ChecklistExecution { get; set; } = null!;

    [ForeignKey("ChecklistSectionId")]
    [InverseProperty("ChecklistExecutionSections")]
    public virtual ChecklistSection ChecklistSection { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistExecutionSectionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistExecutionSectionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
