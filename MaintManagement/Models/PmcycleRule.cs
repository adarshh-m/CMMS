using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMCycleRule", Schema = "pm")]
public partial class PmcycleRule
{
    [Key]
    [Column("PMCycleRuleId")]
    public Guid PmcycleRuleId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public long CycleThreshold { get; set; }

    public long? LastCycleValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmcycleRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmcycleRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmcycleRules")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
