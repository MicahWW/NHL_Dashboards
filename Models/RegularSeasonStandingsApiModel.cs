namespace NHL_Dashboards.Models;

public class RegularSeasonStandingsApiModel
{
    public TeamData? Central1 { get; set; }
    public TeamData? Central2 { get; set; }
    public TeamData? Central3 { get; set; }
    public TeamData? Pacific1 { get; set; }
    public TeamData? Pacific2 { get; set; }
    public TeamData? Pacific3 { get; set; }
    public TeamData? WesternWildcard1 { get; set; }
    public TeamData? WesternWildcard2 { get; set; }
    public TeamData? WesternWildcard3 { get; set; }
    public TeamData? WesternWildcard4 { get; set; }
    public TeamData? WesternWildcard5 { get; set; }
    public TeamData? WesternWildcard6 { get; set; }
    public TeamData? WesternWildcard7 { get; set; }
    public TeamData? WesternWildcard8 { get; set; }
    public TeamData? WesternWildcard9 { get; set; }
    public TeamData? WesternWildcard10 { get; set; }
    public TeamData? Atlantic1 { get; set; }
    public TeamData? Atlantic2 { get; set; }
    public TeamData? Atlantic3 { get; set; }
    public TeamData? Metropolitan1 { get; set; }
    public TeamData? Metropolitan2 { get; set; }
    public TeamData? Metropolitan3 { get; set; }
    public TeamData? EasternWildcard1 { get; set; }
    public TeamData? EasternWildcard2 { get; set; }
    public TeamData? EasternWildcard3 { get; set; }
    public TeamData? EasternWildcard4 { get; set; }
    public TeamData? EasternWildcard5 { get; set; }
    public TeamData? EasternWildcard6 { get; set; }
    public TeamData? EasternWildcard7 { get; set; }
    public TeamData? EasternWildcard8 { get; set; }
    public TeamData? EasternWildcard9 { get; set; }
    public TeamData? EasternWildcard10 { get; set; }

    public class TeamData
    {
        public int Points { get; set; }
        public  int GamesPlayed { get; set; }
        public  string? Name { get; set; }
        public  string? Abbr { get; set; }
        public string? ClinchIndicator { get; set; }               
    }
}