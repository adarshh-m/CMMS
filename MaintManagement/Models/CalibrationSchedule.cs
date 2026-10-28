using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationSchedule", Schema = "calibration")]
[Index("NextDueDate", Name = "IX_CalibrationSchedule_DueDate")]
public partial class CalibrationSchedule
{
    [Key]
    public Guid CalibrationScheduleId { get; set; }

    public Guid TenantId { get; set; }

    public Guid CalibrationAssetId { get; set; }

    public Guid CalibrationMethodId { get; set; }

    public int FrequencyDays { get; set; }

    public DateOnly? LastCalibrationDate { get; set; }

    public DateOnly NextDueDate { get; set; }

    public int AlertDaysBefore { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationAssetId")]
    [InverseProperty("CalibrationSchedules")]
    public virtual CalibrationAsset CalibrationAsset { get; set; } = null!;

    [ForeignKey("CalibrationMethodId")]
    [InverseProperty("CalibrationSchedules")]
    public virtual CalibrationMethod CalibrationMethod { get; set; } = null!;

    [InverseProperty("CalibrationSchedule")]
    public virtual ICollection<CalibrationWorkOrder> CalibrationWorkOrders { get; set; } = new List<CalibrationWorkOrder>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationScheduleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationScheduleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("CalibrationSchedules")]
    public virtual Tenant Tenant { get; set; } = null!;
}
