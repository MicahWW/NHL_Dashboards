using Microsoft.AspNetCore.Mvc;

namespace NHL_Dashboards.Controllers;

public class SeatingController(ILogger<SeatingController> logger) : Controller
{
    private readonly ILogger<SeatingController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
}