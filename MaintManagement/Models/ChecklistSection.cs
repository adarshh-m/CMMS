using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistSection", Schema = "checklist")]
public partial class ChecklistSection
{
    [Key]
    public Guid ChecklistSectionId { get; set; }

    public Guid ChecklistVersionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SectionCode { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? SectionName { get; set; }

    public int SequenceNo { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("ChecklistSection")]
    public virtual ICollection<ChecklistExecutionSection> ChecklistExecutionSections { get; set; } = new List<ChecklistExecutionSection>();

    [InverseProperty("ChecklistSection")]
    public virtual ICollection<ChecklistQuestion> ChecklistQuestions { get; set; } = new List<ChecklistQuestion>();

    [ForeignKey("ChecklistVersionId")]
    [InverseProperty("ChecklistSections")]
    public virtual ChecklistVersion ChecklistVersion { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistSectionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistSectionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
