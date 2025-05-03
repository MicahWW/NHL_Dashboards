using System.Text.Json;
using NHL_Dashboards.Models;

namespace NHL_Dashboards.Services;

public class NhlApi(IHttpClientFactory httpClientFactory)
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("NhlApi");

    /// <summary>
    /// Grabs data from the NHL standings-season endpoint.
    /// </summary>
    /// <returns>Formatted data from the standings-season endpoint.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<NhlStandingsSeason> GetStandingsSeasonAsync()
    {
        using var response = await _httpClient.GetAsync("v1/standings-season");
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
    /// Validates if the date passed in is within the range of any of the seasons in the standings-season endpoint.
    /// </summary>
    /// <param name="date">A date to be checked if within a season.</param>
    /// <returns>Returns true if the date is within a season and false if otherwise.</returns>
    private async Task<bool> IsValidStandingSeasonDateAsync(string date)
    {
        var StandingsSeason = await GetStandingsSeasonAsync();

        foreach (var season in StandingsSeason.Seasons)
        {
            var start = DateTime.ParseExact(season.StandingsStart, "yyyy-MM-dd", null);
            var end = DateTime.ParseExact(season.StandingsEnd, "yyyy-MM-dd", null);
            var userDate = DateTime.ParseExact(date, "yyyy-MM-dd", null);

            if (userDate >= start && userDate <= end)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Grabs data from the NHL standings endpoint. Specifying a date will return the standings for that date, if no
    /// date is specified it will return the standings for the latest date possible.
    /// </summary>
    /// <param name="date">What date to get the standings from, if not passed grab the latest date possible.</param>
    /// <returns>Formatted data from the standings endpoint at the specified date.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<NhlRegularSeasonStandingsModel> GetRegularSeasonStandingsAsync(string date = "")
    {
        if (string.IsNullOrEmpty(date))
        {
            // The NHL API will redirect to the latest date if no date is passed in the URL
            date = "now";
        }
        else
        {
            // Validate the date format to be yyyy-MM-dd
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _))
                throw new Exception("The date passed in was not in the correct format. Please use yyyy-MM-dd.");

            if (!await IsValidStandingSeasonDateAsync(date))
                throw new Exception("The date given was not in the range of any season. Please use a date between the start and end of a season.");
        }

        using var response = await _httpClient.GetAsync($"v1/standings/{date}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Received a unsuccessful status code when retrieving the standings data.");

        using var contentStream = await response.Content.ReadAsStreamAsync();
        var json = JsonSerializer.Deserialize<NhlRegularSeasonStandingsModel>(contentStream, _options);

        if (json != null)
            return json;
        else
            throw new Exception("After deserializing standings data the data was null.");
    }

    /// <summary>
    /// Grabs data from the NHL playoff bracket endpoint. Specifying a year will return the playoff bracket for that
    /// year, if no year is specified it will return the playoff bracket for the current year.
    /// </summary>
    /// <param name="year">What playoff year to get the playoff bracket from.</param>
    /// <returns>Formatted data from the playoff bracket endpoint at the requested year.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<NhlPlayoffBracketModel> GetPlayoffBracketAsync(string year = "")
    {
        if (string.IsNullOrEmpty(year))
            year = DateTime.Now.Year.ToString();

        using var response = await _httpClient.GetAsync($"v1/playoff-bracket/{year}");

        if (!response.IsSuccessStatusCode)
            throw new Exception("Received a unsuccessful status code when retrieving the playoff bracket data.");

        using var contentStream = await response.Content.ReadAsStreamAsync();
        var json = JsonSerializer.Deserialize<NhlPlayoffBracketModel>(contentStream, _options);

        if (json != null)
            return json;
        else
            throw new Exception("After deserializing playoff bracket data the data was null.");
    }
}