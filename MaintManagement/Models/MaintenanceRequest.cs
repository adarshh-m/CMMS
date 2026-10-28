using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MaintenanceRequest", Schema = "maintenance")]
public partial class MaintenanceRequest
{
    [Key]
    public Guid RequestId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string RequestNo { get; set; } = null!;

    public Guid AssetId { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Priority { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? RequestedBy { get; set; }

    public DateTime RequestedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("MaintenanceRequests")]
    public virtual Asset Asset { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaintenanceRequestCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MaintenanceRequestLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("RequestedBy")]
    [InverseProperty("MaintenanceRequestRequestedByNavigations")]
    public virtual User? RequestedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("MaintenanceRequests")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("Request")]
    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
