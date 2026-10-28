using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMExecution", Schema = "pm")]
[Index("CompletedOn", Name = "IX_PMExecution_Completed")]
public partial class Pmexecution
{
    [Key]
    [Column("PMExecutionId")]
    public Guid PmexecutionId { get; set; }

    [Column("PMWorkOrderId")]
    public Guid PmworkOrderId { get; set; }

    public DateTime? StartedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    public Guid? ExecutedBy { get; set; }

    public string? ExecutionRemarks { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Result { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmexecutionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmexecutionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Pmexecution")]
    public virtual ICollection<PmexecutionChecklist> PmexecutionChecklists { get; set; } = new List<PmexecutionChecklist>();

    [InverseProperty("Pmexecution")]
    public virtual ICollection<PmexecutionReading> PmexecutionReadings { get; set; } = new List<PmexecutionReading>();

    [ForeignKey("PmworkOrderId")]
    [InverseProperty("Pmexecutions")]
    public virtual PmworkOrder PmworkOrder { get; set; } = null!;
}
