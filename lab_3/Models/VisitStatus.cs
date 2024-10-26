using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class VisitStatus
{
    public int VisitStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
