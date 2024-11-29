namespace CodeFirst1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitService")]
    public partial class VisitService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisitService()
        {
            ProvidedServices = new HashSet<ProvidedService>();
        }

        public int VisitServiceID { get; set; }

        public int VisitID { get; set; }

        public int ServiceID { get; set; }

        public int Quantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProvidedService> ProvidedServices { get; set; }

        public virtual Service Service { get; set; }

        public virtual Visit Visit { get; set; }
    }
}
