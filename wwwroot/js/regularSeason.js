// The URL to get the Standings data from
let requestURL = "/api/standings/regular";

// The logo and color to use if not defined below
let not_found = {"logo": "https://s3.amazonaws.com/jebbit-assets/images/kWyOoiBQ/business-images/cOZXFMB7Qwy10vktNxer_NHL_Shield_English_Primary.png", 
    "color": "rgb(127, 127, 127)"
};
// The logo link and team colors
let displayInfo = {};
displayInfo.CHI = {"logo": "https://assets.nhle.com/logos/nhl/svg/CHI_dark.svg",  "color": "rgb(207, 10, 44)"}
displayInfo.NSH = {"logo": "https://assets.nhle.com/logos/nhl/svg/NSH_dark.svg",  "color": "rgb(255, 184, 28)"}
displayInfo.STL = {"logo": "https://assets.nhle.com/logos/nhl/svg/STL_black.svg", "color": "rgb(0, 47, 135)"}
displayInfo.CGY = {"logo": "https://assets.nhle.com/logos/nhl/svg/CGY_dark.svg",  "color": "rgb(210, 0, 28)"}
displayInfo.COL = {"logo": "https://assets.nhle.com/logos/nhl/svg/COL_dark.svg",  "color": "rgb(111, 38, 61)"}
displayInfo.EDM = {"logo": "https://assets.nhle.com/logos/nhl/svg/EDM_dark.svg",  "color": "rgb(4, 30, 66)"}
displayInfo.VAN = {"logo": "https://assets.nhle.com/logos/nhl/svg/VAN_light.svg", "color": "rgb(0, 32, 91)"}
displayInfo.ANA = {"logo": "https://assets.nhle.com/logos/nhl/svg/ANA_dark.svg",  "color": "rgb(252, 72, 2)"}
displayInfo.DAL = {"logo": "https://assets.nhle.com/logos/nhl/svg/DAL_light.svg", "color": "rgb(0, 104, 71)"}
displayInfo.LAK = {"logo": "https://assets.nhle.com/logos/nhl/svg/LAK_dark.svg",  "color": "rgb(17, 17, 17)"}
displayInfo.SJS = {"logo": "https://assets.nhle.com/logos/nhl/svg/SJS_dark.svg",  "color": "rgb(0, 109, 117)"}
displayInfo.MIN = {"logo": "https://assets.nhle.com/logos/nhl/svg/MIN_dark.svg",  "color": "rgb(175, 35, 36)"}
displayInfo.WPG = {"logo": "https://assets.nhle.com/logos/nhl/svg/WPG_dark.svg",  "color": "rgb(4, 30, 66)"}
displayInfo.ARI = {"logo": "https://assets.nhle.com/logos/nhl/svg/ARI_dark.svg",  "color": "rgb(140, 38, 51)"}
displayInfo.VGK = {"logo": "https://assets.nhle.com/logos/nhl/svg/VGK_dark.svg",  "color": "rgb(185, 151, 91)"}
displayInfo.SEA = {"logo": "https://assets.nhle.com/logos/nhl/svg/SEA_dark.svg",  "color": "rgb(0, 22, 40)"}
displayInfo.UTA = {"logo": "https://assets.nhle.com/logos/nhl/svg/UTA_light.svg", "color": "rgb(113, 175, 229"}


// fetches data then passes it to the function to display it
const getData = async () => {
    try {
        const response = await fetch(requestURL);
        if(response.ok) {
            const jsonResponse = await response.json();
            displayData(jsonResponse);
        }
    } catch(error) {
        console.log(error);
    }
}


function displayData(data) {
    setRow(data.central1, "central", 1);
    setRow(data.central2, "central", 2);
    setRow(data.central3, "central", 3);

    setRow(data.pacific1, "pacific", 1);
    setRow(data.pacific2, "pacific", 2);
    setRow(data.pacific3, "pacific", 3);

    setRow(data.wildcard1, "wildCard", 1);
    setRow(data.wildcard2, "wildCard", 2);
    setRow(data.wildcard3, "wildCard", 3);
    setRow(data.wildcard4, "wildCard", 4);
    setRow(data.wildcard5, "wildCard", 5);
    setRow(data.wildcard6, "wildCard", 6);
    setRow(data.wildcard7, "wildCard", 7);
    setRow(data.wildcard8, "wildCard", 8);
    setRow(data.wildcard9, "wildCard", 9);
    setRow(data.wildcard10, "wildCard", 10);
}


/* Row refers to divison (if top 3) or wildcard (if out of top 3)
* index refers to the postion
*/
function setRow(team, row, index) {
    let ele = document.getElementsByClassName(`${row}${index}`)[0];

    ele.getElementsByClassName("logo")[0].src = (displayInfo[team.abbr] || not_found).logo;
    ele.getElementsByClassName("name")[0].innerHTML = team.name;
    ele.getElementsByClassName("clinchIndicator")[0].innerHTML = team.clinchIndicator;
    ele.getElementsByClassName("gamesPlayed")[0].innerHTML = team.gamesPlayed;
    ele.getElementsByClassName("points")[0].innerHTML = team.points;
}


// inital request then set the interval for every 30 minutes
getData();
setInterval(getData, 1800000);