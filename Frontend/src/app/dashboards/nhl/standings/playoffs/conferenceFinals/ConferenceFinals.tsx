"use client";

import { useFontResizer } from "@/hooks/useFrontResizer";
import { useEffect, useState } from "react";
import { fetchPlayoffs } from "../fetchPlayoffs";
import { PlayoffSeriesData } from "@/models/PlayoffSeriesData";
import PlayoffSeries from "../PlayoffSeries";

type ConferenceFinalsProps = {
    roundThree: PlayoffSeriesData[];
}

const ConferenceFinals = ({ roundThree }: ConferenceFinalsProps) => {
    useFontResizer();
    const west = roundThree.filter(series => series.seriesLetter.toLowerCase() == "n");
    const east = roundThree.filter(series => series.seriesLetter.toLowerCase() == "m");

    const [westernConference, setWesternConference] = useState(west)
    const [easternConference, setEasternConference] = useState(east);

    useEffect(() => {
        const interval = setInterval(async () => {
            const [ , , roundThreeFetch] = await fetchPlayoffs();
            const west = roundThreeFetch.filter(series => series.seriesLetter.toLowerCase() == "n");
            const east = roundThreeFetch.filter(series => series.seriesLetter.toLowerCase() == "m");
            setWesternConference(west);
            setEasternConference(east);

        }, 1800000);

        return () => clearInterval(interval);
    }, []);

    return (
        <>
            <div className="title">
                <div data-resizable className="title-text">
                    Conference Finals
                </div>
            </div>
            <main>
                <div id="western-conference">
                    {westernConference.map((series) => (
                        <PlayoffSeries key={series.seriesLetter} series={series} />
                    ))}
                </div>
                <div id="eastern-conference">
                    {easternConference.map((series) => (
                        <PlayoffSeries key={series.seriesLetter} series={series} />
                    ))}
                </div>
            </main>
        </>
    );
}

export default ConferenceFinals;