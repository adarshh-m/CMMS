using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitRiskAssessment", Schema = "permit")]
public partial class PermitRiskAssessment
{
    [Key]
    public Guid PermitRiskAssessmentId { get; set; }

    public Guid PermitId { get; set; }

    public int InitialRiskScore { get; set; }

    public int ResidualRiskScore { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? RiskCategory { get; set; }

    public string? AssessmentRemarks { get; set; }

    public Guid AssessedByUserId { get; set; }

    public DateTime AssessmentDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssessedByUserId")]
    [InverseProperty("PermitRiskAssessmentAssessedByUsers")]
    public virtual User AssessedByUser { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitRiskAssessmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitRiskAssessmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitRiskAssessments")]
    public virtual Permit Permit { get; set; } = null!;
}
