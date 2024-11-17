using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Abstraction.DTOs
{
    public class EmployeeDTO : IEmployee
    {
        public int EmployeeID { get; set; }

        public int? EmployeePositionID { get; set; }

        public int StationID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public virtual StationDTO Station { get; set; }
        public virtual EmployeePositionDTO EmployeePosition { get; set; }
    }
}
