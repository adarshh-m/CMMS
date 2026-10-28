using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureRoleAssignment", Schema = "esign")]
public partial class ElectronicSignatureRoleAssignment
{
    [Key]
    public Guid ElectronicSignatureRoleAssignmentId { get; set; }

    public Guid ElectronicSignaturePurposeId { get; set; }

    public Guid ElectronicSignatureRoleId { get; set; }

    public bool IsMandatory { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureRoleAssignmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ElectronicSignaturePurposeId")]
    [InverseProperty("ElectronicSignatureRoleAssignments")]
    public virtual ElectronicSignaturePurpose ElectronicSignaturePurpose { get; set; } = null!;

    [ForeignKey("ElectronicSignatureRoleId")]
    [InverseProperty("ElectronicSignatureRoleAssignments")]
    public virtual ElectronicSignatureRole ElectronicSignatureRole { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureRoleAssignmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
