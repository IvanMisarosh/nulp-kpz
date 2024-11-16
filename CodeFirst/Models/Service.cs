namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            VisitServices = new HashSet<VisitService>();
        }

        public int ServiceID { get; set; }

        public int? ServiceTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitService> VisitServices { get; set; }
    }
}
