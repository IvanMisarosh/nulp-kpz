using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.ModelInterfaces
{
    public interface ICar
    {
        int CarID { get; set; }

        int CustomerID { get; set; }

        int CarModelID { get; set; }

        int ColorID { get; set; }

        int? ManufactureYear { get; set; }

        string Note { get; set; }

        string VIN { get; set; }

        int? Mileage { get; set; }

        //virtual ICarModel CarModel { get; set; }

        //public virtual ICollection<IVisit> Visits { get; set; } 
    }
}
