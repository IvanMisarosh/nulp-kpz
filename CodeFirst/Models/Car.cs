namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            Visits = new HashSet<Visit>();
        }

        public int CarID { get; set; }

        public int CustomerID { get; set; }

        public int CarModelID { get; set; }

        public int ColorID { get; set; }

        public int? ManufactureYear { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        [StringLength(17)]
        public string VIN { get; set; }

        public int? Mileage { get; set; }

        public virtual CarModel CarModel { get; set; }

        public virtual Color Color { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
