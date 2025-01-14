namespace AutoTrack.Application.Models;

public class CreateCarModelDto
{
    public string ModelName { get; set; }

    public string CarType { get; set; }

    public string EngineType { get; set; }

    public string FuelType { get; set; }
    
    public string DriveType { get; set; }

    public int SeatingCapacity { get; set; }
}