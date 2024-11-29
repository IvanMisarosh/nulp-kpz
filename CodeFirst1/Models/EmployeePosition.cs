﻿using System;
using System.Collections.Generic;

namespace CodeFirst1.Models;

public partial class EmployeePosition
{
    public int EmployeePositionId { get; set; }

    public string PositionName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
