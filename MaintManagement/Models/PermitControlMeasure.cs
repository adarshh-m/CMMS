using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitControlMeasure", Schema = "permit")]
public partial class PermitControlMeasure
{
    [Key]
    public Guid PermitControlMeasureId { get; set; }

    public Guid PermitId { get; set; }

    public Guid ControlMeasureId { get; set; }

    public bool IsMandatory { get; set; }

    public bool Verified { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("ControlMeasureId")]
    [InverseProperty("PermitControlMeasures")]
    public virtual ControlMeasure ControlMeasure { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitControlMeasureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitControlMeasureLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitControlMeasures")]
    public virtual Permit Permit { get; set; } = null!;
}
