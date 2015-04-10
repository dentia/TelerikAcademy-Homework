function addToDisplay(value) {

    if (value === "BS") {
        var length = display.value.length - 1;
        value = display.value.substring(0, length);
        display.value = "";
    }
    else if (value === "C") {
        display.value = value = "";
    }
    else if (value === "=") {
        value = eval(display.value);
        display.value = "";
    }

    display.value += value;
}