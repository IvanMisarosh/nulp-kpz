using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class PaymentStatus
{
    public int PaymentStatusId { get; set; }

    public string PaymentName { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
