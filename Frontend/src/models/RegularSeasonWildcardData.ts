export class RegularSeasonWildcardData {
    central1: TeamData;
    central2: TeamData;
    central3: TeamData;
    pacific1: TeamData;
    pacific2: TeamData;
    pacific3: TeamData;
    westernWildcard1: TeamData;
    westernWildcard2: TeamData;
    westernWildcard3: TeamData;
    westernWildcard4: TeamData;
    westernWildcard5: TeamData;
    westernWildcard6: TeamData;
    westernWildcard7: TeamData;
    westernWildcard8: TeamData;
    westernWildcard9: TeamData;
    westernWildcard10: TeamData;
    atlantic1: TeamData;
    atlantic2: TeamData;
    atlantic3: TeamData;
    metropolitan1: TeamData;
    metropolitan2: TeamData;
    metropolitan3: TeamData;
    easternWildcard1: TeamData;
    easternWildcard2: TeamData;
    easternWildcard3: TeamData;
    easternWildcard4: TeamData;
    easternWildcard5: TeamData;
    easternWildcard6: TeamData;
    easternWildcard7: TeamData;
    easternWildcard8: TeamData;
    easternWildcard9: TeamData;
    easternWildcard10: TeamData;

    public constructor(json: string) {
        const data = JSON.parse(json);
        this.central1 = new TeamData(data.central1.points, data.central1.gamesPlayed, data.central1.name, data.central1.abbr, data.central1.clinchIndicator);
        this.central2 = new TeamData(data.central2.points, data.central2.gamesPlayed, data.central2.name, data.central2.abbr, data.central2.clinchIndicator);
        this.central3 = new TeamData(data.central3.points, data.central3.gamesPlayed, data.central3.name, data.central3.abbr, data.central3.clinchIndicator);
        this.pacific1 = new TeamData(data.pacific1.points, data.pacific1.gamesPlayed, data.pacific1.name, data.pacific1.abbr, data.pacific1.clinchIndicator);
        this.pacific2 = new TeamData(data.pacific2.points, data.pacific2.gamesPlayed, data.pacific2.name, data.pacific2.abbr, data.pacific2.clinchIndicator);
        this.pacific3 = new TeamData(data.pacific3.points, data.pacific3.gamesPlayed, data.pacific3.name, data.pacific3.abbr, data.pacific3.clinchIndicator);
        this.westernWildcard1 = new TeamData(data.westernWildcard1.points, data.westernWildcard1.gamesPlayed, data.westernWildcard1.name, data.westernWildcard1.abbr, data.westernWildcard1.clinchIndicator);
        this.westernWildcard2 = new TeamData(data.westernWildcard2.points, data.westernWildcard2.gamesPlayed, data.westernWildcard2.name, data.westernWildcard2.abbr, data.westernWildcard2.clinchIndicator);
        this.westernWildcard3 = new TeamData(data.westernWildcard3.points, data.westernWildcard3.gamesPlayed, data.westernWildcard3.name, data.westernWildcard3.abbr, data.westernWildcard3.clinchIndicator);
        this.westernWildcard4 = new TeamData(data.westernWildcard4.points, data.westernWildcard4.gamesPlayed, data.westernWildcard4.name, data.westernWildcard4.abbr, data.westernWildcard4.clinchIndicator);
        this.westernWildcard5 = new TeamData(data.westernWildcard5.points, data.westernWildcard5.gamesPlayed, data.westernWildcard5.name, data.westernWildcard5.abbr, data.westernWildcard5.clinchIndicator);
        this.westernWildcard6 = new TeamData(data.westernWildcard6.points, data.westernWildcard6.gamesPlayed, data.westernWildcard6.name, data.westernWildcard6.abbr, data.westernWildcard6.clinchIndicator);
        this.westernWildcard7 = new TeamData(data.westernWildcard7.points, data.westernWildcard7.gamesPlayed, data.westernWildcard7.name, data.westernWildcard7.abbr, data.westernWildcard7.clinchIndicator);
        this.westernWildcard8 = new TeamData(data.westernWildcard8.points, data.westernWildcard8.gamesPlayed, data.westernWildcard8.name, data.westernWildcard8.abbr, data.westernWildcard8.clinchIndicator);
        this.westernWildcard9 = new TeamData(data.westernWildcard9.points, data.westernWildcard9.gamesPlayed, data.westernWildcard9.name, data.westernWildcard9.abbr, data.westernWildcard9.clinchIndicator);
        this.westernWildcard10 = new TeamData(data.westernWildcard10.points, data.westernWildcard10.gamesPlayed, data.westernWildcard10.name, data.westernWildcard10.abbr, data.westernWildcard10.clinchIndicator);
        this.atlantic1 = new TeamData(data.atlantic1.points, data.atlantic1.gamesPlayed, data.atlantic1.name, data.atlantic1.abbr, data.atlantic1.clinchIndicator);
        this.atlantic2 = new TeamData(data.atlantic2.points, data.atlantic2.gamesPlayed, data.atlantic2.name, data.atlantic2.abbr, data.atlantic2.clinchIndicator);
        this.atlantic3 = new TeamData(data.atlantic3.points, data.atlantic3.gamesPlayed, data.atlantic3.name, data.atlantic3.abbr, data.atlantic3.clinchIndicator);
        this.metropolitan1 = new TeamData(data.metropolitan1.points, data.metropolitan1.gamesPlayed, data.metropolitan1.name, data.metropolitan1.abbr, data.metropolitan1.clinchIndicator);
        this.metropolitan2 = new TeamData(data.metropolitan2.points, data.metropolitan2.gamesPlayed, data.metropolitan2.name, data.metropolitan2.abbr, data.metropolitan2.clinchIndicator);
        this.metropolitan3 = new TeamData(data.metropolitan3.points, data.metropolitan3.gamesPlayed, data.metropolitan3.name, data.metropolitan3.abbr, data.metropolitan3.clinchIndicator);
        this.easternWildcard1 = new TeamData(data.easternWildcard1.points, data.easternWildcard1.gamesPlayed, data.easternWildcard1.name, data.easternWildcard1.abbr, data.easternWildcard1.clinchIndicator);
        this.easternWildcard2 = new TeamData(data.easternWildcard2.points, data.easternWildcard2.gamesPlayed, data.easternWildcard2.name, data.easternWildcard2.abbr, data.easternWildcard2.clinchIndicator);
        this.easternWildcard3 = new TeamData(data.easternWildcard3.points, data.easternWildcard3.gamesPlayed, data.easternWildcard3.name, data.easternWildcard3.abbr, data.easternWildcard3.clinchIndicator);
        this.easternWildcard4 = new TeamData(data.easternWildcard4.points, data.easternWildcard4.gamesPlayed, data.easternWildcard4.name, data.easternWildcard4.abbr, data.easternWildcard4.clinchIndicator);
        this.easternWildcard5 = new TeamData(data.easternWildcard5.points, data.easternWildcard5.gamesPlayed, data.easternWildcard5.name, data.easternWildcard5.abbr, data.easternWildcard5.clinchIndicator);
        this.easternWildcard6 = new TeamData(data.easternWildcard6.points, data.easternWildcard6.gamesPlayed, data.easternWildcard6.name, data.easternWildcard6.abbr, data.easternWildcard6.clinchIndicator);
        this.easternWildcard7 = new TeamData(data.easternWildcard7.points, data.easternWildcard7.gamesPlayed, data.easternWildcard7.name, data.easternWildcard7.abbr, data.easternWildcard7.clinchIndicator);
        this.easternWildcard8 = new TeamData(data.easternWildcard8.points, data.easternWildcard8.gamesPlayed, data.easternWildcard8.name, data.easternWildcard8.abbr, data.easternWildcard8.clinchIndicator);
        this.easternWildcard9 = new TeamData(data.easternWildcard9.points, data.easternWildcard9.gamesPlayed, data.easternWildcard9.name, data.easternWildcard9.abbr, data.easternWildcard9.clinchIndicator);
        this.easternWildcard10 = new TeamData(data.easternWildcard10.points, data.easternWildcard10.gamesPlayed, data.easternWildcard10.name, data.easternWildcard10.abbr, data.easternWildcard10.clinchIndicator);
    }
}

export class TeamData {
    points: number;
    gamesPlayed: number;
    name: string;
    abbr: string;
    clinchIndicator: string;

    public constructor(
        points: number = 0,
        gamesPlayed: number = 0,
        name: string = "",
        abbr: string = "",
        clinchIndicator: string = ""
    ) {
        this.points = points;
        this.gamesPlayed = gamesPlayed;
        this.name = name;
        this.abbr = abbr;
        this.clinchIndicator = clinchIndicator;
    }
}