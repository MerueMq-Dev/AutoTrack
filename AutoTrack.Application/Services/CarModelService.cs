using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models;
using AutoTrack.Domain;
using AutoTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutoTrack.Application.Services;

public class CarModelService(AutoTrackDbContext context) : ICarModelService
{
    public async Task<CarModelDto> Create(CreateCarModelDto carModel)
    {
        CarModelEntity carModelEntity = new CarModelEntity
        {
            ModelName = carModel.ModelName,
            FuelType = carModel.FuelType,
            EngineType = carModel.EngineType,
            CarType = carModel.CarType,
            DriveType = carModel.DriveType,
            SeatingCapacity = carModel.SeatingCapacity,
        };

        EntityEntry<CarModelEntity> model = await context.CarModels.AddAsync(carModelEntity);
        await context.SaveChangesAsync();
        CarModelEntity entity = model.Entity;

        return new CarModelDto
        {
            Id = entity.Id,
            ModelName = entity.ModelName,
            FuelType = entity.FuelType,
            EngineType = entity.EngineType,
            CarType = entity.CarType,
            DriveType = entity.DriveType,
            SeatingCapacity = entity.SeatingCapacity
        };
    }

    public async Task<CarModelDto> GetById(long id)
    {
        CarModelEntity? carModel = await context.CarModels
            .Where(item => item.DeletedAt == null)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (carModel == null)
            return null;

        return new CarModelDto
        {
            Id = carModel.Id,
            ModelName = carModel.ModelName,
            FuelType = carModel.FuelType,
            EngineType = carModel.EngineType,
            CarType = carModel.CarType,
            DriveType = carModel.DriveType,
            SeatingCapacity = carModel.SeatingCapacity
        };
    }

    public Task<List<CarModelDto>> GetAll()
    {
        return Task.FromResult(
            context.CarModels
                .Where(item => item.DeletedAt == null)
                .Select(item => new CarModelDto
                {
                    Id = item.Id,
                    ModelName = item.ModelName,
                    FuelType = item.FuelType,
                    EngineType = item.EngineType,
                    CarType = item.CarType,
                    DriveType = item.DriveType,
                    SeatingCapacity = item.SeatingCapacity
                }).ToList()
        );
    }

    public async Task<CarModelDto> Update(CarModelDto carModelDto)
    {
        CarModelEntity? carModel = await context.CarModels
            .Where(item => item.DeletedAt == null)
            .FirstOrDefaultAsync(item => item.Id == carModelDto.Id);

        if (carModel == null)
            return null;

        carModel.ModelName = carModelDto.ModelName;
        carModel.CarType = carModelDto.CarType;
        carModel.FuelType = carModelDto.FuelType;
        carModel.EngineType = carModelDto.EngineType;
        carModel.DriveType = carModelDto.DriveType;
        carModel.SeatingCapacity = carModelDto.SeatingCapacity;

        await context.SaveChangesAsync();

        return carModelDto;
    }

    public async Task<CarModelDto> Delete(long id)
    {
        CarModelEntity? carModel = await context.CarModels
            .FirstOrDefaultAsync(item => item.Id == id && item.DeletedAt == null);
        
        if (carModel is null)
            return null;

        carModel.DeletedAt = DateTime.UtcNow;
        await context.SaveChangesAsync();

            return new CarModelDto
            {
                Id = carModel.Id,
                ModelName = carModel.ModelName,
                FuelType = carModel.FuelType,
                EngineType = carModel.EngineType,
                CarType = carModel.CarType,
                DriveType = carModel.DriveType,
                SeatingCapacity = carModel.SeatingCapacity
            };
    }
}