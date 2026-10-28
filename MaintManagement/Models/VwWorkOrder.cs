using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Keyless]
public partial class VwWorkOrder
{
    public Guid WorkOrderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string WorkOrderNo { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AssetCode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string AssetName { get; set; } = null!;
}
