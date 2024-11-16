using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.ModelInterfaces
{
    public interface IVisit
    {
        int VisitID { get; set; }

        int VisitStatusID { get; set; }

        int CarID { get; set; }

        int EmployeeID { get; set; }

        int? PaymentStatusID { get; set; }

        DateTime? VisitDate { get; set; }

        DateTime? PlannedEndDate { get; set; }

        DateTime? ActualEndDate { get; set; }

        string Details { get; set; }

        int VisitNumber { get; set; }

        decimal? Price { get; set; }

        DateTime? PaymentDate { get; set; }
    }
}
