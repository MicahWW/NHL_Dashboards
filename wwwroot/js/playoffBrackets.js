const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
let year = urlParams.get("year");

// The URL to get the Standings data from
let requestURL = year == null ? "/Api/Standings/Playoffs" : `/Api/Standings/Playoffs?year=${year}`;
let colorsURL = "/Api/TeamDetails";

// fetches data then passes it to the function to display it
const getData = async () => {
    try {
        const response = await fetch(requestURL);
        if (response.ok) {
            const jsonResponse = await response.json();
            await displayData(jsonResponse);
        }
    } catch(error) {
        console.log(`Get Data error\n ${error}`);
    }
}

async function displayData(data) {
    let colors = await getColors();

    for (let i = 0; i < data.series.length; i++) {
        let ele = document.getElementById(`series-${data.series[i].seriesLetter.toLowerCase()}`)

        if (ele != null) {
            let topTeam = ele.getElementsByClassName("top-team")[0];
            let botTeam = ele.getElementsByClassName("bot-team")[0];

            // let topTeamColors = colors.teams[data.series[i].topTeam.abbr];
            // let botTeamColors = colors.teams[data.series[i].botTeam.abbr];
            // topTeam.style.backgroundColor = `rgba(${topTeamColors.colors.primary.decimalRed}, ${topTeamColors.colors.primary.decimalGreen}, ${topTeamColors.colors.primary.decimalBlue}, var(--teamBackgroundOpacity))`;
            // botTeam.style.backgroundColor = `rgba(${botTeamColors.colors.primary.decimalRed}, ${botTeamColors.colors.primary.decimalGreen}, ${botTeamColors.colors.primary.decimalBlue}, var(--teamBackgroundOpacity))`;

            if (data.series[i].topTeam != null) {
                topTeam.getElementsByClassName("logo")[0].src = `https://assets.nhle.com/logos/nhl/svg/${data.series[i].topTeam.abbr}_dark.svg`;
                topTeam.getElementsByClassName("wins")[0].innerHTML = data.series[i].topTeam.wins;
            } else {
                topTeam.getElementsByClassName("logo")[0].style.display = "none";
                topTeam.getElementsByClassName("wins")[0].style.display = "none";
            }

            if (data.series[i].botTeam != null) {
                botTeam.getElementsByClassName("logo")[0].src = `https://assets.nhle.com/logos/nhl/svg/${data.series[i].botTeam.abbr}_dark.svg`;
                botTeam.getElementsByClassName("wins")[0].innerHTML = data.series[i].botTeam.wins;
            } else {
                botTeam.getElementsByClassName("logo")[0].style.display = "none";
                botTeam.getElementsByClassName("wins")[0].style.display = "none";
            }

            // Adds the series-loser class to the team that lost the series
            if (data.series[i].topTeam != null && data.series[i].botTeam != null) {
                if (data.series[i].topTeam.wins == 4) {
                    botTeam.classList.add("series-loser");
                }

                if (data.series[i].botTeam.wins == 4) {
                    topTeam.classList.add("series-loser");
                }
            }
        }

    }
}

async function getColors() {
    try {
        const response = await fetch(colorsURL);
        if (response.ok) {
            const jsonResponse = await response.json();
            return jsonResponse;
        }
    } catch(error) {
        console.log(`Get colors error\n${error}`);
    }
}