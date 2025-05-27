import { fetchPlayoffs } from "../../fetchPlayoffs";

export default async function fetchData(conference: string) {
    const [roundOneFetch, roundTwoFetch, roundThreeFetch] = await fetchPlayoffs();

    const roundOneLetters = conference === "western" ? ["e", "f", "g", "h"] : ["a", "b", "c", "d"];
    const roundTwoLetters = conference === "western" ? ["k", "l"] : ["i", "j"];
    const roundThreeLetters = conference === "western" ? ["n"] : ["m"];

    const roundOne = roundOneFetch.filter(series => roundOneLetters.includes(series.seriesLetter.toLowerCase()));
    const roundTwo = roundTwoFetch.filter(series => roundTwoLetters.includes(series.seriesLetter.toLowerCase()));
    const roundThree = roundThreeFetch.filter(series => roundThreeLetters.includes(series.seriesLetter.toLowerCase()));

    return [roundOne, roundTwo, roundThree];
}