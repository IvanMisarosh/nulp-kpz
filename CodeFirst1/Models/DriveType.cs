﻿using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class DriveType
{
    public int DriveTypeId { get; set; }

    public string DriveTypeName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}