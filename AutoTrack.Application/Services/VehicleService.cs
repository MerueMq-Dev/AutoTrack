using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models;
using AutoTrack.Application.Models.Vehicle;
using AutoTrack.Domain;
using AutoTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutoTrack.Application.Services;

public class VehicleService(AutoTrackDbContext context, ICarModelService carModelService) : IVehicleService
{
    public async Task<VehicleDto> Create(CreateVehicleDto createVehicleDto)
    {
        VehicleEntity vehicleEntity = new VehicleEntity()
        {
            YearOfManufacture = createVehicleDto.YearOfManufacture,
            Color = createVehicleDto.Color,
            Price = createVehicleDto.Price,
            Mileage = createVehicleDto.Mileage,
            VIN = createVehicleDto.VIN,
            WasInAccident = createVehicleDto.WasInAccident,
            TechnicalCondition = createVehicleDto.TechnicalCondition,
            CarModelId = createVehicleDto.CarModelId
        };

        EntityEntry<VehicleEntity> entity = context.Vehicles.Add(vehicleEntity);
        VehicleEntity savedEntity = entity.Entity;
        await context.SaveChangesAsync();
        
        return new VehicleDto()
        {
            Id = savedEntity.Id,
            YearOfManufacture = savedEntity.YearOfManufacture,
            Color = savedEntity.Color,
            Price = savedEntity.Price,
            Mileage = savedEntity.Mileage,
            VIN = savedEntity.VIN,
            WasInAccident = savedEntity.WasInAccident,
            TechnicalCondition = savedEntity.TechnicalCondition,
            CarModelId = savedEntity.CarModelId,
        };
    }

    public async Task<VehicleDto> GetById(long id)
    {
        VehicleEntity? vehicleEntity = await context.Vehicles.Where(item => item.DeletedAt == null)
            .FirstOrDefaultAsync(item => item.Id == id);
        if (vehicleEntity is null)
            return null;

        return new VehicleDto()
        {
            Id = vehicleEntity.Id,
            YearOfManufacture = vehicleEntity.YearOfManufacture,
            Color = vehicleEntity.Color,
            Price = vehicleEntity.Price,
            Mileage = vehicleEntity.Mileage,
            VIN = vehicleEntity.VIN,
            WasInAccident = vehicleEntity.WasInAccident,
            TechnicalCondition = vehicleEntity.TechnicalCondition,
            CarModelId = vehicleEntity.CarModelId
        };
    }

    public Task<List<VehicleDto>> GetAll()
    {
        return Task.FromResult(
            context.Vehicles
                .Where(item => item.DeletedAt == null)
                .Select(item => new VehicleDto()
                {
                    Id = item.Id,
                    YearOfManufacture = item.YearOfManufacture,
                    Color = item.Color,
                    Price = item.Price,
                    Mileage = item.Mileage,
                    VIN = item.VIN,
                    WasInAccident = item.WasInAccident,
                    TechnicalCondition = item.TechnicalCondition,
                    CarModelId = item.CarModelId,
                }).ToList()
        );
    }

    public async Task<VehicleDto> Update(VehicleDto vehicleDto)
    {
        VehicleEntity? vehicleEntity = await context.Vehicles
            .FirstOrDefaultAsync(item => item.Id == vehicleDto.Id && item.DeletedAt == null);

        if (vehicleEntity is null)
            return null;

        vehicleEntity.YearOfManufacture = vehicleDto.YearOfManufacture;
        vehicleEntity.Color = vehicleDto.Color;
        vehicleEntity.Price = vehicleDto.Price;
        vehicleEntity.Mileage = vehicleDto.Mileage;
        vehicleEntity.VIN = vehicleDto.VIN;
        vehicleEntity.WasInAccident = vehicleDto.WasInAccident;
        vehicleEntity.TechnicalCondition = vehicleDto.TechnicalCondition;
        vehicleEntity.CarModelId = vehicleDto.CarModelId;

        await context.SaveChangesAsync();

        return vehicleDto;
    }

    public async Task<VehicleDto> Delete(long id)
    {
        VehicleEntity? vehicleEntity = await context.Vehicles
            .Include(item => item.CarModel)
            .FirstOrDefaultAsync(item => item.Id == id && item.DeletedAt == null);

        if (vehicleEntity is null)
            return null;


        vehicleEntity.DeletedAt = DateTime.UtcNow;
        await context.SaveChangesAsync();

        return new VehicleDto()
        {
            Id = vehicleEntity.Id,
            YearOfManufacture = vehicleEntity.YearOfManufacture,
            Color = vehicleEntity.Color,
            Price = vehicleEntity.Price,
            Mileage = vehicleEntity.Mileage,
            VIN = vehicleEntity.VIN,
            WasInAccident = vehicleEntity.WasInAccident,
            TechnicalCondition = vehicleEntity.TechnicalCondition,
            CarModelId = vehicleEntity.CarModelId
        };
    }
}