using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ElectronicSignatureMeaning", Schema = "esign")]
public partial class ElectronicSignatureMeaning
{
    [Key]
    public Guid ElectronicSignatureMeaningId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MeaningCode { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? MeaningText { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ElectronicSignatureMeaningCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("ElectronicSignatureMeaningLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }
}
