namespace NHL_Dashboards.Models;

public class PlayoffsStandingsApiModel
{
    public class SeriesData
    {
        public class TeamData(NhlPlayoffBracketModel.SeriesData.TeamSeedData? data, int wins, int rank, string? seedAbbr)
        {
            public int Id { get; set; } = data != null ? data.Id : 0;
            public string? Abbr { get; set; } = data?.Abbrev;
            public int Wins { get; set; } = wins;
            public int SeedRank { get; set; } = rank;
            public string? SeedAbbr { get; set; } = seedAbbr;
        }

        public TeamData? TopTeam { get; set; }
        public TeamData? BotTeam { get; set; }
        public string? Conference { get; set; }
        public string? SeriesLetter { get; set; }

        public SeriesData(NhlPlayoffBracketModel.SeriesData data) : this(data.SeriesLetter, data.TopSeedTeam!, data.TopSeedWins, data.TopSeedRank, data.TopSeedRankAbbrev!, data.BottomSeedTeam!, data.BottomSeedWins, data.BottomSeedRank, data.BottomSeedRankAbbrev!)
        { }
        // {
        //     SeriesLetter = data.SeriesLetter;
        //     // The series letters listed below are all of the series that aren't the final
        //     if ("ABCDEFGHIJKLMN".Contains(data.SeriesLetter))
        //     {
        //         // The series listed below are all of the series that are in the Western conference, minus the final.
        //         Conference =  "EFGHKLN".Contains(SeriesLetter) ? "Western" : "Eastern";
        //     }
        //     else
        //     {
        //         Conference = "Stanley Cup Final";
        //     }

        //     TopTeam = new TeamData(data.TopSeedTeam, data.TopSeedWins, data.TopSeedRank, data.TopSeedRankAbbrev);
        //     BotTeam = new TeamData(data.BottomSeedTeam, data.BottomSeedWins, data.BottomSeedRank, data.BottomSeedRankAbbrev);
        // }

        public SeriesData(string seriesLetter, NhlPlayoffBracketModel.SeriesData.TeamSeedData? topTeam, int topSeedWins, int topSeedRank, string topSeedRankAbbr, NhlPlayoffBracketModel.SeriesData.TeamSeedData? botTeam, int botSeedWins, int botSeedRank, string botSeedRankAbbr)
        {
            SeriesLetter = seriesLetter;

            // The series letters listed below are all of the series that aren't the final
            if ("ABCDEFGHIJKLMN".Contains(SeriesLetter))
            {
                // The series listed below are all of the series that are in the Western conference, minus the final.
                Conference =  "EFGHKLN".Contains(SeriesLetter) ? "Western" : "Eastern";
            }
            else
            {
                Conference = "Stanley Cup Final";
            }

            TopTeam = new TeamData(topTeam, topSeedWins, topSeedRank, topSeedRankAbbr); 
            BotTeam = new TeamData(botTeam, botSeedWins, botSeedRank, botSeedRankAbbr); 
        }

        public SeriesData() { }
    }

    public List<SeriesData> Series { get; set; } = [];
}