import { RegularSeasonWildcardData, TeamData } from "@/models/RegularSeasonWildcardData";
import Team from "./team";

export default async function Page({
    params,
}: {
    params: Promise<{ conference: string }>
}) {
    const { conference } = await params;
    if (conference !== "western" && conference !== "eastern") {
        return <div>Invalid conference</div>
    }
    const data = await fetch("https://dsit-dashboards-efeyduc2eebxbhaf.southcentralus-01.azurewebsites.net/api/standings/RegularSeason")
    // const json = await data.json();
    // const standings = new RegularSeasonWildcardData(json);
    const standings: RegularSeasonWildcardData = await data.json();

    let topConferenceTeams: TeamData[] = [];
    let botConferenceTeams: TeamData[] = [];
    let wildcardTeams: TeamData[] = [];
    if (conference === "western") {
        topConferenceTeams = [standings.central1, standings.central2, standings.central3];
        botConferenceTeams = [standings.pacific1, standings.pacific2, standings.pacific3];
        wildcardTeams = [standings.westernWildcard1, standings.westernWildcard2, standings.westernWildcard3,
            standings.westernWildcard4, standings.westernWildcard5, standings.westernWildcard6,
            standings.westernWildcard7, standings.westernWildcard8, standings.westernWildcard9,
            standings.westernWildcard10
        ];
    } else if (conference === "eastern") {
        topConferenceTeams = [standings.atlantic1, standings.atlantic2, standings.atlantic3];
        botConferenceTeams = [standings.metropolitan1, standings.metropolitan2, standings.metropolitan3];
        wildcardTeams = [standings.easternWildcard1, standings.easternWildcard2, standings.easternWildcard3,
            standings.easternWildcard4, standings.easternWildcard5, standings.easternWildcard6,
            standings.easternWildcard7, standings.easternWildcard8, standings.easternWildcard9,
            standings.easternWildcard10
        ];
    }

    return (
        <div>
            <h1>Regular Season Standings</h1>
            {topConferenceTeams.map((team, index) => (
                <Team key={index} team={team} index={index + 1} />
            ))}
            {botConferenceTeams.map((team, index) => (
                <Team key={index + 3} team={team} index={index + 1} />
            ))}
            {wildcardTeams.map((team, index) => (
                <Team key={index + 6} team={team} index={index + 1} />
            ))}
        </div>
    )
}