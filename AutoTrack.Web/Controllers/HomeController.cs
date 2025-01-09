using AutoTrack.Domain;
using AutoTrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AutoTrack.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AutoTrackDbContext context;

    public HomeController(ILogger<HomeController> logger, AutoTrackDbContext context)
    {
        _logger = logger;
        this.context = context;
        
        // this.context.Vehicles.Include(x => x.CarModelId)
    }


    public IActionResult Index()
    {
        
        return View();
    }

    public IActionResult Vehicles()
    {
        return View();
    }
    
    public IActionResult CarModels()
    {
        return View();
    }
}