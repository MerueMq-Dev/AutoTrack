using Microsoft.AspNetCore.Mvc;


namespace AutoTrack.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AutoTrack()
    {
        return View();
    }
    
}