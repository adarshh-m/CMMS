using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitSignature", Schema = "permit")]
public partial class PermitSignature
{
    [Key]
    public Guid PermitSignatureId { get; set; }

    public Guid PermitId { get; set; }

    public Guid UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SignatureRole { get; set; }

    public DateTime SignatureDate { get; set; }

    public byte[]? SignatureHash { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitSignatureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitSignatureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitSignatures")]
    public virtual Permit Permit { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("PermitSignatureUsers")]
    public virtual User User { get; set; } = null!;
}
