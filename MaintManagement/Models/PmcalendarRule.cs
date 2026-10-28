using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMCalendarRule", Schema = "pm")]
[Index("NextDueDate", Name = "IX_PMCalendarRule_NextDue")]
public partial class PmcalendarRule
{
    [Key]
    [Column("PMCalendarRuleId")]
    public Guid PmcalendarRuleId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string FrequencyType { get; set; } = null!;

    public int FrequencyValue { get; set; }

    public DateTime NextDueDate { get; set; }

    public DateTime? LastGeneratedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmcalendarRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmcalendarRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmcalendarRules")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
