using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("TenantLanguage", Schema = "masterdata")]
public partial class TenantLanguage
{
    [Key]
    public Guid TenantLanguageId { get; set; }

    public Guid TenantId { get; set; }

    public Guid LanguageId { get; set; }

    public bool IsDefault { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TenantLanguageCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("TenantLanguages")]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("TenantLanguageLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("TenantLanguages")]
    public virtual Tenant Tenant { get; set; } = null!;
}
