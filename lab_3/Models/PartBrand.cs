using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class PartBrand
{
    public int PartBrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
