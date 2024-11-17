using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Abstraction.DTOs
{
    public class VisitStatusDTO : IVisitStatus
    {
        public int VisitStatusID { get; set; }

        public string StatusName { get; set; }
    }
}
