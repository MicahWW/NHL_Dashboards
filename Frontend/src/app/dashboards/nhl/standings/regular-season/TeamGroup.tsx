import TeamRow from "./TeamRow";
// import { TeamData } from "@/models/RegularSeasonWildcardData";
import { RegularSeasonTeamGroupData } from "@/models/RegularSeasonTeamGroupData";

type TeamGroupProps = {
    data: RegularSeasonTeamGroupData
}

const TeamGroup = ({ data }: TeamGroupProps) => {
    return (
        <div className={`team-group${data.name ? ` ${data.name}` : ""}`}>
            {data.team.map((team, index) => (
                <TeamRow key={team.abbr} team={team} index={data.indexStart + index} />
            ))}
        </div>
    );
}

export default TeamGroup;