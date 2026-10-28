using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("SystemMessage", Schema = "masterdata")]
public partial class SystemMessage
{
    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string MessageCode { get; set; } = null!;

    [StringLength(1000)]
    public string? DefaultText { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SystemMessageCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("SystemMessageLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
