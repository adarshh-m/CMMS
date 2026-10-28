using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignaturePurpose", Schema = "esign")]
public partial class ElectronicSignaturePurpose
{
    [Key]
    public Guid ElectronicSignaturePurposeId { get; set; }

    public Guid ElectronicSignaturePolicyId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string PurposeCode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string PurposeName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string EntityType { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignaturePurposeCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ElectronicSignaturePolicyId")]
    [InverseProperty("ElectronicSignaturePurposes")]
    public virtual ElectronicSignaturePolicy ElectronicSignaturePolicy { get; set; } = null!;

    [InverseProperty("ElectronicSignaturePurpose")]
    public virtual ICollection<ElectronicSignatureRoleAssignment> ElectronicSignatureRoleAssignments { get; set; } = new List<ElectronicSignatureRoleAssignment>();

    [InverseProperty("ElectronicSignaturePurpose")]
    public virtual ICollection<ElectronicSignatureSequence> ElectronicSignatureSequences { get; set; } = new List<ElectronicSignatureSequence>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignaturePurposeLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
