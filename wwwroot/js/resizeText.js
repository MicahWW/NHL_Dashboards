function resizeText() {
    const resizeElements = document.getElementsByClassName("resize-text");

    for (let i = 0; i < resizeElements.length; i++) {
        // Without this if there is an empty element the page will stuck in a loop
        if (resizeElements[i].innerHTML == "") {
            continue;
        }
        
        const parentElement = resizeElements[i].parentElement;
        const eleMaxHeightProp = window.getComputedStyle(resizeElements[i]).maxHeight;
        const eleMaxWidthProp = window.getComputedStyle(resizeElements[i]).maxWidth;
        let maxHeight = null;
        let maxWidth = null;

        // if the maxHeight/maxWidth property isn't set then use the client height/width but if the max is set and is a percentage
        // then compute what the max should be.
        if (eleMaxHeightProp != "none" && eleMaxHeightProp.includes("%")) {
            maxHeight = parentElement.clientHeight * parseFloat(eleMaxHeightProp) / 100;
        } else {
            maxHeight = resizeElements[i].clientHeight;
        }

        if (eleMaxWidthProp != "none" && eleMaxWidthProp.includes("%")) {
            maxWidth = parentElement.clientWidth * parseFloat(eleMaxWidthProp) / 100;
        } else {
            maxWidth = resizeElements[i].clientWidth;
        }

        let fontSize = 1;
        resizeElements[i].style.fontSize = fontSize + "px";

        while (resizeElements[i].scrollHeight <= maxHeight && resizeElements[i].scrollWidth <= maxWidth) {
            resizeElements[i].style.fontSize = ++fontSize + "px";
        }
        resizeElements[i].style.fontSize = --fontSize + "px";
    }
}