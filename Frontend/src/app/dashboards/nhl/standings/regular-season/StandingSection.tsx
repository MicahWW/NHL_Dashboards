import { RegularSeasonTeamGroupData } from "@/models/RegularSeasonTeamGroupData";
import TeamRow from "./TeamRow";
import TeamGroup from "./TeamGroup";

type StandingSectionProps = {
    name: string;
    teamGroups: RegularSeasonTeamGroupData[]
}

const StandingSection = ({ name, teamGroups }: StandingSectionProps) => {
    return (
        <div id={name} className="standing-section-container">
            <div className="table-headers">
                <div className="standing-header-container">{/* <!-- blank for spacing --> */}</div>
                <div className="standing-section-teams">
                    <TeamRow />
                </div>
            </div>
            <div className="standing-header-container">
                {teamGroups.map((group) => (
                    <div key={`${group.name}-header`} className={group.name}>
                        <div data-resizable className="standing-header">
                            {group.displayName}
                        </div>
                    </div>
                ))}
            </div>
            <div className="standing-section-teams">
                {teamGroups.map((group) => (
                    <TeamGroup key={`${group.name}-team-group`} data={group} />
                ))}
            </div>
        </div>
    );
}

export default StandingSection;