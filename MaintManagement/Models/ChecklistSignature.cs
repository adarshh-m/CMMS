using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistSignature", Schema = "checklist")]
public partial class ChecklistSignature
{
    [Key]
    public Guid ChecklistSignatureId { get; set; }

    public Guid ChecklistExecutionId { get; set; }

    public Guid SignedByUserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SignatureRole { get; set; }

    public byte[]? SignatureHash { get; set; }

    public DateTime SignedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistExecutionId")]
    [InverseProperty("ChecklistSignatures")]
    public virtual ChecklistExecution ChecklistExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistSignatureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistSignatureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("SignedByUserId")]
    [InverseProperty("ChecklistSignatureSignedByUsers")]
    public virtual User SignedByUser { get; set; } = null!;
}
