using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class Car
{
    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public int CarModelId { get; set; }

    public int ColorId { get; set; }

    public int? ManufactureYear { get; set; }

    public string? Note { get; set; }

    public string? Vin { get; set; }

    public int? Mileage { get; set; }

    public virtual CarModel CarModel { get; set; } = null!;

    public virtual Color Color { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
