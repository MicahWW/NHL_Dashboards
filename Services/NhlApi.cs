using System.Text.Json;
using NHL_Dashboards.Models;

namespace NHL_Dashboards.Services;

public static class NhlApi
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };


    public static async Task<NhlStandingsSeason> GetStandingsSeason(HttpClient httpClient)
    {
        using var response = await httpClient.GetAsync("v1/standings-season");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Received a unsuccessful status code when retrieving the standings-season data.");

        using var contentStream = await response.Content.ReadAsStreamAsync();
        var json = JsonSerializer.Deserialize<NhlStandingsSeason>(contentStream, _options);

        if (json != null)
            return json;
        else
            throw new Exception("After deserializing standings-season data the data was null.");
    }

    // passing a date is not required, if it is not passed then it will grab the latest date possible
    public static async Task<NhlRegularSeasonStandings> GetRegularSeasonStandings(HttpClient httpClient, string date = "")
    {
        if (string.IsNullOrEmpty(date))
        {
            var StandingsSeason = await GetStandingsSeason(httpClient);
            date = StandingsSeason!.Seasons[^1].StandingsEnd;
        }
        else {
            // TODO: Validate the users date input as a valid date format and it is within a range given by the NHL
        }

        using var response = await httpClient.GetAsync($"v1/standings/{date}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Received a unsuccessful status code when retrieving the standings data.");

        using var contentStream = await response.Content.ReadAsStreamAsync();
        var json = JsonSerializer.Deserialize<NhlRegularSeasonStandings>(contentStream, _options);

        if (json != null)
            return json;
        else
            throw new Exception("After deserializing standings data the data was null.");
    }
}