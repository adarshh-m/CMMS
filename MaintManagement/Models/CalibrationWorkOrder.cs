using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationWorkOrder", Schema = "calibration")]
[Index("Status", Name = "IX_CalibrationWorkOrder_Status")]
public partial class CalibrationWorkOrder
{
    [Key]
    public Guid CalibrationWorkOrderId { get; set; }

    public Guid TenantId { get; set; }

    public Guid CalibrationScheduleId { get; set; }

    public Guid? WorkOrderId { get; set; }

    public DateOnly DueDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("CalibrationWorkOrder")]
    public virtual ICollection<CalibrationExecution> CalibrationExecutions { get; set; } = new List<CalibrationExecution>();

    [ForeignKey("CalibrationScheduleId")]
    [InverseProperty("CalibrationWorkOrders")]
    public virtual CalibrationSchedule CalibrationSchedule { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationWorkOrderCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationWorkOrderLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("CalibrationWorkOrders")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("CalibrationWorkOrders")]
    public virtual WorkOrder? WorkOrder { get; set; }
}
