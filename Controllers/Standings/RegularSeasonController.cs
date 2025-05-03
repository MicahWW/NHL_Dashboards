using Microsoft.AspNetCore.Mvc;

namespace NHL_Dashboards.Controllers.Standings;

public class RegularSeasonController(ILogger<RegularSeasonController> logger) : Controller
{
    private readonly ILogger<RegularSeasonController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Eastern()
    {
        ViewData["JsFileName"] = "regularSeason.js";
        ViewData["CssFileName"] = "regularSeason.css";
        ViewData["Title"] = "Eastern Conference Standings";
        ViewData["Conference"] = "Eastern";
        return View("Standings");
    }

    public IActionResult Western()
    {
        ViewData["JsFileName"] = "regularSeason.js";
        ViewData["CssFileName"] = "regularSeason.css";
        ViewData["Title"] = "Western Conference Standings";
        ViewData["Conference"] = "Western";
        return View("Standings");
    }
}