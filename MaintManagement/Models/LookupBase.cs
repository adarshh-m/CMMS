using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("LookupBase", Schema = "masterdata")]
public partial class LookupBase
{
    [Key]
    public Guid LookupId { get; set; }

    public Guid TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LookupType { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    [Unicode(false)]
    public string? Description { get; set; }

    public Guid? ParentLookupId { get; set; }

    public int SortOrder { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("LookupBaseCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("LookupBaseLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("LookupBases")]
    public virtual Tenant Tenant { get; set; } = null!;
}
