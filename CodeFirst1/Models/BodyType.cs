using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class BodyType
{
    public int BodyTypeId { get; set; }

    public string BodyTypeName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
