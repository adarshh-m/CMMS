using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("SlaInstance", Schema = "maintenance")]
public partial class SlaInstance
{
    [Key]
    public Guid SlaInstanceId { get; set; }

    public Guid TenantId { get; set; }

    public Guid WorkOrderId { get; set; }

    public DateTime? ResponseTarget { get; set; }

    public DateTime? ResolutionTarget { get; set; }

    public bool? ResponseBreached { get; set; }

    public bool? ResolutionBreached { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SlaInstanceCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("SlaInstanceLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("SlaInstances")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("SlaInstances")]
    public virtual WorkOrder WorkOrder { get; set; } = null!;
}
