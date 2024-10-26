using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class CarBrand
{
    public int CarBrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
