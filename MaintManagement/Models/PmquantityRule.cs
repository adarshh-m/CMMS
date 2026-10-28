using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMQuantityRule", Schema = "pm")]
public partial class PmquantityRule
{
    [Key]
    [Column("PMQuantityRuleId")]
    public Guid PmquantityRuleId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public long QuantityThreshold { get; set; }

    public long? LastQuantityValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmquantityRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmquantityRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmquantityRules")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
