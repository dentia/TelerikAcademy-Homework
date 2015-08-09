// open the index.html page to view the result

function checkIfBrowserIsMozilla() {
    console.log('aaaaaaa');
    var currentWindow = window,
        browser = currentWindow.navigator.appCodeName,
        isMozilla = browser === "Mozilla";

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}