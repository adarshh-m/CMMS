using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowVariable", Schema = "workflow")]
public partial class WorkflowVariable
{
    [Key]
    public Guid WorkflowVariableId { get; set; }

    public Guid WorkflowInstanceId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? VariableName { get; set; }

    public string? VariableValue { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DataType { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("WorkflowVariableCreatedByNavigations")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("LastModifiedBy")]
    [InverseProperty("WorkflowVariableLastModifiedByNavigations")]
    public virtual User? LastModifiedByNavigation { get; set; }

    [ForeignKey("WorkflowInstanceId")]
    [InverseProperty("WorkflowVariables")]
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;
}
