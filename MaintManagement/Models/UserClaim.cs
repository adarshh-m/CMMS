using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("UserClaim", Schema = "security")]
public partial class UserClaim
{
    [Key]
    public Guid UserClaimId { get; set; }

    public Guid UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ClaimType { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ClaimValue { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UserClaimCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("UserClaimLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserClaimUsers")]
    public virtual User User { get; set; } = null!;
}
