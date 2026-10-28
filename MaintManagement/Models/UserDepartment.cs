using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("UserDepartment", Schema = "security")]
public partial class UserDepartment
{
    [Key]
    public Guid UserDepartmentId { get; set; }

    public Guid UserId { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UserDepartmentCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("UserDepartments")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("UserDepartmentLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserDepartmentUsers")]
    public virtual User User { get; set; } = null!;
}
