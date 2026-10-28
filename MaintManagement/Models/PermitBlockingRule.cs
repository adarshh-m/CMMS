using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitBlockingRule", Schema = "permit")]
public partial class PermitBlockingRule
{
    [Key]
    public Guid PermitBlockingRuleId { get; set; }

    public Guid TenantId { get; set; }

    public Guid PermitTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string WorkType { get; set; } = null!;

    public bool BlockExecution { get; set; }

    public bool BlockMachineRelease { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitBlockingRuleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitBlockingRuleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitTypeId")]
    [InverseProperty("PermitBlockingRules")]
    public virtual PermitType PermitType { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("PermitBlockingRules")]
    public virtual Tenant Tenant { get; set; } = null!;
}
