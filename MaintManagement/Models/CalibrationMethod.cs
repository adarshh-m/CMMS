using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("CalibrationMethod", Schema = "calibration")]
public partial class CalibrationMethod
{
    [Key]
    public Guid CalibrationMethodId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string MethodCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string MethodName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? RevisionNo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ProcedureDocumentNo { get; set; }

    public string? Description { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("CalibrationMethod")]
    public virtual ICollection<CalibrationSchedule> CalibrationSchedules { get; set; } = new List<CalibrationSchedule>();

    [InverseProperty("CalibrationMethod")]
    public virtual ICollection<CalibrationVersion> CalibrationVersions { get; set; } = new List<CalibrationVersion>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("CalibrationMethodCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("CalibrationMethodLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("CalibrationMethods")]
    public virtual Tenant Tenant { get; set; } = null!;
}
