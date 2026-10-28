using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("NotificationPreference", Schema = "notification")]
public partial class NotificationPreference
{
    [Key]
    public Guid NotificationPreferenceId { get; set; }

    public Guid UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ChannelCode { get; set; }

    public bool IsEnabled { get; set; }

    public TimeOnly? QuietHoursStart { get; set; }

    public TimeOnly? QuietHoursEnd { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NotificationPreferenceCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("NotificationPreferenceLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("NotificationPreferenceUsers")]
    public virtual User User { get; set; } = null!;
}
