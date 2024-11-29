using System;
using System.Collections.Generic;
using Abstraction.ModelInterfaces;

namespace CodeFirst1.Models;

public partial class Employee: IEmployee
{
    public int EmployeeID { get; set; }

    public int? EmployeePositionID { get; set; }

    public int StationID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    public virtual EmployeePosition? EmployeePosition { get; set; }

    public virtual ICollection<ProvidedService> ProvidedServices { get; set; } = new List<ProvidedService>();

    public virtual Station Station { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
