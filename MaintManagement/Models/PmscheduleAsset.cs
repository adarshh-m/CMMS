using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMScheduleAsset", Schema = "pm")]
public partial class PmscheduleAsset
{
    [Key]
    [Column("PMScheduleAssetId")]
    public Guid PmscheduleAssetId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public Guid AssetId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("PmscheduleAssets")]
    public virtual Asset Asset { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmscheduleAssetCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmscheduleAssetLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("PmscheduleAssets")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
