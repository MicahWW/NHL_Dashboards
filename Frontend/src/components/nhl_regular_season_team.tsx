/* eslint-disable @next/next/no-img-element */
import { TeamData } from "@/models/RegularSeasonWildcardData";

type TeamProps = {
    team: TeamData;
    index: number;
}

const Team = ({ team, index }: TeamProps) => {
    return (
        <div className="standing-row">
            <div className="standing-number">{index}</div>
            <div className="team-div">
                <div className="team-info">
                    <img className="logo" src={"https://assets.nhle.com/logos/nhl/svg/"+ team.abbr + "_dark.svg"} alt={team.abbr + "-team-abbreveation"}/>
                    <div className="clinch-indicator">{team.clinchIndicator}</div>
                    <div className="name">{team.name}</div>
                </div>
                <div className="games-played">{team.gamesPlayed}</div>
                <div className="points">{team.points}</div>
            </div>
        </div>
    )
}

export default Team;