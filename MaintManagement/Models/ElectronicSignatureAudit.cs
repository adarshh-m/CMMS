using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureAudit", Schema = "esign")]
[Index("EventDate", Name = "IX_ESignAudit_Date")]
public partial class ElectronicSignatureAudit
{
    [Key]
    public long ElectronicSignatureAuditId { get; set; }

    public Guid ElectronicSignatureId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EventType { get; set; }

    public DateTime EventDate { get; set; }

    public string? EventData { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureAuditCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ElectronicSignatureId")]
    [InverseProperty("ElectronicSignatureAudits")]
    public virtual ElectronicSignature ElectronicSignature { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureAuditLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
