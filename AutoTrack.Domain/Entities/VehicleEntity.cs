namespace AutoTrack.Domain.Entities;

public class VehicleEntity : BaseEntity
{
    public int YearOfManufacture { get; set; } // Год выпуска
    public double Mileage { get; set; } // Пробег в километрах
    public decimal Price { get; set; } // Стоимость автомобиля
    public string Color { get; set; } // Цвет автомобиля
    public string VIN { get; set; } // Уникальный идентификатор (номер VIN)
    public bool WasInAccident { get; set; } // Участвовала в аварии
    public string TechnicalCondition { get; set; } // Оценка технического состояния автомобиля (например, "отличное", "хорошее", "требует ремонта")   
}