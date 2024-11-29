using System;
using System.Collections.Generic;
using Abstraction.ModelInterfaces;

namespace CodeFirst1.Models;

public partial class VisitStatus : IVisitStatus
{
    public int VisitStatusID { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
