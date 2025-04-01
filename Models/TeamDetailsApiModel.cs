namespace NHL_Dashboards.Models;

public class TeamDetailsApiModel
{
    public class TeamDetails
    {
        public class TeamColors {
            public required string Primary { get; set; }
            public required string Accent { get; set; }
            public required string TextOnPrimary { get; set; }
            public required string TextOnAccent { get; set; }
            public required string Gamecenter { get; set; }
            public required string Contrast { get; set; }
            public required string TextOnGamecenter { get; set; }
        }

        public required TeamColors Colors { get; set;}
    }

    public Dictionary<string, TeamDetails> Teams { get; set;}

    public TeamDetailsApiModel()
    {
        Teams = new Dictionary<string, TeamDetails>()
        {
            {"ANA", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#CF4520", TextOnPrimary = "#000000", TextOnAccent = "#FFFFFF", Gamecenter = "#CF4520", Contrast = "#A3895B", TextOnGamecenter = "#FFFFFF" } } },
            {"ARI", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#DDCBA4", Accent = "#6F263D", TextOnPrimary = "#6F263D", TextOnAccent = "#DDCBA4", Gamecenter = "#DDCBA4", Contrast = "#DDCBA4", TextOnGamecenter = "#000000" } } },
            {"BOS", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#FFB81C", TextOnPrimary = "#000000", TextOnAccent = "#000000", Gamecenter = "#FFB81C", Contrast = "#FFB81C", TextOnGamecenter = "#000000" } } },
            {"BUF", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#FFB81C", TextOnPrimary = "#003087", TextOnAccent = "#000000", Gamecenter = "#FFB81C", Contrast = "#FFB81C", TextOnGamecenter = "#003087" } } },
            {"CAN", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#EE2723", Accent = "#DDCBA4", TextOnPrimary = "#000000", TextOnAccent = "#000000", Gamecenter = "#EE2723", Contrast = "#FFFFFF", TextOnGamecenter = "#000000" } } },
            {"CGY", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#C8102E", Accent = "#F1BE48", TextOnPrimary = "#FFFFFF", TextOnAccent = "#000000", Gamecenter = "#E01234", Contrast = "#F1BE48", TextOnGamecenter = "#FFFFFF" } } },
            {"CAR", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#A2AAAD", TextOnPrimary = "#C8102E", TextOnAccent = "#000000", Gamecenter = "#E02134", Contrast = "#C3C9CB", TextOnGamecenter = "#FFFFFF" } } },
            {"CHI", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#CE1126", Accent = "#FFFFFF", TextOnPrimary = "#FFFFFF", TextOnAccent = "#CE1126", Gamecenter = "#CE1126", Contrast = "#FFD100", TextOnGamecenter = "#FFFFFF" } } },
            {"COL", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#C2C6C9", Accent = "#236093", TextOnPrimary = "#000000", TextOnAccent = "#FFFFFF", Gamecenter = "#AB2739", Contrast = "#FFFFFF", TextOnGamecenter = "#FFFFFF" } } },
            {"CBJ", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#C8102E", TextOnPrimary = "#041E42", TextOnAccent = "#FFFFFF", Gamecenter = "#E02134", Contrast = "#A2AAAD", TextOnGamecenter = "#FFFFFF" } } },
            {"DAL", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#00823E", Accent = "#A2AAAD", TextOnPrimary = "#FFFFFF", TextOnAccent = "#000000", Gamecenter = "#00823E", Contrast = "#129651", TextOnGamecenter = "#FFFFFF" } } },
            {"DET", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#C8102E", Accent = "#FFFFFF", TextOnPrimary = "#FFFFFF", TextOnAccent = "#C8102E", Gamecenter = "#E01234", Contrast = "#FFFFFF", TextOnGamecenter = "#FFFFFF" } } },
            {"EDM", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#D14520", TextOnPrimary = "#00205B", TextOnAccent = "#000000", Gamecenter = "#EB3A0C", Contrast = "#FD531E", TextOnGamecenter = "#000000" } } },
            {"FIN", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#004C97", Accent = "#FFB81C", TextOnPrimary = "#FFFFFF", TextOnAccent = "#041E42", Gamecenter = "#006EB3", Contrast = "#FFB81C", TextOnGamecenter = "#FFFFFF" } } },
            {"FLA", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#C8102E", Accent = "#FFFFFF", TextOnPrimary = "#FFFFFF", TextOnAccent = "#041E42", Gamecenter = "#B9975B", Contrast = "#B9975B", TextOnGamecenter = "#000000" } } },
            {"HGS", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#000000", Accent = "#C8102E", TextOnPrimary = "#C8102E", TextOnAccent = "#C8102E", Gamecenter = "#C8102E", Contrast = "#C8102E", TextOnGamecenter = "#FFFFFF" } } },
            {"LAK", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#A2AAAD", TextOnPrimary = "#000000", TextOnAccent = "#000000", Gamecenter = "#A2AAAD", Contrast = "#A2AAAD", TextOnGamecenter = "#000000" } } },
            {"MAT", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#3A5DAE", Accent = "#3A5DAE", TextOnPrimary = "#3A5DAE", TextOnAccent = "#3A5DAE", Gamecenter = "#3A5DAE", Contrast = "#3A5DAE", TextOnGamecenter = "#FFFFFF" } } },
            {"MCD", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#FFFFFF", TextOnPrimary = "#FFFFFF", TextOnAccent = "#FFFFFF", Gamecenter = "#FFFFFF", Contrast = "#FFFFFF", TextOnGamecenter = "#FFFFFF" } } },
            {"MIN", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#DDC9A3", Accent = "#0E4431", TextOnPrimary = "#000000", TextOnAccent = "#DDC9A3", Gamecenter = "#016944", Contrast = "#EAAA00", TextOnGamecenter = "#FFFFFF" } } },
            {"MKN", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFB81C", Accent = "#FFB81C", TextOnPrimary = "#FFB81C", TextOnAccent = "#FFB81C", Gamecenter = "#FFB81C", Contrast = "#FFB81C", TextOnGamecenter = "#FFFFFF" } } },
            {"MTL", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#A6192E", TextOnPrimary = "#A6192E", TextOnAccent = "#FFFFFF", Gamecenter = "#C2273E", Contrast = "#FFFFFF", TextOnGamecenter = "#FFFFFF" } } },
            {"NSH", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFB81C", Accent = "#FFFFFF", TextOnPrimary = "#041E42", TextOnAccent = "#014E42", Gamecenter = "#FFB81C", Contrast = "#FFB81C", TextOnGamecenter = "#041E42" } } },
            {"NJD", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#CC0000", TextOnPrimary = "#CC0000", TextOnAccent = "#FFFFFF", Gamecenter = "#ED0000", Contrast = "#FFFFFF", TextOnGamecenter = "#FFFFFF" } } },
            {"NYI", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#F26924", TextOnPrimary = "#00468B", TextOnAccent = "#000000", Gamecenter = "#006DD9", Contrast = "#F26924", TextOnGamecenter = "#FFFFFF" } } },
            {"NYR", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#C8102E", TextOnPrimary = "#0033A0", TextOnAccent = "#FFFFFF", Gamecenter = "#0051FF", Contrast = "#246AFF", TextOnGamecenter = "#FFFFFF" } } },
            {"OTT", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#B9975B", TextOnPrimary = "#000000", TextOnAccent = "#000000", Gamecenter = "#B9975B", Contrast = "#B9975B", TextOnGamecenter = "#000000" } } },
            {"PHI", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#D24303", TextOnPrimary = "#D24303", TextOnAccent = "#FFFFFF", Gamecenter = "#D24303", Contrast = "#F14F07", TextOnGamecenter = "#000000" } } },
            {"PIT", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#FFB81C", TextOnPrimary = "#000000", TextOnAccent = "#000000", Gamecenter = "#FFB81C", Contrast = "#FFB81C", TextOnGamecenter = "#000000" } } },
            {"SEA", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#96D8D8", TextOnPrimary = "#001425", TextOnAccent = "#001425", Gamecenter = "#96D8D8", Contrast = "#96D8D8", TextOnGamecenter = "#001425" } } },
            {"SJS", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#E57200", TextOnPrimary = "#000000", TextOnAccent = "#000000", Gamecenter = "#00778B", Contrast = "#E57200", TextOnGamecenter = "#FFFFFF" } } },
            {"STL", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFB81C", Accent = "#FFFFFF", TextOnPrimary = "#004986", TextOnAccent = "#004986", Gamecenter = "#106AB5", Contrast = "#FFB81C", TextOnGamecenter = "#FFFFFF" } } },
            {"SWE", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFD100", Accent = "#006EB3", TextOnPrimary = "#000000", TextOnAccent = "#FFFFFF", Gamecenter = "#FFD100", Contrast = "#FFD100", TextOnGamecenter = "#FFFFFF" } } },
            {"TBL", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#FFFFFF", TextOnPrimary = "#00205B", TextOnAccent = "#00205B", Gamecenter = "#FFFFFF", Contrast = "#FFFFFF", TextOnGamecenter = "#00205B" } } },
            {"TOR", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#FFFFFF", TextOnPrimary = "#00205B", TextOnAccent = "#00205B", Gamecenter = "#FFFFFF", Contrast = "#FFFFFF", TextOnGamecenter = "#00205B" } } },
            {"USA", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#003087", TextOnPrimary = "#003087", TextOnAccent = "#FFFFFF", Gamecenter = "#FFFFFF", Contrast = "#FFFFFF", TextOnGamecenter = "#003087" } } },
            {"UTA", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#6CACE4", Accent = "#FFFFFF", TextOnPrimary = "#000000", TextOnAccent = "#000000", Gamecenter = "#6CACE4", Contrast = "#6CACE4", TextOnGamecenter = "#000000" } } },
            {"VAN", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#97999B", TextOnPrimary = "#00205B", TextOnAccent = "#041C2C", Gamecenter = "#00843D", Contrast = "#97999B", TextOnGamecenter = "#FFFFFF" } } },
            {"VGK", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#B9975B", TextOnPrimary = "#333F48", TextOnAccent = "#000000", Gamecenter = "#B9975B", Contrast = "#B9975B", TextOnGamecenter = "#000000" } } },
            {"WPG", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#A2AAAD", TextOnPrimary = "#041E42", TextOnAccent = "#041E42", Gamecenter = "#3176D6", Contrast = "#4384DF", TextOnGamecenter = "#000000" } } },
            {"WSH", new TeamDetails() { Colors = new TeamDetails.TeamColors() { Primary = "#FFFFFF", Accent = "#C8102E", TextOnPrimary = "#C8102E", TextOnAccent = "#FFFFFF", Gamecenter = "#E01234", Contrast = "#FFFFFF", TextOnGamecenter = "#FFFFFF" } } }
        };
    }
}