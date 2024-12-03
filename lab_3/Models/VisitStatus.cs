using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Wpf.Models
{
    public class VisitStatus : IVisitStatus
    {
        public int VisitStatusID { get; set; }

        public string StatusName { get; set; }
    }
}
