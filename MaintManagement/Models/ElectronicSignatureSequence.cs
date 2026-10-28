using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureSequence", Schema = "esign")]
public partial class ElectronicSignatureSequence
{
    [Key]
    public Guid ElectronicSignatureSequenceId { get; set; }

    public Guid ElectronicSignaturePurposeId { get; set; }

    public int SequenceNo { get; set; }

    public Guid ElectronicSignatureRoleId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureSequenceCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ElectronicSignaturePurposeId")]
    [InverseProperty("ElectronicSignatureSequences")]
    public virtual ElectronicSignaturePurpose ElectronicSignaturePurpose { get; set; } = null!;

    [ForeignKey("ElectronicSignatureRoleId")]
    [InverseProperty("ElectronicSignatureSequences")]
    public virtual ElectronicSignatureRole ElectronicSignatureRole { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureSequenceLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
