// Write a function to count the number of divs on the web page

// to view the result, open the divCounter.html page

function countElements(type) {

    var count = document.getElementsByTagName(type).length - 1;
    document.getElementById('result').innerHTML = 'count: ' + count;
    document.getElementById('btnCount').style.display = 'none';
}
