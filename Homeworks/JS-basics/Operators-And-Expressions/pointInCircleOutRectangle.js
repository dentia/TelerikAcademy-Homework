// Write an expression that checks for given point (x, y)
// if it is within the circle K( (1,1), 3) and out of the
// rectangle R(top=1, left=-1, width=6, height=2).

var rectangle = [1, -1, -1, 5], circle = [1, 1, 3], pointTrue = [2, 2], pointFalse = [1, 1];

console.log(isInsideCircle(pointTrue[0], pointTrue[1], circle[0], circle[1], circle[2])
         && isOutsideRectangle(pointTrue[0], pointTrue[1], rectangle[0], rectangle[1], rectangle[2], rectangle[3]));
console.log(isInsideCircle(pointFalse[0], pointFalse[1], circle[0], circle[1], circle[2])
         && isOutsideRectangle(pointFalse[0], pointFalse[1], rectangle[0], rectangle[1], rectangle[2], rectangle[3]));

function isInsideCircle(x, y, cx, cy, r){
    return (x - cx) * (x - cx) + (y - cy) * (y - cy) < r * r;
}

function isOutsideRectangle(x, y, top, bottom, left, right){
    return !(x >= left && x <= right && y <= top && y >= bottom);
}