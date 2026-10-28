using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("ABCClassification", Schema = "inventory")]
public partial class Abcclassification
{
    [Key]
    [Column("ABCClassificationId")]
    public Guid AbcclassificationId { get; set; }

    public Guid TenantId { get; set; }

    public Guid MaterialId { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string ClassificationCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? AnnualConsumptionValue { get; set; }

    public DateTime? LastCalculatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("AbcclassificationCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("AbcclassificationLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("Abcclassifications")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Abcclassifications")]
    public virtual Tenant Tenant { get; set; } = null!;
}
