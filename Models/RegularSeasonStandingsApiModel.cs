namespace StaticApps.Models;

public class RegularSeasonStandingsApiModel
{
    public TeamData? Central1 { get; set; }
    public TeamData? Central2 { get; set; }
    public TeamData? Central3 { get; set; }
    public TeamData? Pacific1 { get; set; }
    public TeamData? Pacific2 { get; set; }
    public TeamData? Pacific3 { get; set; }
    public TeamData? Wildcard1 { get; set; }
    public TeamData? Wildcard2 { get; set; }
    public TeamData? Wildcard3 { get; set; }
    public TeamData? Wildcard4 { get; set; }
    public TeamData? Wildcard5 { get; set; }
    public TeamData? Wildcard6 { get; set; }
    public TeamData? Wildcard7 { get; set; }
    public TeamData? Wildcard8 { get; set; }
    public TeamData? Wildcard9 { get; set; }
    public TeamData? Wildcard10 { get; set; }
    // public TeamData? Atlantic1 { get; set; }
    // public TeamData? Atlantic2 { get; set; }
    // public TeamData? Atlantic3 { get; set; }
    // public TeamData? Metropolitan1 { get; set; }
    // public TeamData? Metropolitan2 { get; set; }
    // public TeamData? Metropolitan3 { get; set; }
    // public TeamData? EasternWildcard1 { get; set; }
    // public TeamData? EasternWildcard2 { get; set; }
    // public TeamData? EasternWildcard3 { get; set; }
    // public TeamData? EasternWildcard4 { get; set; }
    // public TeamData? EasternWildcard5 { get; set; }
    // public TeamData? EasternWildcard6 { get; set; }
    // public TeamData? EasternWildcard7 { get; set; }
    // public TeamData? EasternWildcard8 { get; set; }
    // public TeamData? EasternWildcard9 { get; set; }
    // public TeamData? EasternWildcard10 { get; set; }

    public class TeamData
    {
        public int Points { get; set; }
        public  int GamesPlayed { get; set; }
        public  string? Name { get; set; }
        public  string? Abbr { get; set; }
        public string? ClinchIndicator { get; set; }               
    }

    // public class DivisionLeaders
    // {
    //     public TeamData? First { get; set; }
    //     public TeamData? Second { get; set; }
    //     public TeamData? Third { get; set; }
    // }
    // public class WildCardRace
    // {
    //     public TeamData? First { get; set; }
    //     public TeamData? Second { get; set; }
    //     public TeamData? Third { get; set; }
    //     public TeamData? Fourth { get; set; }
    //     public TeamData? Fifth { get; set; }
    //     public TeamData? Sixth { get; set; }
    //     public TeamData? Seventh { get; set; }
    //     public TeamData? Eighth { get; set; }
    //     public TeamData? Ninth { get; set; }
    //     public TeamData? Tenth { get; set; }

    // }
}