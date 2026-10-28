using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Breakdown", Schema = "breakdown")]
[Index("AssetId", Name = "IX_Breakdown_Asset")]
[Index("CurrentStatus", Name = "IX_Breakdown_Status")]
[Index("WorkOrderId", Name = "IX_Breakdown_WorkOrder")]
public partial class Breakdown
{
    [Key]
    public Guid BreakdownId { get; set; }

    public Guid TenantId { get; set; }

    public Guid WorkOrderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BreakdownNumber { get; set; } = null!;

    public Guid AssetId { get; set; }

    public DateTime BreakdownDateTime { get; set; }

    public DateTime DowntimeStart { get; set; }

    public DateTime? DowntimeEnd { get; set; }

    [StringLength(2000)]
    public string? FailureDescription { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ProductionLossQty { get; set; }

    public int? DowntimeMinutes { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SeverityCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CurrentStatus { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("Breakdowns")]
    public virtual Asset Asset { get; set; } = null!;

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownApproval> BreakdownApprovals { get; set; } = new List<BreakdownApproval>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownCause> BreakdownCauses { get; set; } = new List<BreakdownCause>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownCorrectiveAction> BreakdownCorrectiveActions { get; set; } = new List<BreakdownCorrectiveAction>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownEvidence> BreakdownEvidences { get; set; } = new List<BreakdownEvidence>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownFailure> BreakdownFailures { get; set; } = new List<BreakdownFailure>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownInvestigation> BreakdownInvestigations { get; set; } = new List<BreakdownInvestigation>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownPreventiveAction> BreakdownPreventiveActions { get; set; } = new List<BreakdownPreventiveAction>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownVerification> BreakdownVerifications { get; set; } = new List<BreakdownVerification>();

    [InverseProperty("Breakdown")]
    public virtual ICollection<BreakdownWhyAnalysis> BreakdownWhyAnalyses { get; set; } = new List<BreakdownWhyAnalysis>();

    [ForeignKey("TenantId")]
    [InverseProperty("Breakdowns")]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey("WorkOrderId")]
    [InverseProperty("Breakdowns")]
    public virtual WorkOrder WorkOrder { get; set; } = null!;
}
