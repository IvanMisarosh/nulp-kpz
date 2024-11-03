using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class ProvidedService
{
    public int ProvidedServiceId { get; set; }

    public int? EmployeeId { get; set; }

    public int VisitServiceId { get; set; }

    public DateTime? ProvidedDate { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<RequiredPart> RequiredParts { get; set; } = new List<RequiredPart>();

    public virtual VisitService VisitService { get; set; } = null!;
}
