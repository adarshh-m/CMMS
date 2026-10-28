using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ChecklistExecution", Schema = "checklist")]
[Index("EntityType", "EntityId", Name = "IX_ChecklistExecution_Entity")]
public partial class ChecklistExecution
{
    [Key]
    public Guid ChecklistExecutionId { get; set; }

    public Guid TenantId { get; set; }

    public Guid ChecklistVersionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EntityType { get; set; } = null!;

    public Guid EntityId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public DateTime? StartedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    public Guid? ExecutedByUserId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [InverseProperty("ChecklistExecution")]
    public virtual ICollection<ChecklistExecutionSection> ChecklistExecutionSections { get; set; } = new List<ChecklistExecutionSection>();

    [InverseProperty("ChecklistExecution")]
    public virtual ICollection<ChecklistResponse> ChecklistResponses { get; set; } = new List<ChecklistResponse>();

    [InverseProperty("ChecklistExecution")]
    public virtual ICollection<ChecklistScore> ChecklistScores { get; set; } = new List<ChecklistScore>();

    [InverseProperty("ChecklistExecution")]
    public virtual ICollection<ChecklistSignature> ChecklistSignatures { get; set; } = new List<ChecklistSignature>();

    [ForeignKey("ChecklistVersionId")]
    [InverseProperty("ChecklistExecutions")]
    public virtual ChecklistVersion ChecklistVersion { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ChecklistExecutionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("ExecutedByUserId")]
    [InverseProperty("ChecklistExecutionExecutedByUsers")]
    public virtual User? ExecutedByUser { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ChecklistExecutionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("ChecklistExecutions")]
    public virtual Tenant Tenant { get; set; } = null!;
}
