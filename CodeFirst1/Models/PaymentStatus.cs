using System;
using System.Collections.Generic;
using Abstraction.ModelInterfaces;


namespace CodeFirst1.Models;

public partial class PaymentStatus: IPaymentStatus
{
    public int PaymentStatusID { get; set; }

    public string PaymentName { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
