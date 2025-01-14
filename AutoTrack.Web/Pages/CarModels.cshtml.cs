using AutoTrack.Application.Abstractions;
using AutoTrack.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoTrack.Web.Pages;

public class CarModels(ICarModelService carModelService) : PageModel
{
    [BindProperty] public CreateCarModelDto NewCarModel { get; set; }
    
    [BindProperty] public long Id { get; set; }
    
    public List<CarModelDto> Models { get; private set; } = new();

    public async Task OnGet()
    {
        Models = await carModelService.GetAll();
    }

    public async Task<IActionResult> OnPostCreate(CreateCarModelDto newCarModel)
    {
        await carModelService.Create(newCarModel);
        return Redirect("/CarModels");
    }
    
    public async Task<IActionResult> OnPostDelete(long id)
    {
        await carModelService.Delete(id);
        return Redirect("/CarModels");
    }
    
    public IActionResult OnPostEdit(long id)
    {
        return Redirect($"/CarModel/Edit/{id}");
    }
}