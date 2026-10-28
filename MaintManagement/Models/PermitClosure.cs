using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitClosure", Schema = "permit")]
public partial class PermitClosure
{
    [Key]
    public Guid PermitClosureId { get; set; }

    public Guid PermitId { get; set; }

    public Guid ClosedByUserId { get; set; }

    public DateTime ClosureDate { get; set; }

    public bool WorkCompleted { get; set; }

    public bool IsolationRemoved { get; set; }

    public bool SiteRestored { get; set; }

    public string? ClosureRemarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ClosedByUserId")]
    [InverseProperty("PermitClosureClosedByUsers")]
    public virtual User ClosedByUser { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitClosureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitClosureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitClosures")]
    public virtual Permit Permit { get; set; } = null!;
}
