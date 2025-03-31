using Microsoft.AspNetCore.Mvc;

namespace NHL_Dashboards.Controllers.Standings;

public class RegularSeasonController : Controller
{
    private readonly ILogger<RegularSeasonController> _logger;

    public RegularSeasonController(ILogger<RegularSeasonController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Eastern()
    {
        ViewData["StaticFilesName"] = "regularSeason";
        ViewData["Title"] = "Eastern Conference Standings";
        ViewData["Conference"] = "Eastern";
        return View("Standings");
    }

    public IActionResult Western()
    {
        ViewData["StaticFilesName"] = "regularSeason";
        ViewData["Title"] = "Western Conference Standings";
        ViewData["Conference"] = "Western";
        return View("Standings");
    }
}