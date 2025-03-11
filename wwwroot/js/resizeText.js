function resizeText() {
    const resizeElements = document.getElementsByClassName("resize-text");

    for (let i=0; i<resizeElements.length; i++) {
        const maxHeight = resizeElements[i].clientHeight;
        let fontSize = 1;
        resizeElements[i].style.fontSize = fontSize + "px";

        while (resizeElements[i].scrollHeight <= maxHeight) {
            resizeElements[i].style.fontSize = ++fontSize + "px";
        }
        resizeElements[i].style.fontSize = --fontSize + "px";
    }
}