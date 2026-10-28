using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMTriggerHistory", Schema = "pm")]
public partial class PmtriggerHistory
{
    [Key]
    [Column("PMTriggerHistoryId")]
    public Guid PmtriggerHistoryId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string TriggerType { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TriggerValue { get; set; }

    public DateTime TriggerDate { get; set; }

    public bool IsTriggered { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmtriggerHistoryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmtriggerHistoryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmtriggerHistories")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
