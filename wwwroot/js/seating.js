let requestURL = "/api/seating";

let dayOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
let months = ["Jan.", "Feb.", "Mar.", "Apr.", "May", "Jun.", "Jul.", "Aug.", "Sep.", "Oct.", "Nov.", "Dec."];
let booths = ["A. ", "B. ", "C. ", "D. ", "E. ", "F. ", "7. ", "8. ", "9. ", "10. "]

// default set to false, will get changed as it pulls data
let useAuxScreenOne = false;
let useBothAuxScreens = false;

// takes the data received from the API and displays
function displayData(data) {
    // goes through each seat and sets the data
    for(let i=1; i<75; i++) {
        document.getElementById(i).innerHTML = `${i}. ${data.seats[parseInt(i-1, 10)] ?? ""}`;
    }

    // goes through the aux seats
    for(let i=1; i<data.auxSeats.length; i++) {
        document.getElementById(`aux${i}`).innerHTML = `${i}. ${data.auxSeats[parseInt(i-1, 10)]}`;
    }

    // updates if the aux box screens should be used
    useAuxScreenOne = data.other.useAuxScreenOne;
    useBothAuxScreens = data.other.useBothAuxScreens;

    // goes through each of the booths and sets the data
    for(let i=1; i<11; i++) {
        document.getElementById(`booth${i}`).innerHTML = `<div class="boothText">${booths[i-1]}${data.booths[parseInt(i-1, 10)]}</div>`;
    }

    // grabs the other pieces of information
    document.getElementById("dsVSopp").innerHTML = `DALLAS STARS vs. ${data.other.opponent}`;
    document.getElementById("wifiPassword").innerHTML = data.other.wiFiPassword;
    document.getElementById("networkName").innerHTML = data.other.wiFiNetwork;

    let date = new Date();
    document.getElementById("date").innerHTML = `${dayOfWeek[date.getDay()]}, ${months[date.getMonth()]} ${date.getDate()}, ${date.getFullYear()}`.toUpperCase();
    shrink();
}


// fetches data then passes it to the function to display it
const getData = async () => {
    console.log("refresh data");
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

// toggles between the different seating charts
function toggle() {
    let main = document.getElementById("mainPressBox");
    let aux1 = document.getElementById("auxBoxOne");
    let aux2 = document.getElementById("auxBoxTwo");
    
    // if the data pull said to use the press box aux screens
    if(useAuxScreenOne || useBothAuxScreens) {
        if(main.style.display == "flex") {
            main.style.display = "none";
            aux1.style.display = "flex";
            document.getElementById("pageTitle").innerHTML = "AUX. PRESS BOX SECTION 307";
        } else {
            if(aux1.style.display == "flex" && useBothAuxScreens) {
                aux1.style.display = "none";
                aux2.style.display = "flex";
                document.getElementById("pageTitle").innerHTML = "AUX. PRESS BOX SECTION 306";

            } else {
                aux1.style.display = "none";
                aux2.style.display = "none";
                turnOnMainChart();
            }
        }
    /* This should catch if the screen is on one of the aux screens and data is
     * pulled that says to no longer use the aux screens. Without this it would
     * be stuck on the aux screen
     */
    } else {
        if(main.style.display != "flex") {
            if(aux1.style.display == "flex") {
                aux1.style.display = "none";
            }
            if(aux2.style.display == "flex") {
                aux2.style.display = "none";
            }
            turnOnMainChart();
        }
    }
}

// turns on the main chart
function turnOnMainChart() {
    let main = document.getElementById("mainPressBox");
    main.style.display = "flex";
    // the shrink function needs to be rerun in case there were changes
    shrink();
    // updates title
    document.getElementById("pageTitle").innerHTML = "PRESS BOX SEATING CHART";
}


// initial request then set the interval for every 30 minutes
getData();
setInterval(getData, 300000);
// toggles the screen every 20 seconds
setInterval(toggle, 20000);

function shrink() {
    // gets all 10 booths
    var boothDivs = document.getElementsByClassName("booth");
    var boothDivsLength = boothDivs.length;

    // Loop through all of the dynamic divs on the page
    for(var i=0; i<boothDivsLength; i++) {
        // grabs the text element in the booth
        var boothText = boothDivs[i].getElementsByClassName("boothText")[0];

        // grabs the size that was set by CSS
        boothText.style.fontSize = getComputedStyle(boothText).fontSize;

        /* keeps making it smaller till it fits correctly. Explanation:
         *   boothText.offsetHeight > 44 => this makes the text fit onto 1 line, it's going to be around 30ish normally
         *   parseInt(boothText.style.fontSize) > 1 => makes sure there isn't an infinite loop going on
         */
        while (boothText.offsetHeight > 44 && parseInt(boothText.style.fontSize) > 1) {
            boothText.style.fontSize = `${parseInt(boothText.style.fontSize) - 1}px`;
        }

        // centers the text in the box
        boothText.style.top = `${(boothDivs[i].offsetHeight / 2) - (boothText.offsetHeight / 2)}px`;
    }

    // shrinks the size of the DS vs OPP line to fit on one line and make the date line the same size
    var dsVSopp = document.getElementById("dsVSopp");

    // grabs the size that was set by CSS
    dsVSopp.style.fontSize = getComputedStyle(dsVSopp).fontSize;

    while (dsVSopp.offsetHeight > 50 && parseInt(dsVSopp.style.fontSize) > 1) {
        dsVSopp.style.fontSize = `${parseInt(dsVSopp.style.fontSize) - 1}px`;
    }

    document.getElementById("date").style.fontSize = dsVSopp.style.fontSize;
}