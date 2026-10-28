using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationEscalationRule", Schema = "notification")]
[Index("EventCode", Name = "IX_Escalation_Event")]
public partial class NotificationEscalationRule
{
    [Key]
    public Guid NotificationEscalationRuleId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EventCode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? PriorityCode { get; set; }

    public int EscalationLevel { get; set; }

    public int EscalationAfterMinutes { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NotifyRoleCode { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationEscalationRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationEscalationRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("NotificationEscalationRules")]
    public virtual Tenant Tenant { get; set; } = null!;
}
