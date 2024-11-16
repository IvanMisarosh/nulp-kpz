using System;
using System.Collections.Generic;
using Abstraction.ModelInterfaces;

namespace DbFirst.Models;

public partial class CarModel : ICarModel
{
    public int CarModelID { get; set; }

    public string ModelName { get; set; } = null!;

    public string? Dimensions { get; set; }

    public int? DriveTypeID { get; set; }

    public int? CarBrandID { get; set; }

    public int? SuspensionTypeID { get; set; }

    public int? TransmissionTypeID { get; set; }

    public int? EngineTypeID { get; set; }

    public int? BodyTypeID { get; set; }

    public virtual BodyType? BodyType { get; set; }

    public virtual CarBrand? CarBrand { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual DriveType? DriveType { get; set; }

    public virtual EngineType? EngineType { get; set; }

    public virtual SuspensionType? SuspensionType { get; set; }

    public virtual TransmissionType? TransmissionType { get; set; }
}
