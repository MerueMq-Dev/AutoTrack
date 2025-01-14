using AutoTrack.Application.Models;

namespace AutoTrack.Application.Abstractions;

public interface ICarModelService
{
  Task<CarModelDto> Create(CreateCarModelDto carModel);
  Task<CarModelDto> GetById(long id);
  Task<List<CarModelDto>> GetAll();
  Task<CarModelDto> Update(CarModelDto carModel);
  Task<CarModelDto> Delete(long id);
}