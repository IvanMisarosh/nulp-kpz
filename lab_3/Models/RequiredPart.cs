using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class RequiredPart
{
    public int RequiredPartId { get; set; }

    public int PartInStationId { get; set; }

    public int ProvidedServiceId { get; set; }

    public int Quantity { get; set; }

    public virtual PartInStation PartInStation { get; set; } = null!;

    public virtual ProvidedService ProvidedService { get; set; } = null!;
}
