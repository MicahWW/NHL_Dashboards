export const adjustFontSize = (element: HTMLElement) => {
    if (!element) return;

    // Without this if there is an empty element the page will stuck in a loop
    if (element.innerHTML == "") {
        return;
    }
    
    const parentElement = element.parentElement;
    const eleMaxHeightProp = window.getComputedStyle(element).maxHeight;
    const eleMaxWidthProp = window.getComputedStyle(element).maxWidth;
    let maxHeight = null;
    let maxWidth = null;
    if (parentElement == null) {
        console.error(`Parent element null for ${element}`);
        return;
    }

    // if the maxHeight/maxWidth property isn't set then use the client height/width but if the max is set and is a percentage
    // then compute what the max should be.
    if (eleMaxHeightProp != "none" && eleMaxHeightProp.includes("%")) {
        maxHeight = parentElement.clientHeight * parseFloat(eleMaxHeightProp) / 100;
    } else {
        maxHeight = element.clientHeight;
    }

    if (eleMaxWidthProp != "none" && eleMaxWidthProp.includes("%")) {
        maxWidth = parentElement.clientWidth * parseFloat(eleMaxWidthProp) / 100;
    } else {
        maxWidth = element.clientWidth;
    }

    let fontSize = 1;
    element.style.fontSize = fontSize + "px";

    while (element.scrollHeight <= maxHeight && element.scrollWidth <= maxWidth) {
        element.style.fontSize = ++fontSize + "px";
    }
    element.style.fontSize = --fontSize + "px";
    console.log("resize");
};
