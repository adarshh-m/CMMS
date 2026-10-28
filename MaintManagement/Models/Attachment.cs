using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Attachment", Schema = "maintenance")]
public partial class Attachment
{
    [Key]
    public Guid AttachmentId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EntityName { get; set; }

    public Guid? EntityId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? BlobUrl { get; set; }

    public DateTime? UploadedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("AttachmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AttachmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("Attachments")]
    public virtual Tenant Tenant { get; set; } = null!;
}
