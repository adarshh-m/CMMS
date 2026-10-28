using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MaintenanceGroup", Schema = "masterdata")]
public partial class MaintenanceGroup
{
    [Key]
    public Guid MaintenanceGroupId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string MaintenanceGroupName { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaintenanceGroupCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MaintenanceGroupLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("MaintenanceGroups")]
    public virtual Tenant Tenant { get; set; } = null!;
}
