using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitExtension", Schema = "permit")]
public partial class PermitExtension
{
    [Key]
    public Guid PermitExtensionId { get; set; }

    public Guid PermitId { get; set; }

    public DateTime PreviousExpiryDate { get; set; }

    public DateTime NewExpiryDate { get; set; }

    [StringLength(1000)]
    public string? ExtensionReason { get; set; }

    public Guid ApprovedByUserId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ApprovedByUserId")]
    [InverseProperty("PermitExtensionApprovedByUsers")]
    public virtual User ApprovedByUser { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitExtensionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitExtensionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitExtensions")]
    public virtual Permit Permit { get; set; } = null!;
}
