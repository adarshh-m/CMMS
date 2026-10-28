using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMWorkOrder", Schema = "pm")]
[Index("DueDate", Name = "IX_PMWorkOrder_DueDate")]
[Index("Pmstatus", Name = "IX_PMWorkOrder_Status")]
public partial class PmworkOrder
{
    [Key]
    [Column("PMWorkOrderId")]
    public Guid PmworkOrderId { get; set; }

    public Guid TenantId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public Guid WorkOrderId { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? PlannedStartDate { get; set; }

    public DateTime? PlannedEndDate { get; set; }

    [Column("PMStatus")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Pmstatus { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmworkOrderCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmworkOrderLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("PmworkOrder")]
    public virtual ICollection<Pmexecution> Pmexecutions { get; set; } = new List<Pmexecution>();

    [InverseProperty("PmworkOrder")]
    public virtual ICollection<PmgenerationLog> PmgenerationLogs { get; set; } = new List<PmgenerationLog>();

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmworkOrders")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("PmworkOrders")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("PmworkOrders")]
    public virtual WorkOrder WorkOrder { get; set; } = null!;
}
