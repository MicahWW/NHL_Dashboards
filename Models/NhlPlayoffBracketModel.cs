using System.Text.Json.Serialization;

namespace NHL_Dashboards.Models;

public class NhlPlayoffBracketModel
{
    public class SeriesData
    {
        public class TeamSeedData
        {
            public class NameData
            {
                [JsonPropertyName("default")]
                public required string Name { get; set; }
            }

            public int Id { get; set; }
            public required string Abbrev { get; set; }
            public required NameData Name { get; set; }
            public required NameData CommonName { get; set; }
            public required NameData PlaceNameWithPreposition { get; set; }
            public required string Logo { get; set; }
            public required string DarkLogo { get; set; }

        }

        public string? SeriesUrl { get; set; }
        public required string SeriesTitle { get; set; }
        public required string SeriesAbbrev { get; set; }
        public required string SeriesLetter { get; set; }
        public int PlayoffRound { get; set; }
        public int TopSeedRank { get; set; }
        public string? TopSeedRankAbbrev { get; set; }
        public int TopSeedWins { get; set; }
        public int BottomSeedRank { get; set; }
        public string? BottomSeedRankAbbrev { get; set; }
        public int BottomSeedWins { get; set; }
        public TeamSeedData? TopSeedTeam { get; set; }
        public TeamSeedData? BottomSeedTeam { get; set; }

        /// <summary>
        /// Returns the id of the winning team in the series. If no team has won yet, it returns -1.
        /// </summary>
        /// <returns>ID of winning team, -1 means no winner.</returns>
        public int SeriesWinnerId()
        {
            if (TopSeedWins == 4)
                return TopSeedTeam!.Id;
            else if (BottomSeedWins == 4)
                return BottomSeedTeam!.Id;
            else
                return -1;
        }
    }

    public required List<SeriesData> Series { get; set; }
    public required string BracketLogo { get; set; }
}