using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class VisitService
{
    public int VisitServiceId { get; set; }

    public int VisitId { get; set; }

    public int ServiceId { get; set; }

    public int Quantity { get; set; }

    public virtual ProvidedService? ProvidedService { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
