import './styles.css';
import Wildcard from "./Wildcard";
import { fetchData } from "./fetchData";
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

    const [topConferenceTeams, topConferenceName, botConferenceTeams, botConferenceName, wildcardTeams, outsideTeams] = await fetchData(conference);

    return (
        <Wildcard conference={conference}
            topConferenceTeams={ { team: topConferenceTeams, name: "top-division", indexStart: 1, displayName: topConferenceName } }
            botConferenceTeams={{ team: botConferenceTeams, name: "bot-division", indexStart: 1, displayName: botConferenceName }}
            wildcardTeams={{ team: wildcardTeams, name: "wildcards", indexStart: 1, displayName: "Wildcards" }}
            outsideTeams={{ team: outsideTeams, name: "wildcard-race", indexStart: 9, displayName: "Wildcard Race" }}
        />
    );
}