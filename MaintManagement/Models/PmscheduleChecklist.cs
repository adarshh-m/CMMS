using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMScheduleChecklist", Schema = "pm")]
public partial class PmscheduleChecklist
{
    [Key]
    [Column("PMScheduleChecklistId")]
    public Guid PmscheduleChecklistId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public Guid ChecklistId { get; set; }

    public bool IsMandatory { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistId")]
    [InverseProperty("PmscheduleChecklists")]
    public virtual ChecklistTemplate Checklist { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmscheduleChecklistCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmscheduleChecklistLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmscheduleChecklists")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
