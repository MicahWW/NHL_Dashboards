using System.Text.Json.Serialization;

namespace NHL_Dashboards.Models;

public class NhlRegularSeasonStandings
{
    public class TeamCommonNameData
    {
        [JsonPropertyName("default")]
        public required string Name { get; set; }
    }

    public class TeamAbbrevData
    {
        [JsonPropertyName("default")]
        public required string Name { get; set; }
    }

    public int Points { get; set; }
    public int GamesPlayed { get; set; }
    // public required TeamCommonNameData TeamCommonName { get; set; }
    [JsonPropertyName("teamCommonName")]
    public required TeamCommonNameData _teamCommonNameData { get; set; }
    [JsonIgnore]
    public string TeamCommonName { get { return _teamCommonNameData.Name; } }
    [JsonPropertyName("teamAbbrev")]
    public required TeamAbbrevData _teamAbbrevData { get; set; }
    [JsonIgnore]
    public string TeamAbbrev { get { return _teamAbbrevData.Name;}}
    public required string ConferenceName { get; set; }
    public int WildcardSequence { get; set; }
    public int DivisionSequence { get; set; }
    public required string DivisionName { get; set; }
    public string ClinchIndicator { get; set; } = string.Empty;
}