using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using NHL_Dashboards.Models;
using NHL_Dashboards.Services;

namespace NHL_Dashboards.Controllers.Api.Standings;

[ApiController]
[Route("[controller]")]
public class RegularSeasonApiController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<RegularSeasonApiController> _logger;

    public RegularSeasonApiController(ILogger<RegularSeasonApiController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }


    /// <summary>
    /// Gets the Regular Season data from the NHL
    /// </summary>
    /// <param name="date">
    /// If you want to get the standings at a particular date list it here in YYYY-MM-DD format. Leaving this blank
    /// will get the latest date posted by the NHL.
    /// </param>
    /// <returns>The NHL teams arranged into the RegularSeasonStandingsApiModel</returns>
    [HttpGet]
    [OpenApiTag("Standings")]
    [ProducesResponseType<RegularSeasonStandingsApiModel>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromQuery] string date = "")
    {
        var httpClient = _httpClientFactory.CreateClient("NhlApi");
        NhlRegularSeasonStandings Standings;

        try
        {
            Standings = await NhlApi.GetRegularSeasonStandingsAsync(httpClient, date);
        }
        catch (Exception ex)
        {
            return Problem
            (
                title: "Getting Standings data from NHL",
                detail: ex.Message,
                statusCode: 500
            );
        }
        var output = new RegularSeasonStandingsApiModel();

        // iterate through standings and assign to the appropriate position
        foreach (var standing in Standings.Standings)
        {
            var teamData = new RegularSeasonStandingsApiModel.TeamData(standing);

            switch (standing)
            {
                case { ConferenceName: "Western", WildcardSequence: 1 }:
                    output.WesternWildcard1 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 2 }:
                    output.WesternWildcard2 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 3 }:
                    output.WesternWildcard3 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 4 }:
                    output.WesternWildcard4 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 5 }:
                    output.WesternWildcard5 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 6 }:
                    output.WesternWildcard6 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 7 }:
                    output.WesternWildcard7 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 8 }:
                    output.WesternWildcard8 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 9 }:
                    output.WesternWildcard9 = teamData;
                    break;
                case { ConferenceName: "Western", WildcardSequence: 10 }:
                    output.WesternWildcard10 = teamData;
                    break;
                case { ConferenceName: "Western", DivisionSequence: 1, DivisionName: "Central" }:
                    output.Central1 = teamData;
                    break;
                case { ConferenceName: "Western", DivisionSequence: 2, DivisionName: "Central" }:
                    output.Central2 = teamData;
                    break;
                case { ConferenceName: "Western", DivisionSequence: 3, DivisionName: "Central" }:
                    output.Central3 = teamData;
                    break;
                case { ConferenceName: "Western", DivisionSequence: 1, DivisionName: "Pacific" }:
                    output.Pacific1 = teamData;
                    break;
                case { ConferenceName: "Western", DivisionSequence: 2, DivisionName: "Pacific" }:
                    output.Pacific2 = teamData;
                    break;
                case { ConferenceName: "Western", DivisionSequence: 3, DivisionName: "Pacific" }:
                    output.Pacific3 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 1 }:
                    output.EasternWildcard1 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 2 }:
                    output.EasternWildcard2 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 3 }:
                    output.EasternWildcard3 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 4 }:
                    output.EasternWildcard4 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 5 }:
                    output.EasternWildcard5 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 6 }:
                    output.EasternWildcard6 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 7 }:
                    output.EasternWildcard7 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 8 }:
                    output.EasternWildcard8 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 9 }:
                    output.EasternWildcard9 = teamData;
                    break;
                case { ConferenceName: "Eastern", WildcardSequence: 10 }:
                    output.EasternWildcard10 = teamData;
                    break;
                case { ConferenceName: "Eastern", DivisionSequence: 1, DivisionName: "Metropolitan" }:
                    output.Metropolitan1 = teamData;
                    break;
                case { ConferenceName: "Eastern", DivisionSequence: 2, DivisionName: "Metropolitan" }:
                    output.Metropolitan2 = teamData;
                    break;
                case { ConferenceName: "Eastern", DivisionSequence: 3, DivisionName: "Metropolitan" }:
                    output.Metropolitan3 = teamData;
                    break;
                case { ConferenceName: "Eastern", DivisionSequence: 1, DivisionName: "Atlantic" }:
                    output.Atlantic1 = teamData;
                    break;
                case { ConferenceName: "Eastern", DivisionSequence: 2, DivisionName: "Atlantic" }:
                    output.Atlantic2 = teamData;
                    break;
                case { ConferenceName: "Eastern", DivisionSequence: 3, DivisionName: "Atlantic" }:
                    output.Atlantic3 = teamData;
                    break;
            }
        }

        return Ok(output);
    }
}