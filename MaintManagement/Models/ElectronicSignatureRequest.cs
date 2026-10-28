using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureRequest", Schema = "esign")]
[Index("EntityType", "EntityId", Name = "IX_ESignRequest_Entity")]
[Index("Status", Name = "IX_ESignRequest_Status")]
public partial class ElectronicSignatureRequest
{
    [Key]
    public Guid ElectronicSignatureRequestId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EntityType { get; set; } = null!;

    public Guid EntityId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string PurposeCode { get; set; } = null!;

    public Guid RequestedByUserId { get; set; }

    public DateTime RequestedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureRequestCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("ElectronicSignatureRequest")]
    public virtual ICollection<ElectronicSignatureChallenge> ElectronicSignatureChallenges { get; set; } = new List<ElectronicSignatureChallenge>();

    [InverseProperty("ElectronicSignatureRequest")]
    public virtual ICollection<ElectronicSignature> ElectronicSignatures { get; set; } = new List<ElectronicSignature>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureRequestLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("RequestedByUserId")]
    [InverseProperty("ElectronicSignatureRequestRequestedByUsers")]
    public virtual User RequestedByUser { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("ElectronicSignatureRequests")]
    public virtual Tenant Tenant { get; set; } = null!;
}
