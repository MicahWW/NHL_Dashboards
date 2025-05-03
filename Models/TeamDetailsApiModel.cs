namespace NHL_Dashboards.Models;

public class TeamDetailsApiModel
{
    public class TeamDetails(string primary, string accent)
    {
        public class TeamColors(string primary, string accent)
        {
            public class Color(string hexCode)
            {
                public string HexCode { get; set; } = hexCode;
                public int DecimalRed { get; set; } = Int32.Parse(hexCode.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
                public int DecimalGreen { get; set; } = Int32.Parse(hexCode.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
                public int DecimalBlue { get; set; } = Int32.Parse(hexCode.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
            }
            public Color Primary { get; set; } = new Color(primary);
            public Color Accent { get; set; } = new Color(accent);
        }

        public TeamColors Colors { get; set; } = new TeamColors(primary, accent);
    }

    public Dictionary<string, TeamDetails> Teams { get; set; }

    public TeamDetailsApiModel()
    {
        Teams = new Dictionary<string, TeamDetails>()
        {
            {"ANA", new TeamDetails("#CF4520", "#A3895B") },
            {"BOS", new TeamDetails("#FFB81C", "#FFFFFF") },
            {"BUF", new TeamDetails("#003087", "#FFB81C") },
            {"CGY", new TeamDetails("#E01234", "#F1BE48") },
            {"CAR", new TeamDetails("#C8102E", "#A2AAAD") },
            {"CHI", new TeamDetails("#CE1126", "#FFD100") },
            {"COL", new TeamDetails("#AB2739", "#236093") },
            {"CBJ", new TeamDetails("#003366", "#C8102E") },
            {"DAL", new TeamDetails("#00823E", "#A2AAAD") },
            {"DET", new TeamDetails("#C8102E", "#FFFFFF") },
            {"EDM", new TeamDetails("#D14520", "#00205B") },
            {"FLA", new TeamDetails("#C8102E", "#041E42") },
            {"LAK", new TeamDetails("#A2AAAD", "#FFFFFF") },
            {"MIN", new TeamDetails("#0E4431", "#DDC9A3") },
            {"MTL", new TeamDetails("#A6192E", "#FFFFFF") },
            {"NSH", new TeamDetails("#FFB81C", "#FFFFFF") },
            {"NJD", new TeamDetails("#ED0000", "#FFFFFF") },
            {"NYI", new TeamDetails("#00468B", "#F26924") },
            {"NYR", new TeamDetails("#0051FF", "#C8102E") },
            {"OTT", new TeamDetails("#B9975B", "#000000") },
            {"PHI", new TeamDetails("#D24303", "#FFFFFF") },
            {"PIT", new TeamDetails("#FFB81C", "#000000") },
            {"SEA", new TeamDetails("#96D8D8", "#001425") },
            {"SJS", new TeamDetails("#00778B", "#E57200") },
            {"STL", new TeamDetails("#004986", "#FFB81C") },
            {"TBL", new TeamDetails("#00205B", "#FFFFFF") },
            {"TOR", new TeamDetails("#00205B", "#FFFFFF") },
            {"UTA", new TeamDetails("#6CACE4", "#FFFFFF") },
            {"VAN", new TeamDetails("#00205B", "#00843D") },
            {"VGK", new TeamDetails("#B9975B", "#333F48") },
            {"WPG", new TeamDetails("#041E42", "#A2AAAD") },
            {"WSH", new TeamDetails("#C8102E", "#FFFFFF") }
        };
    }
}