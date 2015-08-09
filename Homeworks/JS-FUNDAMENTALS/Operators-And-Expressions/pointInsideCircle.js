// Write an expression that checks if given print (x, y)
// is within a circle K(O, 5).

var inside = [0,0], outside = [5.1, 5.1];

console.log(isInside(inside[0], inside[1], 0, 0, 5));
console.log(isInside(outside[0], outside[1], 0, 0, 5));

function isInside(x, y, cx, cy, r){
    return (x - cx) * (x - cx) + (y - cy) * (y - cy) < r * r;
}