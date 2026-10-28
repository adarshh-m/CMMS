using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMSchedule", Schema = "pm")]
[Index("IsActive", Name = "IX_PMSchedule_Active")]
[Index("AssetId", Name = "IX_PM_Asset")]
public partial class Pmschedule
{
    [Key]
    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public Guid TenantId { get; set; }

    public Guid AssetId { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? ScheduleName { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? FrequencyType { get; set; }

    public int? FrequencyValue { get; set; }

    public DateTime? NextDueDate { get; set; }

    public bool ActiveFlag { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ScheduleCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MaintenanceType { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Priority { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public bool AutoGenerate { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("Pmschedules")]
    public virtual Asset Asset { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmscheduleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmscheduleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmcalendarRule> PmcalendarRules { get; set; } = new List<PmcalendarRule>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmcycleRule> PmcycleRules { get; set; } = new List<PmcycleRule>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<Pmforecast> Pmforecasts { get; set; } = new List<Pmforecast>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmgenerationLog> PmgenerationLogs { get; set; } = new List<PmgenerationLog>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmquantityRule> PmquantityRules { get; set; } = new List<PmquantityRule>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmruntimeRule> PmruntimeRules { get; set; } = new List<PmruntimeRule>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmscheduleAsset> PmscheduleAssets { get; set; } = new List<PmscheduleAsset>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmscheduleChecklist> PmscheduleChecklists { get; set; } = new List<PmscheduleChecklist>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmtriggerHistory> PmtriggerHistories { get; set; } = new List<PmtriggerHistory>();

    [InverseProperty("Pmschedule")]
    public virtual ICollection<PmworkOrder> PmworkOrders { get; set; } = new List<PmworkOrder>();

    [ForeignKey("TenantId")]
    [InverseProperty("Pmschedules")]
    public virtual Tenant Tenant { get; set; } = null!;
}
