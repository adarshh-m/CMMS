using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureVerification", Schema = "esign")]
public partial class ElectronicSignatureVerification
{
    [Key]
    public Guid ElectronicSignatureVerificationId { get; set; }

    public Guid ElectronicSignatureId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerificationMethod { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerificationResult { get; set; }

    public DateTime VerificationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureVerificationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ElectronicSignatureId")]
    [InverseProperty("ElectronicSignatureVerifications")]
    public virtual ElectronicSignature ElectronicSignature { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureVerificationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
