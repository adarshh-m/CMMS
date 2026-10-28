using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkOrder", Schema = "maintenance")]
[Index("AssetId", Name = "IX_WorkOrder_Asset")]
[Index("TenantId", Name = "IX_WorkOrder_Tenant")]
public partial class WorkOrder
{
    [Key]
    public Guid WorkOrderId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string WorkOrderNo { get; set; } = null!;

    public Guid? RequestId { get; set; }

    public Guid AssetId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public DateTime? OpenedOn { get; set; }

    public DateTime? ClosedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("WorkOrders")]
    public virtual Asset Asset { get; set; } = null!;

    [InverseProperty("WorkOrder")]
    public virtual ICollection<Breakdown> Breakdowns { get; set; } = new List<Breakdown>();

    [InverseProperty("WorkOrder")]
    public virtual ICollection<CalibrationWorkOrder> CalibrationWorkOrders { get; set; } = new List<CalibrationWorkOrder>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkOrderCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("WorkOrder")]
    public virtual ICollection<InventoryConsumption> InventoryConsumptions { get; set; } = new List<InventoryConsumption>();

    [InverseProperty("WorkOrder")]
    public virtual ICollection<InventoryIssue> InventoryIssues { get; set; } = new List<InventoryIssue>();

    [InverseProperty("WorkOrder")]
    public virtual ICollection<InventoryReservation> InventoryReservations { get; set; } = new List<InventoryReservation>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkOrderLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("WorkOrder")]
    public virtual ICollection<Permit> Permits { get; set; } = new List<Permit>();

    [InverseProperty("WorkOrder")]
    public virtual ICollection<PmworkOrder> PmworkOrders { get; set; } = new List<PmworkOrder>();

    [ForeignKey("RequestId")]
    [InverseProperty("WorkOrders")]
    public virtual MaintenanceRequest? Request { get; set; }

    [InverseProperty("WorkOrder")]
    public virtual ICollection<SlaInstance> SlaInstances { get; set; } = new List<SlaInstance>();

    [InverseProperty("WorkOrder")]
    public virtual ICollection<SpareRequest> SpareRequests { get; set; } = new List<SpareRequest>();

    [ForeignKey("TenantId")]
    [InverseProperty("WorkOrders")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("WorkOrder")]
    public virtual ICollection<WorkOrderAssignment> WorkOrderAssignments { get; set; } = new List<WorkOrderAssignment>();
}
