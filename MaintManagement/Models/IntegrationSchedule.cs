using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationSchedule", Schema = "integration")]
public partial class IntegrationSchedule
{
    [Key]
    public Guid IntegrationScheduleId { get; set; }

    public Guid IntegrationSystemId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? ScheduleName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CronExpression { get; set; }

    public DateTime? NextRunTime { get; set; }

    public DateTime? LastRunTime { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationScheduleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IntegrationSystemId")]
    [InverseProperty("IntegrationSchedules")]
    public virtual IntegrationSystem IntegrationSystem { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationScheduleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
