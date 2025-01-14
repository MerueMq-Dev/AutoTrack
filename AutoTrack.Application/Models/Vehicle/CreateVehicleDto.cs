namespace AutoTrack.Application.Models.Vehicle;

public class CreateVehicleDto
{
    public int YearOfManufacture { get; set; }
    
    public double Mileage { get; set; }
    
    public decimal Price { get; set; }
    
    public string Color { get; set; }
    
    public string VIN { get; set; }
    
    public bool WasInAccident { get; set; }
    
    public string TechnicalCondition { get; set; }
    
    public long CarModelId { get; set; }
}