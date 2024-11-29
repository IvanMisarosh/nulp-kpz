namespace CodeFirst1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartInStation")]
    public partial class PartInStation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartInStation()
        {
            RequiredParts = new HashSet<RequiredPart>();
        }

        public int PartInStationID { get; set; }

        public int StationID { get; set; }

        public int PartID { get; set; }

        public int? Quantity { get; set; }

        public virtual Part Part { get; set; }

        public virtual Station Station { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequiredPart> RequiredParts { get; set; }
    }
}
