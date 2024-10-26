using System;
using System.Collections.Generic;

namespace lab_3.Models;

public partial class CarModel
{
    public int CarModelId { get; set; }

    public string ModelName { get; set; } = null!;

    public string? Dimensions { get; set; }

    public int? DriveTypeId { get; set; }

    public int? CarBrandId { get; set; }

    public int? SuspensionTypeId { get; set; }

    public int? TransmissionTypeId { get; set; }

    public int? EngineTypeId { get; set; }

    public int? BodyTypeId { get; set; }

    public virtual BodyType? BodyType { get; set; }

    public virtual CarBrand? CarBrand { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual DriveType? DriveType { get; set; }

    public virtual EngineType? EngineType { get; set; }

    public virtual SuspensionType? SuspensionType { get; set; }

    public virtual TransmissionType? TransmissionType { get; set; }
}
