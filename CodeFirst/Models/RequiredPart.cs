namespace CodeFirst1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequiredPart")]
    public partial class RequiredPart
    {
        public int RequiredPartID { get; set; }

        public int PartInStationID { get; set; }

        public int ProvidedServiceID { get; set; }

        public int Quantity { get; set; }

        public virtual PartInStation PartInStation { get; set; }

        public virtual ProvidedService ProvidedService { get; set; }
    }
}
