using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Email { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
