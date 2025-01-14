namespace AutoTrack.Application.Models.Vehicle;

public class VehicleDto : CreateVehicleDto
{
    public long Id { get; set; }

    public CarModelDto CarModel { get; set; }
}