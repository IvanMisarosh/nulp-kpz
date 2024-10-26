using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class Visit
{
    public int VisitId { get; set; }

    public int VisitStatusId { get; set; }

    public int CarId { get; set; }

    public int EmployeeId { get; set; }

    public int? PaymentStatusId { get; set; }

    public DateTime? VisitDate { get; set; }

    public DateTime? PlannedEndDate { get; set; }

    public DateTime? ActualEndDate { get; set; }

    public string? Details { get; set; }

    public int VisitNumber { get; set; }

    public decimal? Price { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual PaymentStatus? PaymentStatus { get; set; }

    public virtual ICollection<VisitService> VisitServices { get; set; } = new List<VisitService>();

    public virtual VisitStatus VisitStatus { get; set; } = null!;
}
