using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class Part
{
    public int PartId { get; set; }

    public int? PartBrandId { get; set; }

    public int? PartTypeId { get; set; }

    public string PartName { get; set; } = null!;

    public decimal? Weight { get; set; }

    public string? Dimensions { get; set; }

    public string? Description { get; set; }

    public int? QuantityPerPackage { get; set; }

    public decimal? PricePerPackage { get; set; }

    public virtual PartBrand? PartBrand { get; set; }

    public virtual ICollection<PartInStation> PartInStations { get; set; } = new List<PartInStation>();

    public virtual PartType? PartType { get; set; }
}
