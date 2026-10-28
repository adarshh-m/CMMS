using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ControlMeasure", Schema = "masterdata")]
[Index("ControlCode", Name = "UQ__ControlM__2C5141132C3C0773", IsUnique = true)]
public partial class ControlMeasure
{
    [Key]
    public Guid ControlMeasureId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ControlCode { get; set; } = null!;

    [StringLength(200)]
    public string ControlName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ControlType { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? RiskReductionLevel { get; set; }

    public bool IsMandatory { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ControlMeasureCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ControlMeasureModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("ControlMeasure")]
    public virtual ICollection<PermitControlMeasure> PermitControlMeasures { get; set; } = new List<PermitControlMeasure>();
}
