using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PermitEmployee", Schema = "permit")]
public partial class PermitEmployee
{
    [Key]
    public Guid PermitEmployeeId { get; set; }

    public Guid PermitId { get; set; }

    public Guid UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RoleName { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PermitEmployeeCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PermitEmployeeLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PermitId")]
    [InverseProperty("PermitEmployees")]
    public virtual Permit Permit { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("PermitEmployeeUsers")]
    public virtual User User { get; set; } = null!;
}
