"use client"
import { RegularSeasonTeamGroupData } from "@/models/RegularSeasonTeamGroupData";
import StandingSection from "../../StandingSection";
import { useFontResizer } from "@/app/hooks/useFrontResizer";

type WildcardProps = {
    conference: "western" | "eastern";
    topConferenceTeams: RegularSeasonTeamGroupData;
    botConferenceTeams: RegularSeasonTeamGroupData;
    wildcardTeams: RegularSeasonTeamGroupData;
    outsideTeams: RegularSeasonTeamGroupData;
}

const Wildcard = ({ conference, topConferenceTeams, botConferenceTeams, wildcardTeams, outsideTeams }: WildcardProps) => {
    useFontResizer("[data-resizable]");
    return (
        <>
            <div className="title">
                <div data-resizable className="title-text">{conference == "western" ? "Western" : "Eastern"} Conference Standings</div>
            </div>

            <main>
                <StandingSection name="playoff-teams" teamGroups={[topConferenceTeams, botConferenceTeams, wildcardTeams]} />
                <StandingSection name="outside-teams" teamGroups={[outsideTeams]} />
            </main>
        </>
    );
}

export default Wildcard;