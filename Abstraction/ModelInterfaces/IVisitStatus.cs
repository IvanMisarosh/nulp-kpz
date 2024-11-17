using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.ModelInterfaces
{
    public interface IVisitStatus
    {
        int VisitStatusID { get; set; }

        string StatusName { get; set; }
    }
}
