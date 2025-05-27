"use server";

import { RegularSeasonWildcardData, TeamData } from "@/models/RegularSeasonWildcardData";

export async function fetchData(conference: "western" | "eastern"): Promise<[TeamData[], string, TeamData[], string, TeamData[], TeamData[]]> {
    const data = await fetch(
        "https://dsit-dashboards-efeyduc2eebxbhaf.southcentralus-01.azurewebsites.net/api/standings/RegularSeason"
    );
    if (!data.ok) {
        throw new Error(`Failed to fetch data: ${data.statusText}`);
    }
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
    return [topConferenceTeams, topConferenceName, botConferenceTeams, botConferenceName, wildcardTeams, outsideTeams];
}