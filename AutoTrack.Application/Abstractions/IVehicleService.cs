using AutoTrack.Application.Models.Vehicle;
using AutoTrack.Domain.Entities;

namespace AutoTrack.Application.Abstractions;

public interface IVehicleService
{
    Task<VehicleDto> Create(CreateVehicleDto createVehicleDto);
    Task<VehicleDto> GetById(long id);
    Task<List<VehicleDto>> GetAll();
    Task<VehicleDto> Update(VehicleDto vehicleDto);
    Task<VehicleDto> Delete(long id);
}