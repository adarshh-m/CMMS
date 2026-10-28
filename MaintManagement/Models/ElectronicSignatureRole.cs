using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureRole", Schema = "esign")]
public partial class ElectronicSignatureRole
{
    [Key]
    public Guid ElectronicSignatureRoleId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RoleCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? RoleName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureRoleCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("ElectronicSignatureRole")]
    public virtual ICollection<ElectronicSignatureRoleAssignment> ElectronicSignatureRoleAssignments { get; set; } = new List<ElectronicSignatureRoleAssignment>();

    [InverseProperty("ElectronicSignatureRole")]
    public virtual ICollection<ElectronicSignatureSequence> ElectronicSignatureSequences { get; set; } = new List<ElectronicSignatureSequence>();

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureRoleLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
