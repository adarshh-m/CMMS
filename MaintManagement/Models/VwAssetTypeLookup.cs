using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaintManagement.Models;

[Keyless]
public partial class VwAssetTypeLookup
{
    public Guid AssetTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }
}
