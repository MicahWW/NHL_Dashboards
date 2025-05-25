import { TeamData } from "./RegularSeasonWildcardData";

export class RegularSeasonTeamGroupData {
    team: TeamData[]
    name: string
    indexStart: number
    displayName?: string;

    public constructor(team: TeamData[], name: string, indexStart: number, displayName: string) {
        this.team = team;
        this.name = name;
        this.indexStart = indexStart;
        this.displayName = displayName;
    }
}