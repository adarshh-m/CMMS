using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureChallenge", Schema = "esign")]
public partial class ElectronicSignatureChallenge
{
    [Key]
    public Guid ElectronicSignatureChallengeId { get; set; }

    public Guid ElectronicSignatureRequestId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ChallengeType { get; set; }

    public DateTime GeneratedOn { get; set; }

    public DateTime ExpiresOn { get; set; }

    public bool IsCompleted { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureChallengeCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ElectronicSignatureRequestId")]
    [InverseProperty("ElectronicSignatureChallenges")]
    public virtual ElectronicSignatureRequest ElectronicSignatureRequest { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureChallengeLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
