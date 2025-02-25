using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StaticApps.Models;

namespace StaticApps.Controllers;

public class RegularSeasonStandingsController : Controller
{
    private readonly ILogger<RegularSeasonStandingsController> _logger;

    public RegularSeasonStandingsController(ILogger<RegularSeasonStandingsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}