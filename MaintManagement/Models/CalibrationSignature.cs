using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationSignature", Schema = "calibration")]
public partial class CalibrationSignature
{
    [Key]
    public Guid CalibrationSignatureId { get; set; }

    public Guid CalibrationExecutionId { get; set; }

    public Guid UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SignatureRole { get; set; }

    public DateTime SignatureDate { get; set; }

    public byte[]? SignatureHash { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationExecutionId")]
    [InverseProperty("CalibrationSignatures")]
    public virtual CalibrationExecution CalibrationExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationSignatureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationSignatureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("CalibrationSignatureUsers")]
    public virtual User User { get; set; } = null!;
}
