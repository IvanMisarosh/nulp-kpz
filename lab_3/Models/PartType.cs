﻿using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class PartType
{
    public int PartTypeId { get; set; }

    public string PartTypeName { get; set; } = null!;

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
