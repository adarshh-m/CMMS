using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistVersion", Schema = "checklist")]
public partial class ChecklistVersion
{
    [Key]
    public Guid ChecklistVersionId { get; set; }

    public Guid ChecklistTemplateId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string VersionNo { get; set; } = null!;

    public DateOnly EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public bool IsCurrent { get; set; }

    [StringLength(1000)]
    public string? ChangeReason { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("ChecklistVersion")]
    public virtual ICollection<ChecklistExecution> ChecklistExecutions { get; set; } = new List<ChecklistExecution>();

    [InverseProperty("ChecklistVersion")]
    public virtual ICollection<ChecklistSection> ChecklistSections { get; set; } = new List<ChecklistSection>();

    [ForeignKey("ChecklistTemplateId")]
    [InverseProperty("ChecklistVersions")]
    public virtual ChecklistTemplate ChecklistTemplate { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistVersionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistVersionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
