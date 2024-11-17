using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.ModelInterfaces
{
    public interface IPaymentStatus
    {
        int PaymentStatusID { get; set; }

        string PaymentName { get; set; }
    }
}
