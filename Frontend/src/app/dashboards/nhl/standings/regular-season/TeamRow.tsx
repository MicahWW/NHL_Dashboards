/* eslint-disable @next/next/no-img-element */
import { TeamData } from "@/models/RegularSeasonWildcardData";

type TeamProps = {
    team?: TeamData;
    index?: number;
}

const TeamRow = ({ team, index }: TeamProps) => {
    return (
        <div className="standing-row">
            <div data-resizable className="standing-number">{team == null ? "" : index}</div>
            <div className="team-div">
                <div className="team-info">
                    {/* If blank set to a 1 pixel transparent gif http://probablyprogramming.com/2009/03/15/the-tiniest-gif-ever */}
                    <img className="logo" src={team == null ? "data:image/gif;base64,R0lGODlhAQABAAD/ACwAAAAAAQABAAACADs=" : "https://assets.nhle.com/logos/nhl/svg/"+ team!.abbr + "_dark.svg"} alt={team == null ? "" : team!.abbr + "-team-abbreviation"}/>
                    <div data-resizable className="clinch-indicator">{team == null ? "" : team!.clinchIndicator}</div>
                    <div data-resizable className="name">{team == null ? "" : team!.name}</div>
                </div>
                <div data-resizable className="games-played">{team == null ? "GP" : team!.gamesPlayed}</div>
                <div data-resizable className="points">{team == null ? "PTS" : team!.points}</div>
            </div>
        </div>
    )
}

export default TeamRow;