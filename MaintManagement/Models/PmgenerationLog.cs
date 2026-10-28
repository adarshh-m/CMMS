using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMGenerationLog", Schema = "pm")]
public partial class PmgenerationLog
{
    [Key]
    [Column("PMGenerationLogId")]
    public Guid PmgenerationLogId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public DateTime GeneratedDate { get; set; }

    [Column("PMWorkOrderId")]
    public Guid? PmworkOrderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? GenerationStatus { get; set; }

    public string? ErrorMessage { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmgenerationLogCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmgenerationLogLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmgenerationLogs")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;

    [ForeignKey("PmworkOrderId")]
    [InverseProperty("PmgenerationLogs")]
    public virtual PmworkOrder? PmworkOrder { get; set; }
}
