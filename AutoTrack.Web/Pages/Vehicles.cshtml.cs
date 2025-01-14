using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models;
using AutoTrack.Application.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoTrack.Web.Pages;

public class Vehicles(IVehicleService vehicleService, ICarModelService carModelService) : PageModel
{
    [BindProperty]
    public CreateVehicleDto NewVehicle { get; set; }
    
    [BindProperty]
    public long Id { get; set; }
    public List<VehicleDto> CurrentVehicles { get; set; } = [];

    public static List<CarModelDto> models = []; 
    public SelectList CarModels { get; set; } = new SelectList(models, "Id", "ModelName");
    
    public async Task<IActionResult> OnPostCreate(CreateVehicleDto newVehicle)
    {
        await vehicleService.Create(newVehicle);
        return Redirect("/Vehicles");
    }

    public async Task<IActionResult> OnPostDelete(long id)
    {
        await vehicleService.Delete(id);
        return Redirect("/Vehicles");
    }

    public IActionResult OnPostEdit(long id)
    {
        return Redirect($"/Vehicle/Edit/{id}");
    }

    public async Task OnGet()
    {
        models = carModelService.GetAll().Result;
        CurrentVehicles = await vehicleService.GetAll();
    }

    public async Task<string> GetCarModelNameById(long id)
    {
         var carModel = await carModelService.GetById(id);
         return carModel.ModelName;
    }
}