using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public int? ServiceTypeId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual ServiceType? ServiceType { get; set; }

    public virtual ICollection<VisitService> VisitServices { get; set; } = new List<VisitService>();
}
