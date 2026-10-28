using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Localization", Schema = "masterdata")]
public partial class Localization
{
    [Key]
    public Guid LocalizationId { get; set; }

    public Guid? TenantId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EntityType { get; set; } = null!;

    public Guid EntityId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string LanguageCode { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string PropertyName { get; set; } = null!;

    public string TranslatedValue { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("LocalizationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("LocalizationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("Localizations")]
    public virtual Tenant? Tenant { get; set; }
}
