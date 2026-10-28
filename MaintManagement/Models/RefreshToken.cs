using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("RefreshToken", Schema = "security")]
public partial class RefreshToken
{
    [Key]
    public Guid RefreshTokenId { get; set; }

    public Guid UserId { get; set; }

    public byte[]? TokenHash { get; set; }

    public DateTime? ExpiresOn { get; set; }

    public DateTime? RevokedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("RefreshTokenCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("RefreshTokenLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("RefreshTokenUsers")]
    public virtual User User { get; set; } = null!;
}
