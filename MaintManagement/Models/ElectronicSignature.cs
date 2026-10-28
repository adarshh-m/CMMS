using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignature", Schema = "esign")]
[Index("SignedOn", Name = "IX_ESignature_Date")]
[Index("UserId", Name = "IX_ESignature_User")]
public partial class ElectronicSignature
{
    [Key]
    public Guid ElectronicSignatureId { get; set; }

    public Guid ElectronicSignatureRequestId { get; set; }

    public Guid UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? SignatureReason { get; set; }

    [StringLength(2000)]
    public string? SignatureComment { get; set; }

    public DateTime SignedOn { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? IpAddress { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? DeviceInformation { get; set; }

    public byte[]? SignatureHash { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("ElectronicSignature")]
    public virtual ICollection<ElectronicSignatureAttachment> ElectronicSignatureAttachments { get; set; } = new List<ElectronicSignatureAttachment>();

    [InverseProperty("ElectronicSignature")]
    public virtual ICollection<ElectronicSignatureAudit> ElectronicSignatureAudits { get; set; } = new List<ElectronicSignatureAudit>();

    [ForeignKey("ElectronicSignatureRequestId")]
    [InverseProperty("ElectronicSignatures")]
    public virtual ElectronicSignatureRequest ElectronicSignatureRequest { get; set; } = null!;

    [InverseProperty("ElectronicSignature")]
    public virtual ICollection<ElectronicSignatureVerification> ElectronicSignatureVerifications { get; set; } = new List<ElectronicSignatureVerification>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ElectronicSignatureUsers")]
    public virtual User User { get; set; } = null!;
}
