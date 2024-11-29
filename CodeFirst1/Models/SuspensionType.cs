﻿using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class SuspensionType
{
    public int SuspensionTypeId { get; set; }

    public string SuspensionTypeName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
