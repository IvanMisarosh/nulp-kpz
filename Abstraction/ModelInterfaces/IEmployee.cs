using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.ModelInterfaces
{
    public interface IEmployee
    {
        int EmployeeID { get; set; }

        int? EmployeePositionID { get; set; }

        int StationID { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string PhoneNumber { get; set; }

        string Address { get; set; }
    }
}
