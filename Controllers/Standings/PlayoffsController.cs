using Microsoft.AspNetCore.Mvc;

namespace NHL_Dashboards.Controllers.Standings;

public class PlayoffsController(ILogger<RegularSeasonController> logger) : Controller
{
    private readonly ILogger<RegularSeasonController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    private void ConferenceSetup(string conferenceName)
    {
        ViewData["JsFileName"] = "playoffBrackets.js";
        ViewData["CssFileName"] = "conference.css";
        ViewData["Title"] = $"{conferenceName} Conference Playoffs";
        ViewData["Logo"] = $"/images/{conferenceName}ConferenceLogo.png";
    }

    public IActionResult EasternConference()
    {
        ConferenceSetup("Eastern");
        return View("Standings");
    }

    public IActionResult WesternConference()
    {
        ConferenceSetup("Western");
        return View("Standings");
    }

    public IActionResult ConferenceFinals()
    {
        ViewData["JsFileName"] = "playoffBrackets.js";
        ViewData["CssFileName"] = "conferenceFinal.css";
        ViewData["Title"] = "Conference Finals";
        ViewData["Logo"] = "/images/stanleyCup.png";

        return View("Standings");
    }

    public IActionResult StanleyCupFinal()
    {
        ViewData["JsFileName"] = "playoffBrackets.js";
        ViewData["CssFileName"] = "stanleyCupFinal.css";
        ViewData["Title"] = "Stanley Cup Finals";
        ViewData["Logo"] = "/images/stanleyCup.png";

        return View("Standings");
    }
}