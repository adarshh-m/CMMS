using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("AuditEvent", Schema = "audit")]
[Index("TenantId", Name = "IX_Audit_Tenant")]
public partial class AuditEvent
{
    [Key]
    public long AuditEventId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? EntityName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EntityId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ActionName { get; set; }

    public Guid? UserId { get; set; }

    public DateTime EventTime { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("AuditEventCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AuditEventLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
