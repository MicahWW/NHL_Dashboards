using Microsoft.AspNetCore.Mvc;

namespace StaticApps.Controllers.Standings;

public class RegularSeasonStandingsController : Controller
{
    private readonly ILogger<RegularSeasonStandingsController> _logger;

    public RegularSeasonStandingsController(ILogger<RegularSeasonStandingsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Eastern()
    {
        ViewData["Conference"] = "Eastern";
        return View("standings");
    }

    public IActionResult Western()
    {
        ViewData["Conference"] = "Western";
        return View("standings");
    }
}