namespace CodeFirst1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProvidedService")]
    public partial class ProvidedService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProvidedService()
        {
            RequiredParts = new HashSet<RequiredPart>();
        }

        public int ProvidedServiceID { get; set; }

        public int? EmployeeID { get; set; }

        public int VisitServiceID { get; set; }

        public DateTime? ProvidedDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual VisitService VisitService { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequiredPart> RequiredParts { get; set; }
    }
}
