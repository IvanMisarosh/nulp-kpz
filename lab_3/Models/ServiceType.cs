using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class ServiceType
{
    public int ServiceTypeId { get; set; }

    public string ServiceTypeName { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
