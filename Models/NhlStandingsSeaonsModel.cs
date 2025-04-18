using System.Text.Json.Serialization;

namespace NHL_Dashboards.Models;

public class NhlStandingsSeason()
{
    public class SeasonDetails
    {
        public int Id { get; set; }
        public bool ConferencesInUse { get; set; }
        public bool DivisionsInUse { get; set; }
        public bool PointForOTlossInUse { get; set; }
        public bool RegulationWinsInUse { get; set; }
        public bool RowInUse { get; set; }
        public required string StandingsEnd { get; set; }
        public required string StandingsStart { get; set; }
        public bool TiesInUse { get; set; }
        public bool WildcardInUse { get; set; }
    }

    public required string CurrentDate { get; set; }
    public required List<SeasonDetails> Seasons { get; set; }
}