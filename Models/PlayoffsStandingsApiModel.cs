namespace NHL_Dashboards.Models;

public class PlayoffsStandingsApiModel
{
    public class TeamData
    {
        public int Id { get; set; }
        public required string Abbr { get; set; }
        public int Wins { get; set; }
        public int SeedRank { get; set; }
        public required string SeedAbbr { get; set; }
    }

    public class SeriesData
    {
        public required TeamData TopTeam { get; set; }
        public required TeamData BotTeam { get; set; }
        public int Conference { get; set; }
        public required string SeriesLetter { get; set; }
    }

    public required List<SeriesData> Series { get; set; }
}