using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("UserPlant", Schema = "security")]
public partial class UserPlant
{
    [Key]
    public Guid UserPlantId { get; set; }

    public Guid UserId { get; set; }

    public Guid PlantId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UserPlantCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("UserPlantLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("PlantId")]
    [InverseProperty("UserPlants")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserPlantUsers")]
    public virtual User User { get; set; } = null!;
}
