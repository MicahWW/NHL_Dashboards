using Microsoft.AspNetCore.Mvc;
using NHL_Dashboards.Models;
using NSwag.Annotations;

namespace NHL_Dashboards.Controllers.Api;

[ApiController]
[Route("[controller]")]
public class TeamDetailsApiController(ILogger<TeamDetailsApiController> logger) : ControllerBase
{
    private readonly ILogger<TeamDetailsApiController> _logger = logger;

    [HttpGet]
    [OpenApiTag("TeamDetails")]
    [ProducesResponseType<TeamDetailsApiModel>(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var output = new TeamDetailsApiModel();
        return Ok(output);
    }

}