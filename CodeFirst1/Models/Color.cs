using System;
using System.Collections.Generic;
using Abstraction.ModelInterfaces;

namespace CodeFirst1.Models;

public partial class Color : IColor
{
    public int ColorID { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
