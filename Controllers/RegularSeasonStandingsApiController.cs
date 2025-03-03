using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using StaticApps.Models;

namespace StaticApps.Controllers;

[ApiController]
[Route("[controller]")]
public class RegularSeasonStandingsApiController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<RegularSeasonStandingsApiController> _logger;

    public RegularSeasonStandingsApiController(ILogger<RegularSeasonStandingsApiController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    [ProducesResponseType<RegularSeasonStandingsApiModel>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var httpClient = _httpClientFactory.CreateClient("NhlApi");
        string standingsEnd = string.Empty;

        // gets the latest allowed value for standings requests
        using (var response = await httpClient.GetAsync("v1/standings-season"))
        {
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                var json = JsonSerializer.Deserialize<JsonNode>(contentStream);
                if (json != null && json["seasons"] != null && json["seasons"] is JsonArray)
                {
                    int last = ((JsonArray)json["seasons"]!).Count - 1;
                    standingsEnd = (string?)json!["seasons"]![last]!["standingsEnd"] ?? string.Empty;
                    if (string.IsNullOrEmpty(standingsEnd))
                    {
                        return Problem(
                            detail: "The value on standingsEnd was empty or non existent.",
                            statusCode: 500,
                            title: "Reading standingsEnd"
                        );
                    }
                }
                else
                {
                    return Problem(
                        detail: "The results from standings-season was empty or non existent.",
                        statusCode: 500,
                        title: "Reading standings-season"
                    );
                }
            }
            else
            {
                return Problem(
                    detail: $"Invalid status code when retrieving standings-season, code received: {(int)response.StatusCode}",
                    statusCode: 500,
                    title: "Requesting standings-season"
                );
            }
        }

        // gets the latest data from the standings
        var Path = $"v1/standings/{standingsEnd}";
        using (var response = await httpClient.GetAsync(Path))
        {
            if(response.IsSuccessStatusCode)
            {

                using var contentStream = await response.Content.ReadAsStreamAsync();
                var json = JsonSerializer.Deserialize<JsonNode>(contentStream);
                if (json != null && json["standings"] != null && json["standings"] is JsonArray)
                {
                    var output = new RegularSeasonStandingsApiModel();

                    // iterate through standings and assign to the appropriate position
                    foreach (var item in (JsonArray)json["standings"]!)
                    {
                        if (item != null) 
                        {
                            var teamData = new RegularSeasonStandingsApiModel.TeamData
                            {
                                Points = (int)item["points"]!,
                                GamesPlayed = (int)item["gamesPlayed"]!,
                                Name = (string?)item["teamCommonName"]!["default"],
                                Abbr = (string?)item["teamAbbrev"]!["default"]
                            };


                            if ((string?)item["conferenceName"] == "Western")
                            {
                                if ((int?)item["wildcardSequence"] > 0)
                                {
                                    switch ((int)item["wildcardSequence"]!)
                                    {
                                        case 1:
                                            output.Wildcard1 = teamData;
                                            break;
                                        case 2:
                                            output.Wildcard2 = teamData;
                                            break;
                                        case 3:
                                            output.Wildcard3 = teamData;
                                            break;
                                        case 4:
                                            output.Wildcard4 = teamData;
                                            break;
                                        case 5:
                                            output.Wildcard5 = teamData;
                                            break;
                                        case 6:
                                            output.Wildcard6 = teamData;
                                            break;
                                        case 7:
                                            output.Wildcard7 = teamData;
                                            break;
                                        case 8:
                                            output.Wildcard8 = teamData;
                                            break;
                                        case 9:
                                            output.Wildcard9 = teamData;
                                            break;
                                        case 10:
                                            output.Wildcard10 = teamData;
                                            break;
                                    }
                                }
                                else if ((string?)item["divisionName"] == "Central")
                                {
                                    switch ((int?)item["divisionSequence"])
                                    {
                                        case 1:
                                            output.Central1 = teamData;
                                            break;
                                        case 2:
                                            output.Central2 = teamData;
                                            break;
                                        case 3:
                                            output.Central3 = teamData;
                                            break;
                                    }
                                }
                                else if ((string?)item["divisionName"] == "Pacific")
                                {
                                    switch ((int?)item["divisionSequence"])
                                    {
                                        case 1:
                                            output.Pacific1 = teamData;
                                            break;
                                        case 2:
                                            output.Pacific2 = teamData;
                                            break;
                                        case 3:
                                            output.Pacific3 = teamData;
                                            break;
                                    }
                                }
                                
                            }
                        }
                    }
                    return Ok(output);
                }
                else
                {
                    return Problem(
                        detail: "The standings result has empty",
                        statusCode: 500,
                        title: "Reading standings"
                    );
                }
            }
            else
            {
                return Problem(
                    detail: $"Invalid status code when retrieving standings, code received: {(int)response.StatusCode}; path called {Path}",
                    statusCode: 500,
                    title: "Requesting standings"
                );
            }
        }
    }
}