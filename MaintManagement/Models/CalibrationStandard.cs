using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationStandard", Schema = "calibration")]
public partial class CalibrationStandard
{
    [Key]
    public Guid CalibrationStandardId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string StandardCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string StandardName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? CertificateNo { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? TraceabilityAuthority { get; set; }

    public DateOnly? EffectiveDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationStandardCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationStandardLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("CalibrationStandards")]
    public virtual Tenant Tenant { get; set; } = null!;
}
