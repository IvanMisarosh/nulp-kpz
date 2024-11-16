using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.ModelInterfaces
{
    public interface ICustomer
    {
        int CustomerID { get; set; }

        string Email { get; set; }

        string FirstName { get; set; } 

        string LastName { get; set; } 

        string PhoneNumber { get; set; }

    }
}
