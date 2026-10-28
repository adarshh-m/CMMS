using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationCertificate", Schema = "calibration")]
[Index("CertificateNumber", Name = "IX_CalibrationCertificate_Number")]
public partial class CalibrationCertificate
{
    [Key]
    public Guid CalibrationCertificateId { get; set; }

    public Guid CalibrationExecutionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CertificateNumber { get; set; } = null!;

    public DateOnly CertificateDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? FileUrl { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CalibrationExecutionId")]
    [InverseProperty("CalibrationCertificates")]
    public virtual CalibrationExecution CalibrationExecution { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationCertificateCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationCertificateLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
