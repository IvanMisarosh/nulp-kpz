using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Wpf.Models
{
    public class Customer : ICustomer
    {
        public int CustomerID { get; set; }
        public string Email { get; set ; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        //public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
