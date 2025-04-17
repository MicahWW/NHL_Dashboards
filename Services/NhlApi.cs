using System.Text.Json;
using NHL_Dashboards.Models;

namespace NHL_Dashboards.Services;

public static class NhlApi
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };


    /// <summary>
    /// Grabs data from the NHL standings-season endpoint
    /// </summary>
    /// <param name="httpClient">A httpClient setup with the NHL API base URL</param>
    /// <returns>Formatted data from the standings-season endpoint</returns>
    /// <exception cref="Exception"></exception>
    public static async Task<NhlStandingsSeason> GetStandingsSeasonAsync(HttpClient httpClient)
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

    /// <summary>
    /// Grabs data from the NHL standings endpoint.
    /// </summary>
    /// <param name="httpClient">A httpClient setup with the NHL API base URL</param>
    /// <param name="date">What date to get the standings from, if not passed grab the latest date possible</param>
    /// <returns>Formatted ata from the standings endpoint at the specified date</returns>
    /// <exception cref="Exception"></exception>
    public static async Task<NhlRegularSeasonStandingsModel> GetRegularSeasonStandingsAsync(HttpClient httpClient, string date = "")
    {
        if (string.IsNullOrEmpty(date))
        {
            var StandingsSeason = await GetStandingsSeasonAsync(httpClient);
            date = StandingsSeason!.Seasons[^1].StandingsEnd;
        }
        else {
            // TODO: Validate the users date input as a valid date format and it is within a range given by the NHL
        }

        using var response = await httpClient.GetAsync($"v1/standings/{date}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Received a unsuccessful status code when retrieving the standings data.");

        using var contentStream = await response.Content.ReadAsStreamAsync();
        var json = JsonSerializer.Deserialize<NhlRegularSeasonStandingsModel>(contentStream, _options);

        if (json != null)
            return json;
        else
            throw new Exception("After deserializing standings data the data was null.");
    }
}