using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NHL_Dashboards.Models;

namespace NHL_Dashboards.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public new IActionResult NotFound()
    {
        Response.StatusCode = 404;
        return View("NotFound");
    }
}
