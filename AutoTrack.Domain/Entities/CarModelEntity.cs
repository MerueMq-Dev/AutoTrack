using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTrack.Domain.Entities;

public class CarModelEntity : BaseEntity
{
    public string ModelName { get; set; }

    public string CarType { get; set; }

    public string EngineType { get; set; }

    public string FuelType { get; set; }
    
    public string DriveType { get; set; }

    public int SeatingCapacity { get; set; }
    
    [InverseProperty(nameof(VehicleEntity.CarModel))]
    public ICollection<VehicleEntity> Vehicles { get; set; }
}