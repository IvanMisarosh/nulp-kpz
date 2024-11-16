using Abstraction.ModelInterfaces;

namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarModel")]
    public partial class CarModel : ICarModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarModel()
        {
            Cars = new HashSet<Car>();
        }

        public int CarModelID { get; set; }

        [Required]
        [StringLength(100)]
        public string ModelName { get; set; }

        [StringLength(35)]
        public string Dimensions { get; set; }

        public int? DriveTypeID { get; set; }

        public int? CarBrandID { get; set; }

        public int? SuspensionTypeID { get; set; }

        public int? TransmissionTypeID { get; set; }

        public int? EngineTypeID { get; set; }

        public int? BodyTypeID { get; set; }

        public virtual BodyType BodyType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars { get; set; }

        public virtual CarBrand CarBrand { get; set; }

        public virtual DriveType DriveType { get; set; }

        public virtual EngineType EngineType { get; set; }

        public virtual SuspensionType SuspensionType { get; set; }

        public virtual TransmissionType TransmissionType { get; set; }
    }
}
