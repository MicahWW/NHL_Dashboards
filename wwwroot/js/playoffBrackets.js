// The URL to get the Standings data from
let requestURL = "/Api/Standings/Playoffs";
let colorsURL = "/Api/TeamDetails";

// fetches data then passes it to the function to display it
const getData = async () => {
    try {
        const response = await fetch(requestURL);
        if (response.ok) {
            const jsonResponse = await response.json();
            displayData(jsonResponse);
        }
    } catch(error) {
        console.log(`Get Data error\n ${error}`);
    }
}

function displayData(data) {
    let colors = getColors();

    for (let i = 0; i < data.series.length; i++) {
        let ele = document.getElementById(`series-${data.series[i].seriesLetter.toLowerCase()}`)

        if (ele != null) {
            let topTeam = ele.getElementsByClassName("top-team")[0];
            let botTeam = ele.getElementsByClassName("bot-team")[0];

            let topTeamColors = colors[data.series[i].topTeam.abbr];
            let botTeamColors = colors[data.series[i].botTeam.abbr];

            topTeam.style.backgroundColor = `rgba(${topTeamColors.decimalRed}, ${topTeamColors.decimalGreen}, ${topTeamColors.decimalBlue}, 0.5)`;
            botTeam.style.backgroundColor = `rgba(${botTeamColors.decimalRed}, ${botTeamColors.decimalGreen}, ${botTeamColors.decimalBlue}, 0.5)`;

            topTeam.getElementsByClassName("logo")[0].src = `https://assets.nhle.com/logos/nhl/svg/${data.series[i].topTeam.abbr}_dark.svg`;
            topTeam.getElementsByClassName("wins")[0].innerHTML = data.series[i].topTeam.wins;
            botTeam.getElementsByClassName("logo")[0].src = `https://assets.nhle.com/logos/nhl/svg/${data.series[i].botTeam.abbr}_dark.svg`;
            botTeam.getElementsByClassName("wins")[0].innerHTML = data.series[i].botTeam.wins;
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