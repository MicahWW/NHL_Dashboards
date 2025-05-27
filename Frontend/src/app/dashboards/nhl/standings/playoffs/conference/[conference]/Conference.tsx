"use client";

import { useFontResizer } from "@/hooks/useFrontResizer";
import { useEffect, useState } from "react";
import { PlayoffSeriesData } from "@/models/PlayoffSeriesData";
import fetchData from "./fetchData";
import PlayoffSeries from "../../PlayoffSeries";

type ConferenceProps = {
    conference: "western" | "eastern";
    roundOne: PlayoffSeriesData[];
    roundTwo: PlayoffSeriesData[];
    roundThree: PlayoffSeriesData[];
}

const Conference = ({ conference, roundOne, roundTwo, roundThree }: ConferenceProps) => {
    useFontResizer();

    const [roundOneData, setRoundOne] = useState(roundOne);
    const [roundTwoData, setRoundTwo] = useState(roundTwo);
    const [roundThreeData, setRoundThree] = useState(roundThree);

    useEffect(() => {
        const interval = setInterval(async () => {
            const [roundOneFetch, roundTwoFetch, roundThreeFetch] = await fetchData(conference);

            setRoundOne(roundOneFetch);
            setRoundTwo(roundTwoFetch);
            setRoundThree(roundThreeFetch);
            
        }, 1800000);
       
        return () => clearInterval(interval);
    });

    return (
        <>
            <div className="title">
                <div data-resizable className="title-text">
                    {conference === "western" ? "Western" : "Eastern"} Conference Playoffs
                </div>
            </div>
            <main>
                <div id="round-one">
                    {roundOneData.map((series) => (
                        <PlayoffSeries key={series.seriesLetter} series={series} />
                    ))}
                </div>
                <div id="round-two">
                    {roundTwoData.map((series) => (
                        <PlayoffSeries key={series.seriesLetter} series={series} />
                    ))}
                </div>
                <div id="round-three">
                    {roundThreeData.map((series) => (
                        <PlayoffSeries key={series.seriesLetter} series={series} />
                    ))}
                </div>
            </main>
        </>
    );
}

export default Conference;