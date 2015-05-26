// Write an expression that calculates trapezoid's area
// by given sides a and b and height h.

var a = 5, b = 10, h = 12;

console.log(getArea(a, b, h));

function getArea(a, b, h){
    return ((a + b ) / 2) * h;
}

