using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class EngineType
{
    public int EngineTypeId { get; set; }

    public string EngineTypeName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
