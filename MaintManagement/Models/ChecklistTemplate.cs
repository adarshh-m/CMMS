using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistTemplate", Schema = "checklist")]
[Index("ChecklistType", Name = "IX_ChecklistTemplate_Type")]
public partial class ChecklistTemplate
{
    [Key]
    public Guid ChecklistTemplateId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TemplateCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string TemplateName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string ChecklistType { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    [InverseProperty("ChecklistTemplate")]
    public virtual ICollection<ChecklistVersion> ChecklistVersions { get; set; } = new List<ChecklistVersion>();

    [InverseProperty("Checklist")]
    public virtual ICollection<PmscheduleChecklist> PmscheduleChecklists { get; set; } = new List<PmscheduleChecklist>();

    [ForeignKey("TenantId")]
    [InverseProperty("ChecklistTemplates")]
    public virtual Tenant Tenant { get; set; } = null!;
}
