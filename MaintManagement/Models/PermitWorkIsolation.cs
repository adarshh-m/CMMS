using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitWorkIsolation", Schema = "permit")]
public partial class PermitWorkIsolation
{
    [Key]
    public Guid PermitWorkIsolationId { get; set; }

    public Guid PermitId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? IsolationType { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? IsolationPoint { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LockNumber { get; set; }

    public Guid? VerifiedByUserId { get; set; }

    public DateTime? VerificationDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitWorkIsolationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitWorkIsolationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitWorkIsolations")]
    public virtual Permit Permit { get; set; } = null!;

    [ForeignKey("VerifiedByUserId")]
    [InverseProperty("PermitWorkIsolationVerifiedByUsers")]
    public virtual User? VerifiedByUser { get; set; }
}
