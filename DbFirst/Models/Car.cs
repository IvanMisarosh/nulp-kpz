using System;
using System.Collections.Generic;
using Abstraction.ModelInterfaces;

namespace DbFirst.Models;

public partial class Car: ICar
{
    public int CarID { get; set; }

    public int CustomerID { get; set; }

    public int CarModelID { get; set; }

    public int ColorID { get; set; }

    public int? ManufactureYear { get; set; }

    public string? Note { get; set; }

    public string? VIN { get; set; }

    public int? Mileage { get; set; }

    public virtual CarModel CarModel { get; set; } = null!;

    public virtual Color Color { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
