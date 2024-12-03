using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Wpf.Models
{
    public class CarModel : ICarModel
    {
        public int CarModelID { get; set; }

        public string ModelName { get; set; }

        public string Dimensions { get; set; }

        public int? DriveTypeID { get; set; }

        public int? CarBrandID { get; set; }

        public int? SuspensionTypeID { get; set; }

        public int? TransmissionTypeID { get; set; }

        public int? EngineTypeID { get; set; }

        public int? BodyTypeID { get; set; }
    }
}
