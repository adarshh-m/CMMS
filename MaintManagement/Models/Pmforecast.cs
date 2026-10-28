using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("PMForecast", Schema = "pm")]
public partial class Pmforecast
{
    [Key]
    [Column("PMForecastId")]
    public Guid PmforecastId { get; set; }

    [Column("PMScheduleId")]
    public Guid PmscheduleId { get; set; }

    public DateOnly ForecastDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ForecastType { get; set; }

    public int? ExpectedWorkOrderCount { get; set; }

    public DateTime ForecastGeneratedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PmforecastCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("PmforecastLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PmscheduleId")]
    [InverseProperty("Pmforecasts")]
    public virtual Pmschedule Pmschedule { get; set; } = null!;
}
