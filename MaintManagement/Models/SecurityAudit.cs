using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("SecurityAudit", Schema = "security")]
public partial class SecurityAudit
{
    [Key]
    public long SecurityAuditId { get; set; }

    public Guid TenantId { get; set; }

    public Guid? UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EventType { get; set; }

    public string? EventDescription { get; set; }

    public DateTime EventTime { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? IpAddress { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SecurityAuditCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("SecurityAuditLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
