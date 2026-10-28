using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitIssue", Schema = "permit")]
[Index("ExpiryDate", Name = "IX_PermitIssue_Expiry")]
public partial class PermitIssue
{
    [Key]
    public Guid PermitIssueId { get; set; }

    public Guid PermitId { get; set; }

    public Guid IssuedByUserId { get; set; }

    public DateTime IssuedDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    [StringLength(1000)]
    public string? IssueRemarks { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitIssueCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("IssuedByUserId")]
    [InverseProperty("PermitIssueIssuedByUsers")]
    public virtual User IssuedByUser { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitIssueLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitIssues")]
    public virtual Permit Permit { get; set; } = null!;
}
