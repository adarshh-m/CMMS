using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureAttachment", Schema = "esign")]
public partial class ElectronicSignatureAttachment
{
    [Key]
    public Guid ElectronicSignatureAttachmentId { get; set; }

    public Guid ElectronicSignatureId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? FileUrl { get; set; }

    public DateTime UploadedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureAttachmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ElectronicSignatureId")]
    [InverseProperty("ElectronicSignatureAttachments")]
    public virtual ElectronicSignature ElectronicSignature { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureAttachmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
