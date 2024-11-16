namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriveType")]
    public partial class DriveType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DriveType()
        {
            CarModels = new HashSet<CarModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DriveTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string DriveTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
