namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EngineType")]
    public partial class EngineType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EngineType()
        {
            CarModels = new HashSet<CarModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EngineTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string EngineTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
