using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrack.Web.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController(IVehicleService vehicleService) : ControllerBase
{
    [HttpGet("GetAllVehicles")]
    public async Task<IEnumerable<VehicleDto>> GetAllVehicles()
    {
        return await vehicleService.GetAll();
    }
}