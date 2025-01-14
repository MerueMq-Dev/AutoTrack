using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models;
using AutoTrack.Application.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoTrack.Web.Pages.Vehicle;

public class Edit(IVehicleService vehicleService, ICarModelService carModelService) : PageModel
{
    [BindProperty]
    public long Id { get; set; }
    
    [BindProperty]
    public VehicleDto CurrentVehicle { get; set; }
    
    public static List<CarModelDto> models = []; 
    public SelectList CarModels { get; set; } = new SelectList(models, "Id", "ModelName");
        
    public async Task OnGet(long? id)
    {
        if (id == null)
        {
            CurrentVehicle = null;
            return;
        }

        models = await carModelService.GetAll();
        Id = id.Value;
        CurrentVehicle = await vehicleService.GetById(Id);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        await vehicleService.Update(CurrentVehicle);
        return Redirect($"/Vehicles");
    }
}