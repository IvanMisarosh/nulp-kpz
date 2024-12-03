using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Wpf.Models
{
    public class PaymentStatus : IPaymentStatus
    {
        public int PaymentStatusID { get; set; }

        public string PaymentName { get; set; }
    }
}
