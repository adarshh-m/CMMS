using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignature", Schema = "security")]
public partial class ElectronicSignature1
{
    [Key]
    public Guid SignatureId { get; set; }

    public Guid UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SignaturePurpose { get; set; }

    public byte[]? SignatureHash { get; set; }

    public DateTime SignedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignature1CreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignature1LastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ElectronicSignature1Users")]
    public virtual User User { get; set; } = null!;
}
