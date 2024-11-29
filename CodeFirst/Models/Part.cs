namespace CodeFirst1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Part")]
    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            PartInStations = new HashSet<PartInStation>();
        }

        public int PartID { get; set; }

        public int? PartBrandID { get; set; }

        public int? PartTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string PartName { get; set; }

        public decimal? Weight { get; set; }

        [StringLength(100)]
        public string Dimensions { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int? QuantityPerPackage { get; set; }

        public decimal? PricePerPackage { get; set; }

        public virtual PartBrand PartBrand { get; set; }

        public virtual PartType PartType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartInStation> PartInStations { get; set; }
    }
}
