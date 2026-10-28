using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("SystemMessageTranslation", Schema = "masterdata")]
public partial class SystemMessageTranslation
{
    [Key]
    public Guid MessageTranslationId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MessageCode { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? LanguageCode { get; set; }

    [StringLength(1000)]
    public string? MessageText { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SystemMessageTranslationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("SystemMessageTranslationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
