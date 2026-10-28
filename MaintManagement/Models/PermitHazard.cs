using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitHazard", Schema = "permit")]
public partial class PermitHazard
{
    [Key]
    public Guid PermitHazardId { get; set; }

    public Guid PermitId { get; set; }

    public Guid HazardId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Severity { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Likelihood { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitHazardCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("HazardId")]
    [InverseProperty("PermitHazards")]
    public virtual HazardMaster Hazard { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitHazardLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitHazards")]
    public virtual Permit Permit { get; set; } = null!;
}
