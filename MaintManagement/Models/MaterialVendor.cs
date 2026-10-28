using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("MaterialVendor", Schema = "inventory")]
public partial class MaterialVendor
{
    [Key]
    public Guid MaterialVendorId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid VendorId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? VendorPartNumber { get; set; }

    public int? LeadTimeDays { get; set; }

    public bool IsPreferred { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaterialVendorCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("MaterialVendorLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("MaterialVendors")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("VendorId")]
    [InverseProperty("MaterialVendors")]
    public virtual Vendor Vendor { get; set; } = null!;
}
