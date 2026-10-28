using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("LoginHistory", Schema = "security")]
public partial class LoginHistory
{
    [Key]
    public long LoginHistoryId { get; set; }

    public Guid UserId { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? IpAddress { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("LoginHistoryCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("LoginHistoryLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("LoginHistoryUsers")]
    public virtual User User { get; set; } = null!;
}
