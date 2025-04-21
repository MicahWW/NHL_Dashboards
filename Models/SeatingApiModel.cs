namespace NHL_Dashboards.Models;

public class SeatingApiModel
{
    public class OtherInfo
    {
        public string WiFiNetwork { get; set; } = string.Empty;
        public string WiFiPassword { get; set; } = string.Empty;
        public string Opponent { get; set; } = string.Empty;
        public bool UseAuxScreenOne { get; set; } = false;
        public bool UseBothAuxScreens { get; set; } = false;
    }
    public List<string> Seats { get; set; } = [];
    public List<string> Booths { get; set; } = [];
    public OtherInfo Other { get; set; } = new();
    public List<string> AuxSeats { get; set; } = [];
}