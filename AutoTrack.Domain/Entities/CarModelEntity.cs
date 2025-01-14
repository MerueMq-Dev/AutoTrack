using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTrack.Domain.Entities;

public class CarModelEntity : BaseEntity
{
    public required string ModelName { get; set; }

    public required  string CarType { get; set; }

    public required  string EngineType { get; set; }

    public required  string FuelType { get; set; }
    
    public required  string DriveType { get; set; }

    public required  int SeatingCapacity { get; set; }
    
    [InverseProperty(nameof(VehicleEntity.CarModel))]
    public ICollection<VehicleEntity> Vehicles { get; set; }
}