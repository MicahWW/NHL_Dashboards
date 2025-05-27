"use server";

import { PlayoffSeriesData } from "@/models/PlayoffSeriesData";

export async function fetchPlayoffs(): Promise<[PlayoffSeriesData[], PlayoffSeriesData[], PlayoffSeriesData[], PlayoffSeriesData[]]> {
    const data = await fetch(
        "https://dsit-dashboards-efeyduc2eebxbhaf.southcentralus-01.azurewebsites.net/api/standings/Playoffs"
    );
    if (!data.ok) {
        throw new Error(`Failed to fetch data: ${data.statusText}`);
    }
    const json: {series: PlayoffSeriesData[]} = await data.json();
    const seriesList = json.series;

    const roundOneLetters: string[] = ["a", "b", "c", "d", "e", "f", "g", "h"];
    const roundTwoLetters: string[] = ["i", "j", "k", "l"];
    const roundThreeLetters: string[] = ["m", "n"];
    const roundFourLetters: string[] = ["o"];

    const roundOne = seriesList.filter(series => roundOneLetters.includes(series.seriesLetter.toLowerCase()));
    const roundTwo = seriesList.filter(series => roundTwoLetters.includes(series.seriesLetter.toLowerCase()));
    const roundThree = seriesList.filter(series => roundThreeLetters.includes(series.seriesLetter.toLowerCase()));
    const roundFour = seriesList.filter(series => roundFourLetters.includes(series.seriesLetter.toLowerCase()));

    return [roundOne, roundTwo, roundThree, roundFour];
}