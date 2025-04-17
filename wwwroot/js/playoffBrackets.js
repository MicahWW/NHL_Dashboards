// The URL to get the Standings data from
let requestURL = "/Api/Standings/Playoffs";

// fetches data then passes it to the function to display it
const getData = async () => {
    try {
        const response = await fetch(requestURL);
        if (response.ok) {
            const jsonResponse = await response.json();
            displayData(jsonResponse);
        }
    } catch {
        console.log(error);
    }
}

function displayData(data) {
    for (let i = 0; i < data.series.length; i++) {
        let ele = document.getElementById(`series-${data.series[i].seriesLetter.toLowerCase()}`)

        if (ele != null) {
            let topTeam = ele.getElementsByClassName("top-team")[0];
            let botTeam = ele.getElementsByClassName("bot-team")[0];

            topTeam.getElementsByClassName("logo")[0].src = `https://assets.nhle.com/logos/nhl/svg/${data.series[i].topTeam.abbr}_dark.svg`;
            topTeam.getElementsByClassName("wins")[0].innerHTML = data.series[i].topTeam.wins;
            botTeam.getElementsByClassName("logo")[0].src = `https://assets.nhle.com/logos/nhl/svg/${data.series[i].botTeam.abbr}_dark.svg`;
            botTeam.getElementsByClassName("wins")[0].innerHTML = data.series[i].botTeam.wins;
        }

    }
}