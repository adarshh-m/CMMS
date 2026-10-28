using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkOrderAssignment", Schema = "maintenance")]
public partial class WorkOrderAssignment
{
    [Key]
    public Guid AssignmentId { get; set; }

    public Guid TenantId { get; set; }

    public Guid WorkOrderId { get; set; }

    public Guid UserId { get; set; }

    public DateTime? AssignedOn { get; set; }

    public DateTime? AcceptedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkOrderAssignmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkOrderAssignmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("WorkOrderAssignments")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("WorkOrderAssignmentUsers")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("WorkOrderAssignments")]
    public virtual WorkOrder WorkOrder { get; set; } = null!;
}
