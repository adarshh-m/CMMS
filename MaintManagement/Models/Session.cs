using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Session", Schema = "security")]
public partial class Session
{
    [Key]
    public Guid SessionId { get; set; }

    public Guid UserId { get; set; }

    public DateTime LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? IpAddress { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? DeviceName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? RefreshTokenHash { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SessionCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("SessionLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("SessionUsers")]
    public virtual User User { get; set; } = null!;
}
