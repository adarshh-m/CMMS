using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationTemplate", Schema = "notification")]
public partial class NotificationTemplate
{
    [Key]
    public Guid NotificationTemplateId { get; set; }

    public Guid TenantId { get; set; }

    public Guid NotificationEventId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ChannelCode { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string TemplateCode { get; set; } = null!;

    [StringLength(500)]
    public string? SubjectTemplate { get; set; }

    public string? BodyTemplate { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationTemplateCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationTemplateLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("NotificationEventId")]
    [InverseProperty("NotificationTemplates")]
    public virtual NotificationEvent NotificationEvent { get; set; } = null!;

    [InverseProperty("NotificationTemplate")]
    public virtual ICollection<NotificationTemplateTranslation> NotificationTemplateTranslations { get; set; } = new List<NotificationTemplateTranslation>();

    [ForeignKey("TenantId")]
    [InverseProperty("NotificationTemplates")]
    public virtual Tenant Tenant { get; set; } = null!;
}
