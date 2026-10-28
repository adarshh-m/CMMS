using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("UserTeam", Schema = "security")]
public partial class UserTeam
{
    [Key]
    public Guid UserTeamId { get; set; }

    public Guid UserId { get; set; }

    public Guid TeamId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UserTeamCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("UserTeamLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("UserTeams")]
    public virtual Team Team { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserTeamUsers")]
    public virtual User User { get; set; } = null!;
}
