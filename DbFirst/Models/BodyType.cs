using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class BodyType
{
    public int BodyTypeId { get; set; }

    public string BodyTypeName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
