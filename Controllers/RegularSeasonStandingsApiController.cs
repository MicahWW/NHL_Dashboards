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
                    var standings = JsonSerializer.Deserialize<List<NhlRegularSeasonStandings>>(json["standings"], new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (standings == null)
                    {
                        return Problem
                        (
                            detail: "Deserializing the standings failed",
                            statusCode: 500,
                            title: "Deserialize standings"
                        );
                    }

                    // iterate through standings and assign to the appropriate position
                    foreach (var standing in standings)
                    {
                        var teamData = new RegularSeasonStandingsApiModel.TeamData
                        {
                            Points = standing.Points,
                            GamesPlayed = standing.GamesPlayed,
                            Name = standing.TeamCommonName,
                            Abbr = standing.TeamAbbrev
                        };

                        switch (standing)
                        {
                            case { ConferenceName: "Western", WildcardSequence: 1 }:
                                output.Wildcard1 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 2 }:
                                output.Wildcard2 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 3 }:
                                output.Wildcard3 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 4 }:
                                output.Wildcard4 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 5 }:
                                output.Wildcard5 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 6 }:
                                output.Wildcard6 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 7 }:
                                output.Wildcard7 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 8 }:
                                output.Wildcard8 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 9 }:
                                output.Wildcard9 = teamData;
                                break;
                            case { ConferenceName: "Western", WildcardSequence: 10 }:
                                output.Wildcard10 = teamData;
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