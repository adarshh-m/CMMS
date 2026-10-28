using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("Vendor", Schema = "masterdata")]
[Index("VendorCode", Name = "UQ__Vendor__10C18F5CC1EFEFBA", IsUnique = true)]
public partial class Vendor
{
    [Key]
    public Guid VendorId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string VendorCode { get; set; } = null!;

    [StringLength(300)]
    public string VendorName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string VendorType { get; set; } = null!;

    [Column("GSTNumber")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Gstnumber { get; set; }

    [Column("PANNumber")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Pannumber { get; set; }

    [StringLength(200)]
    public string? ContactPerson { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(500)]
    public string? AddressLine1 { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string VendorStatus { get; set; } = null!;

    public bool PreferredVendor { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? RiskScore { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("VendorCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [InverseProperty("Vendor")]
    public virtual ICollection<InventoryReceipt> InventoryReceipts { get; set; } = new List<InventoryReceipt>();

    [InverseProperty("Vendor")]
    public virtual ICollection<MaterialVendor> MaterialVendors { get; set; } = new List<MaterialVendor>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("VendorModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("Vendor")]
    public virtual ICollection<PurchaseReceipt> PurchaseReceipts { get; set; } = new List<PurchaseReceipt>();
}
