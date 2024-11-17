using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Abstraction.DTOs
{
    public class PaymentStatusDTO : IPaymentStatus
    {
        public int PaymentStatusID { get; set; }

        public string PaymentName { get; set; }
    }
}
