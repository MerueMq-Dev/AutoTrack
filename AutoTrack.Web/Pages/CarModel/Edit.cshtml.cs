using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoTrack.Web.Pages.CarModel;

public class Edit(ICarModelService carModelService) : PageModel
{
    [BindProperty]
    public long Id { get; set; }
    
    [BindProperty]
    public CarModelDto CurrentCarModel { get; set; }
    
    public async Task OnGet(long? id)
    {
        if (id == null)
        {
            CurrentCarModel = null;
            return;
        }
        Id = id.Value;
        CurrentCarModel = await carModelService.GetById(Id);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        await carModelService.Update(CurrentCarModel);
        return Redirect("/CarModels");
    }
}