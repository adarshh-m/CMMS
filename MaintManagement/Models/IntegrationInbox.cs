using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("IntegrationInbox", Schema = "integration")]
[Index("ExternalMessageId", Name = "IX_Inbox_ExternalMessageId")]
public partial class IntegrationInbox
{
    [Key]
    public Guid InboxId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string ExternalMessageId { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? SourceSystemCode { get; set; }

    public string? Payload { get; set; }

    public DateTime? ProcessedOn { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? ProcessingStatus { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("IntegrationInboxCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("IntegrationInboxLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("IntegrationInboxes")]
    public virtual Tenant Tenant { get; set; } = null!;
}
