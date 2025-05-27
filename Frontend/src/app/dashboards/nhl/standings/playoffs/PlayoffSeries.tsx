import { PlayoffSeriesData } from "@/models/PlayoffSeriesData";
import PlayoffTeam from "./PlayoffTeam";

type PlayoffSeriesProps = {
    series: PlayoffSeriesData;
}

const PlayoffSeries = ({ series }: PlayoffSeriesProps) => {
    return (
        <div id={`series-${series.seriesLetter.toLowerCase()}`} className="series">
            <PlayoffTeam name="top-team" wins={series.topTeam.wins} team={series.topTeam} isLoser={series.botTeam.wins == 4}/>
            <PlayoffTeam name="bot-team" wins={series.botTeam.wins} team={series.botTeam} isLoser={series.topTeam.wins == 4}/>
        </div>
    );
}

export default PlayoffSeries;