using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistResponseAttachment", Schema = "checklist")]
public partial class ChecklistResponseAttachment
{
    [Key]
    public Guid ChecklistResponseAttachmentId { get; set; }

    public Guid ChecklistResponseId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? FileUrl { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FileType { get; set; }

    public DateTime UploadedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ChecklistResponseId")]
    [InverseProperty("ChecklistResponseAttachments")]
    public virtual ChecklistResponse ChecklistResponse { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistResponseAttachmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistResponseAttachmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
