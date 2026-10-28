using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitSuspend", Schema = "permit")]
public partial class PermitSuspend
{
    [Key]
    public Guid PermitSuspendId { get; set; }

    public Guid PermitId { get; set; }

    public Guid SuspendedByUserId { get; set; }

    public DateTime SuspensionDate { get; set; }

    [StringLength(1000)]
    public string? SuspensionReason { get; set; }

    public DateTime? ResumeDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitSuspendCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitSuspendLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitSuspends")]
    public virtual Permit Permit { get; set; } = null!;

    [ForeignKey("SuspendedByUserId")]
    [InverseProperty("PermitSuspendSuspendedByUsers")]
    public virtual User SuspendedByUser { get; set; } = null!;
}
