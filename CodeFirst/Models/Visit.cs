namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visit")]
    public partial class Visit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visit()
        {
            VisitServices = new HashSet<VisitService>();
        }

        public int VisitID { get; set; }

        public int VisitStatusID { get; set; }

        public int CarID { get; set; }

        public int EmployeeID { get; set; }

        public int? PaymentStatusID { get; set; }

        public DateTime? VisitDate { get; set; }

        public DateTime? PlannedEndDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        [StringLength(500)]
        public string Details { get; set; }

        public int VisitNumber { get; set; }

        public decimal? Price { get; set; }

        public DateTime? PaymentDate { get; set; }

        public virtual Car Car { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual PaymentStatus PaymentStatu { get; set; }

        public virtual VisitStatus VisitStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitService> VisitServices { get; set; }
    }
}
