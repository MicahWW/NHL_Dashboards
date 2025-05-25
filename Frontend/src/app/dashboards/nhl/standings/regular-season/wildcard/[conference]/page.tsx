import { RegularSeasonWildcardData, TeamData } from "@/models/RegularSeasonWildcardData";
import './styles.css';
import Wildcard from "./Wildcard";

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
    const standings: RegularSeasonWildcardData = await data.json();

    let topConferenceTeams: TeamData[] = [];
    let botConferenceTeams: TeamData[] = [];
    let wildcardTeams: TeamData[] = [];
    let outsideTeams: TeamData[] = [];
    let topConferenceName: string = "";
    let botConferenceName: string = "";
    if (conference === "western") {
        topConferenceTeams = [standings.central1, standings.central2, standings.central3];
        botConferenceTeams = [standings.pacific1, standings.pacific2, standings.pacific3];
        wildcardTeams = [standings.westernWildcard1, standings.westernWildcard2];
        outsideTeams = [standings.westernWildcard3, standings.westernWildcard4, standings.westernWildcard5,
            standings.westernWildcard6, standings.westernWildcard7, standings.westernWildcard8,
            standings.westernWildcard9, standings.westernWildcard10
        ];
        topConferenceName = "Central";
        botConferenceName = "Pacific";
    } else if (conference === "eastern") {
        topConferenceTeams = [standings.atlantic1, standings.atlantic2, standings.atlantic3];
        botConferenceTeams = [standings.metropolitan1, standings.metropolitan2, standings.metropolitan3];
        wildcardTeams = [standings.easternWildcard1, standings.easternWildcard2];
        outsideTeams = [standings.easternWildcard3, standings.easternWildcard4, standings.easternWildcard5,
            standings.easternWildcard6, standings.easternWildcard7, standings.easternWildcard8,
            standings.easternWildcard9, standings.easternWildcard10
        ];
        topConferenceName = "Atlantic";
        botConferenceName =  "Metropolitan";
    }

    return (
        <Wildcard conference={conference}
            topConferenceTeams={ { team: topConferenceTeams, name: "top-division", indexStart: 1, displayName: topConferenceName } }
            botConferenceTeams={{ team: botConferenceTeams, name: "bot-division", indexStart: 1, displayName: botConferenceName }}
            wildcardTeams={{ team: wildcardTeams, name: "wildcards", indexStart: 1, displayName: "Wildcards" }}
            outsideTeams={{ team: outsideTeams, name: "wildcard-race", indexStart: 9, displayName: "Wildcard Race" }}
        />
    )
}