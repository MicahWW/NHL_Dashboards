export class PlayoffSeriesData {
    seriesLetter: string;
    conference: string;
    topTeam: PlayoffTeamData;
    botTeam: PlayoffTeamData;

    public constructor(seriesLetter: string, conference: string, topTeam: PlayoffTeamData, botTeam: PlayoffTeamData) {
        this.seriesLetter = seriesLetter;
        this.conference = conference;
        this.topTeam = topTeam;
        this.botTeam = botTeam;
    }
}

export class PlayoffTeamData {
    id: number;
    abbr: string;
    wins: number;
    seedRank: number;
    seedAbbr: string;

    public constructor(id: number, abbr: string, wins: number, seedRank: number, seedAbbr: string) {
        this.id = id;
        this.abbr = abbr;
        this.wins = wins;
        this.seedRank = seedRank;
        this.seedAbbr = seedAbbr;
    }
}