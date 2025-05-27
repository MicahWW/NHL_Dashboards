import { PlayoffTeamData } from "@/models/PlayoffSeriesData";

type PlayoffTeamProps = {
    wins: number;
    team: PlayoffTeamData;
    name: string;
    isLoser: boolean;
}

const PlayoffTeam = ({wins, team, name, isLoser}: PlayoffTeamProps) => {
    return (
        <div className={`${name}${isLoser ? " series-loser" : ""}`}>
            { /* eslint-disable-next-line @next/next/no-img-element */}
            <img className="logo" src={`https://assets.nhle.com/logos/nhl/svg/${team.abbr}_dark.svg`} alt={`${team.abbr} logo`}/>
            <div data-resizable className="wins">{wins}</div>
        </div>
    );
}

export default PlayoffTeam;