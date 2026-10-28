using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitAttachment", Schema = "permit")]
public partial class PermitAttachment
{
    [Key]
    public Guid PermitAttachmentId { get; set; }

    public Guid PermitId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? FileUrl { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DocumentType { get; set; }

    public DateTime UploadedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitAttachmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitAttachmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitAttachments")]
    public virtual Permit Permit { get; set; } = null!;
}
