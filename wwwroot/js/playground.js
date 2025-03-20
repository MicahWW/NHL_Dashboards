// The URL to get the Standings data from
let requestURL = "/Api/Standings/RegularSeason"

// fetches data then passes it to the function to display it
const getData = async (topDivisionName, botDivisionName, conferenceName) => {
    try {
        const response = await fetch(requestURL);
        if(response.ok) {
            const jsonResponse = await response.json();
            displayData(jsonResponse, topDivisionName.toLowerCase(), botDivisionName.toLowerCase(), conferenceName.toLowerCase());
        }
    } catch(error) {
        console.log(error);
    }
}

function displayData(data, topDivisionName, botDivisionName, conferenceName) {
    let topDivisionElements = document.getElementById("top-division").getElementsByClassName("team-div");
    let botDivisionElements = document.getElementById("bot-division").getElementsByClassName("team-div");
    let wildcardsElements = document.getElementById("wildcards").getElementsByClassName("team-div");
    let wildcardRaceElements = document.getElementById("outside-teams").getElementsByClassName("teams")[0].getElementsByClassName("team-div");

    for (let i = 0; i < 3; i++) {
        setRow(data[`${topDivisionName}${i+1}`], topDivisionElements[i]);
        setRow(data[`${botDivisionName}${i+1}`], botDivisionElements[i]);
    }

    for (let i = 0; i < 2; i++) {
        setRow(data[`${conferenceName}Wildcard${i+1}`], wildcardsElements[i]);
    }

    for (let i = 0; i < 8; i++) {
        setRow(data[`${conferenceName}Wildcard${i+3}`], wildcardRaceElements[i]);
    }
}

function setRow(rowData, rowEle) {
    try {
        rowEle.getElementsByClassName("logo")[0].src = `https://assets.nhle.com/logos/nhl/svg/${rowData.abbr}_dark.svg`;
        rowEle.getElementsByClassName("name")[0].innerHTML = rowData.name;
        rowEle.getElementsByClassName("clinch-indicator")[0].innerHTML = rowData.clinchIndicator;
        rowEle.getElementsByClassName("games-played")[0].innerHTML = rowData.gamesPlayed;
        rowEle.getElementsByClassName("points")[0].innerHTML = rowData.points;        
    } catch (e) {
        console.log("Was trying to set the Row Data listed below but an error was caught, listed below the Row Data.");
        console.log(rowData);
        console.log(e);
    }

}