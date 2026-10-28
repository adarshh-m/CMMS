using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMRuntimeRule", Schema = "pm")]
public partial class PmruntimeRule
{
    [Key]
    [Column("PMRuntimeRuleId")]
    public Guid PmruntimeRuleId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal RuntimeThreshold { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string RuntimeUnit { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? LastRuntimeValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmruntimeRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmruntimeRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmruntimeRules")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
