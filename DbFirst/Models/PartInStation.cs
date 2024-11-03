using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class PartInStation
{
    public int PartInStationId { get; set; }

    public int StationId { get; set; }

    public int PartId { get; set; }

    public int? Quantity { get; set; }

    public virtual Part Part { get; set; } = null!;

    public virtual ICollection<RequiredPart> RequiredParts { get; set; } = new List<RequiredPart>();

    public virtual Station Station { get; set; } = null!;
}
