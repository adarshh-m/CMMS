using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Table("WorkflowComment", Schema = "workflow")]
public partial class WorkflowComment
{
    [Key]
    public Guid WorkflowCommentId { get; set; }

    public Guid WorkflowInstanceId { get; set; }

    public string? CommentText { get; set; }

    public Guid CreatedByUserId { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("WorkflowComments")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("WorkflowInstanceId")]
    [InverseProperty("WorkflowComments")]
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;
}
