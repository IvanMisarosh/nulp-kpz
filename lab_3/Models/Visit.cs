using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;


namespace Wpf.Models
{
    public class Visit : IVisit
    {
        public int VisitID { get; set; }

        public int VisitStatusID { get; set; }

        public int CarID { get; set; }

        public int EmployeeID { get; set; }

        public int? PaymentStatusID { get; set; }

        public DateTime? VisitDate { get; set; }

        public DateTime? PlannedEndDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        public string Details { get; set; }

        public int VisitNumber { get; set; }

        public decimal? Price { get; set; }

        public DateTime? PaymentDate { get; set; }

        public virtual Car Car { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual PaymentStatus PaymentStatus { get; set; }

        ////public virtual ICollection<VisitService> VisitServices { get; set; } 

        public virtual VisitStatus VisitStatus { get; set; }
    }
}
