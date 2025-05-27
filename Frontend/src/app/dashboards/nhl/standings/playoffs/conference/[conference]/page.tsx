import fetchData from './fetchData';
import Conference from './Conference';
import './styles.css';
import { notFound } from 'next/navigation';

export default async function Page({
    params,
}: {
    params: Promise<{ conference: string }>
}) {
    const { conference } = await params;
    if (conference !== "western" && conference !== "eastern") {
        return notFound();
    }

    const [roundOneFetch, roundTwoFetch, roundThreeFetch] = await fetchData(conference);

    return (
        <Conference conference={conference}
            roundOne={roundOneFetch}
            roundTwo={roundTwoFetch}
            roundThree={roundThreeFetch}
        />
    );
}