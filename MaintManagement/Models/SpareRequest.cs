using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("SpareRequest", Schema = "inventory")]
[Index("Status", Name = "IX_SpareRequest_Status")]
public partial class SpareRequest
{
    [Key]
    public Guid SpareRequestId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string RequestNumber { get; set; } = null!;

    public Guid? WorkOrderId { get; set; }

    public DateTime RequestDate { get; set; }

    public Guid RequestedByUserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SpareRequestCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("SpareRequestLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("RequestedByUserId")]
    [InverseProperty("SpareRequestRequestedByUsers")]
    public virtual User RequestedByUser { get; set; } = null!;

    [InverseProperty("SpareRequest")]
    public virtual ICollection<SpareRequestItem> SpareRequestItems { get; set; } = new List<SpareRequestItem>();

    [ForeignKey("TenantId")]
    [InverseProperty("SpareRequests")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("SpareRequests")]
    public virtual WorkOrder? WorkOrder { get; set; }
}
