using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationTemplateTranslation", Schema = "notification")]
public partial class NotificationTemplateTranslation
{
    [Key]
    public Guid NotificationTemplateTranslationId { get; set; }

    public Guid NotificationTemplateId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string LanguageCode { get; set; } = null!;

    [StringLength(500)]
    public string? SubjectTemplate { get; set; }

    public string? BodyTemplate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationTemplateTranslationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationTemplateTranslationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("NotificationTemplateId")]
    [InverseProperty("NotificationTemplateTranslations")]
    public virtual NotificationTemplate NotificationTemplate { get; set; } = null!;
}
