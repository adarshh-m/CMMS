using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("DeadStockAnalysis", Schema = "inventory")]
public partial class DeadStockAnalysis
{
    [Key]
    public Guid DeadStockAnalysisId { get; set; }

    public Guid TenantId { get; set; }

    public Guid MaterialId { get; set; }

    public DateOnly? LastIssueDate { get; set; }

    public int? DaysWithoutMovement { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? CurrentStock { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DeadStockValue { get; set; }

    public DateOnly AnalysisDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("DeadStockAnalysisCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("DeadStockAnalysisLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("DeadStockAnalyses")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("DeadStockAnalyses")]
    public virtual Tenant Tenant { get; set; } = null!;
}
