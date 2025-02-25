using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaticApps.Models;

namespace StaticApps.Controllers;

[ApiController]
[Route("api/standings/regular")]
public class RegularSeasonStandingsApiController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<RegularSeasonStandingsApiController> _logger;

    public RegularSeasonStandingsApiController(ILogger<RegularSeasonStandingsApiController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet(Name = "foo")]
    public async Task<RegularSeasonStandingsApiModel> Get()
    {
        var httpClient = _httpClientFactory.CreateClient("NhlApi");
        string standingsEnd = string.Empty;
        var output = new RegularSeasonStandingsApiModel();

        using (var response = await httpClient.GetAsync("v1/standings-season"))
        {
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                var json = JsonSerializer.Deserialize<JsonNode>(contentStream);
                if (json != null && json["seasons"] != null)
                {
                    int last = ((JsonArray)json!["seasons"]!).Count - 1;
                    standingsEnd = (string?)(json!["seasons"]![last]!["standingsEnd"]) ?? string.Empty;
                }
            }
        }

        // TODO: Error if still empty string on standingsEnd

        using (var response = await httpClient.GetAsync($"v1/standings/{standingsEnd}"))
        {
            if(response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                var json = JsonSerializer.Deserialize<JsonNode>(contentStream);
                if (json != null && json["standings"] != null)
                {
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
                }
            }
        }

        return output;
    }
}