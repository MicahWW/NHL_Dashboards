using Microsoft.AspNetCore.Mvc;

namespace NHL_Dashboards.Controllers.Standings;

public class PlayoffsController(ILogger<RegularSeasonController> logger) : Controller
{
    private readonly ILogger<RegularSeasonController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Eastern()
    {
        ViewData["StaticFilesName"] = "playoffBrackets";
        ViewData["Title"] = "Eastern Conference Playoffs";
        ViewData["Conference"] = "Eastern";
        return View("Conference");
    }

    public IActionResult Western()
    {
        ViewData["StaticFilesName"] = "playoffBrackets";
        ViewData["Title"] = "Western Conference Playoffs";
        ViewData["Conference"] = "Western";
        return View("Conference");
    }
}