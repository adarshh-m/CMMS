using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Language", Schema = "masterdata")]
public partial class Language
{
    [Key]
    public Guid LanguageId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string LanguageCode { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string LanguageName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string CultureCode { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("LanguageCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("LanguageLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [InverseProperty("Language")]
    public virtual ICollection<TenantLanguage> TenantLanguages { get; set; } = new List<TenantLanguage>();
}
