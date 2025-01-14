using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models;
using AutoTrack.Application.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrack.Web.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarModelController(ICarModelService carModelService) : ControllerBase
{

    [HttpGet("GetAllCarModels")]
    public async Task<IEnumerable<CarModelDto>> GetAllCarModels()
    {
        return await carModelService.GetAll();
    }
}