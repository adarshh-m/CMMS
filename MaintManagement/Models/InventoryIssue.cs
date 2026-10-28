using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("InventoryIssue", Schema = "inventory")]
public partial class InventoryIssue
{
    [Key]
    public Guid InventoryIssueId { get; set; }

    public Guid InventoryTransactionId { get; set; }

    public Guid WorkOrderId { get; set; }

    public Guid? IssuedToUserId { get; set; }

    public DateTime IssueDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryIssueCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("InventoryTransactionId")]
    [InverseProperty("InventoryIssues")]
    public virtual InventoryTransaction InventoryTransaction { get; set; } = null!;

    [ForeignKey("IssuedToUserId")]
    [InverseProperty("InventoryIssueIssuedToUsers")]
    public virtual User? IssuedToUser { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("InventoryIssueLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkOrderId")]
    [InverseProperty("InventoryIssues")]
    public virtual WorkOrder WorkOrder { get; set; } = null!;
}
