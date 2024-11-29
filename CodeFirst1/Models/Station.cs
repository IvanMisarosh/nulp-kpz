using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class Station
{
    public int StationId { get; set; }

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<PartInStation> PartInStations { get; set; } = new List<PartInStation>();
}
