"use client";

import { RegularSeasonTeamGroupData } from "@/models/RegularSeasonTeamGroupData";
import StandingSection from "../../StandingSection";
import { useFontResizer } from "@/hooks/useFrontResizer";
import { useEffect } from "react";
import { fetchData } from "./fetchData";
import { useState } from "react";

type WildcardProps = {
    conference: "western" | "eastern";
    topConferenceTeams: RegularSeasonTeamGroupData;
    botConferenceTeams: RegularSeasonTeamGroupData;
    wildcardTeams: RegularSeasonTeamGroupData;
    outsideTeams: RegularSeasonTeamGroupData;
}

const Wildcard = ({ conference, topConferenceTeams, botConferenceTeams, wildcardTeams, outsideTeams }: WildcardProps) => {
    useFontResizer();

    const [conf, setConf] = useState(conference);
    const [topTeams, setTopTeams] = useState(topConferenceTeams);
    const [botTeams, setBotTeams] = useState(botConferenceTeams);
    const [wildcardTeamsData, setWildcardTeams] = useState(wildcardTeams);
    const [outsideTeamsData, setOutsideTeams] = useState(outsideTeams);

    useEffect(() => {
        const interval = setInterval(async () => {
            const data = await fetchData(conf)

            setConf(conference);
            setTopTeams( {team: data[0], name: "top-division", indexStart: 1, displayName: data[1] });
            setBotTeams( {team: data[2], name: "bot-division", indexStart: 1, displayName: data[3] });
            setWildcardTeams( {team: data[4], name: "wildcards", indexStart: 1, displayName: "Wildcards" });
            setOutsideTeams( {team: data[5], name: "wildcard-race", indexStart: 9, displayName: "Wildcard Race" });
        }, 18000000); 

        return () => clearInterval(interval);
    });

    return (
        <>
            <div className="title">
                <div data-resizable className="title-text">{conf == "western" ? "Western" : "Eastern"} Conference Standings</div>
            </div>

            <main>
                <StandingSection name="playoff-teams" teamGroups={[topTeams, botTeams, wildcardTeamsData]} />
                <StandingSection name="outside-teams" teamGroups={[outsideTeamsData]} />
            </main>
        </>
    );
}

export default Wildcard;