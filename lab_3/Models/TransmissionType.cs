﻿using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class TransmissionType
{
    public int TransmissionTypeId { get; set; }

    public string TransmissionTypeName { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
