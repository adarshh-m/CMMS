using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignaturePolicy", Schema = "esign")]
public partial class ElectronicSignaturePolicy
{
    [Key]
    public Guid ElectronicSignaturePolicyId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string PolicyCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string PolicyName { get; set; } = null!;

    public bool RequirePassword { get; set; }

    [Column("RequireMFA")]
    public bool RequireMfa { get; set; }

    public bool RequireReason { get; set; }

    public bool RequireComment { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    [InverseProperty("ElectronicSignaturePolicy")]
    public virtual ICollection<ElectronicSignaturePurpose> ElectronicSignaturePurposes { get; set; } = new List<ElectronicSignaturePurpose>();

    [ForeignKey("TenantId")]
    [InverseProperty("ElectronicSignaturePolicies")]
    public virtual Tenant Tenant { get; set; } = null!;
}
